// Copyright (c) 2024 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

extern alias eVolve;
using ProductAPI = eVolve::eVolve.Core.Revit.ProductInfo.API;
using ReportingAPI = eVolve::eVolve.Core.Revit.Reporting.API;

namespace eVolve.DataTableTools.Revit.ExternalTables;

/// <summary> Methods which implement the functionality of external data tables. </summary>
internal static class ExternalTablesMethods
{
    /// <summary> Gets the file path where the persisted <see cref="ExternalTablesSettings"/> are stored. </summary>
    ///
    /// <param name="isGlobal"> [out] Specifies if the path is set to a global/company standard location (<see langword="true"/>)
    ///     or a local path (<see langword="false"/>). </param>
    internal static string GetExternalTablesSettingsFilePath(out bool isGlobal)
    {
        isGlobal = !string.IsNullOrEmpty(ProductAPI.GlobalConfigurationFolderPath);
        return System.IO.Path.Combine(!string.IsNullOrEmpty(ProductAPI.GlobalConfigurationFolderPath) ? ProductAPI.GlobalConfigurationFolderPath : ApplicationConfigurationPath, "ExternalTables.xml");
    }

    /// <summary>
    /// Gets the <see cref="ExternalTablesSettings"/> currently staved on disk or creates a new instance if it does not
    /// exist.
    /// </summary>
    public static ExternalTablesSettings GetSettings() => LoadSettings<ExternalTablesSettings>(GetExternalTablesSettingsFilePath(out _)) ?? new ExternalTablesSettings();

    /// <summary> Gets a list of Ids currently registered via <see cref="ReportingAPI.RegisterExternalDataTable"/>. </summary>
    private static List<string> CurrentlyRegisteredIds { get; } = [];

    /// <summary>
    /// Saves the provided <paramref name="settings"/> to disk and handles registration of all sources with <see cref="ReportingAPI"/>.
    /// </summary>
    ///
    /// <param name="settings"> Current settings. </param>
    public static void ApplySettings(ExternalTablesSettings settings)
    {
        SaveSettings(settings, GetExternalTablesSettingsFilePath(out _));

        foreach (var unregisterId in CurrentlyRegisteredIds)
        {
            ReportingAPI.UnregisterExternalDataTable(unregisterId);
        }
        CurrentlyRegisteredIds.Clear();

        foreach (var source in Enumerable.Empty<eVolve::eVolve.Core.Revit.Reporting.IExternalDataTable>()
            .Concat(settings.Excel.Select(excel => new ExcelTableSource(excel)))
            .Concat(settings.SqlServer.Select(sqlServer => new SqlServerTableSource(sqlServer))))
        {
            ReportingAPI.RegisterExternalDataTable(source);
            CurrentlyRegisteredIds.Add(source.Id);
        }
    }

    /// <summary>
    /// Wraps the code for opening and closing an Excel document and delegates all work to be done to the provided <paramref name="action"/>.
    /// </summary>
    ///
    /// <exception cref="Exception"> Thrown when an exception error condition occurs. </exception>
    ///
    /// <param name="file"> The Excel file to open. </param>
    /// <param name="action"> The action to be done with the provided <see cref="ExcelWrapper.Worksheet"/>. </param>
    internal static void ReadFromExcel(string file, Action<ExcelWrapper.Worksheet> action)
    {
        if (!System.IO.File.Exists(file) || action == null)
        {
            return;
        }

        try
        {
            using var excel = new ExcelWrapper.Excel();
            var workbook = excel.OpenWorkbook(file);
            var worksheet = workbook.GetWorksheet(1);

            try
            {
                action(worksheet);
            }
            finally
            {
                excel.Close();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(Resources.ReadingExcelFileError
                + Environment.NewLine + file
                + Environment.NewLine
                + Environment.NewLine + ex.Message);
        }
    }
}
