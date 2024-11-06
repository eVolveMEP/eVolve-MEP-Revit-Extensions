namespace eVolve.DataTableTools.Revit.CopyTable;

partial class CopyTableDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopyTableDialog));
            this.ViewSourceCodeLabel = new System.Windows.Forms.Label();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.CopyGroupBox = new System.Windows.Forms.GroupBox();
            this.ReadOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.CopyButton = new System.Windows.Forms.Button();
            this.DestinationDataTableComboBox = new System.Windows.Forms.ComboBox();
            this.DestinationDataTableLabel = new System.Windows.Forms.Label();
            this.SourceDataTableLabel = new System.Windows.Forms.Label();
            this.SourceDataTableComboBox = new System.Windows.Forms.ComboBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.HelpLinkPictureBox = new System.Windows.Forms.PictureBox();
            this.OpenConfigurationPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.CopyGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HelpLinkPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpenConfigurationPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ViewSourceCodeLabel
            // 
            resources.ApplyResources(this.ViewSourceCodeLabel, "ViewSourceCodeLabel");
            this.ViewSourceCodeLabel.Name = "ViewSourceCodeLabel";
            // 
            // LogoPictureBox
            // 
            resources.ApplyResources(this.LogoPictureBox, "LogoPictureBox");
            this.LogoPictureBox.Image = global::eVolve.DataTableTools.Revit.Properties.Resources.Logo;
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.TabStop = false;
            // 
            // CloseButton
            // 
            resources.ApplyResources(this.CloseButton, "CloseButton");
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // CopyGroupBox
            // 
            resources.ApplyResources(this.CopyGroupBox, "CopyGroupBox");
            this.CopyGroupBox.Controls.Add(this.ReadOnlyCheckBox);
            this.CopyGroupBox.Controls.Add(this.CopyButton);
            this.CopyGroupBox.Controls.Add(this.DestinationDataTableComboBox);
            this.CopyGroupBox.Controls.Add(this.DestinationDataTableLabel);
            this.CopyGroupBox.Controls.Add(this.SourceDataTableLabel);
            this.CopyGroupBox.Controls.Add(this.SourceDataTableComboBox);
            this.CopyGroupBox.Name = "CopyGroupBox";
            this.CopyGroupBox.TabStop = false;
            // 
            // ReadOnlyCheckBox
            // 
            resources.ApplyResources(this.ReadOnlyCheckBox, "ReadOnlyCheckBox");
            this.ReadOnlyCheckBox.Name = "ReadOnlyCheckBox";
            this.ReadOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // CopyButton
            // 
            resources.ApplyResources(this.CopyButton, "CopyButton");
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.UseVisualStyleBackColor = true;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // DestinationDataTableComboBox
            // 
            resources.ApplyResources(this.DestinationDataTableComboBox, "DestinationDataTableComboBox");
            this.DestinationDataTableComboBox.FormattingEnabled = true;
            this.DestinationDataTableComboBox.Name = "DestinationDataTableComboBox";
            // 
            // DestinationDataTableLabel
            // 
            resources.ApplyResources(this.DestinationDataTableLabel, "DestinationDataTableLabel");
            this.DestinationDataTableLabel.Name = "DestinationDataTableLabel";
            // 
            // SourceDataTableLabel
            // 
            resources.ApplyResources(this.SourceDataTableLabel, "SourceDataTableLabel");
            this.SourceDataTableLabel.Name = "SourceDataTableLabel";
            // 
            // SourceDataTableComboBox
            // 
            resources.ApplyResources(this.SourceDataTableComboBox, "SourceDataTableComboBox");
            this.SourceDataTableComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SourceDataTableComboBox.FormattingEnabled = true;
            this.SourceDataTableComboBox.Name = "SourceDataTableComboBox";
            // 
            // InfoLabel
            // 
            resources.ApplyResources(this.InfoLabel, "InfoLabel");
            this.InfoLabel.Name = "InfoLabel";
            // 
            // HelpLinkPictureBox
            // 
            resources.ApplyResources(this.HelpLinkPictureBox, "HelpLinkPictureBox");
            this.HelpLinkPictureBox.Image = global::eVolve.DataTableTools.Revit.Properties.Resources.Help_Medium_20x20;
            this.HelpLinkPictureBox.Name = "HelpLinkPictureBox";
            this.HelpLinkPictureBox.TabStop = false;
            // 
            // OpenConfigurationPictureBox
            // 
            resources.ApplyResources(this.OpenConfigurationPictureBox, "OpenConfigurationPictureBox");
            this.OpenConfigurationPictureBox.Image = global::eVolve.DataTableTools.Revit.Properties.Resources.Settings_20x20;
            this.OpenConfigurationPictureBox.Name = "OpenConfigurationPictureBox";
            this.OpenConfigurationPictureBox.TabStop = false;
            this.OpenConfigurationPictureBox.Click += new System.EventHandler(this.OpenConfigurationPictureBox_Click);
            // 
            // CopyTableDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OpenConfigurationPictureBox);
            this.Controls.Add(this.HelpLinkPictureBox);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.CopyGroupBox);
            this.Controls.Add(this.ViewSourceCodeLabel);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.CloseButton);
            this.Name = "CopyTableDialog";
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.CopyGroupBox.ResumeLayout(false);
            this.CopyGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HelpLinkPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpenConfigurationPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label ViewSourceCodeLabel;
    private System.Windows.Forms.PictureBox LogoPictureBox;
    private System.Windows.Forms.Button CloseButton;
    private System.Windows.Forms.GroupBox CopyGroupBox;
    private System.Windows.Forms.ComboBox SourceDataTableComboBox;
    private System.Windows.Forms.Label InfoLabel;
    private System.Windows.Forms.Label SourceDataTableLabel;
    private System.Windows.Forms.Button CopyButton;
    private System.Windows.Forms.ComboBox DestinationDataTableComboBox;
    private System.Windows.Forms.Label DestinationDataTableLabel;
    private System.Windows.Forms.PictureBox HelpLinkPictureBox;
    private System.Windows.Forms.CheckBox ReadOnlyCheckBox;
    private System.Windows.Forms.PictureBox OpenConfigurationPictureBox;
}