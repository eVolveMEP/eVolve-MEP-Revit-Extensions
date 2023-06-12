namespace eVolve.DataTableTools.Revit;

partial class ToolsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolsDialog));
            this.OpenConfigurationPictureBox = new System.Windows.Forms.PictureBox();
            this.HelpLinkPictureBox = new System.Windows.Forms.PictureBox();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.ColumnToolsTabPage = new System.Windows.Forms.TabPage();
            this.ExpressionColumnGroupBox = new System.Windows.Forms.GroupBox();
            this.ExpressionColumnExpressionGroupBox = new System.Windows.Forms.GroupBox();
            this.ExpressionColumnExpressionTextBox = new System.Windows.Forms.TextBox();
            this.ExpressionColumnNameTextBox = new System.Windows.Forms.TextBox();
            this.ExpressionColumnAddButton = new System.Windows.Forms.Button();
            this.ExpressionColumnNameLabel = new System.Windows.Forms.Label();
            this.ChangeColumnTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.ChangeColumnTypeButton = new System.Windows.Forms.Button();
            this.ChangeColumnTypeDataTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ChangeColumnTypeDataTypeLabel = new System.Windows.Forms.Label();
            this.ChangeColumnTypeColumnComboBox = new System.Windows.Forms.ComboBox();
            this.ChangeColumnTypeColumnLabel = new System.Windows.Forms.Label();
            this.SqlServerToolsTabPage = new System.Windows.Forms.TabPage();
            this.SQLExportDataGroupBox = new System.Windows.Forms.GroupBox();
            this.SQLExportPostEventButton = new System.Windows.Forms.Button();
            this.SQLExportPreEventButton = new System.Windows.Forms.Button();
            this.SQLExportPostEventCheckBox = new System.Windows.Forms.CheckBox();
            this.SQLExportPreEventCheckBox = new System.Windows.Forms.CheckBox();
            this.SQLExportFieldMappingGroupBox = new System.Windows.Forms.GroupBox();
            this.SQLExportFieldMappingRemoveButton = new System.Windows.Forms.Button();
            this.SQLExportFieldMappingAddButton = new System.Windows.Forms.Button();
            this.SQLExportFieldMappingListBox = new System.Windows.Forms.ListBox();
            this.SQLExportTargetComboBox = new System.Windows.Forms.ComboBox();
            this.SQLExportTargetLabel = new System.Windows.Forms.Label();
            this.SQLImportDataGroupBox = new System.Windows.Forms.GroupBox();
            this.SQLImportSourceGroupBox = new System.Windows.Forms.GroupBox();
            this.SQLImportSourceCustomButton = new System.Windows.Forms.Button();
            this.SQLImportSourceViewComboBox = new System.Windows.Forms.ComboBox();
            this.SQLImportSourceTableComboBox = new System.Windows.Forms.ComboBox();
            this.SQLImportSourceCustomRadioButton = new System.Windows.Forms.RadioButton();
            this.SQLImportSourceViewRadioButton = new System.Windows.Forms.RadioButton();
            this.SQLImportSourceTableRadioButton = new System.Windows.Forms.RadioButton();
            this.SQLImportTargetComboBox = new System.Windows.Forms.ComboBox();
            this.SQLImportTargetLabel = new System.Windows.Forms.Label();
            this.SQLConnectionStringGroupBox = new System.Windows.Forms.GroupBox();
            this.SQLConnectionStringHelpLabel = new System.Windows.Forms.Label();
            this.SQLConnectionStatusLabel = new System.Windows.Forms.Label();
            this.SQLConnectButton = new System.Windows.Forms.Button();
            this.SQLConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.DataTableLabel = new System.Windows.Forms.Label();
            this.DataTableComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.OpenConfigurationPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpLinkPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.MainTabControl.SuspendLayout();
            this.ColumnToolsTabPage.SuspendLayout();
            this.ExpressionColumnGroupBox.SuspendLayout();
            this.ExpressionColumnExpressionGroupBox.SuspendLayout();
            this.ChangeColumnTypeGroupBox.SuspendLayout();
            this.SqlServerToolsTabPage.SuspendLayout();
            this.SQLExportDataGroupBox.SuspendLayout();
            this.SQLExportFieldMappingGroupBox.SuspendLayout();
            this.SQLImportDataGroupBox.SuspendLayout();
            this.SQLImportSourceGroupBox.SuspendLayout();
            this.SQLConnectionStringGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenConfigurationPictureBox
            // 
            resources.ApplyResources(this.OpenConfigurationPictureBox, "OpenConfigurationPictureBox");
            this.OpenConfigurationPictureBox.Image = global::eVolve.DataTableTools.Revit.Properties.Resources.Settings_20x20;
            this.OpenConfigurationPictureBox.Name = "OpenConfigurationPictureBox";
            this.OpenConfigurationPictureBox.TabStop = false;
            this.OpenConfigurationPictureBox.Click += new System.EventHandler(this.OpenConfigurationPictureBox_Click);
            // 
            // HelpLinkPictureBox
            // 
            resources.ApplyResources(this.HelpLinkPictureBox, "HelpLinkPictureBox");
            this.HelpLinkPictureBox.Image = global::eVolve.DataTableTools.Revit.Properties.Resources.Help_Medium_20x20;
            this.HelpLinkPictureBox.Name = "HelpLinkPictureBox";
            this.HelpLinkPictureBox.TabStop = false;
            this.HelpLinkPictureBox.Click += new System.EventHandler(this.HelpLinkPictureBox_Click);
            // 
            // LogoPictureBox
            // 
            resources.ApplyResources(this.LogoPictureBox, "LogoPictureBox");
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.TabStop = false;
            // 
            // CloseButton
            // 
            resources.ApplyResources(this.CloseButton, "CloseButton");
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // MainTabControl
            // 
            resources.ApplyResources(this.MainTabControl, "MainTabControl");
            this.MainTabControl.Controls.Add(this.ColumnToolsTabPage);
            this.MainTabControl.Controls.Add(this.SqlServerToolsTabPage);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            // 
            // ColumnToolsTabPage
            // 
            this.ColumnToolsTabPage.Controls.Add(this.ExpressionColumnGroupBox);
            this.ColumnToolsTabPage.Controls.Add(this.ChangeColumnTypeGroupBox);
            resources.ApplyResources(this.ColumnToolsTabPage, "ColumnToolsTabPage");
            this.ColumnToolsTabPage.Name = "ColumnToolsTabPage";
            this.ColumnToolsTabPage.UseVisualStyleBackColor = true;
            // 
            // ExpressionColumnGroupBox
            // 
            this.ExpressionColumnGroupBox.Controls.Add(this.ExpressionColumnExpressionGroupBox);
            this.ExpressionColumnGroupBox.Controls.Add(this.ExpressionColumnNameTextBox);
            this.ExpressionColumnGroupBox.Controls.Add(this.ExpressionColumnAddButton);
            this.ExpressionColumnGroupBox.Controls.Add(this.ExpressionColumnNameLabel);
            resources.ApplyResources(this.ExpressionColumnGroupBox, "ExpressionColumnGroupBox");
            this.ExpressionColumnGroupBox.Name = "ExpressionColumnGroupBox";
            this.ExpressionColumnGroupBox.TabStop = false;
            // 
            // ExpressionColumnExpressionGroupBox
            // 
            this.ExpressionColumnExpressionGroupBox.Controls.Add(this.ExpressionColumnExpressionTextBox);
            resources.ApplyResources(this.ExpressionColumnExpressionGroupBox, "ExpressionColumnExpressionGroupBox");
            this.ExpressionColumnExpressionGroupBox.Name = "ExpressionColumnExpressionGroupBox";
            this.ExpressionColumnExpressionGroupBox.TabStop = false;
            // 
            // ExpressionColumnExpressionTextBox
            // 
            resources.ApplyResources(this.ExpressionColumnExpressionTextBox, "ExpressionColumnExpressionTextBox");
            this.ExpressionColumnExpressionTextBox.Name = "ExpressionColumnExpressionTextBox";
            // 
            // ExpressionColumnNameTextBox
            // 
            resources.ApplyResources(this.ExpressionColumnNameTextBox, "ExpressionColumnNameTextBox");
            this.ExpressionColumnNameTextBox.Name = "ExpressionColumnNameTextBox";
            // 
            // ExpressionColumnAddButton
            // 
            resources.ApplyResources(this.ExpressionColumnAddButton, "ExpressionColumnAddButton");
            this.ExpressionColumnAddButton.Name = "ExpressionColumnAddButton";
            this.ExpressionColumnAddButton.UseVisualStyleBackColor = true;
            // 
            // ExpressionColumnNameLabel
            // 
            resources.ApplyResources(this.ExpressionColumnNameLabel, "ExpressionColumnNameLabel");
            this.ExpressionColumnNameLabel.Name = "ExpressionColumnNameLabel";
            // 
            // ChangeColumnTypeGroupBox
            // 
            this.ChangeColumnTypeGroupBox.Controls.Add(this.ChangeColumnTypeButton);
            this.ChangeColumnTypeGroupBox.Controls.Add(this.ChangeColumnTypeDataTypeComboBox);
            this.ChangeColumnTypeGroupBox.Controls.Add(this.ChangeColumnTypeDataTypeLabel);
            this.ChangeColumnTypeGroupBox.Controls.Add(this.ChangeColumnTypeColumnComboBox);
            this.ChangeColumnTypeGroupBox.Controls.Add(this.ChangeColumnTypeColumnLabel);
            resources.ApplyResources(this.ChangeColumnTypeGroupBox, "ChangeColumnTypeGroupBox");
            this.ChangeColumnTypeGroupBox.Name = "ChangeColumnTypeGroupBox";
            this.ChangeColumnTypeGroupBox.TabStop = false;
            // 
            // ChangeColumnTypeButton
            // 
            resources.ApplyResources(this.ChangeColumnTypeButton, "ChangeColumnTypeButton");
            this.ChangeColumnTypeButton.Name = "ChangeColumnTypeButton";
            this.ChangeColumnTypeButton.UseVisualStyleBackColor = true;
            this.ChangeColumnTypeButton.Click += new System.EventHandler(this.ChangeColumnTypeButton_Click);
            // 
            // ChangeColumnTypeDataTypeComboBox
            // 
            resources.ApplyResources(this.ChangeColumnTypeDataTypeComboBox, "ChangeColumnTypeDataTypeComboBox");
            this.ChangeColumnTypeDataTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChangeColumnTypeDataTypeComboBox.FormattingEnabled = true;
            this.ChangeColumnTypeDataTypeComboBox.Name = "ChangeColumnTypeDataTypeComboBox";
            // 
            // ChangeColumnTypeDataTypeLabel
            // 
            resources.ApplyResources(this.ChangeColumnTypeDataTypeLabel, "ChangeColumnTypeDataTypeLabel");
            this.ChangeColumnTypeDataTypeLabel.Name = "ChangeColumnTypeDataTypeLabel";
            // 
            // ChangeColumnTypeColumnComboBox
            // 
            resources.ApplyResources(this.ChangeColumnTypeColumnComboBox, "ChangeColumnTypeColumnComboBox");
            this.ChangeColumnTypeColumnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChangeColumnTypeColumnComboBox.FormattingEnabled = true;
            this.ChangeColumnTypeColumnComboBox.Name = "ChangeColumnTypeColumnComboBox";
            // 
            // ChangeColumnTypeColumnLabel
            // 
            resources.ApplyResources(this.ChangeColumnTypeColumnLabel, "ChangeColumnTypeColumnLabel");
            this.ChangeColumnTypeColumnLabel.Name = "ChangeColumnTypeColumnLabel";
            // 
            // SqlServerToolsTabPage
            // 
            this.SqlServerToolsTabPage.Controls.Add(this.SQLExportDataGroupBox);
            this.SqlServerToolsTabPage.Controls.Add(this.SQLImportDataGroupBox);
            this.SqlServerToolsTabPage.Controls.Add(this.SQLConnectionStringGroupBox);
            resources.ApplyResources(this.SqlServerToolsTabPage, "SqlServerToolsTabPage");
            this.SqlServerToolsTabPage.Name = "SqlServerToolsTabPage";
            this.SqlServerToolsTabPage.UseVisualStyleBackColor = true;
            // 
            // SQLExportDataGroupBox
            // 
            this.SQLExportDataGroupBox.Controls.Add(this.SQLExportPostEventButton);
            this.SQLExportDataGroupBox.Controls.Add(this.SQLExportPreEventButton);
            this.SQLExportDataGroupBox.Controls.Add(this.SQLExportPostEventCheckBox);
            this.SQLExportDataGroupBox.Controls.Add(this.SQLExportPreEventCheckBox);
            this.SQLExportDataGroupBox.Controls.Add(this.SQLExportFieldMappingGroupBox);
            this.SQLExportDataGroupBox.Controls.Add(this.SQLExportTargetComboBox);
            this.SQLExportDataGroupBox.Controls.Add(this.SQLExportTargetLabel);
            resources.ApplyResources(this.SQLExportDataGroupBox, "SQLExportDataGroupBox");
            this.SQLExportDataGroupBox.Name = "SQLExportDataGroupBox";
            this.SQLExportDataGroupBox.TabStop = false;
            // 
            // SQLExportPostEventButton
            // 
            resources.ApplyResources(this.SQLExportPostEventButton, "SQLExportPostEventButton");
            this.SQLExportPostEventButton.Name = "SQLExportPostEventButton";
            this.SQLExportPostEventButton.UseVisualStyleBackColor = true;
            // 
            // SQLExportPreEventButton
            // 
            resources.ApplyResources(this.SQLExportPreEventButton, "SQLExportPreEventButton");
            this.SQLExportPreEventButton.Name = "SQLExportPreEventButton";
            this.SQLExportPreEventButton.UseVisualStyleBackColor = true;
            // 
            // SQLExportPostEventCheckBox
            // 
            resources.ApplyResources(this.SQLExportPostEventCheckBox, "SQLExportPostEventCheckBox");
            this.SQLExportPostEventCheckBox.Name = "SQLExportPostEventCheckBox";
            this.SQLExportPostEventCheckBox.UseVisualStyleBackColor = true;
            // 
            // SQLExportPreEventCheckBox
            // 
            resources.ApplyResources(this.SQLExportPreEventCheckBox, "SQLExportPreEventCheckBox");
            this.SQLExportPreEventCheckBox.Name = "SQLExportPreEventCheckBox";
            this.SQLExportPreEventCheckBox.UseVisualStyleBackColor = true;
            // 
            // SQLExportFieldMappingGroupBox
            // 
            resources.ApplyResources(this.SQLExportFieldMappingGroupBox, "SQLExportFieldMappingGroupBox");
            this.SQLExportFieldMappingGroupBox.Controls.Add(this.SQLExportFieldMappingRemoveButton);
            this.SQLExportFieldMappingGroupBox.Controls.Add(this.SQLExportFieldMappingAddButton);
            this.SQLExportFieldMappingGroupBox.Controls.Add(this.SQLExportFieldMappingListBox);
            this.SQLExportFieldMappingGroupBox.Name = "SQLExportFieldMappingGroupBox";
            this.SQLExportFieldMappingGroupBox.TabStop = false;
            // 
            // SQLExportFieldMappingRemoveButton
            // 
            resources.ApplyResources(this.SQLExportFieldMappingRemoveButton, "SQLExportFieldMappingRemoveButton");
            this.SQLExportFieldMappingRemoveButton.Name = "SQLExportFieldMappingRemoveButton";
            this.SQLExportFieldMappingRemoveButton.UseVisualStyleBackColor = true;
            // 
            // SQLExportFieldMappingAddButton
            // 
            resources.ApplyResources(this.SQLExportFieldMappingAddButton, "SQLExportFieldMappingAddButton");
            this.SQLExportFieldMappingAddButton.Name = "SQLExportFieldMappingAddButton";
            this.SQLExportFieldMappingAddButton.UseVisualStyleBackColor = true;
            // 
            // SQLExportFieldMappingListBox
            // 
            this.SQLExportFieldMappingListBox.FormattingEnabled = true;
            resources.ApplyResources(this.SQLExportFieldMappingListBox, "SQLExportFieldMappingListBox");
            this.SQLExportFieldMappingListBox.Name = "SQLExportFieldMappingListBox";
            // 
            // SQLExportTargetComboBox
            // 
            resources.ApplyResources(this.SQLExportTargetComboBox, "SQLExportTargetComboBox");
            this.SQLExportTargetComboBox.FormattingEnabled = true;
            this.SQLExportTargetComboBox.Name = "SQLExportTargetComboBox";
            // 
            // SQLExportTargetLabel
            // 
            resources.ApplyResources(this.SQLExportTargetLabel, "SQLExportTargetLabel");
            this.SQLExportTargetLabel.Name = "SQLExportTargetLabel";
            // 
            // SQLImportDataGroupBox
            // 
            this.SQLImportDataGroupBox.Controls.Add(this.SQLImportSourceGroupBox);
            this.SQLImportDataGroupBox.Controls.Add(this.SQLImportTargetComboBox);
            this.SQLImportDataGroupBox.Controls.Add(this.SQLImportTargetLabel);
            resources.ApplyResources(this.SQLImportDataGroupBox, "SQLImportDataGroupBox");
            this.SQLImportDataGroupBox.Name = "SQLImportDataGroupBox";
            this.SQLImportDataGroupBox.TabStop = false;
            // 
            // SQLImportSourceGroupBox
            // 
            resources.ApplyResources(this.SQLImportSourceGroupBox, "SQLImportSourceGroupBox");
            this.SQLImportSourceGroupBox.Controls.Add(this.SQLImportSourceCustomButton);
            this.SQLImportSourceGroupBox.Controls.Add(this.SQLImportSourceViewComboBox);
            this.SQLImportSourceGroupBox.Controls.Add(this.SQLImportSourceTableComboBox);
            this.SQLImportSourceGroupBox.Controls.Add(this.SQLImportSourceCustomRadioButton);
            this.SQLImportSourceGroupBox.Controls.Add(this.SQLImportSourceViewRadioButton);
            this.SQLImportSourceGroupBox.Controls.Add(this.SQLImportSourceTableRadioButton);
            this.SQLImportSourceGroupBox.Name = "SQLImportSourceGroupBox";
            this.SQLImportSourceGroupBox.TabStop = false;
            // 
            // SQLImportSourceCustomButton
            // 
            resources.ApplyResources(this.SQLImportSourceCustomButton, "SQLImportSourceCustomButton");
            this.SQLImportSourceCustomButton.Name = "SQLImportSourceCustomButton";
            this.SQLImportSourceCustomButton.UseVisualStyleBackColor = true;
            // 
            // SQLImportSourceViewComboBox
            // 
            resources.ApplyResources(this.SQLImportSourceViewComboBox, "SQLImportSourceViewComboBox");
            this.SQLImportSourceViewComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SQLImportSourceViewComboBox.FormattingEnabled = true;
            this.SQLImportSourceViewComboBox.Name = "SQLImportSourceViewComboBox";
            // 
            // SQLImportSourceTableComboBox
            // 
            resources.ApplyResources(this.SQLImportSourceTableComboBox, "SQLImportSourceTableComboBox");
            this.SQLImportSourceTableComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SQLImportSourceTableComboBox.FormattingEnabled = true;
            this.SQLImportSourceTableComboBox.Name = "SQLImportSourceTableComboBox";
            // 
            // SQLImportSourceCustomRadioButton
            // 
            resources.ApplyResources(this.SQLImportSourceCustomRadioButton, "SQLImportSourceCustomRadioButton");
            this.SQLImportSourceCustomRadioButton.Name = "SQLImportSourceCustomRadioButton";
            this.SQLImportSourceCustomRadioButton.TabStop = true;
            this.SQLImportSourceCustomRadioButton.UseVisualStyleBackColor = true;
            // 
            // SQLImportSourceViewRadioButton
            // 
            resources.ApplyResources(this.SQLImportSourceViewRadioButton, "SQLImportSourceViewRadioButton");
            this.SQLImportSourceViewRadioButton.Name = "SQLImportSourceViewRadioButton";
            this.SQLImportSourceViewRadioButton.TabStop = true;
            this.SQLImportSourceViewRadioButton.UseVisualStyleBackColor = true;
            // 
            // SQLImportSourceTableRadioButton
            // 
            resources.ApplyResources(this.SQLImportSourceTableRadioButton, "SQLImportSourceTableRadioButton");
            this.SQLImportSourceTableRadioButton.Name = "SQLImportSourceTableRadioButton";
            this.SQLImportSourceTableRadioButton.TabStop = true;
            this.SQLImportSourceTableRadioButton.UseVisualStyleBackColor = true;
            // 
            // SQLImportTargetComboBox
            // 
            resources.ApplyResources(this.SQLImportTargetComboBox, "SQLImportTargetComboBox");
            this.SQLImportTargetComboBox.FormattingEnabled = true;
            this.SQLImportTargetComboBox.Name = "SQLImportTargetComboBox";
            // 
            // SQLImportTargetLabel
            // 
            resources.ApplyResources(this.SQLImportTargetLabel, "SQLImportTargetLabel");
            this.SQLImportTargetLabel.Name = "SQLImportTargetLabel";
            // 
            // SQLConnectionStringGroupBox
            // 
            this.SQLConnectionStringGroupBox.Controls.Add(this.SQLConnectionStringHelpLabel);
            this.SQLConnectionStringGroupBox.Controls.Add(this.SQLConnectionStatusLabel);
            this.SQLConnectionStringGroupBox.Controls.Add(this.SQLConnectButton);
            this.SQLConnectionStringGroupBox.Controls.Add(this.SQLConnectionStringTextBox);
            resources.ApplyResources(this.SQLConnectionStringGroupBox, "SQLConnectionStringGroupBox");
            this.SQLConnectionStringGroupBox.Name = "SQLConnectionStringGroupBox";
            this.SQLConnectionStringGroupBox.TabStop = false;
            // 
            // SQLConnectionStringHelpLabel
            // 
            resources.ApplyResources(this.SQLConnectionStringHelpLabel, "SQLConnectionStringHelpLabel");
            this.SQLConnectionStringHelpLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SQLConnectionStringHelpLabel.ForeColor = System.Drawing.Color.Blue;
            this.SQLConnectionStringHelpLabel.Name = "SQLConnectionStringHelpLabel";
            // 
            // SQLConnectionStatusLabel
            // 
            resources.ApplyResources(this.SQLConnectionStatusLabel, "SQLConnectionStatusLabel");
            this.SQLConnectionStatusLabel.Name = "SQLConnectionStatusLabel";
            // 
            // SQLConnectButton
            // 
            resources.ApplyResources(this.SQLConnectButton, "SQLConnectButton");
            this.SQLConnectButton.Name = "SQLConnectButton";
            this.SQLConnectButton.UseVisualStyleBackColor = true;
            // 
            // SQLConnectionStringTextBox
            // 
            resources.ApplyResources(this.SQLConnectionStringTextBox, "SQLConnectionStringTextBox");
            this.SQLConnectionStringTextBox.Name = "SQLConnectionStringTextBox";
            // 
            // DataTableLabel
            // 
            resources.ApplyResources(this.DataTableLabel, "DataTableLabel");
            this.DataTableLabel.Name = "DataTableLabel";
            // 
            // DataTableComboBox
            // 
            this.DataTableComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataTableComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.DataTableComboBox, "DataTableComboBox");
            this.DataTableComboBox.Name = "DataTableComboBox";
            this.DataTableComboBox.SelectedIndexChanged += new System.EventHandler(this.DataTableComboBox_SelectedIndexChanged);
            // 
            // ToolsDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataTableComboBox);
            this.Controls.Add(this.DataTableLabel);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.OpenConfigurationPictureBox);
            this.Controls.Add(this.HelpLinkPictureBox);
            this.Name = "ToolsDialog";
            this.Load += new System.EventHandler(this.ToolsDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OpenConfigurationPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpLinkPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.MainTabControl.ResumeLayout(false);
            this.ColumnToolsTabPage.ResumeLayout(false);
            this.ExpressionColumnGroupBox.ResumeLayout(false);
            this.ExpressionColumnGroupBox.PerformLayout();
            this.ExpressionColumnExpressionGroupBox.ResumeLayout(false);
            this.ExpressionColumnExpressionGroupBox.PerformLayout();
            this.ChangeColumnTypeGroupBox.ResumeLayout(false);
            this.ChangeColumnTypeGroupBox.PerformLayout();
            this.SqlServerToolsTabPage.ResumeLayout(false);
            this.SQLExportDataGroupBox.ResumeLayout(false);
            this.SQLExportDataGroupBox.PerformLayout();
            this.SQLExportFieldMappingGroupBox.ResumeLayout(false);
            this.SQLImportDataGroupBox.ResumeLayout(false);
            this.SQLImportDataGroupBox.PerformLayout();
            this.SQLImportSourceGroupBox.ResumeLayout(false);
            this.SQLImportSourceGroupBox.PerformLayout();
            this.SQLConnectionStringGroupBox.ResumeLayout(false);
            this.SQLConnectionStringGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox OpenConfigurationPictureBox;
    private System.Windows.Forms.PictureBox HelpLinkPictureBox;
    private System.Windows.Forms.PictureBox LogoPictureBox;
    private System.Windows.Forms.Button CloseButton;
    private System.Windows.Forms.TabControl MainTabControl;
    private System.Windows.Forms.TabPage ColumnToolsTabPage;
    private System.Windows.Forms.TabPage SqlServerToolsTabPage;
    private System.Windows.Forms.Label DataTableLabel;
    private System.Windows.Forms.ComboBox DataTableComboBox;
    private System.Windows.Forms.GroupBox ChangeColumnTypeGroupBox;
    private System.Windows.Forms.ComboBox ChangeColumnTypeColumnComboBox;
    private System.Windows.Forms.Label ChangeColumnTypeColumnLabel;
    private System.Windows.Forms.ComboBox ChangeColumnTypeDataTypeComboBox;
    private System.Windows.Forms.Label ChangeColumnTypeDataTypeLabel;
    private System.Windows.Forms.Button ChangeColumnTypeButton;
    private System.Windows.Forms.TextBox SQLConnectionStringTextBox;
    private System.Windows.Forms.GroupBox SQLConnectionStringGroupBox;
    private System.Windows.Forms.Button SQLConnectButton;
    private System.Windows.Forms.Label SQLConnectionStatusLabel;
    private System.Windows.Forms.Label SQLConnectionStringHelpLabel;
    private System.Windows.Forms.GroupBox SQLImportDataGroupBox;
    private System.Windows.Forms.ComboBox SQLImportTargetComboBox;
    private System.Windows.Forms.Label SQLImportTargetLabel;
    private System.Windows.Forms.GroupBox SQLImportSourceGroupBox;
    private System.Windows.Forms.ComboBox SQLImportSourceTableComboBox;
    private System.Windows.Forms.RadioButton SQLImportSourceCustomRadioButton;
    private System.Windows.Forms.RadioButton SQLImportSourceViewRadioButton;
    private System.Windows.Forms.RadioButton SQLImportSourceTableRadioButton;
    private System.Windows.Forms.Button SQLImportSourceCustomButton;
    private System.Windows.Forms.ComboBox SQLImportSourceViewComboBox;
    private System.Windows.Forms.GroupBox ExpressionColumnGroupBox;
    private System.Windows.Forms.TextBox ExpressionColumnNameTextBox;
    private System.Windows.Forms.Button ExpressionColumnAddButton;
    private System.Windows.Forms.Label ExpressionColumnNameLabel;
    private System.Windows.Forms.GroupBox ExpressionColumnExpressionGroupBox;
    private System.Windows.Forms.TextBox ExpressionColumnExpressionTextBox;
    private System.Windows.Forms.GroupBox SQLExportDataGroupBox;
    private System.Windows.Forms.GroupBox SQLExportFieldMappingGroupBox;
    private System.Windows.Forms.ComboBox SQLExportTargetComboBox;
    private System.Windows.Forms.Label SQLExportTargetLabel;
    private System.Windows.Forms.CheckBox SQLExportPostEventCheckBox;
    private System.Windows.Forms.CheckBox SQLExportPreEventCheckBox;
    private System.Windows.Forms.Button SQLExportPostEventButton;
    private System.Windows.Forms.Button SQLExportPreEventButton;
    private System.Windows.Forms.ListBox SQLExportFieldMappingListBox;
    private System.Windows.Forms.Button SQLExportFieldMappingRemoveButton;
    private System.Windows.Forms.Button SQLExportFieldMappingAddButton;
}