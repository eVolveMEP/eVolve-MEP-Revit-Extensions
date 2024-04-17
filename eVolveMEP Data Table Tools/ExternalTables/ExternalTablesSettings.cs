// Copyright (c) 2024 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace eVolve.DataTableTools.Revit.ExternalTables;

/// <summary> (Serializable) Stores configuration for external data table sources. </summary>
[Serializable]
public class ExternalTablesSettings
{
    /// <summary> Gets or sets the Excel data sources. </summary>
    public ExcelSource[] Excel { get; set; } = [];

    /// <summary> Gets or sets the SQL Server data sources. </summary>
    public SqlServerSource[] SqlServer { get; set; } = [];
}

/// <summary> Base class which all <see cref="ExternalTablesSettings"/> sources should inherit from. </summary>
public abstract class ExternalTableSourceBase
{
    /// <summary> Gets or sets the name of source. </summary>
    ///
    /// <remarks> This should be unique. </remarks>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this data is cached (<see langword="true"/>) or performs a live lookup on
    /// each request (<see langword="false"/>).
    /// </summary>
    public bool Cache { get; set; }
}


/// <summary> (Serializable) External Excel data source configuration information. </summary>
[Serializable]
public class ExcelSource : ExternalTableSourceBase
{
    /// <summary> Gets or sets the full pathname of the file. </summary>
    public string FilePath { get; set; }

    /// <summary>
    /// Gets or sets a list of column names which should be included in the results.
    /// <para>When this is empty, it indicates all columns should be included.</para>
    /// </summary>
    ///
    /// <remarks>
    /// When the same value appears in both <see cref="IncludeColumnNames"/> and <see cref="ExcludeColumnNames"/>,
    /// <see cref="ExcludeColumnNames"/> takes priority.
    /// </remarks>
    public string[] IncludeColumnNames { get; set; } = [];

    /// <summary> Gets or sets a list of column names which should be excluded from the results. </summary>
    ///
    /// <remarks> <inheritdoc cref="IncludeColumnNames" path="/remarks"/> </remarks>
    public string[] ExcludeColumnNames { get; set; } = [];

    /// <summary> Gets or sets a list of definitions specifying the type of data columns contain. </summary>
    ///
    /// <remarks> If a column does not have a definition, it assumed to be a <see langword="string"/>. </remarks>
    public ExcelColumnDataType[] ColumnDataTypes { get; set; } = [];
}

/// <summary> (Serializable) Defines the data type which a column within <see cref="ExcelSource"/> holds. </summary>
[Serializable]
public class ExcelColumnDataType
{
    /// <summary> Gets or sets the name of the column for this definition. </summary>
    public string ColumnName { get; set; }

    /// <summary>
    /// Gets or sets the type of the data. This should be a key value within <see cref="ColumnDataTypeLookup"/>.
    /// </summary>
    public string DataType { get; set; }
}

/// <summary> (Serializable) External SQL Server data source configuration information. </summary>
[Serializable]
public class SqlServerSource : ExternalTableSourceBase
{
    /// <summary> Gets or sets the connection string. </summary>
    public string ConnectionString { get; set; }

    /// <summary> Gets or sets the SQL command text to be executed. </summary>
    public string CommandText { get; set; }
}