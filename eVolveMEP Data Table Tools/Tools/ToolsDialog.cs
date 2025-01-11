// Copyright (c) 2025 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

extern alias eVolve;
using eVolve::eVolve.Core.Revit.Reporting;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace eVolve.DataTableTools.Revit.Tools;

/// <summary> Dialog for handling all operations. </summary>
internal sealed partial class ToolsDialog : System.Windows.Forms.Form
{
    /// <summary> Gets the current Revit document. </summary>
    private Document Document { get; }

    /// <summary>
    /// Gets a lookup by data table name (key) of the active <see cref="SqlTableSettings"/> currently respresented on
    /// this form (value).
    /// </summary>
    ///
    /// <remarks>
    /// This can be different from what is currently saved since the user may not yet have applied settings.
    /// </remarks>
    private Dictionary<string, SqlTableSettings> ActiveSqlTableSettings { get; } = [];

    /// <summary>
    /// Gets the value to use as the key for capturing default values as they will be stored by this configuration.
    /// </summary>
    private string DefaultSettingsKey => $"___{nameof(DefaultSettingsKey)}";

    /// <summary> Constructor. </summary>
    ///
    /// <param name="document"> The current Revit document. </param>
    public ToolsDialog(Document document)
    {
        InitializeComponent();

        this.PrepDialog(Resources.ToolsButtonText, ToolsCommand.IconResource,
            ToolsCommand.HelpLinkUrl, HelpLinkPictureBox, ToolsCommand.VideoUrl, VideoLinkPictureBox, ViewSourceCodeLabel);

        Document = document;

        RefreshDataTables();

        // Capture the default values.
        PreviouslySelectedDataTableName = DefaultSettingsKey;
        DataTableChangedSqlHandler(null, EventArgs.Empty);

        var datatypeNames = ColumnDataTypeLookup.Keys.Prepend("").ToArray();
        foreach (var combobox in new[] { ChangeColumnDataTypeComboBox, ExpressionColumnDataTypeComboBox })
        {
            combobox.Items.Clear();
            combobox.Items.AddRange(datatypeNames);
        }

        SQLConnectionStatusLabel.TextChanged += SQLConnectionStatusLabel_TextChanged;

        // TextChanged occurs before SelectedIndexChanged so consumers interested in the previous value need to consider this.
        DataTableComboBox.TextChanged += DataTableChangedToolsHandler;
        DataTableComboBox.TextChanged += DataTableChangedSqlHandler;
        DataTableComboBox.SelectedIndexChanged += (_, _) => PreviouslySelectedDataTableName = DataTableComboBox.Text;

        foreach (var button in new[] { SQLImportSourceCustomButton, SQLExportPreEventButton, SQLExportPostEventButton })
        {
            button.Click += EditSqlButton_Click;
        }

        Shown += (_, _) =>
        {
            ResetEntireConfigurationGroupBox.Text = string.Format(ResetEntireConfigurationGroupBox.Text, Text);
            ResetSelectedConfigurationButton.Text = string.Format(ResetSelectedConfigurationButton.Text, DataTableLabel.Text);
        };

        FormClosing += ToolsDialog_FormClosing;
    }

