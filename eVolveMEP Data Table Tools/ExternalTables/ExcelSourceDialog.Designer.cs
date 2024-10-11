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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelSourceDialog));
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
            resources.ApplyResources(this.ExternalTableSourceBaseControl, "ExternalTableSourceBaseControl");
            this.ExternalTableSourceBaseControl.Name = "ExternalTableSourceBaseControl";
            // 
            // LogoPictureBox
            // 
            resources.ApplyResources(this.LogoPictureBox, "LogoPictureBox");
            this.LogoPictureBox.Image = global::eVolve.DataTableTools.Revit.Properties.Resources.Logo;
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.TabStop = false;
            // 
            // Cancel_Button
            // 
            resources.ApplyResources(this.Cancel_Button, "Cancel_Button");
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            resources.ApplyResources(this.OKButton, "OKButton");
            this.OKButton.Name = "OKButton";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // FileGroupBox
            // 
            resources.ApplyResources(this.FileGroupBox, "FileGroupBox");
            this.FileGroupBox.Controls.Add(this.RefreshButton);
            this.FileGroupBox.Controls.Add(this.FileBrowseButton);
            this.FileGroupBox.Controls.Add(this.FileTextBox);
            this.FileGroupBox.Name = "FileGroupBox";
            this.FileGroupBox.TabStop = false;
            // 
            // RefreshButton
            // 
            resources.ApplyResources(this.RefreshButton, "RefreshButton");
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // FileBrowseButton
            // 
            resources.ApplyResources(this.FileBrowseButton, "FileBrowseButton");
            this.FileBrowseButton.Name = "FileBrowseButton";
            this.FileBrowseButton.UseVisualStyleBackColor = true;
            this.FileBrowseButton.Click += new System.EventHandler(this.FileBrowseButton_Click);
            // 
            // FileTextBox
            // 
            resources.ApplyResources(this.FileTextBox, "FileTextBox");
            this.FileTextBox.Name = "FileTextBox";
            // 
            // ColumnsGroupBox
            // 
            resources.ApplyResources(this.ColumnsGroupBox, "ColumnsGroupBox");
            this.ColumnsGroupBox.Controls.Add(this.ColumnsDataGridView);
            this.ColumnsGroupBox.Name = "ColumnsGroupBox";
            this.ColumnsGroupBox.TabStop = false;
            // 
            // ColumnsDataGridView
            // 
            this.ColumnsDataGridView.AllowUserToAddRows = false;
            this.ColumnsDataGridView.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.ColumnsDataGridView, "ColumnsDataGridView");
            this.ColumnsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ColumnsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.DataTypeColumn,
            this.ExcludeColumn});
            this.ColumnsDataGridView.Name = "ColumnsDataGridView";
            // 
            // NameColumn
            // 
            resources.ApplyResources(this.NameColumn, "NameColumn");
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // DataTypeColumn
            // 
            resources.ApplyResources(this.DataTypeColumn, "DataTypeColumn");
            this.DataTypeColumn.Name = "DataTypeColumn";
            // 
            // ExcludeColumn
            // 
            resources.ApplyResources(this.ExcludeColumn, "ExcludeColumn");
            this.ExcludeColumn.Name = "ExcludeColumn";
            // 
            // ExcelSourceDialog
            // 
            this.AcceptButton = this.OKButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
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