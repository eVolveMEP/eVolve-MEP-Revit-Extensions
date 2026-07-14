// Copyright (c) 2026 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using System.Windows.Forms;

namespace eVolve.DataTableTools.Revit.ExternalTables;

/// <summary> Dialog for defining a <see cref="SqlServerSource"/>. </summary>
internal partial class SqlServerSourceDialog : System.Windows.Forms.Form
{
    /// <summary> Constructor. </summary>
    ///
    /// <param name="dialogTitle"> The dialog title. </param>
    /// <param name="source"> Source object to fill the user input fields with. </param>
    public SqlServerSourceDialog(string dialogTitle, SqlServerSource source)
    {
        InitializeComponent();

        this.PrepDialog(dialogTitle);

        ExternalTableSourceBaseControl.SetData(source);
        ConnectionStringTextBox.Text = source.ConnectionString.FromBase64();
        CommandTextBox.Text = source.CommandText.FromBase64();

        FormClosing += SqlServerSourceDialog_FormClosing;
    }

    /// <summary> Validates user input. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Form closing event information. </param>
    private void SqlServerSourceDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (DialogResult == DialogResult.OK && !e.Cancel)
        {
            var source = GetSource();
            e.Cancel = !ExternalTableSourceBaseControl.ValidateData(source,
            [
                (source.ConnectionString, ConnectionStringGroupBox.Text),
                (source.CommandText, CommandGroupBox.Text),
            ]);
        }
    }

    /// <summary> Opens the URL associated with the label. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void ConnectionStringHelpLabel_Click(object sender, EventArgs e) => Files.StartProcess(ConnectionStringHelpLabel.Tag.ToString());

    /// <summary> Returns a new <see cref="SqlServerSource"/> based on the current input. </summary>
    public SqlServerSource GetSource()
    {
        var data = ExternalTableSourceBaseControl.GetData<SqlServerSource>();
        data.ConnectionString = ConnectionStringTextBox.Text.Trim().ToBase64();
        data.CommandText = CommandTextBox.Text.ToBase64();
        return data;
    }
}
