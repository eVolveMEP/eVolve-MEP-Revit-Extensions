// Copyright (c) 2023 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace eVolve.DataTableTools.Revit;

/// <summary> Stores settings configured on <see cref="ToolsDialog"/>. </summary>
[Serializable]
public class Settings
{
    /// <summary> Gets or sets the SQL Server connection string. </summary>
    public string SqlConnectionString { get; set; }

    /// <summary> Gets or sets the custom SQL command to run for data import. </summary>
    public string SqlCustomImport { get; set; }

    /// <summary> Gets or sets the SQL command to optionally run before exporting a data table to a SQL table. </summary>
    public string SqlExportPreCommand { get; set; }

    /// <summary> Gets or sets the SQL command to optionally run after exporting a data table to a SQL table. </summary>
    public string SqlExportPostCommand { get; set; }

}