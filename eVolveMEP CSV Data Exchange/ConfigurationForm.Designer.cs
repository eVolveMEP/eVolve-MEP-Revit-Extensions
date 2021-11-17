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
            this.DirectionGroupBox.SuspendLayout();
            this.ProfileGroupBox.SuspendLayout();
            this.FileGroupBox.SuspendLayout();
            this.DelimiterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.OptionalExportColumnsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HelpLinkPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ProfileComboBox
            // 
            this.ProfileComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProfileComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProfileComboBox.FormattingEnabled = true;
            this.ProfileComboBox.Location = new System.Drawing.Point(13, 26);
            this.ProfileComboBox.Name = "ProfileComboBox";
            this.ProfileComboBox.Size = new System.Drawing.Size(273, 21);
            this.ProfileComboBox.TabIndex = 0;
            // 
            // DirectionGroupBox
            // 
            this.DirectionGroupBox.Controls.Add(this.ImportRadioButton);
            this.DirectionGroupBox.Controls.Add(this.ExportRadioButton);
            this.DirectionGroupBox.Location = new System.Drawing.Point(13, 13);
            this.DirectionGroupBox.Name = "DirectionGroupBox";
            this.DirectionGroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.DirectionGroupBox.Size = new System.Drawing.Size(299, 63);
            this.DirectionGroupBox.TabIndex = 0;
            this.DirectionGroupBox.TabStop = false;
            this.DirectionGroupBox.Text = "Direction";
            // 
            // ImportRadioButton
            // 
            this.ImportRadioButton.AutoSize = true;
            this.ImportRadioButton.Location = new System.Drawing.Point(139, 26);
            this.ImportRadioButton.Name = "ImportRadioButton";
            this.ImportRadioButton.Size = new System.Drawing.Size(54, 17);
            this.ImportRadioButton.TabIndex = 1;
            this.ImportRadioButton.TabStop = true;
            this.ImportRadioButton.Text = "Import";
            this.ImportRadioButton.UseVisualStyleBackColor = true;
            // 
            // ExportRadioButton
            // 
            this.ExportRadioButton.AutoSize = true;
            this.ExportRadioButton.Location = new System.Drawing.Point(13, 26);
            this.ExportRadioButton.Name = "ExportRadioButton";
            this.ExportRadioButton.Size = new System.Drawing.Size(55, 17);
            this.ExportRadioButton.TabIndex = 0;
            this.ExportRadioButton.TabStop = true;
            this.ExportRadioButton.Text = "Export";
            this.ExportRadioButton.UseVisualStyleBackColor = true;
            // 
            // ProfileGroupBox
            // 
            this.ProfileGroupBox.Controls.Add(this.ProfileComboBox);
            this.ProfileGroupBox.Location = new System.Drawing.Point(13, 87);
            this.ProfileGroupBox.Name = "ProfileGroupBox";
            this.ProfileGroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.ProfileGroupBox.Size = new System.Drawing.Size(299, 63);
            this.ProfileGroupBox.TabIndex = 1;
            this.ProfileGroupBox.TabStop = false;
            this.ProfileGroupBox.Text = "Profile";
            // 
            // FileGroupBox
            // 
            this.FileGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileGroupBox.Controls.Add(this.FileBrowseButton);
            this.FileGroupBox.Controls.Add(this.FileTextBox);
            this.FileGroupBox.Location = new System.Drawing.Point(13, 161);
            this.FileGroupBox.Name = "FileGroupBox";
            this.FileGroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.FileGroupBox.Size = new System.Drawing.Size(758, 63);
            this.FileGroupBox.TabIndex = 3;
            this.FileGroupBox.TabStop = false;
            this.FileGroupBox.Text = "Target File";
            // 
            // FileBrowseButton
            // 
            this.FileBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FileBrowseButton.Location = new System.Drawing.Point(630, 24);
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
            this.FileTextBox.Location = new System.Drawing.Point(13, 26);
            this.FileTextBox.Name = "FileTextBox";
            this.FileTextBox.Size = new System.Drawing.Size(611, 20);
            this.FileTextBox.TabIndex = 0;
            // 
            // DelimiterGroupBox
            // 
            this.DelimiterGroupBox.Controls.Add(this.DelimiterTabRadioButton);
            this.DelimiterGroupBox.Controls.Add(this.DelimiterCommaRadioButton);
            this.DelimiterGroupBox.Location = new System.Drawing.Point(13, 235);
            this.DelimiterGroupBox.Name = "DelimiterGroupBox";
            this.DelimiterGroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.DelimiterGroupBox.Size = new System.Drawing.Size(299, 63);
            this.DelimiterGroupBox.TabIndex = 4;
            this.DelimiterGroupBox.TabStop = false;
            this.DelimiterGroupBox.Text = "Delimiter";
            // 
            // DelimiterTabRadioButton
            // 
            this.DelimiterTabRadioButton.AutoSize = true;
            this.DelimiterTabRadioButton.Location = new System.Drawing.Point(139, 26);
            this.DelimiterTabRadioButton.Name = "DelimiterTabRadioButton";
            this.DelimiterTabRadioButton.Size = new System.Drawing.Size(44, 17);
            this.DelimiterTabRadioButton.TabIndex = 1;
            this.DelimiterTabRadioButton.TabStop = true;
            this.DelimiterTabRadioButton.Text = "Tab";
            this.DelimiterTabRadioButton.UseVisualStyleBackColor = true;
            // 
            // DelimiterCommaRadioButton
            // 
            this.DelimiterCommaRadioButton.AutoSize = true;
            this.DelimiterCommaRadioButton.Location = new System.Drawing.Point(13, 26);
            this.DelimiterCommaRadioButton.Name = "DelimiterCommaRadioButton";
            this.DelimiterCommaRadioButton.Size = new System.Drawing.Size(60, 17);
            this.DelimiterCommaRadioButton.TabIndex = 0;
            this.DelimiterCommaRadioButton.TabStop = true;
            this.DelimiterCommaRadioButton.Text = "Comma";
            this.DelimiterCommaRadioButton.UseVisualStyleBackColor = true;
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_Button.Location = new System.Drawing.Point(459, 352);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(100, 23);
            this.OK_Button.TabIndex = 5;
            this.OK_Button.Text = "OK";
            this.OK_Button.UseVisualStyleBackColor = true;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(565, 352);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(100, 23);
            this.Cancel_Button.TabIndex = 6;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyButton.Location = new System.Drawing.Point(671, 352);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(100, 23);
            this.ApplyButton.TabIndex = 7;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LogoPictureBox.Image")));
            this.LogoPictureBox.Location = new System.Drawing.Point(13, 352);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(146, 23);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoPictureBox.TabIndex = 7;
            this.LogoPictureBox.TabStop = false;
            // 
            // OptionalExportColumnsGroupBox
            // 
            this.OptionalExportColumnsGroupBox.Controls.Add(this.OptionalExportColumnsCheckedListBox);
            this.OptionalExportColumnsGroupBox.Location = new System.Drawing.Point(342, 13);
            this.OptionalExportColumnsGroupBox.Name = "OptionalExportColumnsGroupBox";
            this.OptionalExportColumnsGroupBox.Size = new System.Drawing.Size(295, 137);
            this.OptionalExportColumnsGroupBox.TabIndex = 2;
            this.OptionalExportColumnsGroupBox.TabStop = false;
            this.OptionalExportColumnsGroupBox.Text = "Optional columns to include in {0}";
            // 
            // OptionalExportColumnsCheckedListBox
            // 
            this.OptionalExportColumnsCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionalExportColumnsCheckedListBox.CheckOnClick = true;
            this.OptionalExportColumnsCheckedListBox.FormattingEnabled = true;
            this.OptionalExportColumnsCheckedListBox.Location = new System.Drawing.Point(6, 19);
            this.OptionalExportColumnsCheckedListBox.Name = "OptionalExportColumnsCheckedListBox";
            this.OptionalExportColumnsCheckedListBox.Size = new System.Drawing.Size(283, 109);
            this.OptionalExportColumnsCheckedListBox.TabIndex = 0;
            // 
            // HelpLinkPictureBox
            // 
            this.HelpLinkPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpLinkPictureBox.Image = global::eVolve.CsvDataExchange.Revit.Properties.Resources.Help_Medium_20x20;
            this.HelpLinkPictureBox.Location = new System.Drawing.Point(764, 0);
            this.HelpLinkPictureBox.Name = "HelpLinkPictureBox";
            this.HelpLinkPictureBox.Size = new System.Drawing.Size(20, 20);
            this.HelpLinkPictureBox.TabIndex = 8;
            this.HelpLinkPictureBox.TabStop = false;
            this.HelpLinkPictureBox.Click += new System.EventHandler(this.HelpLinkPictureBox_Click);
            // 
            // ConfigurationForm
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(784, 388);
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
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "ConfigurationForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "eVolve CSV Data Exchange Configuration";
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
    }
}