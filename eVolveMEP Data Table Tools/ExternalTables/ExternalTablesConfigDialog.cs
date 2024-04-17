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

        Text = GetButtonTextWithNoLineBreaks(Resources.ExternalTablesButtonText);
        Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)System.Drawing.Image.FromStream(ExternalTablesConfigCommand.IconResource)).GetHicon());

        ViewSourceCodeLabel.Click += ViewSourceCodeHandler;

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
