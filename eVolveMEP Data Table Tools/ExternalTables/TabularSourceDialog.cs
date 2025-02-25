// Copyright (c) 2024 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using System.ComponentModel;
using System.Windows.Forms;

namespace eVolve.DataTableTools.Revit.ExternalTables;

/// <summary> Dialog for defining a data source derived from <see cref="TabularSourceBase"/>. </summary>
internal partial class TabularSourceDialog : System.Windows.Forms.Form
{
    /// <summary> Backing data for <see cref="ColumnsDataGridView"/>. </summary>
    private BindingList<TabularColumnInfo> Columns { get; } = [];

    /// <summary>
    /// Gets or sets the initial source object which feeds this data.
    /// <para>This will be <see langword="null"/> after the form as loaded.</para>
    /// </summary>
    private TabularSourceBase InitialSource { get; set; }

    /// <summary> File browse dialog selection filter. </summary>
    private string FileFilter { get; }

    /// <summary>
    /// Function which takes in a file path and returns a lookup of column header text (key) and column index (value).
    /// </summary>
    private Func<string, Dictionary<string, int>> GetHeaderColumns { get; }

    /// <summary> Constructor. </summary>
    ///
    /// <param name="dialogTitle"> The dialog title. </param>
    /// <param name="source"> Source object to fill the user input fields with. </param>
    /// <param name="fileFilter"> <inheritdoc cref="FileFilter" path="/summary"/></param>
    /// <param name="getHeaderColumns"> <inheritdoc cref="GetHeaderColumns" path="/summary"/></param>
    public TabularSourceDialog(string dialogTitle, TabularSourceBase source, string fileFilter, Func<string, Dictionary<string, int>> getHeaderColumns)
    {
        InitializeComponent();

        this.PrepDialog(dialogTitle);

        InitialSource = source;
        FileFilter = fileFilter;
        GetHeaderColumns = getHeaderColumns;

        ExternalTableSourceBaseControl.SetData(source);
        FileTextBox.Text = source.FilePath;

        NameColumn.DataPropertyName = nameof(TabularColumnInfo.Name);
        ExcludeColumn.DataPropertyName = nameof(TabularColumnInfo.Exclude);
        DataTypeColumn.DataPropertyName = nameof(TabularColumnInfo.DataType);
        DataTypeColumn.DataSource = ColumnDataTypeLookup.ToArray();
        DataTypeColumn.ValueMember = "Key";
        DataTypeColumn.DisplayMember = "Key";

        ColumnsDataGridView.DataSource = Columns;

        Load += (_, _) =>
        {
            RefreshButton_Click(RefreshButton, EventArgs.Empty);
            InitialSource = null;
        };
        FormClosing += ExcelSourceDialog_FormClosing;
        FileTextBox.Validated += RefreshButton_Click;
    }

    /// <summary> Validates user input. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Form closing event information. </param>
    private void ExcelSourceDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (DialogResult == DialogResult.OK && !e.Cancel)
        {
            var source = GetSource<TabularSourceBase>();
            e.Cancel = !ExternalTableSourceBaseControl.ValidateData(source,
            [
                (source.FilePath, FileGroupBox.Text),
            ]);
        }
    }

    /// <summary> Prompts the user to select a source Excel file. </summary>
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
            RefreshButton_Click(sender, EventArgs.Empty);
        }
    }

    /// <summary> Reloads column information from the currently specified Excel file. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void RefreshButton_Click(object sender, EventArgs e)
    {
        var currentConfig = InitialSource ?? GetSource<TabularSourceBase>();
        Columns.Clear();

        if (string.IsNullOrWhiteSpace(FileTextBox.Text))
        {
            return;
        }
        if (!System.IO.File.Exists(FileTextBox.Text))
        {
            ShowErrorMessage(this, Resources.ExcelFileNotFoundError);
            return;
        }

        Dictionary<string, int> headers;
        try
        {
            headers = GetHeaderColumns(FileTextBox.Text);
        }
        catch (Exception ex)
        {
            ShowErrorMessage(this, ex.Message);
            return;
        }

        foreach (var header in headers)
        {
            var columnInfo = new TabularColumnInfo() { Name = header.Key };
            columnInfo.Exclude = currentConfig.ExcludeColumnNames.Contains(columnInfo.Name);
            if (currentConfig.ColumnDataTypes.FirstOrDefault(dataType => dataType.ColumnName == columnInfo.Name) is { } dataTypeEntry)
            {
                columnInfo.DataType = dataTypeEntry.DataType;
            }
            Columns.Add(columnInfo);
        }
    }

    /// <summary> Returns a new <typeparamref name="T"/> based on the current input. </summary>
    ///
    /// <typeparam name="T"> Concrete implementation of <see cref="TabularSourceBase"/> which this form represents. </typeparam>
    public T GetSource<T>() where T : TabularSourceBase, new()
    {
        var data = ExternalTableSourceBaseControl.GetData<T>();

        data.FilePath = FileTextBox.Text;

        data.ExcludeColumnNames = Columns
            .Where(column => column.Exclude)
            .Select(column => column.Name)
            .ToArray();

        data.ColumnDataTypes = Columns
            .Select(column => new TabularColumnDataType()
            {
                ColumnName = column.Name,
                DataType = column.DataType,
            })
            .ToArray();

        return data;
    }


    /// <summary> Defines information for how a column should be handled when reading as a data source. </summary>
    private sealed class TabularColumnInfo
    {
        /// <summary> Gets or sets the column name. </summary>
        public string Name { get; set; }

        /// <summary> Gets or sets a value indicating whether this column should be excluded from the table. </summary>
        public bool Exclude { get; set; }

        /// <summary> Gets or sets the type of the data this column holds. </summary>
        public string DataType { get; set; } = ColumnDataTypeLookup.Keys.First();
    }
}
