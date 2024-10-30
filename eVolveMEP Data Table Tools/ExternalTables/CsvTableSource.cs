// Copyright (c) 2024 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

extern alias eVolve;

using System.Data;

namespace eVolve.DataTableTools.Revit.ExternalTables;

/// <summary> Constructor. </summary>
///
/// <param name="source"> <inheritdoc cref="Source" path="/summary"/>. </param>
internal class CsvTableSource(CsvSource source) : eVolve::eVolve.Core.Revit.Reporting.IExternalDataTable
{
    /// <summary> Source definition which defines how data is pulled. </summary>
    private CsvSource Source { get; } = source;

    /// <inheritdoc />
    public string Id => $"{nameof(CsvTableSource)}_{Source.Name}";

    /// <inheritdoc />
    public string Name => Source.Name;

    /// <inheritdoc />
    public string Description => Source.Description;

    /// <inheritdoc />
    public bool CacheData => Source.Cache;

    /// <summary> Backing field for <see cref="GetLastUpdatedOn"/>. </summary>
    private DateTime LastUpdated { get; set; } = DateTime.MinValue;

    /// <inheritdoc />
    public DateTime GetLastUpdatedOn(Document document) => LastUpdated;

    /// <summary>
    /// Returns a new CSV file reader for the provided <paramref name="filePath"/>.
    /// <para>If <paramref name="filePath"/> does not exist, <see langword="null"/> is returned.</para>
    /// </summary>
    ///
    /// <param name="filePath"> Full pathname of the file to create the reader for. </param>
    private static Microsoft.VisualBasic.FileIO.TextFieldParser GetCsvReader(string filePath)
    {
        if (!System.IO.File.Exists(filePath))
        {
            return null;
        }

        var csvReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(filePath);
        csvReader.SetDelimiters(",");
        csvReader.HasFieldsEnclosedInQuotes = true;
        return csvReader;
    }

    /// <summary>
    /// Gets an index of column headers using the column name (key) and the index position (value) for the provided <paramref name="filePath"/>.
    /// <para>If <paramref name="filePath"/> does not exist, <see langword="null"/> is returned.</para>
    /// </summary>
    ///
    /// <param name="filePath"> Full pathname of the file to get the header information for. </param>
    /// <param name="reader"> (Optional) Existing file reader to use. If not provided, a new one is created and disposed
    ///     when finished. </param>
    internal static Dictionary<string, int> GetHeaders(string filePath, Microsoft.VisualBasic.FileIO.TextFieldParser reader = null)
    {
        var keepOpen = reader != null;
        reader ??= GetCsvReader(filePath);

        if (reader == null)
        {
            return null;
        }

        try
        {
            return reader.ReadFields()?
                .Select((text, index) => (text, index))
                .ToDictionary(entry => entry.text, entry => entry.index);
        }
        finally
        {
            if (!keepOpen)
            {
                reader.Dispose();
            }
        }
    }

    /// <inheritdoc/>
    public DataTable GetData(Document document, out string metadata)
    {
        metadata = null;
        if (GetCsvReader(Source.FilePath) is not { } reader)
        {
            return null;
        }

        try
        {
            var headers = GetHeaders(Source.FilePath, reader)
                .Where(entry => !Source.ExcludeColumnNames.Contains(entry.Key))
                .ToArray();

            if (!headers.Any())
            {
                return null;
            }

            var table = new DataTable(Source.Name);

            foreach (var headerEntry in headers)
            {
                var type = ColumnDataTypeLookup[Source.ColumnDataTypes.DefaultIfEmpty(new TabularColumnDataType()).FirstOrDefault(columnType => columnType.ColumnName == headerEntry.Key)!.DataType];
                table.Columns.Add(headerEntry.Key, type);
                table.Columns[headerEntry.Key].DefaultValue = type == typeof(string) ? "" : Activator.CreateInstance(type);
            }

            while (!reader.EndOfData)
            {
                if (reader.ReadFields() is not { } line)
                {
                    continue;
                }

                var rowData = table.NewRow();
                foreach (var headerEntry in headers)
                {
                    var cellData = line[headerEntry.Value];
                    var fieldType = table.Columns[headerEntry.Key].DataType;

                    // Skip known failures.
                    if (fieldType != typeof(string))
                    {
                        cellData = cellData.Trim();
                        if (string.IsNullOrEmpty(cellData))
                        {
                            continue;
                        }
                    }

                    try
                    {
                        rowData[headerEntry.Key] = Convert.ChangeType(cellData, fieldType);
                    }
                    catch
                    {
                        // Intentially ignore errors.
                    }
                }
                table.Rows.Add(rowData);
            }

            LastUpdated = DateTime.Now;
            return table;
        }
        finally
        {
            reader.Dispose();
        }
    }
}
