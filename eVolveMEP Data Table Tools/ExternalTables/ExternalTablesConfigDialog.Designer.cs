namespace eVolve.DataTableTools.Revit.ExternalTables;

partial class ExternalTablesConfigDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExternalTablesConfigDialog));
            this.TabControl = new System.Windows.Forms.TabControl();
            this.ExcelTabPage = new System.Windows.Forms.TabPage();
            this.ExcelDeleteButton = new System.Windows.Forms.Button();
            this.ExcelEditButton = new System.Windows.Forms.Button();
            this.ExcelNewButton = new System.Windows.Forms.Button();
            this.ExcelDataGridView = new System.Windows.Forms.DataGridView();
            this.ExcelNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExcelFilePathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExcelCachedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ExcelDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CsvTabPage = new System.Windows.Forms.TabPage();
            this.CsvDeleteButton = new System.Windows.Forms.Button();
            this.CsvEditButton = new System.Windows.Forms.Button();
            this.CsvNewButton = new System.Windows.Forms.Button();
            this.CsvDataGridView = new System.Windows.Forms.DataGridView();
            this.CsvNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CsvFilePathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CsvCachedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CsvDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SqlTabPage = new System.Windows.Forms.TabPage();
            this.SqlDeleteButton = new System.Windows.Forms.Button();
            this.SqlEditButton = new System.Windows.Forms.Button();
            this.SqlNewButton = new System.Windows.Forms.Button();
            this.SqlDataGridView = new System.Windows.Forms.DataGridView();
            this.SqlNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SqlCachedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SqlDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataTableTabPage = new System.Windows.Forms.TabPage();
            this.DataTableDeleteButton = new System.Windows.Forms.Button();
            this.DataTableEditButton = new System.Windows.Forms.Button();
            this.DataTableNewButton = new System.Windows.Forms.Button();
            this.DataTableDataGridView = new System.Windows.Forms.DataGridView();
            this.DataTableNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataTableFilePathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataTableCachedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DataTableDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.ViewSourceCodeLabel = new System.Windows.Forms.Label();
            this.ConfigLocationLabel = new System.Windows.Forms.Label();
            this.GlobalConfigInfoLabel = new System.Windows.Forms.Label();
            this.HelpLinkPictureBox = new System.Windows.Forms.PictureBox();
            this.VideoLinkPictureBox = new System.Windows.Forms.PictureBox();
            this.TabControl.SuspendLayout();
            this.ExcelTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExcelDataGridView)).BeginInit();
            this.CsvTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CsvDataGridView)).BeginInit();
            this.SqlTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SqlDataGridView)).BeginInit();
            this.DataTableTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpLinkPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoLinkPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            resources.ApplyResources(this.TabControl, "TabControl");
            this.TabControl.Controls.Add(this.ExcelTabPage);
            this.TabControl.Controls.Add(this.CsvTabPage);
            this.TabControl.Controls.Add(this.SqlTabPage);
            this.TabControl.Controls.Add(this.DataTableTabPage);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            // 
            // ExcelTabPage
            // 
            this.ExcelTabPage.Controls.Add(this.ExcelDeleteButton);
            this.ExcelTabPage.Controls.Add(this.ExcelEditButton);
            this.ExcelTabPage.Controls.Add(this.ExcelNewButton);
            this.ExcelTabPage.Controls.Add(this.ExcelDataGridView);
            resources.ApplyResources(this.ExcelTabPage, "ExcelTabPage");
            this.ExcelTabPage.Name = "ExcelTabPage";
            this.ExcelTabPage.UseVisualStyleBackColor = true;
            // 
            // ExcelDeleteButton
            // 
            resources.ApplyResources(this.ExcelDeleteButton, "ExcelDeleteButton");
            this.ExcelDeleteButton.Name = "ExcelDeleteButton";
            this.ExcelDeleteButton.UseVisualStyleBackColor = true;
            // 
            // ExcelEditButton
            // 
            resources.ApplyResources(this.ExcelEditButton, "ExcelEditButton");
            this.ExcelEditButton.Name = "ExcelEditButton";
            this.ExcelEditButton.UseVisualStyleBackColor = true;
            // 
            // ExcelNewButton
            // 
            resources.ApplyResources(this.ExcelNewButton, "ExcelNewButton");
            this.ExcelNewButton.Name = "ExcelNewButton";
            this.ExcelNewButton.UseVisualStyleBackColor = true;
            // 
            // ExcelDataGridView
            // 
            resources.ApplyResources(this.ExcelDataGridView, "ExcelDataGridView");
            this.ExcelDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExcelDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExcelNameColumn,
            this.ExcelFilePathColumn,
            this.ExcelCachedColumn,
            this.ExcelDescriptionColumn});
            this.ExcelDataGridView.Name = "ExcelDataGridView";
            // 
            // ExcelNameColumn
            // 
            resources.ApplyResources(this.ExcelNameColumn, "ExcelNameColumn");
            this.ExcelNameColumn.Name = "ExcelNameColumn";
            this.ExcelNameColumn.ReadOnly = true;
            // 
            // ExcelFilePathColumn
            // 
            resources.ApplyResources(this.ExcelFilePathColumn, "ExcelFilePathColumn");
            this.ExcelFilePathColumn.Name = "ExcelFilePathColumn";
            this.ExcelFilePathColumn.ReadOnly = true;
            // 
            // ExcelCachedColumn
            // 
            resources.ApplyResources(this.ExcelCachedColumn, "ExcelCachedColumn");
            this.ExcelCachedColumn.Name = "ExcelCachedColumn";
            this.ExcelCachedColumn.ReadOnly = true;
            // 
            // ExcelDescriptionColumn
            // 
            resources.ApplyResources(this.ExcelDescriptionColumn, "ExcelDescriptionColumn");
            this.ExcelDescriptionColumn.Name = "ExcelDescriptionColumn";
            this.ExcelDescriptionColumn.ReadOnly = true;
            this.ExcelDescriptionColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ExcelDescriptionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CsvTabPage
            // 
            this.CsvTabPage.Controls.Add(this.CsvDeleteButton);
            this.CsvTabPage.Controls.Add(this.CsvEditButton);
            this.CsvTabPage.Controls.Add(this.CsvNewButton);
            this.CsvTabPage.Controls.Add(this.CsvDataGridView);
            resources.ApplyResources(this.CsvTabPage, "CsvTabPage");
            this.CsvTabPage.Name = "CsvTabPage";
            this.CsvTabPage.UseVisualStyleBackColor = true;
            // 
            // CsvDeleteButton
            // 
            resources.ApplyResources(this.CsvDeleteButton, "CsvDeleteButton");
            this.CsvDeleteButton.Name = "CsvDeleteButton";
            this.CsvDeleteButton.UseVisualStyleBackColor = true;
            // 
            // CsvEditButton
            // 
            resources.ApplyResources(this.CsvEditButton, "CsvEditButton");
            this.CsvEditButton.Name = "CsvEditButton";
            this.CsvEditButton.UseVisualStyleBackColor = true;
            // 
            // CsvNewButton
            // 
            resources.ApplyResources(this.CsvNewButton, "CsvNewButton");
            this.CsvNewButton.Name = "CsvNewButton";
            this.CsvNewButton.UseVisualStyleBackColor = true;
            // 
            // CsvDataGridView
            // 
            resources.ApplyResources(this.CsvDataGridView, "CsvDataGridView");
            this.CsvDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CsvDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CsvNameColumn,
            this.CsvFilePathColumn,
            this.CsvCachedColumn,
            this.CsvDescriptionColumn});
            this.CsvDataGridView.Name = "CsvDataGridView";
            // 
            // CsvNameColumn
            // 
            resources.ApplyResources(this.CsvNameColumn, "CsvNameColumn");
            this.CsvNameColumn.Name = "CsvNameColumn";
            this.CsvNameColumn.ReadOnly = true;
            // 
            // CsvFilePathColumn
            // 
            resources.ApplyResources(this.CsvFilePathColumn, "CsvFilePathColumn");
            this.CsvFilePathColumn.Name = "CsvFilePathColumn";
            this.CsvFilePathColumn.ReadOnly = true;
            // 
            // CsvCachedColumn
            // 
            resources.ApplyResources(this.CsvCachedColumn, "CsvCachedColumn");
            this.CsvCachedColumn.Name = "CsvCachedColumn";
            this.CsvCachedColumn.ReadOnly = true;
            // 
            // CsvDescriptionColumn
            // 
            resources.ApplyResources(this.CsvDescriptionColumn, "CsvDescriptionColumn");
            this.CsvDescriptionColumn.Name = "CsvDescriptionColumn";
            this.CsvDescriptionColumn.ReadOnly = true;
            this.CsvDescriptionColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CsvDescriptionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SqlTabPage
            // 
            this.SqlTabPage.Controls.Add(this.SqlDeleteButton);
            this.SqlTabPage.Controls.Add(this.SqlEditButton);
            this.SqlTabPage.Controls.Add(this.SqlNewButton);
            this.SqlTabPage.Controls.Add(this.SqlDataGridView);
            resources.ApplyResources(this.SqlTabPage, "SqlTabPage");
            this.SqlTabPage.Name = "SqlTabPage";
            this.SqlTabPage.UseVisualStyleBackColor = true;
            // 
            // SqlDeleteButton
            // 
            resources.ApplyResources(this.SqlDeleteButton, "SqlDeleteButton");
            this.SqlDeleteButton.Name = "SqlDeleteButton";
            this.SqlDeleteButton.UseVisualStyleBackColor = true;
            // 
            // SqlEditButton
            // 
            resources.ApplyResources(this.SqlEditButton, "SqlEditButton");
            this.SqlEditButton.Name = "SqlEditButton";
            this.SqlEditButton.UseVisualStyleBackColor = true;
            // 
            // SqlNewButton
            // 
            resources.ApplyResources(this.SqlNewButton, "SqlNewButton");
            this.SqlNewButton.Name = "SqlNewButton";
            this.SqlNewButton.UseVisualStyleBackColor = true;
            // 
            // SqlDataGridView
            // 
            resources.ApplyResources(this.SqlDataGridView, "SqlDataGridView");
            this.SqlDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SqlDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SqlNameColumn,
            this.SqlCachedColumn,
            this.SqlDescriptionColumn});
            this.SqlDataGridView.Name = "SqlDataGridView";
            // 
            // SqlNameColumn
            // 
            resources.ApplyResources(this.SqlNameColumn, "SqlNameColumn");
            this.SqlNameColumn.Name = "SqlNameColumn";
            this.SqlNameColumn.ReadOnly = true;
            // 
            // SqlCachedColumn
            // 
            resources.ApplyResources(this.SqlCachedColumn, "SqlCachedColumn");
            this.SqlCachedColumn.Name = "SqlCachedColumn";
            this.SqlCachedColumn.ReadOnly = true;
            // 
            // SqlDescriptionColumn
            // 
            resources.ApplyResources(this.SqlDescriptionColumn, "SqlDescriptionColumn");
            this.SqlDescriptionColumn.Name = "SqlDescriptionColumn";
            this.SqlDescriptionColumn.ReadOnly = true;
            // 
            // DataTableTabPage
            // 
            this.DataTableTabPage.Controls.Add(this.DataTableDeleteButton);
            this.DataTableTabPage.Controls.Add(this.DataTableEditButton);
            this.DataTableTabPage.Controls.Add(this.DataTableNewButton);
            this.DataTableTabPage.Controls.Add(this.DataTableDataGridView);
            resources.ApplyResources(this.DataTableTabPage, "DataTableTabPage");
            this.DataTableTabPage.Name = "DataTableTabPage";
            this.DataTableTabPage.UseVisualStyleBackColor = true;
            // 
            // DataTableDeleteButton
            // 
            resources.ApplyResources(this.DataTableDeleteButton, "DataTableDeleteButton");
            this.DataTableDeleteButton.Name = "DataTableDeleteButton";
            this.DataTableDeleteButton.UseVisualStyleBackColor = true;
            // 
            // DataTableEditButton
            // 
            resources.ApplyResources(this.DataTableEditButton, "DataTableEditButton");
            this.DataTableEditButton.Name = "DataTableEditButton";
            this.DataTableEditButton.UseVisualStyleBackColor = true;
            // 
            // DataTableNewButton
            // 
            resources.ApplyResources(this.DataTableNewButton, "DataTableNewButton");
            this.DataTableNewButton.Name = "DataTableNewButton";
            this.DataTableNewButton.UseVisualStyleBackColor = true;
            // 
            // DataTableDataGridView
            // 
            resources.ApplyResources(this.DataTableDataGridView, "DataTableDataGridView");
            this.DataTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataTableNameColumn,
            this.DataTableFilePathColumn,
            this.DataTableCachedColumn,
            this.DataTableDescriptionColumn});
            this.DataTableDataGridView.Name = "DataTableDataGridView";
            // 
            // DataTableNameColumn
            // 
            resources.ApplyResources(this.DataTableNameColumn, "DataTableNameColumn");
            this.DataTableNameColumn.Name = "DataTableNameColumn";
            this.DataTableNameColumn.ReadOnly = true;
            // 
            // DataTableFilePathColumn
            // 
            resources.ApplyResources(this.DataTableFilePathColumn, "DataTableFilePathColumn");
            this.DataTableFilePathColumn.Name = "DataTableFilePathColumn";
            this.DataTableFilePathColumn.ReadOnly = true;
            // 
            // DataTableCachedColumn
            // 
            resources.ApplyResources(this.DataTableCachedColumn, "DataTableCachedColumn");
            this.DataTableCachedColumn.Name = "DataTableCachedColumn";
            this.DataTableCachedColumn.ReadOnly = true;
            // 
            // DataTableDescriptionColumn
            // 
            resources.ApplyResources(this.DataTableDescriptionColumn, "DataTableDescriptionColumn");
            this.DataTableDescriptionColumn.Name = "DataTableDescriptionColumn";
            this.DataTableDescriptionColumn.ReadOnly = true;
            this.DataTableDescriptionColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataTableDescriptionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LogoPictureBox
            // 
            resources.ApplyResources(this.LogoPictureBox, "LogoPictureBox");
            this.LogoPictureBox.Image = global::eVolve.DataTableTools.Revit.Properties.Resources.Logo;
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.TabStop = false;
            // 
            // OKButton
            // 
            resources.ApplyResources(this.OKButton, "OKButton");
            this.OKButton.Name = "OKButton";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // Cancel_Button
            // 
            resources.ApplyResources(this.Cancel_Button, "Cancel_Button");
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // ApplyButton
            // 
            resources.ApplyResources(this.ApplyButton, "ApplyButton");
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // ViewSourceCodeLabel
            // 
            resources.ApplyResources(this.ViewSourceCodeLabel, "ViewSourceCodeLabel");
            this.ViewSourceCodeLabel.Name = "ViewSourceCodeLabel";
            // 
            // ConfigLocationLabel
            // 
            resources.ApplyResources(this.ConfigLocationLabel, "ConfigLocationLabel");
            this.ConfigLocationLabel.Name = "ConfigLocationLabel";
            // 
            // GlobalConfigInfoLabel
            // 
            resources.ApplyResources(this.GlobalConfigInfoLabel, "GlobalConfigInfoLabel");
            this.GlobalConfigInfoLabel.Name = "GlobalConfigInfoLabel";
            // 
            // HelpLinkPictureBox
            // 
            resources.ApplyResources(this.HelpLinkPictureBox, "HelpLinkPictureBox");
            this.HelpLinkPictureBox.Image = global::eVolve.DataTableTools.Revit.Properties.Resources.Help_Medium_20x20;
            this.HelpLinkPictureBox.Name = "HelpLinkPictureBox";
            this.HelpLinkPictureBox.TabStop = false;
            // 
            // VideoLinkPictureBox
            // 
            resources.ApplyResources(this.VideoLinkPictureBox, "VideoLinkPictureBox");
            this.VideoLinkPictureBox.Image = global::eVolve.DataTableTools.Revit.Properties.Resources.LinkedVideo_20x20;
            this.VideoLinkPictureBox.Name = "VideoLinkPictureBox";
            this.VideoLinkPictureBox.TabStop = false;
            // 
            // ExternalTablesConfigDialog
            // 
            this.AcceptButton = this.OKButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.Controls.Add(this.VideoLinkPictureBox);
            this.Controls.Add(this.HelpLinkPictureBox);
            this.Controls.Add(this.GlobalConfigInfoLabel);
            this.Controls.Add(this.ConfigLocationLabel);
            this.Controls.Add(this.ViewSourceCodeLabel);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.TabControl);
            this.Name = "ExternalTablesConfigDialog";
            this.Load += new System.EventHandler(this.ExternalTablesConfigDialog_Load);
            this.TabControl.ResumeLayout(false);
            this.ExcelTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExcelDataGridView)).EndInit();
            this.CsvTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CsvDataGridView)).EndInit();
            this.SqlTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SqlDataGridView)).EndInit();
            this.DataTableTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataTableDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpLinkPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoLinkPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabControl TabControl;
    private System.Windows.Forms.TabPage ExcelTabPage;
    private System.Windows.Forms.TabPage SqlTabPage;
    private System.Windows.Forms.PictureBox LogoPictureBox;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button Cancel_Button;
    private System.Windows.Forms.Button ApplyButton;
    private System.Windows.Forms.DataGridView ExcelDataGridView;
    private System.Windows.Forms.DataGridView SqlDataGridView;
    private System.Windows.Forms.Button ExcelDeleteButton;
    private System.Windows.Forms.Button ExcelEditButton;
    private System.Windows.Forms.Button ExcelNewButton;
    private System.Windows.Forms.Button SqlDeleteButton;
    private System.Windows.Forms.Button SqlEditButton;
    private System.Windows.Forms.Button SqlNewButton;
    private System.Windows.Forms.Label ViewSourceCodeLabel;
    private System.Windows.Forms.Label ConfigLocationLabel;
    private System.Windows.Forms.Label GlobalConfigInfoLabel;
    private System.Windows.Forms.DataGridViewTextBoxColumn SqlNameColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn SqlCachedColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn SqlDescriptionColumn;
    private System.Windows.Forms.PictureBox HelpLinkPictureBox;
    private System.Windows.Forms.TabPage DataTableTabPage;
    private System.Windows.Forms.Button DataTableDeleteButton;
    private System.Windows.Forms.Button DataTableEditButton;
    private System.Windows.Forms.Button DataTableNewButton;
    private System.Windows.Forms.DataGridView DataTableDataGridView;
    private System.Windows.Forms.DataGridViewTextBoxColumn ExcelNameColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn ExcelFilePathColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn ExcelCachedColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn ExcelDescriptionColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn DataTableNameColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn DataTableFilePathColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn DataTableCachedColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn DataTableDescriptionColumn;
    private System.Windows.Forms.TabPage CsvTabPage;
    private System.Windows.Forms.Button CsvDeleteButton;
    private System.Windows.Forms.Button CsvEditButton;
    private System.Windows.Forms.Button CsvNewButton;
    private System.Windows.Forms.DataGridView CsvDataGridView;
    private System.Windows.Forms.DataGridViewTextBoxColumn CsvNameColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn CsvFilePathColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn CsvCachedColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn CsvDescriptionColumn;
    private System.Windows.Forms.PictureBox VideoLinkPictureBox;
}