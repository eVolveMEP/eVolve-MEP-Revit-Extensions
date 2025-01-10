// Copyright (c) 2025 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

extern alias eVolve;
using eVolve::eVolve.Core.Revit.Reporting;

namespace eVolve.DataTableTools.Revit.ViewTable;

/// <summary> Dialog for viewing <see cref="System.Data.DataTable"/>s. </summary>
internal partial class ViewTableDialog : System.Windows.Forms.Form
{
    /// <summary> The current Revit document. </summary>
    private Document Document { get; }

    /// <summary> Constructor. </summary>
    ///
    /// <param name="document"> <inheritdoc cref="Document" path="/summary"/> </param>
    public ViewTableDialog(Document document)
    {
        InitializeComponent();

        this.PrepDialog(Resources.ViewTableButtonText, ViewTableCommand.IconResource, ViewTableCommand.HelpLinkUrl, HelpLinkPictureBox,
            ViewSourceCodeLabel, ViewTableCommand.VideoUrl, VideoLinkPictureBox);

        Document = document;

        DataTableComboBox.Items.Clear();
        DataTableComboBox.Items.AddRange(Document.GetTableNames());
    }

    /// <summary> Updates the contents of <see cref="TableDataGridView"/> according to the user selection. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void DataTableComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        TableDataGridView.Columns.Clear();
        TableDataGridView.AutoGenerateColumns = true;

        if (!string.IsNullOrEmpty(DataTableComboBox.Text))
        {
            try
            {
                UseWaitCursor = true;
                System.Windows.Forms.Application.DoEvents();

                TableDataGridView.DataSource = Document.GetTable(DataTableComboBox.Text, out _);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(this, ex.Message);
            }
            finally
            {
                UseWaitCursor = false;
            }
        }

        TableDataGridView.Refresh();
    }

    /// <summary> Clears the <see cref="Document"/> cache and calls <see cref="DataTableComboBox_SelectedIndexChanged"/>. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void ClearCacheButton_Click(object sender, EventArgs e)
    {
        Document.ClearTableCache();
        DataTableComboBox_SelectedIndexChanged(DataTableComboBox, EventArgs.Empty);
    }
}
