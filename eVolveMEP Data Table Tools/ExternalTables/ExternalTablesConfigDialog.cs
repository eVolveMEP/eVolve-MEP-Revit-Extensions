// Copyright (c) 2026 eVolve MEP, LLC
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
    /// <summary> Gets the current Revit document. </summary>
    private Document Document { get; }

    /// <summary> Backing data for <see cref="ExcelDataGridView"/>. </summary>
    private BindingList<ExcelSource> ExcelSources { get; }

    /// <summary> Backing data for <see cref="CsvDataGridView"/>. </summary>
    private BindingList<CsvSource> CsvSources { get; }

    /// <summary> Backing data for <see cref="SqlDataGridView"/>. </summary>
    private BindingList<SqlServerSource> SqlSources { get; }

    /// <summary> Backing data for <see cref="DataTableDataGridView"/>. </summary>
    private BindingList<SerializedDataTableSource> DataTableSources { get; }

    /// <summary> Default constructor. </summary>
    ///
    /// <param name="document"> The current Revit document. </param>
    public ExternalTablesConfigDialog(Document document)
    {
        InitializeComponent();

        Document = document;

        this.PrepDialog(Resources.ExternalTablesButtonText, ExternalTablesConfigCommand.IconResource,
            ExternalTablesConfigCommand.HelpLinkUrl, HelpLinkPictureBox, ExternalTablesConfigCommand.VideoUrl, VideoLinkPictureBox, ViewSourceCodeLabel);

        var settings = ExternalTablesMethods.GetSettings(ExternalTablesMethods.GetExternalTablesSettingsFilePath(out _));
        var globalSettings = ExternalTablesMethods.GetSettings(ExternalTablesMethods.ExternalTablesGlobalSettingsFilePath);
        ExcelSources = [.. settings.Excel, .. globalSettings.Excel];
        CsvSources = [.. settings.Csv, .. globalSettings.Csv];
        SqlSources = [.. settings.SqlServer, .. globalSettings.SqlServer];
        DataTableSources = [.. settings.SerializedDataTables, .. globalSettings.SerializedDataTables];

        ConfigLocationLabel.Text = string.Format(ConfigLocationLabel.Text, ExternalTablesMethods.GetExternalTablesSettingsFilePath(out var isStandard));
        CommonConfigInfoLabel.Visible = isStandard;

        GlobalConfigLocationLabel.Text = string.Format(GlobalConfigLocationLabel.Text, ExternalTablesMethods.ExternalTablesGlobalSettingsFilePath);

        foreach (var excelButton in new[] { ExcelNewButton, ExcelEditButton, ExcelDeleteButton })
        {
            static (Dictionary<string, int>, string[]) getFileData(string file, string sheetName)
            {
                var headers = new Dictionary<string, int>();
                var sheetNames = Array.Empty<string>();
                ExternalTablesMethods.ReadFromExcel(file, sheetName,
                    worksheet => headers = worksheet.GetHeaderIndexes(),
                    workbook => sheetNames = Enumerable.Range(1, workbook.WorksheetCount).Select(i => workbook.GetWorksheet(i).Name).ToArray()
                    );
                return (headers, sheetNames);
            }

            excelButton.Click += (sender, _) =>
                GridHandlers(ExcelSources, ExcelDataGridView, (sender, ExcelNewButton, ExcelEditButton, ExcelDeleteButton),
                    source => new TabularSourceDialog($"{((Button)sender).Text} {ExcelTabPage.Text}", source, Resources.ExcelFiles + string.Format(" (*{0})|*{0}", ".xlsx"), getFileData),
                    dialog => ((TabularSourceDialog)dialog).GetSource<ExcelSource>());
        }

        foreach (var csvButton in new[] { CsvNewButton, CsvEditButton, CsvDeleteButton })
        {
            csvButton.Click += (sender, _) =>
                GridHandlers(CsvSources, CsvDataGridView, (sender, CsvNewButton, CsvEditButton, CsvDeleteButton),
                    source => new TabularSourceDialog($"{((Button)sender).Text} {CsvTabPage.Text}", source, Resources.CsvFiles + string.Format(" (*{0})|*{0}", ".csv"), (file, _) => (CsvTableSource.GetHeaders(file), [])),
                    dialog => ((TabularSourceDialog)dialog).GetSource<CsvSource>());
        }

        foreach (var sqlButton in new[] { SqlNewButton, SqlEditButton, SqlDeleteButton })
        {
            sqlButton.Click += (sender, _) =>
                GridHandlers(SqlSources, SqlDataGridView, (sender, SqlNewButton, SqlEditButton, SqlDeleteButton),
                    source => new SqlServerSourceDialog($"{((Button)sender).Text} {SqlTabPage.Text}", source),
                    dialog => ((SqlServerSourceDialog)dialog).GetSource());
        }

        foreach (var datatableButton in new[] { DataTableNewButton, DataTableEditButton, DataTableDeleteButton })
        {
            datatableButton.Click += (sender, _) =>
                GridHandlers(DataTableSources, DataTableDataGridView, (sender, DataTableNewButton, DataTableEditButton, DataTableDeleteButton),
                    source => new DataTableSourceDialog(Document, $"{((Button)sender).Text} {DataTableTabPage.Text}", source),
                    dialog => ((DataTableSourceDialog)dialog).GetSource());
        }

        FormClosed += ExternalTablesConfigDialog_FormClosed;
    }

    /// <summary> Binds sources to their respective display grids. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void ExternalTablesConfigDialog_Load(object sender, EventArgs e)
    {
        foreach (var grid in new[] { ExcelDataGridView, CsvDataGridView, SqlDataGridView, DataTableDataGridView })
        {
            grid.AutoGenerateColumns = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
        }

        ExcelDataGridView.DataSource = ExcelSources;
        ExcelNameColumn.DataPropertyName = nameof(ExcelSource.Name);
        ExcelDescriptionColumn.DataPropertyName = nameof(ExcelSource.Description);
        ExcelCachedColumn.DataPropertyName = nameof(ExcelSource.Cache);
        ExcelFilePathColumn.DataPropertyName = nameof(ExcelSource.FilePathConsumable);
        ExcelSheetNameColumn.DataPropertyName = nameof(ExcelSource.SheetName);
        ExcelGlobalColumn.DataPropertyName = nameof(ExcelSource.Global);

        CsvDataGridView.DataSource = CsvSources;
        CsvNameColumn.DataPropertyName = nameof(CsvSource.Name);
        CsvDescriptionColumn.DataPropertyName = nameof(CsvSource.Description);
        CsvCachedColumn.DataPropertyName = nameof(CsvSource.Cache);
        CsvFilePathColumn.DataPropertyName = nameof(CsvSource.FilePathConsumable);
        CsvGlobalColumn.DataPropertyName = nameof(CsvSource.Global);

        SqlDataGridView.DataSource = SqlSources;
        SqlNameColumn.DataPropertyName = nameof(SqlServerSource.Name);
        SqlDescriptionColumn.DataPropertyName = nameof(SqlServerSource.Description);
        SqlCachedColumn.DataPropertyName = nameof(SqlServerSource.Cache);
        SqlGlobalColumn.DataPropertyName = nameof(SqlServerSource.Global);

        DataTableDataGridView.DataSource = DataTableSources;
        DataTableNameColumn.DataPropertyName = nameof(SerializedDataTableSource.Name);
        DataTableDescriptionColumn.DataPropertyName = nameof(SerializedDataTableSource.Description);
        DataTableCachedColumn.DataPropertyName = nameof(SerializedDataTableSource.Cache);
        DataTableFilePathColumn.DataPropertyName = nameof(SerializedDataTableSource.FilePathConsumable);
        DataTableGlobalColumn.DataPropertyName = nameof(SerializedDataTableSource.Global);
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
            Csv = CsvSources.ToArray(),
            SqlServer = SqlSources.ToArray(),
            SerializedDataTables = DataTableSources.ToArray(),
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
            if (grid.CurrentRow?.DataBoundItem is T { Global: false } toDelete)
            {
                sources.Remove(toDelete);
            }
        }

        if (source != null)
        {
            if (source.Global)
            {
                ShowNoticeMessage(this, Resources.GlobalConfigurationWillNotBeSavedNotice);
            }

            using var sourceDialog = createSourceDialog(source);
            if (sourceDialog.ShowDialog(this) == DialogResult.OK && !source.Global)
            {
                onSuccess(getSourceDataFromDialog(sourceDialog));
            }
        }

        grid.Refresh();
    }
}
