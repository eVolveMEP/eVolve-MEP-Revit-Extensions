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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.ExcelTabPage = new System.Windows.Forms.TabPage();
            this.ExcelDeleteButton = new System.Windows.Forms.Button();
            this.ExcelEditButton = new System.Windows.Forms.Button();
            this.ExcelNewButton = new System.Windows.Forms.Button();
            this.ExcelDataGridView = new System.Windows.Forms.DataGridView();
            this.ExcelNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExcelFilePathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExcelCachedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ExcelDescriptoinColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SqlTabPage = new System.Windows.Forms.TabPage();
            this.SqlDeleteButton = new System.Windows.Forms.Button();
            this.SqlEditButton = new System.Windows.Forms.Button();
            this.SqlNewButton = new System.Windows.Forms.Button();
            this.SqlDataGridView = new System.Windows.Forms.DataGridView();
            this.SqlNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SqlCachedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SqlDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.ViewSourceCodeLabel = new System.Windows.Forms.Label();
            this.ConfigLocationLabel = new System.Windows.Forms.Label();
            this.GlobalConfigInfoLabel = new System.Windows.Forms.Label();
            this.HelpLinkPictureBox = new System.Windows.Forms.PictureBox();
            this.TabControl.SuspendLayout();
            this.ExcelTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExcelDataGridView)).BeginInit();
            this.SqlTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SqlDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpLinkPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.ExcelTabPage);
            this.TabControl.Controls.Add(this.SqlTabPage);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(776, 408);
            this.TabControl.TabIndex = 0;
            // 
            // ExcelTabPage
            // 
            this.ExcelTabPage.Controls.Add(this.ExcelDeleteButton);
            this.ExcelTabPage.Controls.Add(this.ExcelEditButton);
            this.ExcelTabPage.Controls.Add(this.ExcelNewButton);
            this.ExcelTabPage.Controls.Add(this.ExcelDataGridView);
            this.ExcelTabPage.Location = new System.Drawing.Point(4, 22);
            this.ExcelTabPage.Name = "ExcelTabPage";
            this.ExcelTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ExcelTabPage.Size = new System.Drawing.Size(768, 382);
            this.ExcelTabPage.TabIndex = 0;
            this.ExcelTabPage.Text = "Source from Excel";
            this.ExcelTabPage.UseVisualStyleBackColor = true;
            // 
            // ExcelDeleteButton
            // 
            this.ExcelDeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExcelDeleteButton.Location = new System.Drawing.Point(188, 353);
            this.ExcelDeleteButton.Name = "ExcelDeleteButton";
            this.ExcelDeleteButton.Size = new System.Drawing.Size(85, 23);
            this.ExcelDeleteButton.TabIndex = 3;
            this.ExcelDeleteButton.Text = "Delete";
            this.ExcelDeleteButton.UseVisualStyleBackColor = true;
            // 
            // ExcelEditButton
            // 
            this.ExcelEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExcelEditButton.Location = new System.Drawing.Point(97, 353);
            this.ExcelEditButton.Name = "ExcelEditButton";
            this.ExcelEditButton.Size = new System.Drawing.Size(85, 23);
            this.ExcelEditButton.TabIndex = 2;
            this.ExcelEditButton.Text = "Edit";
            this.ExcelEditButton.UseVisualStyleBackColor = true;
            // 
            // ExcelNewButton
            // 
            this.ExcelNewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExcelNewButton.Location = new System.Drawing.Point(6, 353);
            this.ExcelNewButton.Name = "ExcelNewButton";
            this.ExcelNewButton.Size = new System.Drawing.Size(85, 23);
            this.ExcelNewButton.TabIndex = 1;
            this.ExcelNewButton.Text = "New";
            this.ExcelNewButton.UseVisualStyleBackColor = true;
            // 
            // ExcelDataGridView
            // 
            this.ExcelDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExcelDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExcelDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExcelNameColumn,
            this.ExcelFilePathColumn,
            this.ExcelCachedColumn,
            this.ExcelDescriptoinColumn});
            this.ExcelDataGridView.Location = new System.Drawing.Point(6, 6);
            this.ExcelDataGridView.Name = "ExcelDataGridView";
            this.ExcelDataGridView.Size = new System.Drawing.Size(756, 341);
            this.ExcelDataGridView.TabIndex = 0;
            // 
            // ExcelNameColumn
            // 
            this.ExcelNameColumn.HeaderText = "Name";
            this.ExcelNameColumn.Name = "ExcelNameColumn";
            this.ExcelNameColumn.ReadOnly = true;
            // 
            // ExcelFilePathColumn
            // 
            this.ExcelFilePathColumn.HeaderText = "File Path";
            this.ExcelFilePathColumn.Name = "ExcelFilePathColumn";
            this.ExcelFilePathColumn.ReadOnly = true;
            // 
            // ExcelCachedColumn
            // 
            this.ExcelCachedColumn.HeaderText = "Cached";
            this.ExcelCachedColumn.Name = "ExcelCachedColumn";
            this.ExcelCachedColumn.ReadOnly = true;
            // 
            // ExcelDescriptoinColumn
            // 
            this.ExcelDescriptoinColumn.HeaderText = "Description";
            this.ExcelDescriptoinColumn.Name = "ExcelDescriptoinColumn";
            this.ExcelDescriptoinColumn.ReadOnly = true;
            this.ExcelDescriptoinColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ExcelDescriptoinColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SqlTabPage
            // 
            this.SqlTabPage.Controls.Add(this.SqlDeleteButton);
            this.SqlTabPage.Controls.Add(this.SqlEditButton);
            this.SqlTabPage.Controls.Add(this.SqlNewButton);
            this.SqlTabPage.Controls.Add(this.SqlDataGridView);
            this.SqlTabPage.Location = new System.Drawing.Point(4, 22);
            this.SqlTabPage.Name = "SqlTabPage";
            this.SqlTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SqlTabPage.Size = new System.Drawing.Size(768, 382);
            this.SqlTabPage.TabIndex = 1;
            this.SqlTabPage.Text = "Source from SQL Server";
            this.SqlTabPage.UseVisualStyleBackColor = true;
            // 
            // SqlDeleteButton
            // 
            this.SqlDeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SqlDeleteButton.Location = new System.Drawing.Point(188, 354);
            this.SqlDeleteButton.Name = "SqlDeleteButton";
            this.SqlDeleteButton.Size = new System.Drawing.Size(85, 23);
            this.SqlDeleteButton.TabIndex = 3;
            this.SqlDeleteButton.Text = "Delete";
            this.SqlDeleteButton.UseVisualStyleBackColor = true;
            // 
            // SqlEditButton
            // 
            this.SqlEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SqlEditButton.Location = new System.Drawing.Point(97, 354);
            this.SqlEditButton.Name = "SqlEditButton";
            this.SqlEditButton.Size = new System.Drawing.Size(85, 23);
            this.SqlEditButton.TabIndex = 2;
            this.SqlEditButton.Text = "Edit";
            this.SqlEditButton.UseVisualStyleBackColor = true;
            // 
            // SqlNewButton
            // 
            this.SqlNewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SqlNewButton.Location = new System.Drawing.Point(6, 354);
            this.SqlNewButton.Name = "SqlNewButton";
            this.SqlNewButton.Size = new System.Drawing.Size(85, 23);
            this.SqlNewButton.TabIndex = 1;
            this.SqlNewButton.Text = "New";
            this.SqlNewButton.UseVisualStyleBackColor = true;
            // 
            // SqlDataGridView
            // 
            this.SqlDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SqlDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SqlDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SqlNameColumn,
            this.SqlCachedColumn,
            this.SqlDescriptionColumn});
            this.SqlDataGridView.Location = new System.Drawing.Point(6, 6);
            this.SqlDataGridView.Name = "SqlDataGridView";
            this.SqlDataGridView.Size = new System.Drawing.Size(756, 342);
            this.SqlDataGridView.TabIndex = 0;
            // 
            // SqlNameColumn
            // 
            this.SqlNameColumn.HeaderText = "Name";
            this.SqlNameColumn.Name = "SqlNameColumn";
            this.SqlNameColumn.ReadOnly = true;
            // 
            // SqlCachedColumn
            // 
            this.SqlCachedColumn.HeaderText = "Cached";
            this.SqlCachedColumn.Name = "SqlCachedColumn";
            this.SqlCachedColumn.ReadOnly = true;
            // 
            // SqlDescriptionColumn
            // 
            this.SqlDescriptionColumn.HeaderText = "Description";
            this.SqlDescriptionColumn.Name = "SqlDescriptionColumn";
            this.SqlDescriptionColumn.ReadOnly = true;
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogoPictureBox.Image = global::eVolve.DataTableTools.Revit.Properties.Resources.Logo;
            this.LogoPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LogoPictureBox.Location = new System.Drawing.Point(12, 497);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(146, 23);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoPictureBox.TabIndex = 16;
            this.LogoPictureBox.TabStop = false;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(476, 497);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(100, 23);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(582, 497);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(100, 23);
            this.Cancel_Button.TabIndex = 3;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyButton.Location = new System.Drawing.Point(688, 497);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(100, 23);
            this.ApplyButton.TabIndex = 4;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // ViewSourceCodeLabel
            // 
            this.ViewSourceCodeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ViewSourceCodeLabel.AutoSize = true;
            this.ViewSourceCodeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ViewSourceCodeLabel.Location = new System.Drawing.Point(190, 502);
            this.ViewSourceCodeLabel.Name = "ViewSourceCodeLabel";
            this.ViewSourceCodeLabel.Size = new System.Drawing.Size(115, 13);
            this.ViewSourceCodeLabel.TabIndex = 1;
            this.ViewSourceCodeLabel.Text = "ViewSourceCodeLabel";
            // 
            // ConfigLocationLabel
            // 
            this.ConfigLocationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ConfigLocationLabel.AutoSize = true;
            this.ConfigLocationLabel.Location = new System.Drawing.Point(19, 423);
            this.ConfigLocationLabel.Name = "ConfigLocationLabel";
            this.ConfigLocationLabel.Size = new System.Drawing.Size(165, 13);
            this.ConfigLocationLabel.TabIndex = 17;
            this.ConfigLocationLabel.Text = "Current configuration location: {0}";
            // 
            // GlobalConfigInfoLabel
            // 
            this.GlobalConfigInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GlobalConfigInfoLabel.AutoSize = true;
            this.GlobalConfigInfoLabel.Location = new System.Drawing.Point(19, 453);
            this.GlobalConfigInfoLabel.Name = "GlobalConfigInfoLabel";
            this.GlobalConfigInfoLabel.Size = new System.Drawing.Size(449, 26);
            this.GlobalConfigInfoLabel.TabIndex = 18;
            this.GlobalConfigInfoLabel.Text = "This is a global/standards path. Any changes will apply to all installations refe" +
    "rencing this path.\r\nA reload of Revit will be required for other installations t" +
    "o apply any updated settings.";
            // 
            // HelpLinkPictureBox
            // 
            this.HelpLinkPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpLinkPictureBox.Image = global::eVolve.DataTableTools.Revit.Properties.Resources.Help_Medium_20x20;
            this.HelpLinkPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.HelpLinkPictureBox.Location = new System.Drawing.Point(780, -1);
            this.HelpLinkPictureBox.Name = "HelpLinkPictureBox";
            this.HelpLinkPictureBox.Size = new System.Drawing.Size(20, 20);
            this.HelpLinkPictureBox.TabIndex = 19;
            this.HelpLinkPictureBox.TabStop = false;
            // 
            // ExternalTablesConfigDialog
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(800, 532);
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
            this.SqlTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SqlDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpLinkPictureBox)).EndInit();
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
    private System.Windows.Forms.DataGridViewTextBoxColumn ExcelNameColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn ExcelFilePathColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn ExcelCachedColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn ExcelDescriptoinColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn SqlNameColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn SqlCachedColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn SqlDescriptionColumn;
    private System.Windows.Forms.PictureBox HelpLinkPictureBox;
}