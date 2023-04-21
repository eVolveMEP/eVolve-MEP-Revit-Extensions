namespace eVolve.CsvDataExchange.Revit
{
    partial class ConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.ProfileComboBox = new System.Windows.Forms.ComboBox();
            this.DirectionGroupBox = new System.Windows.Forms.GroupBox();
            this.ImportRadioButton = new System.Windows.Forms.RadioButton();
            this.ExportRadioButton = new System.Windows.Forms.RadioButton();
            this.ProfileGroupBox = new System.Windows.Forms.GroupBox();
            this.FileGroupBox = new System.Windows.Forms.GroupBox();
            this.FileBrowseButton = new System.Windows.Forms.Button();
            this.FileTextBox = new System.Windows.Forms.TextBox();
            this.DelimiterGroupBox = new System.Windows.Forms.GroupBox();
            this.DelimiterTabRadioButton = new System.Windows.Forms.RadioButton();
            this.DelimiterCommaRadioButton = new System.Windows.Forms.RadioButton();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.OptionalExportColumnsGroupBox = new System.Windows.Forms.GroupBox();
            this.OptionalExportColumnsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.HelpLinkPictureBox = new System.Windows.Forms.PictureBox();
            this.OpenConfigurationPictureBox = new System.Windows.Forms.PictureBox();
            this.DirectionGroupBox.SuspendLayout();
            this.ProfileGroupBox.SuspendLayout();
            this.FileGroupBox.SuspendLayout();
            this.DelimiterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.OptionalExportColumnsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HelpLinkPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpenConfigurationPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ProfileComboBox
            // 
            resources.ApplyResources(this.ProfileComboBox, "ProfileComboBox");
            this.ProfileComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProfileComboBox.FormattingEnabled = true;
            this.ProfileComboBox.Name = "ProfileComboBox";
            // 
            // DirectionGroupBox
            // 
            this.DirectionGroupBox.Controls.Add(this.ImportRadioButton);
            this.DirectionGroupBox.Controls.Add(this.ExportRadioButton);
            resources.ApplyResources(this.DirectionGroupBox, "DirectionGroupBox");
            this.DirectionGroupBox.Name = "DirectionGroupBox";
            this.DirectionGroupBox.TabStop = false;
            // 
            // ImportRadioButton
            // 
            resources.ApplyResources(this.ImportRadioButton, "ImportRadioButton");
            this.ImportRadioButton.Name = "ImportRadioButton";
            this.ImportRadioButton.TabStop = true;
            this.ImportRadioButton.UseVisualStyleBackColor = true;
            // 
            // ExportRadioButton
            // 
            resources.ApplyResources(this.ExportRadioButton, "ExportRadioButton");
            this.ExportRadioButton.Name = "ExportRadioButton";
            this.ExportRadioButton.TabStop = true;
            this.ExportRadioButton.UseVisualStyleBackColor = true;
            // 
            // ProfileGroupBox
            // 
            this.ProfileGroupBox.Controls.Add(this.ProfileComboBox);
            resources.ApplyResources(this.ProfileGroupBox, "ProfileGroupBox");
            this.ProfileGroupBox.Name = "ProfileGroupBox";
            this.ProfileGroupBox.TabStop = false;
            // 
            // FileGroupBox
            // 
            resources.ApplyResources(this.FileGroupBox, "FileGroupBox");
            this.FileGroupBox.Controls.Add(this.FileBrowseButton);
            this.FileGroupBox.Controls.Add(this.FileTextBox);
            this.FileGroupBox.Name = "FileGroupBox";
            this.FileGroupBox.TabStop = false;
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
            // DelimiterGroupBox
            // 
            this.DelimiterGroupBox.Controls.Add(this.DelimiterTabRadioButton);
            this.DelimiterGroupBox.Controls.Add(this.DelimiterCommaRadioButton);
            resources.ApplyResources(this.DelimiterGroupBox, "DelimiterGroupBox");
            this.DelimiterGroupBox.Name = "DelimiterGroupBox";
            this.DelimiterGroupBox.TabStop = false;
            // 
            // DelimiterTabRadioButton
            // 
            resources.ApplyResources(this.DelimiterTabRadioButton, "DelimiterTabRadioButton");
            this.DelimiterTabRadioButton.Name = "DelimiterTabRadioButton";
            this.DelimiterTabRadioButton.TabStop = true;
            this.DelimiterTabRadioButton.UseVisualStyleBackColor = true;
            // 
            // DelimiterCommaRadioButton
            // 
            resources.ApplyResources(this.DelimiterCommaRadioButton, "DelimiterCommaRadioButton");
            this.DelimiterCommaRadioButton.Name = "DelimiterCommaRadioButton";
            this.DelimiterCommaRadioButton.TabStop = true;
            this.DelimiterCommaRadioButton.UseVisualStyleBackColor = true;
            // 
            // OK_Button
            // 
            resources.ApplyResources(this.OK_Button, "OK_Button");
            this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.UseVisualStyleBackColor = true;
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
            // LogoPictureBox
            // 
            resources.ApplyResources(this.LogoPictureBox, "LogoPictureBox");
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.TabStop = false;
            // 
            // OptionalExportColumnsGroupBox
            // 
            this.OptionalExportColumnsGroupBox.Controls.Add(this.OptionalExportColumnsCheckedListBox);
            resources.ApplyResources(this.OptionalExportColumnsGroupBox, "OptionalExportColumnsGroupBox");
            this.OptionalExportColumnsGroupBox.Name = "OptionalExportColumnsGroupBox";
            this.OptionalExportColumnsGroupBox.TabStop = false;
            // 
            // OptionalExportColumnsCheckedListBox
            // 
            resources.ApplyResources(this.OptionalExportColumnsCheckedListBox, "OptionalExportColumnsCheckedListBox");
            this.OptionalExportColumnsCheckedListBox.CheckOnClick = true;
            this.OptionalExportColumnsCheckedListBox.FormattingEnabled = true;
            this.OptionalExportColumnsCheckedListBox.Name = "OptionalExportColumnsCheckedListBox";
            // 
            // HelpLinkPictureBox
            // 
            resources.ApplyResources(this.HelpLinkPictureBox, "HelpLinkPictureBox");
            this.HelpLinkPictureBox.Image = global::eVolve.CsvDataExchange.Revit.Properties.Resources.Help_Medium_20x20;
            this.HelpLinkPictureBox.Name = "HelpLinkPictureBox";
            this.HelpLinkPictureBox.TabStop = false;
            this.HelpLinkPictureBox.Click += new System.EventHandler(this.HelpLinkPictureBox_Click);
            // 
            // OpenConfigurationPictureBox
            // 
            resources.ApplyResources(this.OpenConfigurationPictureBox, "OpenConfigurationPictureBox");
            this.OpenConfigurationPictureBox.Image = global::eVolve.CsvDataExchange.Revit.Properties.Resources.Settings_20x20;
            this.OpenConfigurationPictureBox.Name = "OpenConfigurationPictureBox";
            this.OpenConfigurationPictureBox.TabStop = false;
            this.OpenConfigurationPictureBox.Click += new System.EventHandler(this.OpenConfigurationPictureBox_Click);
            // 
            // ConfigurationForm
            // 
            this.AcceptButton = this.OK_Button;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.Controls.Add(this.OpenConfigurationPictureBox);
            this.Controls.Add(this.HelpLinkPictureBox);
            this.Controls.Add(this.OptionalExportColumnsGroupBox);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.DelimiterGroupBox);
            this.Controls.Add(this.FileGroupBox);
            this.Controls.Add(this.ProfileGroupBox);
            this.Controls.Add(this.DirectionGroupBox);
            this.Name = "ConfigurationForm";
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            this.DirectionGroupBox.ResumeLayout(false);
            this.DirectionGroupBox.PerformLayout();
            this.ProfileGroupBox.ResumeLayout(false);
            this.FileGroupBox.ResumeLayout(false);
            this.FileGroupBox.PerformLayout();
            this.DelimiterGroupBox.ResumeLayout(false);
            this.DelimiterGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.OptionalExportColumnsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HelpLinkPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpenConfigurationPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ProfileComboBox;
        private System.Windows.Forms.GroupBox DirectionGroupBox;
        private System.Windows.Forms.RadioButton ImportRadioButton;
        private System.Windows.Forms.RadioButton ExportRadioButton;
        private System.Windows.Forms.GroupBox ProfileGroupBox;
        private System.Windows.Forms.GroupBox FileGroupBox;
        private System.Windows.Forms.Button FileBrowseButton;
        private System.Windows.Forms.TextBox FileTextBox;
        private System.Windows.Forms.GroupBox DelimiterGroupBox;
        private System.Windows.Forms.RadioButton DelimiterTabRadioButton;
        private System.Windows.Forms.RadioButton DelimiterCommaRadioButton;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.GroupBox OptionalExportColumnsGroupBox;
        private System.Windows.Forms.CheckedListBox OptionalExportColumnsCheckedListBox;
        private System.Windows.Forms.PictureBox HelpLinkPictureBox;
        private System.Windows.Forms.PictureBox OpenConfigurationPictureBox;
    }
}