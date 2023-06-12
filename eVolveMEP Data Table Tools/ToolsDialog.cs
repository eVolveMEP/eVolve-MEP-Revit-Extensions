// Copyright (c) 2023 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

extern alias eVolve;
using eVolve::eVolve.Core.Revit.Reporting;
using eVolve.ExtensionsCommon.Revit;
using System.Data;
using System.Windows.Forms;

namespace eVolve.DataTableTools.Revit;

/// <summary> Dialog for handling all operations. </summary>
internal sealed partial class ToolsDialog : System.Windows.Forms.Form
{
    /// <summary> Gets the current Revit document. </summary>
    private Document Document { get; }

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

        ChangeColumnTypeDataTypeComboBox.Items.Clear();
        ChangeColumnTypeDataTypeComboBox.Items.AddRange(new[]
        {
            nameof(String),
            nameof(Int32),
            nameof(Int64),
            nameof(Double),
            nameof(Decimal),
            nameof(Boolean),
        });

        this.FormClosing += ToolsDialog_FormClosing;
        this.HelpRequested += ToolsDialog_HelpRequested;
    }

    /// <summary> Loads saved configuration values into the editors. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void ToolsDialog_Load(object sender, EventArgs e)
    {
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
    private static string SettingsFilePath { get; } = System.IO.Path.Combine(Methods.BaseSaveSettingsFileFolder, "Data Table Tools", "Settings.xml");

    /// <summary>
    /// Saves the saved options from <see cref="SettingsFilePath"/> into the form. If an error occurs, the user is notified.
    /// </summary>
    private void LoadSettings()
    {
        if (Methods.LoadSettings<Settings>(SettingsFilePath) is { } settings)
        {
            SQLConnectionStringTextBox.Text = settings.SqlConnectionString;
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
        };

        Methods.SaveSettings(settings, SettingsFilePath);
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
            var table = Document.GetTable(DataTableComboBox.Text, out _);

            ChangeColumnTypeColumnComboBox.Items.AddRange(table.Columns.Cast<DataColumn>().OrderBy(name => name).ToArray());
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, DataTableLabel.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    #region Column Tools

    /// <summary> Performs a column data type change based on user provided input. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void ChangeColumnTypeButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(ChangeColumnTypeColumnComboBox.Text) || string.IsNullOrEmpty(ChangeColumnTypeDataTypeComboBox.Text))
        {
            MessageBox.Show(this, $"A value must be provided for '{ChangeColumnTypeColumnLabel.Text}' and '{ChangeColumnTypeDataTypeLabel.Text}'.", ChangeColumnTypeGroupBox.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            var table = Document.GetTable(DataTableComboBox.Text, out var metadata);
            var clone = table.Clone();

            Type newType;
            Func<object, object> convertToNewType;
            var conversionFailedAtLeastOnce = false;
            switch (ChangeColumnTypeDataTypeComboBox.Text)
            {
                case nameof(String):
                    newType = typeof(string);
                    convertToNewType = existing => existing.ToString();
                    break;
                case nameof(Int32):
                    newType = typeof(int);
                    convertToNewType = existing =>
                    {
                        conversionFailedAtLeastOnce |= !int.TryParse(existing.ToString(), out var value);
                        return value;
                    };
                    break;
                case nameof(Int64):
                    newType = typeof(long);
                    convertToNewType = existing =>
                    {
                        conversionFailedAtLeastOnce |= !long.TryParse(existing.ToString(), out var value);
                        return value;
                    };
                    break;
                case nameof(Double):
                    newType = typeof(double);
                    convertToNewType = existing =>
                    {
                        conversionFailedAtLeastOnce |= !double.TryParse(existing.ToString(), out var value);
                        return value;
                    };
                    break;
                case nameof(Decimal):
                    newType = typeof(decimal);
                    convertToNewType = existing =>
                    {
                        conversionFailedAtLeastOnce |= !decimal.TryParse(existing.ToString(), out var value);
                        return value;
                    };
                    break;
                case nameof(Boolean):
                    newType = typeof(bool);
                    convertToNewType = existing =>
                    {
                        conversionFailedAtLeastOnce |= !bool.TryParse(existing.ToString(), out var value);
                        return value;
                    };
                    break;
                default:
                    throw new Exception(ChangeColumnTypeDataTypeComboBox.Text);
            }

            var sourceColumnIndex = table.Columns.IndexOf(ChangeColumnTypeColumnComboBox.Text);
            clone.Columns[ChangeColumnTypeColumnComboBox.Text].DataType = newType;

            foreach (var row in table.Rows.Cast<DataRow>())
            {
                var newRow = clone.Rows.Add();
                for (var i = 0; i < table.Columns.Count; i++)
                {
                    newRow[i] = i == sourceColumnIndex ? convertToNewType(row[i]) : row[i];
                }
            }

            Document.SaveTable(table.TableName, null, false, clone, metadata);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, ChangeColumnTypeGroupBox.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    #endregion

    #region SQL Server

    #endregion
}
