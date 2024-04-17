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

    /// <summary> Constructor. </summary>
    ///
    /// <param name="dialogTitle"> The dialog title. </param>
    /// <param name="source"> Source object to fill the user input fields with. </param>
    public ExcelSourceDialog(string dialogTitle, ExcelSource source)
    {
        InitializeComponent();

        Text = dialogTitle;

        ExternalTableSourceBaseControl.SetData(source);

        NameColumn.DataPropertyName = nameof(ExcelColumnInfo.Name);
        DataTypeColumn.DataPropertyName = nameof(ExcelColumnInfo.DataType);
        IncludeColumn.DataPropertyName = nameof(ExcelColumnInfo.Include);
        ExcludeColumn.DataPropertyName = nameof(ExcelColumnInfo.Exclude);

        ColumnsDataGridView.DataSource = Columns;

        Load += (_, _) => RefreshButton_Click(RefreshButton, EventArgs.Empty);
        FormClosing += ExcelSourceDialog_FormClosing;
        FileTextBox.TextChanged += RefreshButton_Click;
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
            e.Cancel = ExternalTableSourceBaseControl.ValidateData(source,
                new[]
                {
                    (source.FilePath, FileGroupBox.Text),
                });
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
        }
    }

    /// <summary> Reloads column information from the currently specified Excel file. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void RefreshButton_Click(object sender, EventArgs e)
    {
        var currentConfig = GetSource();
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
            using var excel = new ExcelWrapper.Excel();
            var workbook = excel.OpenWorkbook(FileTextBox.Text);
            var worksheet = workbook.GetWorksheet(1);
            headers = worksheet.GetHeaderIndexes();
            excel.Close();
        }
        catch (Exception ex)
        {
            ShowErrorMessage(this, Resources.ReadingExcelFileError + "\n\n" + ex.Message);
            return;
        }

        foreach (var header in headers)
        {
            var columnInfo = new ExcelColumnInfo() { Name = header.Key };
            columnInfo.Include = !currentConfig.IncludeColumnNames.Any() || currentConfig.IncludeColumnNames.Contains(columnInfo.Name);
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

        data.IncludeColumnNames = Columns.All(column => column.Include)
            ? []
            : Columns
                .Where(column => column.Include)
                .Select(column => column.Name)
                .ToArray();

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

        /// <summary> Gets or sets a value indicating whether this column should be included the table. </summary>
        public bool Include { get; set; } = true;

        /// <summary> Gets or sets a value indicating whether this column should be excluded from the table. </summary>
        public bool Exclude { get; set; }

        /// <summary> Gets or sets the type of the data this column holds. </summary>
        public string DataType { get; set; } = ColumnDataTypeLookup.Keys.First();
    }
}
