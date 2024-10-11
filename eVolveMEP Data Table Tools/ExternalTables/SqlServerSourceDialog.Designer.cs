namespace eVolve.DataTableTools.Revit.ExternalTables;

partial class SqlServerSourceDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlServerSourceDialog));
            this.ConnectionStringGroupBox = new System.Windows.Forms.GroupBox();
            this.ConnectionStringHelpLabel = new System.Windows.Forms.Label();
            this.ConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.CommandGroupBox = new System.Windows.Forms.GroupBox();
            this.CommandTextBox = new System.Windows.Forms.TextBox();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.ExternalTableSourceBaseControl = new eVolve.DataTableTools.Revit.ExternalTables.ExternalTableSourceBaseControl();
            this.ConnectionStringGroupBox.SuspendLayout();
            this.CommandGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectionStringGroupBox
            // 
            resources.ApplyResources(this.ConnectionStringGroupBox, "ConnectionStringGroupBox");
            this.ConnectionStringGroupBox.Controls.Add(this.ConnectionStringHelpLabel);
            this.ConnectionStringGroupBox.Controls.Add(this.ConnectionStringTextBox);
            this.ConnectionStringGroupBox.Name = "ConnectionStringGroupBox";
            this.ConnectionStringGroupBox.TabStop = false;
            // 
            // ConnectionStringHelpLabel
            // 
            resources.ApplyResources(this.ConnectionStringHelpLabel, "ConnectionStringHelpLabel");
            this.ConnectionStringHelpLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConnectionStringHelpLabel.ForeColor = System.Drawing.Color.Blue;
            this.ConnectionStringHelpLabel.Name = "ConnectionStringHelpLabel";
            this.ConnectionStringHelpLabel.Tag = "https://www.connectionstrings.com/microsoft-data-sqlclient/";
            this.ConnectionStringHelpLabel.Click += new System.EventHandler(this.ConnectionStringHelpLabel_Click);
            // 
            // ConnectionStringTextBox
            // 
            resources.ApplyResources(this.ConnectionStringTextBox, "ConnectionStringTextBox");
            this.ConnectionStringTextBox.Name = "ConnectionStringTextBox";
            // 
            // CommandGroupBox
            // 
            resources.ApplyResources(this.CommandGroupBox, "CommandGroupBox");
            this.CommandGroupBox.Controls.Add(this.CommandTextBox);
            this.CommandGroupBox.Name = "CommandGroupBox";
            this.CommandGroupBox.TabStop = false;
            // 
            // CommandTextBox
            // 
            this.CommandTextBox.AcceptsReturn = true;
            this.CommandTextBox.AcceptsTab = true;
            resources.ApplyResources(this.CommandTextBox, "CommandTextBox");
            this.CommandTextBox.Name = "CommandTextBox";
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
            // LogoPictureBox
            // 
            resources.ApplyResources(this.LogoPictureBox, "LogoPictureBox");
            this.LogoPictureBox.Image = global::eVolve.DataTableTools.Revit.Properties.Resources.Logo;
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.TabStop = false;
            // 
            // ExternalTableSourceBaseControl
            // 
            resources.ApplyResources(this.ExternalTableSourceBaseControl, "ExternalTableSourceBaseControl");
            this.ExternalTableSourceBaseControl.Name = "ExternalTableSourceBaseControl";
            // 
            // SqlServerSourceDialog
            // 
            this.AcceptButton = this.OKButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.Controls.Add(this.ExternalTableSourceBaseControl);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CommandGroupBox);
            this.Controls.Add(this.ConnectionStringGroupBox);
            this.Name = "SqlServerSourceDialog";
            this.ConnectionStringGroupBox.ResumeLayout(false);
            this.ConnectionStringGroupBox.PerformLayout();
            this.CommandGroupBox.ResumeLayout(false);
            this.CommandGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox ConnectionStringGroupBox;
    private System.Windows.Forms.Label ConnectionStringHelpLabel;
    private System.Windows.Forms.TextBox ConnectionStringTextBox;
    private System.Windows.Forms.GroupBox CommandGroupBox;
    private System.Windows.Forms.TextBox CommandTextBox;
    private System.Windows.Forms.Button Cancel_Button;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.PictureBox LogoPictureBox;
    private ExternalTableSourceBaseControl ExternalTableSourceBaseControl;
}