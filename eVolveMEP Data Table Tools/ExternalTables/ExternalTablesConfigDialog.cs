// Copyright (c) 2024 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using System.ComponentModel;
using System.Windows.Forms;

namespace eVolve.DataTableTools.Revit.ExternalTables;

/// <summary> Dialog for configuration of externally sourced data tables. </summary>
internal partial class ExternalTablesConfigDialog : System.Windows.Forms.Form
{
    /// <summary> Backing data for <see cref="ExcelDataGridView"/>. </summary>
    private BindingList<ExcelSource> ExcelSources { get; }

    /// <summary> Backing data for <see cref="SqlDataGridView"/>. </summary>
    private BindingList<SqlServerSource> SqlSources { get; }

    /// <summary> Default constructor. </summary>
    public ExternalTablesConfigDialog()
    {
        InitializeComponent();

        this.PrepDialog(Resources.ExternalTablesButtonText, ExternalTablesConfigCommand.IconResource, ExternalTablesConfigCommand.HelpLinkUrl, HelpLinkPictureBox, ViewSourceCodeLabel);

        var settings = ExternalTablesMethods.GetSettings();
        ExcelSources = new BindingList<ExcelSource>(settings.Excel.ToList());
        SqlSources = new BindingList<SqlServerSource>(settings.SqlServer.ToList());

        ConfigLocationLabel.Text = string.Format(ConfigLocationLabel.Text, ExternalTablesMethods.GetExternalTablesSettingsFilePath(out var isGlobal));
        GlobalConfigInfoLabel.Visible = isGlobal;

        foreach (var excelButton in new[] { ExcelNewButton, ExcelEditButton, ExcelDeleteButton })
        {
            excelButton.Click += (sender, _) =>
                GridHandlers(ExcelSources, ExcelDataGridView, (sender, ExcelNewButton, ExcelEditButton, ExcelDeleteButton),
                    source => new ExcelSourceDialog($"{((Button)sender).Text} {ExcelTabPage.Text}", source),
                    dialog => ((ExcelSourceDialog)dialog).GetSource());
        }

        foreach (var sqlButton in new[] { SqlNewButton, SqlEditButton, SqlDeleteButton })
        {
            sqlButton.Click += (sender, _) =>
                GridHandlers(SqlSources, SqlDataGridView, (sender, SqlNewButton, SqlEditButton, SqlDeleteButton),
                    source => new SqlServerSourceDialog($"{((Button)sender).Text} {SqlTabPage.Text}", source),
                    dialog => ((SqlServerSourceDialog)dialog).GetSource());
        }

        FormClosed += ExternalTablesConfigDialog_FormClosed;
    }

    /// <summary> Binds sources to their respective display grids. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void ExternalTablesConfigDialog_Load(object sender, EventArgs e)
    {
        foreach (var grid in new[] { ExcelDataGridView, SqlDataGridView })
        {
            grid.AutoGenerateColumns = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
        }

        ExcelDataGridView.DataSource = ExcelSources;
        ExcelNameColumn.DataPropertyName = nameof(ExcelSource.Name);
        ExcelDescriptoinColumn.DataPropertyName = nameof(ExcelSource.Description);
        ExcelCachedColumn.DataPropertyName = nameof(ExcelSource.Cache);
        ExcelFilePathColumn.DataPropertyName = nameof(ExcelSource.FilePath);

        SqlDataGridView.DataSource = SqlSources;
        SqlNameColumn.DataPropertyName = nameof(SqlServerSource.Name);
        SqlDescriptionColumn.DataPropertyName = nameof(SqlServerSource.Description);
        SqlCachedColumn.DataPropertyName = nameof(SqlServerSource.Cache);
    }

    /// <summary> Applies settings as required based on the <see cref="System.Windows.Forms.Form.DialogResult"/>. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Form closed event information. </param>
    private void ExternalTablesConfigDialog_FormClosed(object sender, FormClosedEventArgs e)
    {
        if (DialogResult == DialogResult.OK)
        {
            ApplyButton_Click(ApplyButton, EventArgs.Empty);
        }
    }

    /// <summary> <inheritdoc cref="ExternalTablesMethods.ApplySettings" path="/summary"/> </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void ApplyButton_Click(object sender, EventArgs e)
    {
        ExternalTablesMethods.ApplySettings(new ExternalTablesSettings()
        {
            Excel = ExcelSources.ToArray(),
            SqlServer = SqlSources.ToArray(),
        });
    }

    /// <summary> Handles the processing of button actions for <see cref="ExternalTableSourceBase"/> grids. </summary>
    ///
    /// <typeparam name="T"> Concrete implementation of <see cref="ExternalTableSourceBase"/>. </typeparam>
    /// <param name="sources"> List of all <typeparamref name="T"/> records. </param>
    /// <param name="grid"> Grid which <paramref name="sources"/> is bound to. </param>
    /// <param name="buttons"> Processing buttons, including the event sender. </param>
    /// <param name="createSourceDialog"> Creates a new instance of a dialog used to edit <typeparamref name="T"/> records. </param>
    /// <param name="getSourceDataFromDialog"> Provided the result of <paramref name="createSourceDialog"/>, returns a <typeparamref name="T"/>
    ///     for the data entered by the user. </param>
    private void GridHandlers<T>(BindingList<T> sources, DataGridView grid, (object Sender, Button New, Button Edit, Button Delete) buttons,
        Func<T, System.Windows.Forms.Form> createSourceDialog, Func<System.Windows.Forms.Form, T> getSourceDataFromDialog)
        where T : ExternalTableSourceBase, new()
    {
        T source = null;
        Action<T> onSuccess = null;
        if (buttons.Sender == buttons.New)
        {
            source = new T();
            onSuccess = sources.Add;
        }
        else if (buttons.Sender == buttons.Edit)
        {
            source = grid.CurrentRow?.DataBoundItem as T;
            onSuccess = updatedSource => sources[sources.IndexOf(source)] = updatedSource;
        }
        else if (buttons.Sender == buttons.Delete)
        {
            if (grid.CurrentRow?.DataBoundItem is T toDelete)
            {
                sources.Remove(toDelete);
            }
        }

        if (source != null)
        {
            using var sourceDialog = createSourceDialog(source);
            if (sourceDialog.ShowDialog(this) == DialogResult.OK)
            {
                onSuccess(getSourceDataFromDialog(sourceDialog));
            }
        }

        grid.Refresh();
    }
}
