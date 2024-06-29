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
internal class ExcelTableSource(ExcelSource source) : eVolve::eVolve.Core.Revit.Reporting.IExternalDataTable
{
    /// <summary> Source definition which defines how data is pulled. </summary>
    private ExcelSource Source { get; } = source;

    /// <inheritdoc />
    public string Id => $"{nameof(ExcelTableSource)}_{Source.Name}";

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

    /// <inheritdoc />
    public DataTable GetData(Document document, out string metadata)
    {
        metadata = null;

        var table = new DataTable(Source.Name);

        ExternalTablesMethods.ReadFromExcel(Source.FilePath,
            worksheet =>
            {
                var headers = worksheet.GetHeaderIndexes()
                    .Where(entry => !Source.ExcludeColumnNames.Contains(entry.Key))
                    .Where(entry => !Source.IncludeColumnNames.Any() || Source.IncludeColumnNames.Contains(entry.Key))
                    .ToArray();

                if (!headers.Any())
                {
                    return;
                }

                foreach (var headerEntry in headers)
                {
                    var type = ColumnDataTypeLookup[Source.ColumnDataTypes.DefaultIfEmpty(new ExcelColumnDataType()).FirstOrDefault(columnType => columnType.ColumnName == headerEntry.Key)!.DataType];
                    table.Columns.Add(headerEntry.Key, type);
                    table.Columns[headerEntry.Key].DefaultValue = type == typeof(string) ? "" : Activator.CreateInstance(type);
                }

                for (var i = 2; i <= worksheet.GetMaxRow(headers.First().Value); i++)
                {
                    var rowData = table.NewRow();
                    foreach (var headerEntry in headers)
                    {
                        try
                        {
                            rowData[headerEntry.Key] = worksheet.GetValue(i, headerEntry.Value);
                        }
                        catch
                        {
                            // Intentially ignore errors.
                        }
                    }
                    table.Rows.Add(rowData);
                }
            });

        LastUpdated = DateTime.Now;
        return table;
    }
}