    /// <summary> Loads saved configuration values into the editors. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void ToolsDialog_Load(object sender, EventArgs e)
    {
        LoadSettings();

        SQLConnectButton.Text = Resources.Connect;
        SQLConnectionStatusLabel.Text = Resources.NotConnected;

        static void openHelpLink(object s1, EventArgs e1) => StartProcess(((Label)s1).Tag.ToString());
        foreach (var helpLabel in new[] { DataTableExpressionHelpLabel, SQLConnectionStringHelpLabel })
        {
            helpLabel.Cursor = Cursors.Hand;
            helpLabel.Click += openHelpLink;
        }

        DataTableComboBox_SelectedIndexChanged(this, EventArgs.Empty);
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
        DataTableComboBox.Text = "";
        DataTableComboBox.Items.Clear();
        DataTableComboBox.Items.AddRange(Document.GetTableNames(includeExternalTables: false));
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

    #region Settings

    /// <summary> Gets the full pathname of the settings file store location on disk. </summary>
    private static string SettingsFilePath { get; } = System.IO.Path.Combine(ApplicationConfigurationPath, "Settings.xml");

    /// <summary>
    /// Saves the saved options from <see cref="SettingsFilePath"/> into the form. If an error occurs, the user is
    /// notified.
    /// </summary>
    ///
    /// <param name="settings"> (Optional) If provided, this is used in place of loading from <see cref="SettingsFilePath"/>. </param>
    private void LoadSettings(Settings settings = null)
    {
        settings ??= LoadSettings<Settings>(SettingsFilePath);
        if (settings != null)
        {
            SQLConnectionStringTextBox.Text = FromBase64(settings.SqlConnectionString);

            // Remove all active state information except for the default state.
            foreach (var key in ActiveSqlTableSettings.Keys.Where(key => key != DefaultSettingsKey).ToArray())
            {
                ActiveSqlTableSettings.Remove(key);
            }
            foreach (var sqlTableSettings in settings.SqlTableSettings)
            {
                ActiveSqlTableSettings.Add(sqlTableSettings.TableName, sqlTableSettings);
            }
        }
    }

    /// <summary>
    /// Saves the currently configured options to <see cref="SettingsFilePath"/>. If an error occurs, the user is notified.
    /// </summary>
    private void SaveSettings()
    {
        DataTableChangedSqlHandler(nameof(SaveSettings), EventArgs.Empty);
        var settings = new Settings()
        {
            SqlConnectionString = ToBase64(SQLConnectionStringTextBox.Text),
            SqlTableSettings = ActiveSqlTableSettings
                .Where(entry => !string.IsNullOrEmpty(entry.Key))
                .Where(entry => entry.Key != DefaultSettingsKey)
                .Select(entry => entry.Value)
                .Where(sqlTableSettings => !isSqlSettingsDefault(sqlTableSettings))
                .ToArray(),
        };

        ExtensionsCommon.Revit.Methods.SaveSettings(settings, SettingsFilePath);

        bool isSqlSettingsDefault(SqlTableSettings sqlTableSettings)
        {
            static string serializedValue(SqlTableSettings data)
            {
                using var stream = new System.IO.StringWriter();
                new System.Xml.Serialization.XmlSerializer(typeof(SqlTableSettings)).Serialize(stream, data);
                return stream.ToString();
            }

            // Source table will always be different, so set it to the same value to remove it from consideration.
            var defaultSettings = ActiveSqlTableSettings[DefaultSettingsKey];
            defaultSettings.TableName = sqlTableSettings.TableName;

            return serializedValue(sqlTableSettings) == serializedValue(defaultSettings);
        }
    }

    #endregion

    /// <summary> Updates the UI when the source data table is changed. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void DataTableComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        MainTabControl.Enabled = !string.IsNullOrEmpty(DataTableComboBox.Text);
    }

    /// <summary>
    /// Gets or sets the name of the previously selected data table on <see cref="DataTableComboBox"/>.
    /// </summary>
    ///
    /// <remarks>
    /// In practice this is set on <see cref="DataTableComboBox"/> value change to capture what is the current (at the
    /// time) value and then consumed on the next value change.
    /// </remarks>
    private string PreviouslySelectedDataTableName
    {
        get => (string)DataTableComboBox.Tag;
        set => DataTableComboBox.Tag = value;
    }

    #region Column Tools

    /// <summary> Handles the change of the source data table. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void DataTableChangedToolsHandler(object sender, EventArgs e)
    {
        ChangeColumnColumnComboBox.Text = null;
        ChangeColumnNameTextBox.Text = null;
        ChangeColumnSequenceComboBox.Text = null;
        ChangeColumnDataTypeComboBox.Text = null;
        ExpressionColumnNameTextBox.Text = null;
        ExpressionColumnDataTypeComboBox.Text = null;
        ExpressionColumnExpressionTextBox.Text = null;

        DataTable table = null;
        if (!string.IsNullOrEmpty(DataTableComboBox.Text))
        {
            try
            {
                table = Document.GetTable(DataTableComboBox.Text, out _);
            }
            catch (KeyNotFoundException)
            {
                // Table does not exist, it has likely been renamed or deleted.
            }
        }

        try
        {
            var columnNames = GetDataTableColumnNames(table) ?? [];

            ChangeColumnColumnComboBox.Items.Clear();
            ChangeColumnColumnComboBox.Items.AddRange(columnNames);

            ChangeColumnSequenceComboBox.Items.Clear();
            ChangeColumnSequenceComboBox.Items.AddRange(Enumerable.Range(1, columnNames.Length)
                .Select(order => order.ToString())
                .Prepend("")
                .ToArray());
        }
        catch (Exception ex)
        {
            ShowErrorMessage(this, ex.Message, DataTableLabel.Text);
        }

        RefreshColumnInfo(table);
    }

