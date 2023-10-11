// Copyright (c) 2023 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using System.Windows.Forms;

namespace eVolve.DataTableTools.Revit;

/// <summary>
/// Dialog for prompting to create a mapping between a data table and a SQL table.
/// <para>Consume via <see cref="GetMapping"/>.</para>
/// </summary>
internal sealed partial class AddMappingDialog : System.Windows.Forms.Form
{
    /// <summary>
    /// Prompts the user with the <see cref="AddMappingDialog"/> and returns the result. If the user cancels, the default
    /// value is returned.
    /// </summary>
    ///
    /// <param name="owner"> Owner of this dialog. </param>
    /// <param name="dataTableFieldNames"> List of column names available within the source data table. </param>
    /// <param name="sqlTableColumnNames"> List of column names available within the destination SQL table. </param>
    public static (string DataTableColumnName, string SQLTableColumnName) GetMapping(System.Windows.Forms.Form owner, IEnumerable<string> dataTableFieldNames, IEnumerable<string> sqlTableColumnNames)
    {
        using var dialog = new AddMappingDialog();
        dialog.Owner = owner;
        dialog.Icon = owner.Icon;

        dialog.DataTableColumnComboBox.Items.Clear();
        dialog.DataTableColumnComboBox.Items.AddRange(dataTableFieldNames.OrderBy(name => name).ToArray());
        dialog.SQLTableColumnComboBox.Items.Clear();
        dialog.SQLTableColumnComboBox.Items.AddRange(sqlTableColumnNames.OrderBy(name => name).ToArray());

        return dialog.ShowDialog(owner) == DialogResult.OK ? (dialog.DataTableColumnComboBox.Text, dialog.SQLTableColumnComboBox.Text) : default;
    }

    /// <summary> Constructor that prevents a default instance of this class from being created. </summary>
    private AddMappingDialog()
    {
        InitializeComponent();

        this.FormClosing += AddMappingDialog_FormClosing;
    }

    /// <summary> Validates input when the user has accepted the dialog. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Form closing event information. </param>
    private void AddMappingDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (DialogResult == DialogResult.OK
            && (string.IsNullOrEmpty(DataTableColumnComboBox.Text) || string.IsNullOrEmpty(SQLTableColumnComboBox.Text)))
        {
            MessageBox.Show(this, $"A value must be provided for '{DataTableColumnGroupBox.Text}' and '{SQLTableColumnGroupBox.Text}'.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;
        }
    }
}
