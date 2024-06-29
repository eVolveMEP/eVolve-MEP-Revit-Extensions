namespace eVolve.DataTableTools.Revit.Tools;

partial class AddMappingDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMappingDialog));
            this.DataTableColumnGroupBox = new System.Windows.Forms.GroupBox();
            this.DataTableColumnComboBox = new System.Windows.Forms.ComboBox();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.SQLTableColumnGroupBox = new System.Windows.Forms.GroupBox();
            this.SQLTableColumnComboBox = new System.Windows.Forms.ComboBox();
            this.DataTableColumnGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SQLTableColumnGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataTableColumnGroupBox
            // 
            this.DataTableColumnGroupBox.Controls.Add(this.DataTableColumnComboBox);
            resources.ApplyResources(this.DataTableColumnGroupBox, "DataTableColumnGroupBox");
            this.DataTableColumnGroupBox.Name = "DataTableColumnGroupBox";
            this.DataTableColumnGroupBox.TabStop = false;
            // 
            // DataTableColumnComboBox
            // 
            resources.ApplyResources(this.DataTableColumnComboBox, "DataTableColumnComboBox");
            this.DataTableColumnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataTableColumnComboBox.FormattingEnabled = true;
            this.DataTableColumnComboBox.Name = "DataTableColumnComboBox";
            // 
            // Cancel_Button
            // 
            resources.ApplyResources(this.Cancel_Button, "Cancel_Button");
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.UseVisualStyleBackColor = true;
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
            // SQLTableColumnGroupBox
            // 
            this.SQLTableColumnGroupBox.Controls.Add(this.SQLTableColumnComboBox);
            resources.ApplyResources(this.SQLTableColumnGroupBox, "SQLTableColumnGroupBox");
            this.SQLTableColumnGroupBox.Name = "SQLTableColumnGroupBox";
            this.SQLTableColumnGroupBox.TabStop = false;
            // 
            // SQLTableColumnComboBox
            // 
            resources.ApplyResources(this.SQLTableColumnComboBox, "SQLTableColumnComboBox");
            this.SQLTableColumnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SQLTableColumnComboBox.FormattingEnabled = true;
            this.SQLTableColumnComboBox.Name = "SQLTableColumnComboBox";
            // 
            // AddMappingDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SQLTableColumnGroupBox);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.DataTableColumnGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AddMappingDialog";
            this.DataTableColumnGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.SQLTableColumnGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox DataTableColumnGroupBox;
    private System.Windows.Forms.Button Cancel_Button;
    private System.Windows.Forms.PictureBox LogoPictureBox;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.ComboBox DataTableColumnComboBox;
    private System.Windows.Forms.GroupBox SQLTableColumnGroupBox;
    private System.Windows.Forms.ComboBox SQLTableColumnComboBox;
}