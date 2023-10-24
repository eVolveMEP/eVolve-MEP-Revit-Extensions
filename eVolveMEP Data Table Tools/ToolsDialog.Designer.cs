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
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.ColumnToolsTabPage = new System.Windows.Forms.TabPage();
            this.ColumnInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.ColumnInfoDataGridView = new System.Windows.Forms.DataGridView();
            this.ExpressionColumnGroupBox = new System.Windows.Forms.GroupBox();
            this.ExpressionColumnDataTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ExpressionColumnDataTypeLabel = new System.Windows.Forms.Label();
            this.ExpressionColumnExpressionGroupBox = new System.Windows.Forms.GroupBox();
            this.DataTableExpressionHelpLabel = new System.Windows.Forms.Label();
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
            this.SQLCustomOperationsGoupBox = new System.Windows.Forms.GroupBox();
            this.SQLExportPreEventCheckBox = new System.Windows.Forms.CheckBox();
            this.SQLExportPostEventCheckBox = new System.Windows.Forms.CheckBox();
            this.SQLExportPostEventButton = new System.Windows.Forms.Button();
            this.SQLExportPreEventButton = new System.Windows.Forms.Button();
            this.SQLExportExecuteButton = new System.Windows.Forms.Button();
            this.SQLExportFieldMappingGroupBox = new System.Windows.Forms.GroupBox();
            this.SQLExportFieldMappingRemoveButton = new System.Windows.Forms.Button();
            this.SQLExportFieldMappingAddButton = new System.Windows.Forms.Button();
            this.SQLExportFieldMappingListBox = new System.Windows.Forms.ListBox();
            this.SQLExportTargetComboBox = new System.Windows.Forms.ComboBox();
            this.SQLExportTargetLabel = new System.Windows.Forms.Label();
            this.SQLImportDataGroupBox = new System.Windows.Forms.GroupBox();
            this.SQLImportExecuteButton = new System.Windows.Forms.Button();
            this.SQLImportSourceGroupBox = new System.Windows.Forms.GroupBox();
            this.SQLImportSourceCustomButton = new System.Windows.Forms.Button();
            this.SQLImportSourceViewComboBox = new System.Windows.Forms.ComboBox();
            this.SQLImportSourceTableComboBox = new System.Windows.Forms.ComboBox();
            this.SQLImportSourceCustomRadioButton = new System.Windows.Forms.RadioButton();
            this.SQLImportSourceViewRadioButton = new System.Windows.Forms.RadioButton();
            this.SQLImportSourceTableRadioButton = new System.Windows.Forms.RadioButton();
            this.SQLConnectionStringGroupBox = new System.Windows.Forms.GroupBox();
            this.SQLConnectionStringHelpLabel = new System.Windows.Forms.Label();
            this.SQLConnectionStatusLabel = new System.Windows.Forms.Label();
            this.SQLConnectButton = new System.Windows.Forms.Button();
            this.SQLConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.ResetDataTabPage = new System.Windows.Forms.TabPage();
            this.ResetEntireConfigurationGroupBox = new System.Windows.Forms.GroupBox();
            this.ResetEntireConfigurationButton = new System.Windows.Forms.Button();
            this.ResetSelectedConfigurationButton = new System.Windows.Forms.Button();
            this.DataTableLabel = new System.Windows.Forms.Label();
            this.DataTableComboBox = new System.Windows.Forms.ComboBox();
            this.ViewSourceCodeLabel = new System.Windows.Forms.Label();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.OK_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OpenConfigurationPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpLinkPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.MainTabControl.SuspendLayout();
            this.ColumnToolsTabPage.SuspendLayout();
            this.ColumnInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnInfoDataGridView)).BeginInit();
            this.ExpressionColumnGroupBox.SuspendLayout();
            this.ExpressionColumnExpressionGroupBox.SuspendLayout();
            this.ChangeColumnTypeGroupBox.SuspendLayout();
            this.SqlServerToolsTabPage.SuspendLayout();
            this.SQLExportDataGroupBox.SuspendLayout();
            this.SQLCustomOperationsGoupBox.SuspendLayout();
            this.SQLExportFieldMappingGroupBox.SuspendLayout();
            this.SQLImportDataGroupBox.SuspendLayout();
            this.SQLImportSourceGroupBox.SuspendLayout();
            this.SQLConnectionStringGroupBox.SuspendLayout();
            this.ResetDataTabPage.SuspendLayout();
            this.ResetEntireConfigurationGroupBox.SuspendLayout();
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
            // MainTabControl
            // 
            resources.ApplyResources(this.MainTabControl, "MainTabControl");
            this.MainTabControl.Controls.Add(this.ColumnToolsTabPage);
            this.MainTabControl.Controls.Add(this.SqlServerToolsTabPage);
            this.MainTabControl.Controls.Add(this.ResetDataTabPage);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            // 
            // ColumnToolsTabPage
            // 
            this.ColumnToolsTabPage.Controls.Add(this.ColumnInfoGroupBox);
            this.ColumnToolsTabPage.Controls.Add(this.ExpressionColumnGroupBox);
            this.ColumnToolsTabPage.Controls.Add(this.ChangeColumnTypeGroupBox);
            resources.ApplyResources(this.ColumnToolsTabPage, "ColumnToolsTabPage");
            this.ColumnToolsTabPage.Name = "ColumnToolsTabPage";
            this.ColumnToolsTabPage.UseVisualStyleBackColor = true;
            // 
            // ColumnInfoGroupBox
            // 
            resources.ApplyResources(this.ColumnInfoGroupBox, "ColumnInfoGroupBox");
            this.ColumnInfoGroupBox.Controls.Add(this.ColumnInfoDataGridView);
            this.ColumnInfoGroupBox.Name = "ColumnInfoGroupBox";
            this.ColumnInfoGroupBox.TabStop = false;
            // 
            // ColumnInfoDataGridView
            // 
            this.ColumnInfoDataGridView.AllowUserToAddRows = false;
            this.ColumnInfoDataGridView.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.ColumnInfoDataGridView, "ColumnInfoDataGridView");
            this.ColumnInfoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ColumnInfoDataGridView.Name = "ColumnInfoDataGridView";
            this.ColumnInfoDataGridView.ReadOnly = true;
            // 
            // ExpressionColumnGroupBox
            // 
            this.ExpressionColumnGroupBox.Controls.Add(this.ExpressionColumnDataTypeComboBox);
            this.ExpressionColumnGroupBox.Controls.Add(this.ExpressionColumnDataTypeLabel);
            this.ExpressionColumnGroupBox.Controls.Add(this.ExpressionColumnExpressionGroupBox);
            this.ExpressionColumnGroupBox.Controls.Add(this.ExpressionColumnNameTextBox);
            this.ExpressionColumnGroupBox.Controls.Add(this.ExpressionColumnAddButton);
            this.ExpressionColumnGroupBox.Controls.Add(this.ExpressionColumnNameLabel);
            resources.ApplyResources(this.ExpressionColumnGroupBox, "ExpressionColumnGroupBox");
            this.ExpressionColumnGroupBox.Name = "ExpressionColumnGroupBox";
            this.ExpressionColumnGroupBox.TabStop = false;
            // 
            // ExpressionColumnDataTypeComboBox
            // 
            resources.ApplyResources(this.ExpressionColumnDataTypeComboBox, "ExpressionColumnDataTypeComboBox");
            this.ExpressionColumnDataTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ExpressionColumnDataTypeComboBox.FormattingEnabled = true;
            this.ExpressionColumnDataTypeComboBox.Name = "ExpressionColumnDataTypeComboBox";
            // 
            // ExpressionColumnDataTypeLabel
            // 
            resources.ApplyResources(this.ExpressionColumnDataTypeLabel, "ExpressionColumnDataTypeLabel");
            this.ExpressionColumnDataTypeLabel.Name = "ExpressionColumnDataTypeLabel";
            // 
            // ExpressionColumnExpressionGroupBox
            // 
            this.ExpressionColumnExpressionGroupBox.Controls.Add(this.DataTableExpressionHelpLabel);
            this.ExpressionColumnExpressionGroupBox.Controls.Add(this.ExpressionColumnExpressionTextBox);
            resources.ApplyResources(this.ExpressionColumnExpressionGroupBox, "ExpressionColumnExpressionGroupBox");
            this.ExpressionColumnExpressionGroupBox.Name = "ExpressionColumnExpressionGroupBox";
            this.ExpressionColumnExpressionGroupBox.TabStop = false;
            // 
            // DataTableExpressionHelpLabel
            // 
            resources.ApplyResources(this.DataTableExpressionHelpLabel, "DataTableExpressionHelpLabel");
            this.DataTableExpressionHelpLabel.ForeColor = System.Drawing.Color.Blue;
            this.DataTableExpressionHelpLabel.Name = "DataTableExpressionHelpLabel";
            this.DataTableExpressionHelpLabel.Tag = "https://learn.microsoft.com/en-us/dotnet/api/system.data.datacolumn.expression?vi" +
    "ew=netframework-4.8#expression-syntax";
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
            this.ExpressionColumnAddButton.Click += new System.EventHandler(this.ExpressionColumnAddButton_Click);
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
            resources.ApplyResources(this.SQLExportDataGroupBox, "SQLExportDataGroupBox");
            this.SQLExportDataGroupBox.Controls.Add(this.SQLCustomOperationsGoupBox);
            this.SQLExportDataGroupBox.Controls.Add(this.SQLExportExecuteButton);
            this.SQLExportDataGroupBox.Controls.Add(this.SQLExportFieldMappingGroupBox);
            this.SQLExportDataGroupBox.Controls.Add(this.SQLExportTargetComboBox);
            this.SQLExportDataGroupBox.Controls.Add(this.SQLExportTargetLabel);
            this.SQLExportDataGroupBox.Name = "SQLExportDataGroupBox";
            this.SQLExportDataGroupBox.TabStop = false;
            // 
            // SQLCustomOperationsGoupBox
            // 
            resources.ApplyResources(this.SQLCustomOperationsGoupBox, "SQLCustomOperationsGoupBox");
            this.SQLCustomOperationsGoupBox.Controls.Add(this.SQLExportPreEventCheckBox);
            this.SQLCustomOperationsGoupBox.Controls.Add(this.SQLExportPostEventCheckBox);
            this.SQLCustomOperationsGoupBox.Controls.Add(this.SQLExportPostEventButton);
            this.SQLCustomOperationsGoupBox.Controls.Add(this.SQLExportPreEventButton);
            this.SQLCustomOperationsGoupBox.Name = "SQLCustomOperationsGoupBox";
            this.SQLCustomOperationsGoupBox.TabStop = false;
            // 
            // SQLExportPreEventCheckBox
            // 
            resources.ApplyResources(this.SQLExportPreEventCheckBox, "SQLExportPreEventCheckBox");
            this.SQLExportPreEventCheckBox.Name = "SQLExportPreEventCheckBox";
            this.SQLExportPreEventCheckBox.UseVisualStyleBackColor = true;
            // 
            // SQLExportPostEventCheckBox
            // 
            resources.ApplyResources(this.SQLExportPostEventCheckBox, "SQLExportPostEventCheckBox");
            this.SQLExportPostEventCheckBox.Name = "SQLExportPostEventCheckBox";
            this.SQLExportPostEventCheckBox.UseVisualStyleBackColor = true;
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
            // SQLExportExecuteButton
            // 
            resources.ApplyResources(this.SQLExportExecuteButton, "SQLExportExecuteButton");
            this.SQLExportExecuteButton.Name = "SQLExportExecuteButton";
            this.SQLExportExecuteButton.UseVisualStyleBackColor = true;
            this.SQLExportExecuteButton.Click += new System.EventHandler(this.SQLExportExecuteButton_Click);
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
            this.SQLExportFieldMappingRemoveButton.Click += new System.EventHandler(this.SQLExportFieldMappingRemoveButton_Click);
            // 
            // SQLExportFieldMappingAddButton
            // 
            resources.ApplyResources(this.SQLExportFieldMappingAddButton, "SQLExportFieldMappingAddButton");
            this.SQLExportFieldMappingAddButton.Name = "SQLExportFieldMappingAddButton";
            this.SQLExportFieldMappingAddButton.UseVisualStyleBackColor = true;
            this.SQLExportFieldMappingAddButton.Click += new System.EventHandler(this.SQLExportFieldMappingAddButton_Click);
            // 
            // SQLExportFieldMappingListBox
            // 
            resources.ApplyResources(this.SQLExportFieldMappingListBox, "SQLExportFieldMappingListBox");
            this.SQLExportFieldMappingListBox.FormattingEnabled = true;
            this.SQLExportFieldMappingListBox.Name = "SQLExportFieldMappingListBox";
            this.SQLExportFieldMappingListBox.Sorted = true;
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
            this.SQLImportDataGroupBox.Controls.Add(this.SQLImportExecuteButton);
            this.SQLImportDataGroupBox.Controls.Add(this.SQLImportSourceGroupBox);
            resources.ApplyResources(this.SQLImportDataGroupBox, "SQLImportDataGroupBox");
            this.SQLImportDataGroupBox.Name = "SQLImportDataGroupBox";
            this.SQLImportDataGroupBox.TabStop = false;
            // 
            // SQLImportExecuteButton
            // 
            resources.ApplyResources(this.SQLImportExecuteButton, "SQLImportExecuteButton");
            this.SQLImportExecuteButton.Name = "SQLImportExecuteButton";
            this.SQLImportExecuteButton.UseVisualStyleBackColor = true;
            this.SQLImportExecuteButton.Click += new System.EventHandler(this.SQLImportExecuteButton_Click);
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
            this.SQLImportSourceViewComboBox.FormattingEnabled = true;
            this.SQLImportSourceViewComboBox.Name = "SQLImportSourceViewComboBox";
            // 
            // SQLImportSourceTableComboBox
            // 
            resources.ApplyResources(this.SQLImportSourceTableComboBox, "SQLImportSourceTableComboBox");
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
            // SQLConnectionStringGroupBox
            // 
            resources.ApplyResources(this.SQLConnectionStringGroupBox, "SQLConnectionStringGroupBox");
            this.SQLConnectionStringGroupBox.Controls.Add(this.SQLConnectionStringHelpLabel);
            this.SQLConnectionStringGroupBox.Controls.Add(this.SQLConnectionStatusLabel);
            this.SQLConnectionStringGroupBox.Controls.Add(this.SQLConnectButton);
            this.SQLConnectionStringGroupBox.Controls.Add(this.SQLConnectionStringTextBox);
            this.SQLConnectionStringGroupBox.Name = "SQLConnectionStringGroupBox";
            this.SQLConnectionStringGroupBox.TabStop = false;
            // 
            // SQLConnectionStringHelpLabel
            // 
            resources.ApplyResources(this.SQLConnectionStringHelpLabel, "SQLConnectionStringHelpLabel");
            this.SQLConnectionStringHelpLabel.ForeColor = System.Drawing.Color.Blue;
            this.SQLConnectionStringHelpLabel.Name = "SQLConnectionStringHelpLabel";
            this.SQLConnectionStringHelpLabel.Tag = "https://www.connectionstrings.com/microsoft-data-sqlclient/";
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
            this.SQLConnectButton.Tag = "";
            this.SQLConnectButton.UseVisualStyleBackColor = true;
            this.SQLConnectButton.Click += new System.EventHandler(this.SQLConnectButton_Click);
            // 
            // SQLConnectionStringTextBox
            // 
            resources.ApplyResources(this.SQLConnectionStringTextBox, "SQLConnectionStringTextBox");
            this.SQLConnectionStringTextBox.Name = "SQLConnectionStringTextBox";
            // 
            // ResetDataTabPage
            // 
            this.ResetDataTabPage.Controls.Add(this.ResetEntireConfigurationGroupBox);
            this.ResetDataTabPage.Controls.Add(this.ResetSelectedConfigurationButton);
            resources.ApplyResources(this.ResetDataTabPage, "ResetDataTabPage");
            this.ResetDataTabPage.Name = "ResetDataTabPage";
            this.ResetDataTabPage.UseVisualStyleBackColor = true;
            // 
            // ResetEntireConfigurationGroupBox
            // 
            this.ResetEntireConfigurationGroupBox.Controls.Add(this.ResetEntireConfigurationButton);
            resources.ApplyResources(this.ResetEntireConfigurationGroupBox, "ResetEntireConfigurationGroupBox");
            this.ResetEntireConfigurationGroupBox.Name = "ResetEntireConfigurationGroupBox";
            this.ResetEntireConfigurationGroupBox.TabStop = false;
            // 
            // ResetEntireConfigurationButton
            // 
            resources.ApplyResources(this.ResetEntireConfigurationButton, "ResetEntireConfigurationButton");
            this.ResetEntireConfigurationButton.Name = "ResetEntireConfigurationButton";
            this.ResetEntireConfigurationButton.UseVisualStyleBackColor = true;
            this.ResetEntireConfigurationButton.Click += new System.EventHandler(this.ResetEntireConfigurationButton_Click);
            // 
            // ResetSelectedConfigurationButton
            // 
            resources.ApplyResources(this.ResetSelectedConfigurationButton, "ResetSelectedConfigurationButton");
            this.ResetSelectedConfigurationButton.Name = "ResetSelectedConfigurationButton";
            this.ResetSelectedConfigurationButton.UseVisualStyleBackColor = true;
            this.ResetSelectedConfigurationButton.Click += new System.EventHandler(this.ResetSelectedConfigurationButton_Click);
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
            // ViewSourceCodeLabel
            // 
            resources.ApplyResources(this.ViewSourceCodeLabel, "ViewSourceCodeLabel");
            this.ViewSourceCodeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ViewSourceCodeLabel.ForeColor = System.Drawing.Color.Blue;
            this.ViewSourceCodeLabel.Name = "ViewSourceCodeLabel";
            // 
            // ApplyButton
            // 
            resources.ApplyResources(this.ApplyButton, "ApplyButton");
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // Cancel_Button
            // 
            resources.ApplyResources(this.Cancel_Button, "Cancel_Button");
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // OK_Button
            // 
            resources.ApplyResources(this.OK_Button, "OK_Button");
            this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.UseVisualStyleBackColor = true;
            // 
            // ToolsDialog
            // 
            this.AcceptButton = this.OK_Button;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.ViewSourceCodeLabel);
            this.Controls.Add(this.DataTableComboBox);
            this.Controls.Add(this.DataTableLabel);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.OpenConfigurationPictureBox);
            this.Controls.Add(this.HelpLinkPictureBox);
            this.Name = "ToolsDialog";
            this.Load += new System.EventHandler(this.ToolsDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OpenConfigurationPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpLinkPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.MainTabControl.ResumeLayout(false);
            this.ColumnToolsTabPage.ResumeLayout(false);
            this.ColumnInfoGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ColumnInfoDataGridView)).EndInit();
            this.ExpressionColumnGroupBox.ResumeLayout(false);
            this.ExpressionColumnGroupBox.PerformLayout();
            this.ExpressionColumnExpressionGroupBox.ResumeLayout(false);
            this.ExpressionColumnExpressionGroupBox.PerformLayout();
            this.ChangeColumnTypeGroupBox.ResumeLayout(false);
            this.ChangeColumnTypeGroupBox.PerformLayout();
            this.SqlServerToolsTabPage.ResumeLayout(false);
            this.SQLExportDataGroupBox.ResumeLayout(false);
            this.SQLExportDataGroupBox.PerformLayout();
            this.SQLCustomOperationsGoupBox.ResumeLayout(false);
            this.SQLCustomOperationsGoupBox.PerformLayout();
            this.SQLExportFieldMappingGroupBox.ResumeLayout(false);
            this.SQLImportDataGroupBox.ResumeLayout(false);
            this.SQLImportSourceGroupBox.ResumeLayout(false);
            this.SQLImportSourceGroupBox.PerformLayout();
            this.SQLConnectionStringGroupBox.ResumeLayout(false);
            this.SQLConnectionStringGroupBox.PerformLayout();
            this.ResetDataTabPage.ResumeLayout(false);
            this.ResetEntireConfigurationGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox OpenConfigurationPictureBox;
    private System.Windows.Forms.PictureBox HelpLinkPictureBox;
    private System.Windows.Forms.PictureBox LogoPictureBox;
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
    private System.Windows.Forms.ComboBox ExpressionColumnDataTypeComboBox;
    private System.Windows.Forms.Label ExpressionColumnDataTypeLabel;
    private System.Windows.Forms.Button SQLExportExecuteButton;
    private System.Windows.Forms.Button SQLImportExecuteButton;
    private System.Windows.Forms.Label ViewSourceCodeLabel;
    private System.Windows.Forms.Label DataTableExpressionHelpLabel;
    private System.Windows.Forms.GroupBox ColumnInfoGroupBox;
    private System.Windows.Forms.DataGridView ColumnInfoDataGridView;
    private System.Windows.Forms.Button ApplyButton;
    private System.Windows.Forms.Button Cancel_Button;
    private System.Windows.Forms.Button OK_Button;
    private System.Windows.Forms.TabPage ResetDataTabPage;
    private System.Windows.Forms.Button ResetEntireConfigurationButton;
    private System.Windows.Forms.Button ResetSelectedConfigurationButton;
    private System.Windows.Forms.GroupBox ResetEntireConfigurationGroupBox;
    private System.Windows.Forms.GroupBox SQLCustomOperationsGoupBox;
}