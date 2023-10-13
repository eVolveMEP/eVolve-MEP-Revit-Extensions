// Copyright (c) 2023 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

extern alias eVolve;
using eVolve::eVolve.Core.Revit.Reporting;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace eVolve.DataTableTools.Revit;

/// <summary> Dialog for handling all operations. </summary>
internal sealed partial class ToolsDialog : System.Windows.Forms.Form
{
    /// <summary> Gets the current Revit document. </summary>
    private Document Document { get; }

    /// <summary> Gets a lookup of column data type display names (key) with each one's respective data type (value). </summary>
    private static Dictionary<string, Type> ColumnDataTypeLookup { get; } = new()
    {
        { nameof(String), typeof(string) },
        { nameof(Int32), typeof(int) },
        { nameof(Int64), typeof(long) },
        { nameof(Double), typeof(double) },
        { nameof(Decimal), typeof(decimal) },
        { nameof(Boolean), typeof(bool) },
    };

    /// <summary> Constructor. </summary>
    ///
    /// <param name="document"> The current Revit document. </param>
    public ToolsDialog(Document document)
    {
        InitializeComponent();

        Document = document;

        Text = Command.ButtonTextWithNoLineBreaks;
        Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)System.Drawing.Image.FromStream(Command.IconResource)).GetHicon());
        RefreshDataTables();

        var datatypeNames = ColumnDataTypeLookup.Keys.ToArray();
        foreach (var combobox in new[] { ChangeColumnTypeDataTypeComboBox, ExpressionColumnDataTypeComboBox })
        {
            combobox.Items.Clear();
            combobox.Items.AddRange(datatypeNames);
        }

        SQLConnectButton.Text = Resources.Connect;

        foreach (var button in new[] { SQLImportSourceCustomButton, SQLExportPreEventButton, SQLExportPostEventButton })
        {
            button.Click += EditSqlButton_Click;
        }

        this.FormClosing += ToolsDialog_FormClosing;
        this.HelpRequested += ToolsDialog_HelpRequested;
    }

    /// <summary> Loads saved configuration values into the editors. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void ToolsDialog_Load(object sender, EventArgs e)
    {
        SQLConnectionStatusLabel.Text = Resources.NotConnected;
        LoadSettings();
    }

    /// <summary> Saves settings when the dialog is closed. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Form closing event information. </param>
    private void ToolsDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
        SaveSettings();
    }

    /// <summary> Refreshes the list of eVolve data tables available within all applicable controls on the form. </summary>
    private void RefreshDataTables()
    {
        var tableNames = Document.GetTableNames();

        foreach (var combobox in new[] { DataTableComboBox, SQLImportTargetComboBox })
        {
            combobox.Text = "";
            combobox.Items.Clear();
            combobox.Items.AddRange(tableNames);
        }
    }

    /// <summary> Opens the Data Tables configuration dialog and refreshes available selections. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void OpenConfigurationPictureBox_Click(object sender, EventArgs e)
    {
        Document.OpenTablesConfigurationDialog();

        // Refresh the data tables list, preserving the existing selection if possible.
        var currentTableSelection = DataTableComboBox.Text;
        RefreshDataTables();
        if (DataTableComboBox.Items.Contains(currentTableSelection))
        {
            DataTableComboBox.Text = currentTableSelection;
        }
    }

    /// <summary> Opens help information when F1 is pressed on the form. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Help event information. </param>
    private static void ToolsDialog_HelpRequested(object sender, HelpEventArgs e)
    {
        e.Handled = true;
        OpenHelpLink();
    }

    /// <summary> Opens help information. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void HelpLinkPictureBox_Click(object sender, EventArgs e)
    {
        OpenHelpLink();
    }

    /// <summary> Opens <see cref="Command.HelpLinkUrl"/> in the default application. </summary>
    private static void OpenHelpLink()
    {
        System.Diagnostics.Process.Start(Command.HelpLinkUrl);
    }

    #region Settings

    /// <summary> Gets the full pathname of the settings file store location on disk. </summary>
    private static string SettingsFilePath { get; } = System.IO.Path.Combine(BaseSaveSettingsFileFolder, "Data Table Tools", "Settings.xml");

    /// <summary>
    /// Saves the saved options from <see cref="SettingsFilePath"/> into the form. If an error occurs, the user is notified.
    /// </summary>
    private void LoadSettings()
    {
        if (LoadSettings<Settings>(SettingsFilePath) is { } settings)
        {
            SQLConnectionStringTextBox.Text = settings.SqlConnectionString;
            SQLImportSourceCustomButton.Tag = settings.SqlCustomImport;
            SQLExportPreEventButton.Tag = settings.SqlExportPreCommand;
            SQLExportPostEventButton.Tag = settings.SqlExportPostCommand;
        }
    }

    /// <summary>
    /// Saves the currently configured options to <see cref="SettingsFilePath"/>. If an error occurs, the user is notified.
    /// </summary>
    private void SaveSettings()
    {
        var settings = new Settings()
        {
            SqlConnectionString = SQLConnectionStringTextBox.Text,
            SqlCustomImport = SQLImportSourceCustomButton.Tag?.ToString(),
            SqlExportPreCommand = SQLExportPreEventButton.Tag?.ToString(),
            SqlExportPostCommand = SQLExportPostEventButton.Tag?.ToString(),
        };

        ExtensionsCommon.Revit.Methods.SaveSettings(settings, SettingsFilePath);
    }

    #endregion

    /// <summary> Updates the UI when the source data table is changed. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void DataTableComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChangeColumnTypeColumnComboBox.Items.Clear();

        try
        {
            ChangeColumnTypeColumnComboBox.Items.AddRange(GetDataTableColumnNames());
        }
        catch (Exception ex)
        {
            ShowErrorMessage(this, ex.Message, DataTableLabel.Text);
        }
    }

    #region Column Tools

    /// <summary> Performs a column data type change based on user provided input. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void ChangeColumnTypeButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(ChangeColumnTypeColumnComboBox.Text) || string.IsNullOrEmpty(ChangeColumnTypeDataTypeComboBox.Text))
            {
                throw new Exception(string.Format(Resources.ValueMustBeProvided2Error, ChangeColumnTypeColumnLabel.Text, ChangeColumnTypeDataTypeLabel.Text));
            }

            var table = Document.GetTable(DataTableComboBox.Text, out var metadata).Copy();

            var conversionFailedAtLeastOnce = false;
            Func<object, object> convertToNewType = ChangeColumnTypeDataTypeComboBox.Text switch
            {
                nameof(String) => existing => existing.ToString(),
                nameof(Int32) => existing =>
                {
                    conversionFailedAtLeastOnce |= !int.TryParse(existing.ToString(), out var value);
                    return value;
                },
                nameof(Int64) => existing =>
                {
                    conversionFailedAtLeastOnce |= !long.TryParse(existing.ToString(), out var value);
                    return value;
                },
                nameof(Double) => existing =>
                {
                    conversionFailedAtLeastOnce |= !double.TryParse(existing.ToString(), out var value);
                    return value;
                },
                nameof(Decimal) => existing =>
                {
                    conversionFailedAtLeastOnce |= !decimal.TryParse(existing.ToString(), out var value);
                    return value;
                },
                nameof(Boolean) => existing =>
                {
                    conversionFailedAtLeastOnce |= !bool.TryParse(existing.ToString(), out var value);
                    return value;
                },
                _ => throw new Exception(ChangeColumnTypeDataTypeComboBox.Text),
            };

            var sourceColumnIndex = table.Columns.IndexOf(ChangeColumnTypeColumnComboBox.Text);
            table.Columns[ChangeColumnTypeColumnComboBox.Text].DataType = ColumnDataTypeLookup[ChangeColumnTypeDataTypeComboBox.Text];

            foreach (var row in table.Rows.Cast<DataRow>())
            {
                var newRow = table.Rows.Add();
                for (var i = 0; i < table.Columns.Count; i++)
                {
                    newRow[i] = i == sourceColumnIndex ? convertToNewType(row[i]) : row[i];
                }
            }

            Document.SaveTable(table.TableName, null, false, table, metadata);

            if (conversionFailedAtLeastOnce)
            {
                ShowWarningMessage(this, Resources.CouldNotConvertValueWarning, ChangeColumnTypeGroupBox.Text);
            }

            RefreshColumnInfo(table);
            ShowNoticeMessage(this, Resources.OperationCompleted, ChangeColumnTypeGroupBox.Text);
        }
        catch (Exception ex)
        {
            ShowErrorMessage(this, ex.Message, ChangeColumnTypeGroupBox.Text);
        }
    }

    /// <summary> Adds a new expression column. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void ExpressionColumnAddButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(DataTableComboBox.Text))
            {
                throw new Exception(string.Format(Resources.ValueMustBeProvided1Error, DataTableComboBox.Text));
            }
            if (string.IsNullOrWhiteSpace(ExpressionColumnNameTextBox.Text) || string.IsNullOrEmpty(ExpressionColumnDataTypeComboBox.Text) || string.IsNullOrWhiteSpace(ExpressionColumnExpressionTextBox.Text))
            {
                throw new Exception(string.Format(Resources.ValueMustBeProvided3Error, ExpressionColumnNameLabel.Text, ExpressionColumnDataTypeLabel.Text, ExpressionColumnExpressionGroupBox.Text));
            }

            var table = Document.GetTable(DataTableComboBox.Text, out var metadata).Copy();
            table.Columns.Add(ExpressionColumnNameTextBox.Text.Trim(), ColumnDataTypeLookup[ExpressionColumnDataTypeComboBox.Text], ExpressionColumnExpressionTextBox.Text.Trim());
            Document.SaveTable(table.TableName, null, false, table, metadata);
            ShowNoticeMessage(this, Resources.OperationCompleted, ExpressionColumnGroupBox.Text);
        }
        catch (Exception ex)
        {
            ShowErrorMessage(this, ex.Message, ExpressionColumnGroupBox.Text);
        }
    }

    #endregion

    #region SQL Server

    /// <summary> Connects to SQL using the provided connection string and updates data selection values. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void SQLConnectButton_Click(object sender, EventArgs e)
    {
        SQLConnectionStatusLabel.Text = Resources.NotConnected;

        try
        {
            using var connection = GetSqlConnection();

            var tables = GetSingleStringData("SELECT [name] FROM sys.tables ORDER BY [name] ASC", connection);
            var views = GetSingleStringData("SELECT [name] FROM sys.views ORDER BY [name] ASC", connection);

            SQLImportSourceTableComboBox.Items.Clear();
            SQLImportSourceTableComboBox.Items.AddRange(tables);
            SQLImportSourceViewComboBox.Items.Clear();
            SQLImportSourceViewComboBox.Items.AddRange(views);
            SQLExportTargetComboBox.Items.Clear();
            SQLExportTargetComboBox.Items.AddRange(tables);
            SQLExportFieldMappingListBox.Items.Clear();
            
            SQLConnectionStatusLabel.Text = Resources.Connected;
        }
        catch (Exception ex)
        {
            ShowErrorMessage(this, ex.Message, SqlServerToolsTabPage.Text);
        }

        if (SQLConnectionStatusLabel.Text == Resources.Connected)
        {
            SQLConnectionStringTextBox.ReadOnly = true;
            SQLConnectButton.Text = Resources.Disconnect;
        }
        else
        {
            SQLConnectionStringTextBox.ReadOnly = false;
            SQLConnectButton.Text = Resources.Connect;
        }

    }

    /// <summary>
    /// Handles events which open <see cref="TextInputDialog"/>.
    /// <para>Values are peristed through the <paramref name="sender"/>'s <c>Tag</c> property.</para>
    /// </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void EditSqlButton_Click(object sender, EventArgs e)
    {
        var button = (Button)sender;

        string title;
        string instructions;

        if (button == SQLImportSourceCustomButton)
        {
            title = $"{SQLImportDataGroupBox.Text}: {SQLImportSourceCustomRadioButton.Text}";
            instructions = Resources.ImportStatementPromptInfo;
        }
        else if (button == SQLExportPreEventButton)
        {
            title = $"{SQLExportDataGroupBox.Text}: {SQLExportPreEventCheckBox.Text}";
            instructions = Resources.StatementToRunPriorToImport + "\n" + Resources.OperationCancelsOnErrorNotice;
        }
        else if (button == SQLExportPostEventButton)
        {
            title = $"{SQLExportDataGroupBox.Text}: {SQLExportPostEventCheckBox.Text}";
            instructions = Resources.StatementToRunAfterImport + "\n" + Resources.OperationCancelsOnErrorNotice;
        }
        else
        {
            return;
        }

        if (TextInputDialog.GetTextInput(this, title, instructions, button.Tag?.ToString()) is { } newValue)
        {
            button.Tag = newValue;
        }
    }

    /// <summary> Performs an import operation where a SQL result is copied to a data table. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void SQLImportExecuteButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(DataTableComboBox.Text))
            {
                throw new Exception(string.Format(Resources.ValueMustBeProvided1Error, DataTableComboBox.Text));
            }

            if (string.IsNullOrWhiteSpace(SQLImportTargetComboBox.Text))
            {
                throw new Exception(string.Format(Resources.ValueMustBeProvided1Error, SQLImportTargetLabel.Text));
            }

            string source;
            if (SQLImportSourceTableRadioButton.Checked)
            {
                if (string.IsNullOrEmpty(SQLImportSourceTableComboBox.Text))
                {
                    throw new Exception(string.Format(Resources.ValueMustBeProvided1Error, SQLImportSourceTableRadioButton.Text));
                }
                source = $"SELECT * FROM {SanitizeSqlObject(SQLImportSourceTableComboBox.Text)}";
            }
            else if (SQLImportSourceViewRadioButton.Checked)
            {
                if (string.IsNullOrEmpty(SQLImportSourceViewComboBox.Text))
                {
                    throw new Exception(string.Format(Resources.ValueMustBeProvided1Error, SQLImportSourceViewRadioButton.Text));
                }
                source = $"SELECT * FROM {SanitizeSqlObject(SQLImportSourceViewComboBox.Text)}";
            }
            else if (SQLImportSourceCustomRadioButton.Checked)
            {
                source = SQLImportSourceCustomButton.Tag?.ToString();
                if (string.IsNullOrWhiteSpace(source))
                {
                    throw new Exception(string.Format(Resources.ValueMustBeProvided1Error, SQLImportSourceCustomRadioButton.Text));
                }
            }
            else
            {
                throw new Exception(string.Format(Resources.NoValueSelectedError, SQLImportSourceGroupBox.Text));
            }

            using var connection = GetSqlConnection();
            using var command = new SqlCommand(source, connection);
            using var adapter = new SqlDataAdapter(command);
            var results = new DataSet();
            adapter.Fill(results);

            var tableName = DataTableComboBox.Text;
            _ = Document.GetTable(tableName, out var metadata);
            Document.SaveTable(tableName, null, false, results.Tables[0], metadata);

            ShowNoticeMessage(this, Resources.OperationCompleted, SQLImportDataGroupBox.Text);
        }
        catch (Exception ex)
        {
            ShowErrorMessage(this, ex.Message, SQLImportDataGroupBox.Text);
        }
    }

    /// <summary> (Immutable) Delimiter used in field mappings to separate the source and destination column names. </summary>
    private const char FieldMappingDelimiter = '=';

    /// <summary> Prompts the user to add a new data table to SQL table mapping entry. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void SQLExportFieldMappingAddButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(SQLExportTargetComboBox.Text))
            {
                throw new Exception(string.Format(Resources.ValueMustBeProvided1Error, SQLExportTargetLabel.Text));
            }

            if (AddMappingDialog.GetMapping(this, GetDataTableColumnNames(), GetSqlTableColumnNames(SQLExportTargetComboBox.Text)) is var mapping
                && !string.IsNullOrEmpty(mapping.DataTableColumnName))
            {
                var mappingEntry = mapping.DataTableColumnName + FieldMappingDelimiter + mapping.SQLTableColumnName;
                if (!SQLExportFieldMappingListBox.Items.Contains(mappingEntry))
                {
                    SQLExportFieldMappingListBox.Items.Add(mappingEntry);
                }
            }
        }
        catch (Exception ex)
        {
            ShowErrorMessage(this, ex.Message, SQLExportFieldMappingGroupBox.Text);
        }
    }

    /// <summary> Gets all column names in the provided <paramref name="sqlTableName"/>. </summary>
    ///
    /// <param name="sqlTableName"> Name of the SQL table to get the columns for. </param>
    private string[] GetSqlTableColumnNames(string sqlTableName)
    {
        using var connection = GetSqlConnection();
        return GetSingleStringData($"SELECT sys.columns.[name] FROM sys.columns INNER JOIN sys.tables ON sys.columns.object_id=sys.tables.object_id WHERE sys.tables.[name]={SanitizeSqlText(sqlTableName)}", connection);
    }

    /// <summary> Gets all column names from the selected <see cref="DataTableComboBox"/>. </summary>
    private string[] GetDataTableColumnNames()
    {
        return Document.GetTable(DataTableComboBox.Text, out _)
            .Columns.Cast<DataColumn>()
            .Select(column => column.ColumnName)
            .ToArray();
    }

    /// <summary> Removes the selected data table to SQL table mapping entries. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void SQLExportFieldMappingRemoveButton_Click(object sender, EventArgs e)
    {
        foreach (var index in SQLExportFieldMappingListBox.SelectedIndices.Cast<int>().OrderByDescending(i => i))
        {
            SQLExportFieldMappingListBox.Items.RemoveAt(index);
        }
    }

    /// <summary> Performs an export operation where a data table rows are copied to a SQL table. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void SQLExportExecuteButton_Click(object sender, EventArgs e)
    {
        var mappings = new List<(string DataTableColumnName, string SqlTableColumnName)>();
        string preCommand = null;
        string postCommand = null;
        SqlTransaction transaction = null;
        try
        {
            if (string.IsNullOrEmpty(DataTableComboBox.Text))
            {
                throw new Exception(string.Format(Resources.ValueMustBeProvided1Error, DataTableComboBox.Text));
            }

            if (string.IsNullOrEmpty(SQLExportTargetComboBox.Text))
            {
                throw new Exception(string.Format(Resources.ValueMustBeProvided1Error, SQLExportTargetLabel.Text));
            }

            var dataTableColumns = GetDataTableColumnNames();
            var sqlTableColumns = GetSqlTableColumnNames(SQLExportTargetComboBox.Text);
            foreach (var mappingEntry in SQLExportFieldMappingListBox.Items.Cast<string>().Select(text => (text + FieldMappingDelimiter).Split(FieldMappingDelimiter)))
            {
                var (dataTableColumn, sqlTableColumn) = (mappingEntry[0], mappingEntry[1]);
                if (!dataTableColumns.Contains(dataTableColumn))
                {
                    throw new Exception(string.Format(Resources.ExportColumnNotFoundError, dataTableColumn, DataTableLabel.Text, DataTableComboBox.Text));
                }
                if (!sqlTableColumns.Contains(sqlTableColumn))
                {
                    throw new Exception(string.Format(Resources.ExportColumnNotFoundError, sqlTableColumn, SQLExportTargetLabel.Text, SQLExportTargetComboBox.Text));
                }
                mappings.Add((dataTableColumn, sqlTableColumn));
            }
            if (mappings.Count == 0)
            {
                throw new Exception(string.Format(Resources.NoEntriesDefinedError, SQLExportFieldMappingGroupBox.Text));
            }

            if (SQLExportPreEventCheckBox.Checked)
            {
                preCommand = SQLExportPreEventButton.Tag?.ToString();
                if (string.IsNullOrWhiteSpace(preCommand))
                {
                    throw new Exception(string.Format(Resources.ValueMustBeProvidedWhenEnabledError, SQLExportPreEventCheckBox.Text));
                }
            }

            if (SQLExportPostEventCheckBox.Checked)
            {
                postCommand = SQLExportPostEventButton.Tag?.ToString();
                if (string.IsNullOrWhiteSpace(postCommand))
                {
                    throw new Exception(string.Format(Resources.ValueMustBeProvidedWhenEnabledError, SQLExportPostEventCheckBox.Text));
                }
            }


            using var connection = GetSqlConnection();
            transaction = connection.BeginTransaction();

            if (preCommand != null)
            {
                using var command = new SqlCommand(preCommand, connection, transaction);
                command.ExecuteNonQuery();
            }

            var table = Document.GetTable(DataTableComboBox.Text, out _);
            var insertCommand = new SqlCommand("INSERT INTO"
                + $" {SanitizeSqlObject(SQLExportTargetComboBox.Text)} ({string.Join(",", mappings.Select(mapping => SanitizeSqlObject(mapping.SqlTableColumnName)))})"
                + $" VALUES ({string.Join(",", Enumerable.Range(0, mappings.Count).Select(i => "@Value" + i))})",
                connection, transaction);

            foreach (var row in table.Rows.Cast<DataRow>())
            {
                insertCommand.Parameters.Clear();
                for (var i = 0; i < mappings.Count; i++)
                {
                    insertCommand.Parameters.AddWithValue("@Value" + i, row[mappings[i].DataTableColumnName]);
                }
                insertCommand.ExecuteNonQuery();
            }

            if (postCommand != null)
            {
                using var command = new SqlCommand(postCommand, connection, transaction);
                command.ExecuteNonQuery();
            }

            transaction.Commit();

            ShowNoticeMessage(this, Resources.OperationCompleted, SQLExportDataGroupBox.Text);
        }
        catch (Exception ex)
        {
            transaction?.Rollback();
            ShowErrorMessage(this, ex.Message, SQLExportDataGroupBox.Text);
        }
    }

    /// <summary> Creates and opens a new SQL Server connection to the current value of <see cref="SQLConnectionStringTextBox"/>. </summary>
    private SqlConnection GetSqlConnection()
    {
        var connection = new SqlConnection(SQLConnectionStringTextBox.Text);
        connection.Open();
        return connection;
    }

    /// <summary> Gets a list of all text values from the first column of each resulting data row. </summary>
    ///
    /// <param name="sql"> Query to execute. This is expected to have text/string data in it's first result column. </param>
    /// <param name="connection"> Open SQL connection. </param>
    private static string[] GetSingleStringData(string sql, SqlConnection connection)
    {
        var data = new List<string>();
        using var command = new SqlCommand(sql, connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            data.Add(reader.GetString(0));
        }
        reader.Close();
        return data.ToArray();
    }

    /// <summary> Sanitizes and properly escapes a SQL object such as a table or field name. </summary>
    ///
    /// <param name="name"> SQL table or column name. </param>
    private static string SanitizeSqlObject(string name) => $"[{name}]";

    /// <summary> Sanitizes and properly escapes a text value for use in a SQL statement. </summary>
    ///
    /// <param name="value"> Text value to be used in a SQL statement. </param>
    private static string SanitizeSqlText(string value) => $"'{value.Replace("'", "''")}'";

    #endregion
}
