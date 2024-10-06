namespace eVolve.DataTableTools.Revit.ExternalTables;

partial class ExternalTableSourceBaseControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.TableInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.CacheCheckBox = new System.Windows.Forms.CheckBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.TableInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableInfoGroupBox
            // 
            this.TableInfoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableInfoGroupBox.Controls.Add(this.DescriptionTextBox);
            this.TableInfoGroupBox.Controls.Add(this.DescriptionLabel);
            this.TableInfoGroupBox.Controls.Add(this.CacheCheckBox);
            this.TableInfoGroupBox.Controls.Add(this.NameTextBox);
            this.TableInfoGroupBox.Controls.Add(this.NameLabel);
            this.TableInfoGroupBox.Location = new System.Drawing.Point(0, 0);
            this.TableInfoGroupBox.Name = "TableInfoGroupBox";
            this.TableInfoGroupBox.Size = new System.Drawing.Size(611, 121);
            this.TableInfoGroupBox.TabIndex = 0;
            this.TableInfoGroupBox.TabStop = false;
            this.TableInfoGroupBox.Text = "Table Information";
            // 
            // CacheCheckBox
            // 
            this.CacheCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CacheCheckBox.AutoSize = true;
            this.CacheCheckBox.Location = new System.Drawing.Point(462, 31);
            this.CacheCheckBox.Name = "CacheCheckBox";
            this.CacheCheckBox.Size = new System.Drawing.Size(83, 17);
            this.CacheCheckBox.TabIndex = 2;
            this.CacheCheckBox.Text = "Cache Data";
            this.ToolTip.SetToolTip(this.CacheCheckBox, "Caching data increases performance for data which seldom changes or is expensive " +
        "to pull.\r\nIf this is unchecked, a live lookup will be performed for each request" +
        ".");
            this.CacheCheckBox.UseVisualStyleBackColor = true;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextBox.Location = new System.Drawing.Point(113, 29);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(268, 20);
            this.NameTextBox.TabIndex = 1;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(20, 32);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            this.ToolTip.SetToolTip(this.NameLabel, "Descriptive and unique name for the table.");
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionTextBox.Location = new System.Drawing.Point(113, 65);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(481, 38);
            this.DescriptionTextBox.TabIndex = 4;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(20, 68);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.DescriptionLabel.TabIndex = 3;
            this.DescriptionLabel.Text = "Description";
            // 
            // ExternalTableSourceBaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableInfoGroupBox);
            this.Name = "ExternalTableSourceBaseControl";
            this.Size = new System.Drawing.Size(611, 121);
            this.TableInfoGroupBox.ResumeLayout(false);
            this.TableInfoGroupBox.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox TableInfoGroupBox;
    private System.Windows.Forms.CheckBox CacheCheckBox;
    private System.Windows.Forms.TextBox NameTextBox;
    private System.Windows.Forms.Label NameLabel;
    private System.Windows.Forms.ToolTip ToolTip;
    private System.Windows.Forms.TextBox DescriptionTextBox;
    private System.Windows.Forms.Label DescriptionLabel;
}
