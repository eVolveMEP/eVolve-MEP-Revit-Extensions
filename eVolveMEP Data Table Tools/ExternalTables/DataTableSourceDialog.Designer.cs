namespace eVolve.DataTableTools.Revit.ExternalTables;

partial class DataTableSourceDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataTableSourceDialog));
            this.ExternalTableSourceBaseControl = new eVolve.DataTableTools.Revit.ExternalTables.ExternalTableSourceBaseControl();
            this.FileGroupBox = new System.Windows.Forms.GroupBox();
            this.FileInfoLabel = new System.Windows.Forms.Label();
            this.FileBrowseButton = new System.Windows.Forms.Button();
            this.FileTextBox = new System.Windows.Forms.TextBox();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.SerializeDataTableGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SerializeDataTableComboBox = new System.Windows.Forms.ComboBox();
            this.SerializeDataTableButton = new System.Windows.Forms.Button();
            this.FileGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SerializeDataTableGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExternalTableSourceBaseControl
            // 
            resources.ApplyResources(this.ExternalTableSourceBaseControl, "ExternalTableSourceBaseControl");
            this.ExternalTableSourceBaseControl.Name = "ExternalTableSourceBaseControl";
            // 
            // FileGroupBox
            // 
            resources.ApplyResources(this.FileGroupBox, "FileGroupBox");
            this.FileGroupBox.Controls.Add(this.FileInfoLabel);
            this.FileGroupBox.Controls.Add(this.FileBrowseButton);
            this.FileGroupBox.Controls.Add(this.FileTextBox);
            this.FileGroupBox.Name = "FileGroupBox";
            this.FileGroupBox.TabStop = false;
            // 
            // FileInfoLabel
            // 
            resources.ApplyResources(this.FileInfoLabel, "FileInfoLabel");
            this.FileInfoLabel.Name = "FileInfoLabel";
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
            // SerializeDataTableGroupBox
            // 
            resources.ApplyResources(this.SerializeDataTableGroupBox, "SerializeDataTableGroupBox");
            this.SerializeDataTableGroupBox.Controls.Add(this.label1);
            this.SerializeDataTableGroupBox.Controls.Add(this.SerializeDataTableComboBox);
            this.SerializeDataTableGroupBox.Controls.Add(this.SerializeDataTableButton);
            this.SerializeDataTableGroupBox.Name = "SerializeDataTableGroupBox";
            this.SerializeDataTableGroupBox.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // SerializeDataTableComboBox
            // 
            resources.ApplyResources(this.SerializeDataTableComboBox, "SerializeDataTableComboBox");
            this.SerializeDataTableComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SerializeDataTableComboBox.FormattingEnabled = true;
            this.SerializeDataTableComboBox.Name = "SerializeDataTableComboBox";
            // 
            // SerializeDataTableButton
            // 
            resources.ApplyResources(this.SerializeDataTableButton, "SerializeDataTableButton");
            this.SerializeDataTableButton.Name = "SerializeDataTableButton";
            this.SerializeDataTableButton.UseVisualStyleBackColor = true;
            this.SerializeDataTableButton.Click += new System.EventHandler(this.SerializeDataTableButton_Click);
            // 
            // DataTableSourceDialog
            // 
            this.AcceptButton = this.OKButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.Controls.Add(this.SerializeDataTableGroupBox);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.FileGroupBox);
            this.Controls.Add(this.ExternalTableSourceBaseControl);
            this.Name = "DataTableSourceDialog";
            this.FileGroupBox.ResumeLayout(false);
            this.FileGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.SerializeDataTableGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private ExternalTableSourceBaseControl ExternalTableSourceBaseControl;
    private System.Windows.Forms.GroupBox FileGroupBox;
    private System.Windows.Forms.Button FileBrowseButton;
    private System.Windows.Forms.TextBox FileTextBox;
    private System.Windows.Forms.PictureBox LogoPictureBox;
    private System.Windows.Forms.Button Cancel_Button;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.GroupBox SerializeDataTableGroupBox;
    private System.Windows.Forms.ComboBox SerializeDataTableComboBox;
    private System.Windows.Forms.Button SerializeDataTableButton;
    private System.Windows.Forms.Label FileInfoLabel;
    private System.Windows.Forms.Label label1;
}