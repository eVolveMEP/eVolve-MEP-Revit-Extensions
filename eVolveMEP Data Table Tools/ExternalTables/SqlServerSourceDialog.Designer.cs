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
            this.ConnectionStringGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectionStringGroupBox.Controls.Add(this.ConnectionStringHelpLabel);
            this.ConnectionStringGroupBox.Controls.Add(this.ConnectionStringTextBox);
            this.ConnectionStringGroupBox.Location = new System.Drawing.Point(12, 147);
            this.ConnectionStringGroupBox.Name = "ConnectionStringGroupBox";
            this.ConnectionStringGroupBox.Size = new System.Drawing.Size(776, 96);
            this.ConnectionStringGroupBox.TabIndex = 1;
            this.ConnectionStringGroupBox.TabStop = false;
            this.ConnectionStringGroupBox.Text = "SQL Server Connection String";
            // 
            // ConnectionStringHelpLabel
            // 
            this.ConnectionStringHelpLabel.AutoSize = true;
            this.ConnectionStringHelpLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConnectionStringHelpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.ConnectionStringHelpLabel.ForeColor = System.Drawing.Color.Blue;
            this.ConnectionStringHelpLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConnectionStringHelpLabel.Location = new System.Drawing.Point(20, 62);
            this.ConnectionStringHelpLabel.Name = "ConnectionStringHelpLabel";
            this.ConnectionStringHelpLabel.Size = new System.Drawing.Size(106, 13);
            this.ConnectionStringHelpLabel.TabIndex = 1;
            this.ConnectionStringHelpLabel.Tag = "https://www.connectionstrings.com/microsoft-data-sqlclient/";
            this.ConnectionStringHelpLabel.Text = "View example values";
            this.ConnectionStringHelpLabel.Click += new System.EventHandler(this.ConnectionStringHelpLabel_Click);
            // 
            // ConnectionStringTextBox
            // 
            this.ConnectionStringTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectionStringTextBox.Location = new System.Drawing.Point(23, 30);
            this.ConnectionStringTextBox.Name = "ConnectionStringTextBox";
            this.ConnectionStringTextBox.Size = new System.Drawing.Size(735, 20);
            this.ConnectionStringTextBox.TabIndex = 0;
            // 
            // CommandGroupBox
            // 
            this.CommandGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandGroupBox.Controls.Add(this.CommandTextBox);
            this.CommandGroupBox.Location = new System.Drawing.Point(12, 266);
            this.CommandGroupBox.Name = "CommandGroupBox";
            this.CommandGroupBox.Size = new System.Drawing.Size(776, 317);
            this.CommandGroupBox.TabIndex = 2;
            this.CommandGroupBox.TabStop = false;
            this.CommandGroupBox.Text = "SQL Command";
            // 
            // CommandTextBox
            // 
            this.CommandTextBox.AcceptsReturn = true;
            this.CommandTextBox.AcceptsTab = true;
            this.CommandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandTextBox.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.CommandTextBox.Location = new System.Drawing.Point(23, 33);
            this.CommandTextBox.Multiline = true;
            this.CommandTextBox.Name = "CommandTextBox";
            this.CommandTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CommandTextBox.Size = new System.Drawing.Size(735, 267);
            this.CommandTextBox.TabIndex = 0;
            this.CommandTextBox.WordWrap = false;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(688, 609);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(100, 23);
            this.Cancel_Button.TabIndex = 4;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(582, 609);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(100, 23);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogoPictureBox.Image = global::eVolve.DataTableTools.Revit.Properties.Resources.Logo;
            this.LogoPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LogoPictureBox.Location = new System.Drawing.Point(12, 609);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(146, 23);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoPictureBox.TabIndex = 17;
            this.LogoPictureBox.TabStop = false;
            // 
            // ExternalTableSourceBaseControl
            // 
            this.ExternalTableSourceBaseControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExternalTableSourceBaseControl.Location = new System.Drawing.Point(12, 12);
            this.ExternalTableSourceBaseControl.Name = "ExternalTableSourceBaseControl";
            this.ExternalTableSourceBaseControl.Size = new System.Drawing.Size(776, 114);
            this.ExternalTableSourceBaseControl.TabIndex = 0;
            // 
            // SqlServerSourceDialog
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(800, 644);
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