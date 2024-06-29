// Copyright (c) 2024 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

extern alias eVolve;

using System.Data;
using System.Data.SqlClient;

namespace eVolve.DataTableTools.Revit.ExternalTables;

/// <summary> Constructor. </summary>
///
/// <param name="source"> <inheritdoc cref="Source" path="/summary"/>. </param>
internal class SqlServerTableSource(SqlServerSource source) : eVolve::eVolve.Core.Revit.Reporting.IExternalDataTable
{
    /// <summary> Source definition which defines how data is pulled. </summary>
    private SqlServerSource Source { get; } = source;

    /// <inheritdoc />
    public string Id => $"{nameof(SqlServerTableSource)}_{Source.Name}";

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

        using var adapter = new SqlDataAdapter(FromBase64(Source.CommandText), FromBase64(Source.ConnectionString));
        var results = new DataSet();
        adapter.Fill(results);
        var table = results.Tables[0].Copy();
        table.TableName = Source.Name;

        LastUpdated = DateTime.Now;
        return table;
    }
}
