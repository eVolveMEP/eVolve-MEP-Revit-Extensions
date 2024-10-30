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

    /// <summary> Gets or sets the CSV data sources. </summary>
    public CsvSource[] Csv { get; set; } = [];

    /// <summary> Gets or sets the SQL Server data sources. </summary>
    public SqlServerSource[] SqlServer { get; set; } = [];

    /// <summary> Gets or sets the serialized data table sources. </summary>
    public SerializedDataTableSource[] SerializedDataTables { get; set; } = [];
}

/// <summary> Base class which all <see cref="ExternalTablesSettings"/> sources should inherit from. </summary>
public abstract class ExternalTableSourceBase
{
    /// <summary> Gets or sets the name of source. </summary>
    ///
    /// <remarks> This should be unique. </remarks>
    public string Name { get; set; }

    /// <summary> Gets or sets the description. </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this data is cached (<see langword="true"/>) or performs a live lookup on
    /// each request (<see langword="false"/>).
    /// </summary>
    public bool Cache { get; set; } = true;
}

/// <summary> Base class which holds information for tabular data source files. </summary>
public class TabularSourceBase : ExternalTableSourceBase
{
    /// <summary> Gets or sets the full pathname of the file. </summary>
    public string FilePath { get; set; }

    /// <summary> Gets or sets a list of column names which should be excluded from the results. </summary>
    public string[] ExcludeColumnNames { get; set; } = [];

    /// <summary> Gets or sets a list of definitions specifying the type of data columns contain. </summary>
    ///
    /// <remarks> If a column does not have a definition, it assumed to be a <see langword="string"/>. </remarks>
    public TabularColumnDataType[] ColumnDataTypes { get; set; } = [];
}

/// <summary> (Serializable) Defines the data type which a column within <see cref="TabularSourceBase"/> holds. </summary>
[Serializable]
public class TabularColumnDataType
{
    /// <summary> Gets or sets the name of the column for this definition. </summary>
    public string ColumnName { get; set; }

    /// <summary>
    /// Gets or sets the type of the data. This should be a key value within <see cref="ColumnDataTypeLookup"/>.
    /// </summary>
    public string DataType { get; set; } = ColumnDataTypeLookup.First().Key;
}

/// <summary> (Serializable) External Excel data source configuration information. </summary>
[Serializable]
public class ExcelSource : TabularSourceBase { }

/// <summary> (Serializable) External CSV file source information. </summary>
[Serializable]
public class CsvSource : TabularSourceBase { }

/// <summary> (Serializable) External SQL Server data source configuration information. </summary>
[Serializable]
public class SqlServerSource : ExternalTableSourceBase
{
    /// <summary> Gets or sets the connection string. </summary>
    ///
    /// <remarks> This is encoded in base64. </remarks>
    public string ConnectionString { get; set; }

    /// <summary> Gets or sets the SQL command text to be executed. </summary>
    ///
    /// <remarks> <inheritdoc cref="ConnectionString" path="/remarks"/> </remarks>
    public string CommandText { get; set; }
}

/// <summary> (Serializable) External serialized <see cref="System.Data.DataTable"/> source information. </summary>
[Serializable]
public class SerializedDataTableSource : ExternalTableSourceBase
{
    /// <summary> Gets or sets the full pathname of the serialized source. </summary>
    public string FilePath { get; set; }
}
