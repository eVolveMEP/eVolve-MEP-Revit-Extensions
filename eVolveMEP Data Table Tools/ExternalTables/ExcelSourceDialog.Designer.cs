namespace eVolve.DataTableTools.Revit.ExternalTables;

partial class ExcelSourceDialog
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.ExternalTableSourceBaseControl = new eVolve.DataTableTools.Revit.ExternalTables.ExternalTableSourceBaseControl();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.FileGroupBox = new System.Windows.Forms.GroupBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.FileBrowseButton = new System.Windows.Forms.Button();
            this.FileTextBox = new System.Windows.Forms.TextBox();
            this.ColumnsGroupBox = new System.Windows.Forms.GroupBox();
            this.ColumnsDataGridView = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataTypeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ExcludeColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.FileGroupBox.SuspendLayout();
            this.ColumnsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ExternalTableSourceBaseControl
            // 
            this.ExternalTableSourceBaseControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExternalTableSourceBaseControl.Location = new System.Drawing.Point(12, 12);
            this.ExternalTableSourceBaseControl.Name = "ExternalTableSourceBaseControl";
            this.ExternalTableSourceBaseControl.Size = new System.Drawing.Size(776, 119);
            this.ExternalTableSourceBaseControl.TabIndex = 1;
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogoPictureBox.Image = global::eVolve.DataTableTools.Revit.Properties.Resources.Logo;
            this.LogoPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LogoPictureBox.Location = new System.Drawing.Point(12, 581);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(146, 23);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoPictureBox.TabIndex = 20;
            this.LogoPictureBox.TabStop = false;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(688, 581);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(100, 23);
            this.Cancel_Button.TabIndex = 19;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(582, 581);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(100, 23);
            this.OKButton.TabIndex = 18;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // FileGroupBox
            // 
            this.FileGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileGroupBox.Controls.Add(this.RefreshButton);
            this.FileGroupBox.Controls.Add(this.FileBrowseButton);
            this.FileGroupBox.Controls.Add(this.FileTextBox);
            this.FileGroupBox.Location = new System.Drawing.Point(12, 137);
            this.FileGroupBox.Name = "FileGroupBox";
            this.FileGroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.FileGroupBox.Size = new System.Drawing.Size(776, 67);
            this.FileGroupBox.TabIndex = 21;
            this.FileGroupBox.TabStop = false;
            this.FileGroupBox.Text = "Source File";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RefreshButton.Location = new System.Drawing.Point(648, 24);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(115, 23);
            this.RefreshButton.TabIndex = 2;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // FileBrowseButton
            // 
            this.FileBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FileBrowseButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FileBrowseButton.Location = new System.Drawing.Point(527, 24);
            this.FileBrowseButton.Name = "FileBrowseButton";
            this.FileBrowseButton.Size = new System.Drawing.Size(115, 23);
            this.FileBrowseButton.TabIndex = 1;
            this.FileBrowseButton.Text = "Browse";
            this.FileBrowseButton.UseVisualStyleBackColor = true;
            this.FileBrowseButton.Click += new System.EventHandler(this.FileBrowseButton_Click);
            // 
            // FileTextBox
            // 
            this.FileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileTextBox.Location = new System.Drawing.Point(20, 26);
            this.FileTextBox.Name = "FileTextBox";
            this.FileTextBox.Size = new System.Drawing.Size(501, 20);
            this.FileTextBox.TabIndex = 0;
            // 
            // ColumnsGroupBox
            // 
            this.ColumnsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ColumnsGroupBox.Controls.Add(this.ColumnsDataGridView);
            this.ColumnsGroupBox.Location = new System.Drawing.Point(12, 226);
            this.ColumnsGroupBox.Name = "ColumnsGroupBox";
            this.ColumnsGroupBox.Size = new System.Drawing.Size(776, 322);
            this.ColumnsGroupBox.TabIndex = 22;
            this.ColumnsGroupBox.TabStop = false;
            this.ColumnsGroupBox.Text = "Column Configuration";
            // 
            // ColumnsDataGridView
            // 
            this.ColumnsDataGridView.AllowUserToAddRows = false;
            this.ColumnsDataGridView.AllowUserToDeleteRows = false;
            this.ColumnsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ColumnsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ColumnsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.DataTypeColumn,
            this.ExcludeColumn});
            this.ColumnsDataGridView.Location = new System.Drawing.Point(20, 30);
            this.ColumnsDataGridView.Name = "ColumnsDataGridView";
            this.ColumnsDataGridView.Size = new System.Drawing.Size(743, 276);
            this.ColumnsDataGridView.TabIndex = 0;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // DataTypeColumn
            // 
            this.DataTypeColumn.HeaderText = "Data Type";
            this.DataTypeColumn.Name = "DataTypeColumn";
            // 
            // ExcludeColumn
            // 
            this.ExcludeColumn.HeaderText = "Exclude";
            this.ExcludeColumn.Name = "ExcludeColumn";
            // 
            // ExcelSourceDialog
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(800, 616);
            this.Controls.Add(this.ColumnsGroupBox);
            this.Controls.Add(this.FileGroupBox);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ExternalTableSourceBaseControl);
            this.Name = "ExcelSourceDialog";
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.FileGroupBox.ResumeLayout(false);
            this.FileGroupBox.PerformLayout();
            this.ColumnsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsDataGridView)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private ExternalTableSourceBaseControl ExternalTableSourceBaseControl;
    private System.Windows.Forms.PictureBox LogoPictureBox;
    private System.Windows.Forms.Button Cancel_Button;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.GroupBox FileGroupBox;
    private System.Windows.Forms.Button FileBrowseButton;
    private System.Windows.Forms.TextBox FileTextBox;
    private System.Windows.Forms.GroupBox ColumnsGroupBox;
    private System.Windows.Forms.DataGridView ColumnsDataGridView;
    private System.Windows.Forms.Button RefreshButton;
    private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
    private System.Windows.Forms.DataGridViewComboBoxColumn DataTypeColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn ExcludeColumn;
}