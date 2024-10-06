// Copyright (c) 2024 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using System.ComponentModel;
using System.Windows.Forms;

namespace eVolve.DataTableTools.Revit.ExternalTables;

/// <summary> Dialog for defining a <see cref="ExcelSourceDialog"/>. </summary>
internal partial class ExcelSourceDialog : System.Windows.Forms.Form
{
    /// <summary> Backing data for <see cref="ColumnsDataGridView"/>. </summary>
    private BindingList<ExcelColumnInfo> Columns { get; } = [];

    /// <summary>
    /// Gets or sets the initial <see cref="ExcelSource"/> object which feeds this data.
    /// <para>This will be <see langword="null"/> after the form as loaded.</para>
    /// </summary>
    private ExcelSource InitialSource { get; set; }

    /// <summary> Constructor. </summary>
    ///
    /// <param name="dialogTitle"> The dialog title. </param>
    /// <param name="source"> Source object to fill the user input fields with. </param>
    public ExcelSourceDialog(string dialogTitle, ExcelSource source)
    {
        InitializeComponent();

        this.PrepDialog(dialogTitle);

        InitialSource = source;

        ExternalTableSourceBaseControl.SetData(source);
        FileTextBox.Text = source.FilePath;

        NameColumn.DataPropertyName = nameof(ExcelColumnInfo.Name);
        ExcludeColumn.DataPropertyName = nameof(ExcelColumnInfo.Exclude);
        DataTypeColumn.DataPropertyName = nameof(ExcelColumnInfo.DataType);
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
            var source = GetSource();
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
        const string FileExtension = ".xlsx";
        var fileFilter = Resources.ExcelFiles + $" (*{FileExtension})|*{FileExtension}";

        using var dialog = new OpenFileDialog();
        dialog.CheckFileExists = true;
        dialog.CheckPathExists = true;
        dialog.FileName = FileTextBox.Text;
        dialog.Filter = fileFilter;
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
        var currentConfig = InitialSource ?? GetSource();
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

        var headers = new Dictionary<string, int>();
        try
        {
            ExternalTablesMethods.ReadFromExcel(FileTextBox.Text, worksheet => headers = worksheet.GetHeaderIndexes());
        }
        catch (Exception ex)
        {
            ShowErrorMessage(this, ex.Message);
            return;
        }

        foreach (var header in headers)
        {
            var columnInfo = new ExcelColumnInfo() { Name = header.Key };
            columnInfo.Exclude = currentConfig.ExcludeColumnNames.Contains(columnInfo.Name);
            if (currentConfig.ColumnDataTypes.FirstOrDefault(dataType => dataType.ColumnName == columnInfo.Name) is { } dataTypeEntry)
            {
                columnInfo.DataType = dataTypeEntry.DataType;
            }
            Columns.Add(columnInfo);
        }
    }

    /// <summary> Returns a new <see cref="ExcelSource"/> based on the current input. </summary>
    public ExcelSource GetSource()
    {
        var data = ExternalTableSourceBaseControl.GetData<ExcelSource>();

        data.FilePath = FileTextBox.Text;

        data.ExcludeColumnNames = Columns
            .Where(column => column.Exclude)
            .Select(column => column.Name)
            .ToArray();

        data.ColumnDataTypes = Columns
            .Select(column => new ExcelColumnDataType()
            {
                ColumnName = column.Name,
                DataType = column.DataType,
            })
            .ToArray();

        return data;
    }


    /// <summary> Defines information for how a column should be handled when reading as a data source. </summary>
    private sealed class ExcelColumnInfo
    {
        /// <summary> Gets or sets the column name. </summary>
        public string Name { get; set; }

        /// <summary> Gets or sets a value indicating whether this column should be excluded from the table. </summary>
        public bool Exclude { get; set; }

        /// <summary> Gets or sets the type of the data this column holds. </summary>
        public string DataType { get; set; } = ColumnDataTypeLookup.Keys.First();
    }
}
