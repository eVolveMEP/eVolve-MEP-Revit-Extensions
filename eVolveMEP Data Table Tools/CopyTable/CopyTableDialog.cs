// Copyright (c) 2025 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

extern alias eVolve;
using eVolve::eVolve.Core.Revit.Reporting;

namespace eVolve.DataTableTools.Revit.CopyTable;

/// <summary> Dialog for copying an existing data table into the current model. </summary>
internal partial class CopyTableDialog : System.Windows.Forms.Form
{
    /// <summary> The current Revit document. </summary>
    private Document Document { get; }

    /// <summary> Constructor. </summary>
    ///
    /// <param name="document"> <inheritdoc cref="Document" path="/summary"/> </param>
    public CopyTableDialog(Document document)
    {
        InitializeComponent();

        this.PrepDialog(Resources.CopyDataTableButtonText, CopyTableCommand.IconResource, CopyTableCommand.HelpLinkUrl, HelpLinkPictureBox,
            ViewSourceCodeLabel, CopyTableCommand.VideoUrl, VideoLinkPictureBox);

        Document = document;

        InfoLabel.Text = string.Format(InfoLabel.Text, SourceDataTableLabel.Text, DestinationDataTableLabel.Text);

        RefreshDataTables();
    }

    /// <summary> Refreshes the selection of available data tables. </summary>
    private void RefreshDataTables()
    {
        SourceDataTableComboBox.Items.Clear();
        SourceDataTableComboBox.Items.AddRange(Document.GetTableNames());
        SourceDataTableComboBox.Text = "";

        DestinationDataTableComboBox.Items.Clear();
        DestinationDataTableComboBox.Items.AddRange(Document.GetTableNames(includeExternalTables: false));
        DestinationDataTableComboBox.Text = "";
    }

    /// <summary> Opens the Data Tables configuration dialog and refreshes available selections. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void OpenConfigurationPictureBox_Click(object sender, EventArgs e)
    {
        Document.OpenTablesConfigurationDialog();

        // Refresh the data tables list, preserving the existing selection if possible.
        var currentSourceTableSelection = SourceDataTableComboBox.Text;
        var currentDestinationTableSelection = DestinationDataTableComboBox.Text;

        RefreshDataTables();
        if (SourceDataTableComboBox.Items.Contains(currentSourceTableSelection))
        {
            SourceDataTableComboBox.Text = currentSourceTableSelection;
        }
        DestinationDataTableComboBox.Text = currentDestinationTableSelection;
    }

    /// <summary> Performs the copy operation between the source and destination. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void CopyButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(SourceDataTableComboBox.Text) || string.IsNullOrEmpty(DestinationDataTableComboBox.Text))
            {
                throw new Exception(string.Format(Resources.ValueMustBeProvided2Error, SourceDataTableLabel.Text, DestinationDataTableLabel.Text));
            }

            UseWaitCursor = true;
            System.Windows.Forms.Application.DoEvents();

            var table = Document.GetTable(SourceDataTableComboBox.Text, out var metadata);
            Document.SaveTable(DestinationDataTableComboBox.Text, null, ReadOnlyCheckBox.Checked, table, metadata);

            ShowNoticeMessage(this, Resources.OperationCompleted);

            RefreshDataTables();
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
}