    /// <summary> Performs a column change based on user provided input. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1140:Add exception to documentation comment.", Justification = "Exceptions do not bubble up")]
    private void ChangeColumnButton_Click(object sender, EventArgs e)
    {
        try
        {
            var originalColumnName = ChangeColumnColumnComboBox.Text;
            if (string.IsNullOrEmpty(originalColumnName))
            {
                throw new Exception(string.Format(Resources.ValueMustBeProvided1Error, ChangeColumnColumnLabel.Text));
            }

            var sourceColumnName = originalColumnName;
            var actionsPerformed = new List<string>();
            var table = Document.GetTable(DataTableComboBox.Text, out var metadata).Copy();


            #region Change Name
            var newName = ChangeColumnNameTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(newName))
            {
                table.Columns[sourceColumnName].ColumnName = newName;
                sourceColumnName = newName;

                actionsPerformed.Add($"{ChangeColumnNameLabel.Text}: {newName}");
            }
            #endregion


            #region Change Sequence
            if (!string.IsNullOrEmpty(ChangeColumnSequenceComboBox.Text))
            {
                var newSequence = int.Parse(ChangeColumnSequenceComboBox.Text);
                table.Columns[sourceColumnName].SetOrdinal(newSequence - 1);

                actionsPerformed.Add($"{ChangeColumnSequenceLabel.Text}: {newSequence}");
            }
            #endregion


            #region Change Data Type
            var newDataType = ChangeColumnDataTypeComboBox.Text;
            if (!string.IsNullOrEmpty(newDataType))
            {
                var conversionFailedAtLeastOnce = false;
                object defaultNewTypeValue;
                Func<object, object> convertToNewType;

                switch (newDataType)
                {
                    case nameof(String):
                        defaultNewTypeValue = default(string);
                        convertToNewType = existing => existing.ToString();
                        break;
                    case nameof(Int32):
                        defaultNewTypeValue = default(int);
                        convertToNewType = existing =>
                        {
                            conversionFailedAtLeastOnce |= !int.TryParse(existing.ToString(), out var value);
                            return value;
                        };
                        break;
                    case nameof(Int64):
                        defaultNewTypeValue = default(long);
                        convertToNewType = existing =>
                        {
                            conversionFailedAtLeastOnce |= !long.TryParse(existing.ToString(), out var value);
                            return value;
                        };
                        break;
                    case nameof(Double):
                        defaultNewTypeValue = default(double);
                        convertToNewType = existing =>
                        {
                            conversionFailedAtLeastOnce |= !double.TryParse(existing.ToString(), out var value);
                            return value;
                        };
                        break;
                    case nameof(Decimal):
                        defaultNewTypeValue = default(decimal);
                        convertToNewType = existing =>
                        {
                            conversionFailedAtLeastOnce |= !decimal.TryParse(existing.ToString(), out var value);
                            return value;
                        };
                        break;
                    case nameof(Boolean):
                        defaultNewTypeValue = default(bool);
                        convertToNewType = existing =>
                        {
                            conversionFailedAtLeastOnce |= !bool.TryParse(existing.ToString(), out var value);
                            return value;
                        };
                        break;
                    case nameof(DateTime):
                        defaultNewTypeValue = default(DateTime);
                        convertToNewType = existing =>
                        {
                            conversionFailedAtLeastOnce |= !DateTime.TryParse(existing.ToString(), out var value);
                            return value;
                        };
                        break;
                    default:
                        throw new ArgumentException(ChangeColumnColumnLabel.Text);
                }

                // Create a new column with the new type and copy 
                var sourceColumnIndex = table.Columns.IndexOf(sourceColumnName);
                var newColumn = table.Columns.Add($"new_{sourceColumnName}", ColumnDataTypeLookup[newDataType]);
                foreach (var row in table.Rows.Cast<DataRow>())
                {
                    row[newColumn] = convertToNewType(row[sourceColumnIndex]);
                }

                // Remove source column and move the new column into its place.
                table.Columns.RemoveAt(sourceColumnIndex);
                newColumn.ColumnName = sourceColumnName;
                newColumn.SetOrdinal(sourceColumnIndex);

                if (conversionFailedAtLeastOnce)
                {
                    ShowWarningMessage(this, string.Format(Resources.CouldNotConvertValueWarning, defaultNewTypeValue), ChangeColumnDataTypeLabel.Text);
                }

                actionsPerformed.Add($"{ChangeColumnDataTypeLabel.Text}: {newDataType}");
            }
            #endregion


            if (actionsPerformed.Any())
            {
                Document.SaveTable(table.TableName, null, false, table, metadata);

                DataTableChangedToolsHandler(ChangeColumnGroupBox, EventArgs.Empty);

                ShowNoticeMessage(this,
                    Resources.OperationCompleted + "\n\n" + string.Join("\n", actionsPerformed.Prepend($"{ChangeColumnGroupBox.Text}: {originalColumnName}")),
                    ChangeColumnGroupBox.Text);
            }
        }
        catch (Exception ex)
        {
            ShowErrorMessage(this, ex.Message, ChangeColumnGroupBox.Text);
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

            RefreshColumnInfo(table);
            ShowNoticeMessage(this, Resources.OperationCompleted, ExpressionColumnGroupBox.Text);
        }
        catch (Exception ex)
        {
            ShowErrorMessage(this, ex.Message, ExpressionColumnGroupBox.Text);
        }
    }

    /// <summary> Rebuilds the current column information of the provided <paramref name="table"/>. </summary>
    ///
    /// <param name="table"> The table to display column information for.
    ///     <para>Provide <see langword="null"/> to clear this information.</para> </param>
    private void RefreshColumnInfo(DataTable table)
    {
        var columnInfoTable = new DataTable();
        columnInfoTable.Columns.Add(Resources.ColumnInfoName_Order, typeof(int));
        columnInfoTable.Columns.Add(Resources.ColumnInfoName_Name, typeof(string));
        columnInfoTable.Columns.Add(Resources.ColumnInfoName_DataType, typeof(string));
        columnInfoTable.Columns.Add(Resources.ColumnInfoName_Expression, typeof(string));

        if (table != null)
        {
            for (var columnIndex = 0; columnIndex < table.Columns.Count; columnIndex++)
            {
                var column = table.Columns[columnIndex];
                // Values are added in the order of column creation.
                columnInfoTable.Rows.Add(
                    columnIndex + 1,
                    column.ColumnName,
                    column.DataType.Name,
                    column.Expression);
            }
        }

        ColumnInfoDataGridView.Columns.Clear();
        ColumnInfoDataGridView.AutoGenerateColumns = true;
        ColumnInfoDataGridView.DataSource = columnInfoTable;
        ColumnInfoDataGridView.AutoResizeColumns();
    }

    #endregion

    #region SQL Server

    /// <summary>
    /// Handles the change of the source data table with respect to the <see cref="SqlServerToolsTabPage"/>.
    /// <para>This method saves the current configuration within the UI to the previously selected value and then
    /// restores the UI to the newly selected value.</para>
    /// </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void DataTableChangedSqlHandler(object sender, EventArgs e)
    {
        if (sender != null && !IsSqlConnected)
        {
            return;
        }

        var previousTableName = 0 switch
        {
            // Use the current value on an explicit save operation.
            _ when (sender?.ToString() == nameof(SaveSettings)) => DataTableComboBox.Text,
            // Disconnecting from current SQL connection - save the current value.
            _ when (sender == SQLConnectButton && e == null) => DataTableComboBox.Text,
            // Connecting to SQL - the selection did not change in this situation.
            _ when (sender == SQLConnectButton && e != null) => "",
            // Reset the selected data tabl - do not save the current data.
            _ when (sender == ResetSelectedConfigurationButton) => "",
            _ => PreviouslySelectedDataTableName,
        };

        // Save existing configuration for the previously selected table.
        if (!string.IsNullOrEmpty(previousTableName))
        {
            ActiveSqlTableSettings[previousTableName] = new SqlTableSettings()
            {
                TableName = previousTableName,
                ImportSource = SQLImportSourceTableRadioButton.Checked ? SqlImportSource.Table
                    : SQLImportSourceViewRadioButton.Checked ? SqlImportSource.View
                    : SQLImportSourceCustomRadioButton.Checked ? SqlImportSource.CustomSql
                    : SqlImportSource.Table,
                ImportSourceTableName = SQLImportSourceTableComboBox.Text,
                ImportSourceViewName = SQLImportSourceViewComboBox.Text,
                ImportSourceCustomSql = ToBase64((string)SQLImportSourceCustomButton.Tag),
                ExportSourceTargetName = SQLExportTargetComboBox.Text,
                ExportFieldMappings = GetCurrentFieldMappings().ToArray(),
                ExportSqlPreCommandEnabled = SQLExportPreEventCheckBox.Checked,
                ExportSqlPreCommand = ToBase64((string)SQLExportPreEventButton.Tag),
                ExportSqlPostCommandEnabled = SQLExportPostEventCheckBox.Checked,
                ExportSqlPostCommand = ToBase64((string)SQLExportPostEventButton.Tag),
            };
        }

        // Restore the configuration for the newly selected table.
        if (sender != null)
        {
            var restoreTableName = e == null ? DefaultSettingsKey : DataTableComboBox.Text;
            if (!ActiveSqlTableSettings.TryGetValue(restoreTableName, out var settings))
            {
                settings = new SqlTableSettings();
            }

            SQLImportSourceTableRadioButton.Checked = settings.ImportSource == SqlImportSource.Table;
            SQLImportSourceViewRadioButton.Checked = settings.ImportSource == SqlImportSource.View;
            SQLImportSourceCustomRadioButton.Checked = settings.ImportSource == SqlImportSource.CustomSql;
            SQLImportSourceTableComboBox.Text = settings.ImportSourceTableName;
            SQLImportSourceViewComboBox.Text = settings.ImportSourceViewName;
            SQLImportSourceCustomButton.Tag = FromBase64(settings.ImportSourceCustomSql);
            SQLExportTargetComboBox.Text = settings.ExportSourceTargetName;
            SQLExportPreEventCheckBox.Checked = settings.ExportSqlPreCommandEnabled;
            SQLExportPreEventButton.Tag = FromBase64(settings.ExportSqlPreCommand);
            SQLExportPostEventCheckBox.Checked = settings.ExportSqlPostCommandEnabled;
            SQLExportPostEventButton.Tag = FromBase64(settings.ExportSqlPostCommand);

            SQLExportFieldMappingListBox.Items.Clear();
            foreach (var fieldMapping in settings.ExportFieldMappings)
            {
                AddSqlFieldMappingEntry(fieldMapping);
            }
        }
    }

    /// <summary> Gets a value indicating whether SQL is currently connected. </summary>
    private bool IsSqlConnected => SQLConnectionStatusLabel.Text == Resources.Connected;

    /// <summary>
    /// Updates the <see cref="SqlServerToolsTabPage"/> based on the current value of <see cref="IsSqlConnected"/>.
    /// </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void SQLConnectionStatusLabel_TextChanged(object sender, EventArgs e)
    {
        if (IsSqlConnected)
        {
            SQLConnectionStringTextBox.ReadOnly = true;
            SQLConnectButton.Text = Resources.Disconnect;

            SQLImportDataGroupBox.Enabled = true;
            SQLExportDataGroupBox.Enabled = true;
        }
        else
        {
            SQLConnectionStringTextBox.ReadOnly = false;
            SQLConnectButton.Text = Resources.Connect;

            ClearSqlObjectSelections();
            SQLExportFieldMappingListBox.Items.Clear();

            SQLImportDataGroupBox.Enabled = false;
            SQLExportDataGroupBox.Enabled = false;
        }
    }

    /// <summary> Clears droplists which are sourced by SQL Server database objects. </summary>
    private void ClearSqlObjectSelections()
    {
        SQLImportSourceTableComboBox.Items.Clear();
        SQLImportSourceViewComboBox.Items.Clear();
        SQLExportTargetComboBox.Items.Clear();
    }

    /// <summary> Connects to SQL Server and performs a <see cref="SQLRefreshButton_Click"/> operation. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void SQLConnectButton_Click(object sender, EventArgs e)
    {
        if (IsSqlConnected)
        {
            // Capture what is current for the selected data table before disconnection.
            DataTableChangedSqlHandler(SQLConnectButton, null);

            SQLConnectionStatusLabel.Text = Resources.NotConnected;
            SQLRefreshButton.Enabled = false;
            return;
        }

        SQLRefreshButton_Click(SQLConnectButton, e);

        if (IsSqlConnected)
        {
            // Restore the configuration of the currently selected data table.
            DataTableChangedSqlHandler(SQLConnectButton, EventArgs.Empty);

            SQLRefreshButton.Enabled = true;
        }
    }

    /// <summary>
    /// Refreshes the available selection options from SQL Server using the provided connection string.
    /// </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void SQLRefreshButton_Click(object sender, EventArgs e)
    {
        try
        {
            ClearSqlObjectSelections();
            using var connection = GetSqlConnection();

            var tables = GetSingleStringData("SELECT [name] FROM sys.tables ORDER BY [name] ASC", connection);
            var views = GetSingleStringData("SELECT [name] FROM sys.views ORDER BY [name] ASC", connection);

            SQLImportSourceTableComboBox.Items.AddRange(tables);
            SQLImportSourceViewComboBox.Items.AddRange(views);
            SQLExportTargetComboBox.Items.AddRange(tables);

            SQLConnectionStatusLabel.Text = Resources.Connected;
        }
        catch (Exception ex)
        {
            ShowErrorMessage(this, ex.Message, SqlServerToolsTabPage.Text);
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
            instructions = string.Format(Resources.ImportStatementPromptInfo, DataTableLabel.Text);
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

            if (!ShowConfirmationPrompt(this, string.Format(Resources.SQLImportConfirmationPrompt, DataTableLabel.Text, SQLImportSourceGroupBox.Text), SQLImportDataGroupBox.Text))
            {
                return;
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

            var table = Document.GetTable(DataTableComboBox.Text, out _);
            if (AddMappingDialog.GetMapping(this, GetDataTableColumnNames(table), GetSqlTableColumnNames(SQLExportTargetComboBox.Text)) is { } mapping)
            {
                AddSqlFieldMappingEntry(mapping);
            }
        }
        catch (Exception ex)
        {
            ShowErrorMessage(this, ex.Message, SQLExportFieldMappingGroupBox.Text);
        }
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

    /// <summary> Gets all column names in the provided <paramref name="sqlTableName"/>. </summary>
    ///
    /// <param name="sqlTableName"> Name of the SQL table to get the columns for. </param>
    private string[] GetSqlTableColumnNames(string sqlTableName)
    {
        using var connection = GetSqlConnection();
        return GetSingleStringData($"SELECT sys.columns.[name] FROM sys.columns INNER JOIN sys.tables ON sys.columns.object_id=sys.tables.object_id WHERE sys.tables.[name]={SanitizeSqlText(sqlTableName)}", connection);
    }

    /// <summary> Gets a list of all column names from the provided <paramref name="table"/>. </summary>
    ///
    /// <param name="table"> The table get the columns information from. </param>
    private static string[] GetDataTableColumnNames(DataTable table)
    {
        return table?.Columns.Cast<DataColumn>()
            .Select(column => column.ColumnName)
            .ToArray();
    }

    /// <summary> Performs an export operation where a data table rows are copied to a SQL table. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void SQLExportExecuteButton_Click(object sender, EventArgs e)
    {
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

            var table = Document.GetTable(DataTableComboBox.Text, out _);
            var dataTableColumns = GetDataTableColumnNames(table);
            var sqlTableColumns = GetSqlTableColumnNames(SQLExportTargetComboBox.Text);
            var mappings = GetCurrentFieldMappings().ToArray();
            if (!mappings.Any())
            {
                throw new Exception(string.Format(Resources.NoEntriesDefinedError, SQLExportFieldMappingGroupBox.Text));
            }
            foreach (var fieldMapping in GetCurrentFieldMappings())
            {
                if (!dataTableColumns.Contains(fieldMapping.SourceFieldName))
                {
                    throw new Exception(string.Format(Resources.ExportColumnNotFoundError, fieldMapping.SourceFieldName, DataTableLabel.Text, DataTableComboBox.Text));
                }
                if (!sqlTableColumns.Contains(fieldMapping.TargetFieldName))
                {
                    throw new Exception(string.Format(Resources.ExportColumnNotFoundError, fieldMapping.TargetFieldName, SQLExportTargetLabel.Text, SQLExportTargetComboBox.Text));
                }
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

            var insertCommand = new SqlCommand("INSERT INTO"
                + $" {SanitizeSqlObject(SQLExportTargetComboBox.Text)} ({string.Join(",", mappings.Select(mapping => SanitizeSqlObject(mapping.TargetFieldName)))})"
                + $" VALUES ({string.Join(",", Enumerable.Range(0, mappings.Length).Select(i => "@Value" + i))})",
                connection, transaction);

            foreach (var row in table.Rows.Cast<DataRow>())
            {
                insertCommand.Parameters.Clear();
                for (var i = 0; i < mappings.Length; i++)
                {
                    insertCommand.Parameters.AddWithValue("@Value" + i, row[mappings[i].SourceFieldName]);
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

    /// <summary>
    /// Creates and opens a new SQL Server connection to the current value of <see cref="SQLConnectionStringTextBox"/>.
    /// </summary>
    private SqlConnection GetSqlConnection()
    {
        var connection = new SqlConnection(SQLConnectionStringTextBox.Text);
        connection.Open();
        return connection;
    }

    /// <summary> (Immutable) Delimiter used in field mappings to separate the source and destination column names. </summary>
    private const char FieldMappingDelimiter = '=';

    /// <summary>
    /// Gets the <see cref="TableFieldMapping"/> entries for the current items within <see cref="SQLExportFieldMappingListBox"/>.
    /// </summary>
    private IEnumerable<TableFieldMapping> GetCurrentFieldMappings()
    {
        return SQLExportFieldMappingListBox.Items.Cast<string>()
            .Select(text => (text + FieldMappingDelimiter).Split(FieldMappingDelimiter))
            .Select(mappingEntry => new TableFieldMapping()
            {
                SourceFieldName = mappingEntry[0],
                TargetFieldName = mappingEntry[1],
            });
    }

    /// <summary>
    /// Adds an entry for the provided <paramref name="mappingEntry"/> in <see cref="SQLExportFieldMappingListBox"/>.
    /// </summary>
    ///
    /// <param name="mappingEntry"> Data to create the entry for. </param>
    private void AddSqlFieldMappingEntry(TableFieldMapping mappingEntry)
    {
        var entryText = mappingEntry.SourceFieldName + FieldMappingDelimiter + mappingEntry.TargetFieldName;
        if (!SQLExportFieldMappingListBox.Items.Contains(entryText))
        {
            SQLExportFieldMappingListBox.Items.Add(entryText);
        }
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
        return [.. data];
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

    #region Reset Saved Data

    /// <summary> Prompts the user and deletes configuration information for the current data table. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void ResetSelectedConfigurationButton_Click(object sender, EventArgs e)
    {
        if (ShowConfirmationPrompt(this, string.Format(Resources.ResetSelectedDataTableConfigPrompt + $"\n{DataTableComboBox.Text}", DataTableLabel.Text)))
        {
            ActiveSqlTableSettings.Remove(DataTableComboBox.Text);
            DataTableChangedSqlHandler(ResetSelectedConfigurationButton, EventArgs.Empty);

            ShowNoticeMessage(this, Resources.OperationCompleted, ResetSelectedConfigurationButton.Text);
        }
    }

    /// <summary> Prompts the user and resets all configuration data for this tool. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void ResetEntireConfigurationButton_Click(object sender, EventArgs e)
    {
        if (ShowConfirmationPrompt(this, Resources.ResetEntireConfigPrompt))
        {
            DataTableComboBox.Text = null;
            LoadSettings(new Settings());
            DataTableChangedSqlHandler(ResetEntireConfigurationButton, EventArgs.Empty);

            ShowNoticeMessage(this, Resources.OperationCompleted, ResetEntireConfigurationButton.Text);
        }
    }

    #endregion
}
