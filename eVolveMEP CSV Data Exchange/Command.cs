// Copyright (c) 2023 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

extern alias eVolve;
using eVolve::eVolve.Core.Revit.Integration;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;

namespace eVolve.CsvDataExchange.Revit;

/// <summary> Executes the import/export process. </summary>
[Transaction(TransactionMode.Manual)]
[Regeneration(RegenerationOption.Manual)]
internal class Command : IExternalCommand
{
    /// <summary> Gets the button name of this tool as single line text. </summary>
    internal static string ButtonTextWithNoLineBreaks => ExtensionsCommon.Revit.Methods.GetButtonTextWithNoLineBreaks(Resources.ButtonText);

    /// <summary> Gets the icon resource. </summary>
    internal static System.IO.Stream IconResource => ExtensionsCommon.Revit.Methods.GetIconResource("CSV_ImportExport_32x32.png");

    /// <summary> Gets URL of the help link to open when requested by the user. </summary>
    internal static string HelpLinkUrl
    {
        get
        {
#if ELECTRICAL
            return "https://help-electrical.evolvemep.com/article/ye5k5bnwu2";
#elif MECHANICAL
            return "https://help-mechanical.evolvemep.com/article/g0p7prhwle";
#else
            return null;
#endif
        }
    }

    /// <inheritdoc/>
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        var document = commandData.Application.ActiveUIDocument.Document;

        if (!ConfigurationForm.TryGetSettings(document, out var settings))
        {
            return Result.Cancelled;
        }

