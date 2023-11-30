// Copyright (c) 2023 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace eVolve.DataTableTools.Revit;

/// <summary> Values that represent SQL import sources. </summary>
[Serializable]
public enum SqlImportSource
{
    /// <summary> SQL table. </summary>
    Table,
    /// <summary> SQL view. </summary>
    View,
    /// <summary> Custom SQL query. </summary>
    CustomSql,
}

/// <summary> Stores settings configured on <see cref="ToolsDialog"/>. </summary>
[Serializable]
public class Settings
{
    /// <summary> Gets or sets the SQL Server connection string. </summary>
    public string SqlConnectionString { get; set; }

    /// <summary> Gets or sets the SQL settings specific for each source data table. </summary>
    public SqlTableSettings[] SqlTableSettings { get; set; } = Array.Empty<SqlTableSettings>();
}

/// <summary> Stores SQL specific table settings. </summary>
[Serializable]
public class SqlTableSettings
{
    /// <summary> Gets or sets the name of the source data table which these settings apply to. </summary>
    public string TableName { get; set; }

    /// <summary> Gets or sets the import source. </summary>
    public SqlImportSource ImportSource { get; set; }

    /// <summary> Gets or sets the name of the SQL table to import from. </summary>
    public string ImportSourceTableName { get; set; }

    /// <summary> Gets or sets the name of the SQL view to import from. </summary>
    public string ImportSourceViewName { get; set; }

    /// <summary> Gets or sets the custom SQL command to run for data import. </summary>
    public string ImportSourceCustomSql { get; set; }

    /// <summary> Gets or sets the name of the export destination SQL table. </summary>
    public string ExportSourceTargetName { get; set; }

    /// <summary>
    /// Gets or sets the field mapping between the source <see cref="TableName"/> and <see cref="ExportSourceTargetName"/>.
    /// </summary>
    public TableFieldMapping[] ExportFieldMappings { get; set; } = Array.Empty<TableFieldMapping>();

    /// <summary> Gets or sets a value <see cref="ExportSqlPreCommand"/> is enabled. </summary>
    public bool ExportSqlPreCommandEnabled { get; set; }

    /// <summary> Gets or sets the SQL command to optionally run before exporting a data table to a SQL table. </summary>
    public string ExportSqlPreCommand { get; set; }

    /// <summary> Gets or sets a value <see cref="ExportSqlPostCommand"/> is enabled. </summary>
    public bool ExportSqlPostCommandEnabled { get; set; }

    /// <summary> Gets or sets the SQL command to optionally run after exporting a data table to a SQL table. </summary>
    public string ExportSqlPostCommand { get; set; }
}

/// <summary> Store a field mapping from one table to another. </summary>
[Serializable]
public class TableFieldMapping
{
    /// <summary> Gets or sets the name of the source field. </summary>
    public string SourceFieldName { get; set; }

    /// <summary> Gets or sets the name of the destination field. </summary>
    public string TargetFieldName { get; set; }
}