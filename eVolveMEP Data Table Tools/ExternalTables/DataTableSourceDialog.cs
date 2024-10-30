// Copyright (c) 2024 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

extern alias eVolve;
using System.Windows.Forms;

namespace eVolve.DataTableTools.Revit.ExternalTables;

/// <summary> Dialog for defining a <see cref="SerializedDataTableSource"/>. </summary>
internal sealed partial class DataTableSourceDialog : System.Windows.Forms.Form
{
    /// <summary> (Immutable) File extension for serialized data table files. </summary>
    private const string FileExtension = ".edt";

    /// <summary> Gets the file filter to use in open/save dialogs. </summary>
    private static string FileFilter => Resources.SerializedDataTableFiles + $" (*{FileExtension})|*{FileExtension}";

    /// <summary> Gets the current Revit document. </summary>
    private Document Document { get; }

    /// <summary> Constructor. </summary>
    ///
    /// <param name="document"> The current Revit document. </param>
    /// <param name="dialogTitle"> The dialog title. </param>
    /// <param name="source"> Source object to fill the user input fields with. </param>
    public DataTableSourceDialog(Document document, string dialogTitle, SerializedDataTableSource source)
    {
        InitializeComponent();

        Document = document;

        this.PrepDialog(dialogTitle);

        ExternalTableSourceBaseControl.SetData(source);
        FileTextBox.Text = source.FilePath;

        FileInfoLabel.Text = string.Format(FileInfoLabel.Text, SerializeDataTableGroupBox.Text);

        SerializeDataTableComboBox.Items.Clear();
        SerializeDataTableComboBox.Items.AddRange(eVolve::eVolve.Core.Revit.Reporting.API.GetTableNames(Document).Prepend("").ToArray());

        FormClosing += DataTableSourceDialog_FormClosing;
    }

    /// <summary> Validates user input. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Form closing event information. </param>
    private void DataTableSourceDialog_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
        if (DialogResult == DialogResult.OK && !e.Cancel)
        {
            var source = GetSource();
            e.Cancel = !ExternalTableSourceBaseControl.ValidateData(source,
            [
                (source.FilePath, FileGroupBox.Text),
            ]);
        }
    }

    /// <summary> Prompts the user to select a source file. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void FileBrowseButton_Click(object sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog();
        dialog.CheckFileExists = true;
        dialog.CheckPathExists = true;
        dialog.FileName = FileTextBox.Text;
        dialog.Filter = FileFilter;
        dialog.Title = FileGroupBox.Text;
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            FileTextBox.Text = dialog.FileName;
        }
    }

    /// <summary> Serialized the selected <see cref="SerializeDataTableComboBox"/> entry to a file. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void SerializeDataTableButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(SerializeDataTableComboBox.Text))
        {
            return;
        }

        using var dialog = new SaveFileDialog();
        dialog.OverwritePrompt = true;
        dialog.FileName = $"{SerializeDataTableComboBox.Text}{FileExtension}";
        dialog.Filter = FileFilter;
        dialog.Title = SerializeDataTableGroupBox.Text;
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            DataTableSource.SaveDataTableToFile(eVolve::eVolve.Core.Revit.Reporting.API.GetTable(Document, SerializeDataTableComboBox.Text, out _), dialog.FileName);
            ShowNoticeMessage(this, Resources.OperationCompleted, SerializeDataTableGroupBox.Text);
        }
    }

    /// <summary> Returns a new <see cref="SerializedDataTableSource"/> based on the current input. </summary>
    public SerializedDataTableSource GetSource()
    {
        var data = ExternalTableSourceBaseControl.GetData<SerializedDataTableSource>();
        data.FilePath = FileTextBox.Text;
        return data;
    }
}