        try
        {
            return settings.Direction switch
            {
                Direction.Export => ExportData(document, settings),
                Direction.Import => ImportData(document, settings),
                _ => Result.Succeeded,
            };
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{Resources.ErrorOccurredNotice}\n\n{ex.Message}", ButtonTextWithNoLineBreaks, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return Result.Failed;
        }
    }

    /// <summary> Additional columns which can be added to the output of <see cref="ExportData"/>. </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("ReSharper", "MissingXmlDoc", Justification = "Meaning is obvious")]
    internal struct OptionalExportColumns
    {
        public static string ProjectName => Resources.ExportColumn_ProjectName;
        public static string ProjectNumber => Resources.ExportColumn_ProjectNumber;
        public static string Timestamp => Resources.ExportColumn_Timestamp;
        public static string UserName => Resources.ExportColumn_UserName;
        public static string Workstation => Resources.ExportColumn_WorkstationName;
    }

    /// <summary>
    /// Exports data to a file according to the provided <paramref name="settings"/> and returns the result. 
    /// <para>Any errors encountered are thrown.</para>
    /// </summary>
    ///
    /// <param name="document"> The current Revit document. </param>
    /// <param name="settings"> Configured settings. </param>
    private static Result ExportData(Document document, Settings settings)
    {
        // Extract all elements matching the condition of the profile.
        var dataToExport = document.GetData(settings.ProfileName, ElementProcessedHandler);
        if (!dataToExport.Any())
        {
            MessageBox.Show(Resources.NoElementsSelectedNotice, Resources.ExportCsvData, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return Result.Failed;
        }


        // Build the header data.
        var headerList = new List<string>() { Resources.UniqueId };
        // Optional columns.
        headerList.AddRange(settings.IncludeExportColumns);

        // Process the structure of the first row in order to determine the defined column header names.
        headerList.AddRange(dataToExport.First().Value.Select(data => formatCsvOutput(data.Key)));

        var exportCsvList = new List<string> { string.Join(getDelimiter(), headerList) };

        // If optional columns are included, the values being output for each row are going to be identical.
        // Just build once and use repeatedly.
        var optionalValues = new List<string>();
        foreach (var optional in settings.IncludeExportColumns)
        {
            if (optional == OptionalExportColumns.ProjectName)
            {
                optionalValues.Add(document.ProjectInformation.Name);
            }
            else if (optional == OptionalExportColumns.ProjectNumber)
            {
                optionalValues.Add(document.ProjectInformation.Number);
            }
            else if (optional == OptionalExportColumns.Timestamp)
            {
                optionalValues.Add(DateTime.Now.ToString("s"));
            }
            else if (optional == OptionalExportColumns.UserName)
            {
                optionalValues.Add(Environment.UserName);
            }
            else if (optional == OptionalExportColumns.Workstation)
            {
                optionalValues.Add(Environment.MachineName);
            }
        }


        // Process each data row.
        foreach (var entry in dataToExport)
        {
            // Key contains the unique Id.
            var currentExportRow = new List<string>() { entry.Key };
            // Optional data.
            currentExportRow.AddRange(optionalValues);

            // Structure contains the data.
            currentExportRow.AddRange(entry.Value.Select(data => formatCsvOutput(data.Value)));
            exportCsvList.Add(string.Join(getDelimiter(), currentExportRow));
        }

        System.IO.File.WriteAllText(settings.FilePath, string.Join(Environment.NewLine, exportCsvList));
        MessageBox.Show(string.Format(Resources.XElementsProcessedNotice, dataToExport.Count), Resources.ExportCompleted, MessageBoxButtons.OK, MessageBoxIcon.Information);

        return Result.Succeeded;


        // Formats a line of data so it is properly escaped.
        static string formatCsvOutput(string fieldValue)
        {
            if (string.IsNullOrEmpty(fieldValue))
            {
                return "";
            }

            // Normalize line breaks to spaces.
            fieldValue = string.Join(" ", fieldValue.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None))
                // Escape embedded quotes.
                .Replace("\"", "\"\"")
                .Trim();

            // Surround with quotes as needed.
            if (fieldValue.Contains(",") || fieldValue.Contains("\""))
            {
                fieldValue = "\"" + fieldValue + "\"";
            }

            return fieldValue;
        }

        // Retrieves the delimiter character based on the user settings.
        string getDelimiter() => settings.Delimiter switch
        {
            DelimiterChars.Tab => "\t",
            _ => ",",
        };
    }

    /// <summary>
    /// Imports data from a file according to the provided <paramref name="settings"/> and returns the result.
    /// <para>Any errors encountered are thrown.</para>
    /// </summary>
    ///
    /// <param name="document"> The current Revit document. </param>
    /// <param name="settings"> Configured settings. </param>
    private static Result ImportData(Document document, Settings settings)
    {
        // Data structure to be provided back to eVolve.
        var importData = new Dictionary<string, Dictionary<string, string>>();

        var csvDataFromFile = System.IO.File.ReadAllText(settings.FilePath);

        var dataRows = csvDataFromFile.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        if (dataRows.Length <= 1)
        {
            // No data or header only.
            MessageBox.Show(Resources.NoDataNotice, Resources.ImportCsvData, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return Result.Failed;
        }


        var headers = splitLineData(dataRows.First()).Select(removeEscapeQuotes).ToArray();

        foreach (var dataRow in dataRows.Skip(1).Where(row => !string.IsNullOrEmpty(row)))
        {
            var data = splitLineData(dataRow).Select(removeEscapeQuotes).ToArray();
            var uniqueId = data.First();

            var elementData = new Dictionary<string, string>();
            // Starting at 1 to skip the UniqueId.
            // All other indexes provide data.
            // Data rows are expected to have the same number of indexes as the header.
            for (var index = 1; index < headers.Length; index++)
            {
                elementData.Add(headers[index], data[index]);
            }
            importData.Add(uniqueId, elementData);
        }

        // Write data back to Revit.
        var elementsProcessed = document.WriteData(settings.ProfileName, importData, true, API.UnmappedFieldAction.Ignore, out _, ElementProcessedHandler);
        MessageBox.Show(string.Format(Resources.XElementsProcessedNotice, elementsProcessed), Resources.ImportCompleted, MessageBoxButtons.OK, MessageBoxIcon.Information);

        return Result.Succeeded;


        // This takes in the raw line of data and returns the values split by the configured delimiter.
        IEnumerable<string> splitLineData(string lineFromFile) => settings.Delimiter switch
        {
            DelimiterChars.Tab => lineFromFile.Split('\t'),
            _ => Regex.Split(lineFromFile, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))"),
        };

        // Removes any quotes which were added to data for the purposes of escaping.
        static string removeEscapeQuotes(string text)
        {
            // Remove surrounding quotes.
            if (text.StartsWith("\"") && text.EndsWith("\"") && text.Length >= 2)
            {
                text = text.Substring(1, text.Length - 2);
            }
            // Remove escaped quotes.
            return text.Replace("\"\"", "\"");
        }
    }

    /// <summary> Implementation of <see cref="API.OnElementProcessed"/>. </summary>
    ///
    /// <remarks> This method does nothing, but it is included to demonstrate how to get incremental feedback. </remarks>
    ///
    /// <inheritdoc cref="API.OnElementProcessed"/>
    private static bool ElementProcessedHandler(int totalElements, int recordNumber, Element element, Dictionary<string, string> fieldData, HashSet<string> stopProcessingFields) => true;
}