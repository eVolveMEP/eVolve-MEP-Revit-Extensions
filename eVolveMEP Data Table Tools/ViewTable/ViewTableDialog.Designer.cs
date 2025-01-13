namespace eVolve.DataTableTools.Revit.ViewTable;

partial class ViewTableDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewTableDialog));
            this.DataTableComboBox = new System.Windows.Forms.ComboBox();
            this.DataTableLabel = new System.Windows.Forms.Label();
            this.TableDataGridView = new System.Windows.Forms.DataGridView();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ClearCacheButton = new System.Windows.Forms.Button();
            this.ViewSourceCodeLabel = new System.Windows.Forms.Label();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.HelpLinkPictureBox = new System.Windows.Forms.PictureBox();
            this.VideoLinkPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpLinkPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoLinkPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTableComboBox
            // 
            this.DataTableComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataTableComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.DataTableComboBox, "DataTableComboBox");
            this.DataTableComboBox.Name = "DataTableComboBox";
            this.DataTableComboBox.SelectedIndexChanged += new System.EventHandler(this.DataTableComboBox_SelectedIndexChanged);
            // 
            // DataTableLabel
            // 
            resources.ApplyResources(this.DataTableLabel, "DataTableLabel");
            this.DataTableLabel.Name = "DataTableLabel";
            // 
            // TableDataGridView
            // 
            this.TableDataGridView.AllowUserToAddRows = false;
            this.TableDataGridView.AllowUserToDeleteRows = false;
            this.TableDataGridView.AllowUserToOrderColumns = true;
            resources.ApplyResources(this.TableDataGridView, "TableDataGridView");
            this.TableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableDataGridView.Name = "TableDataGridView";
            this.TableDataGridView.ReadOnly = true;
            // 
            // CloseButton
            // 
            resources.ApplyResources(this.CloseButton, "CloseButton");
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // ClearCacheButton
            // 
            resources.ApplyResources(this.ClearCacheButton, "ClearCacheButton");
            this.ClearCacheButton.Name = "ClearCacheButton";
            this.ClearCacheButton.UseVisualStyleBackColor = true;
            this.ClearCacheButton.Click += new System.EventHandler(this.ClearCacheButton_Click);
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
            // HelpLinkPictureBox
            // 
            resources.ApplyResources(this.HelpLinkPictureBox, "HelpLinkPictureBox");
            this.HelpLinkPictureBox.Image = global::eVolve.DataTableTools.Revit.Properties.Resources.Help_Medium_20x20;
            this.HelpLinkPictureBox.Name = "HelpLinkPictureBox";
            this.HelpLinkPictureBox.TabStop = false;
            // 
            // VideoLinkPictureBox
            // 
            resources.ApplyResources(this.VideoLinkPictureBox, "VideoLinkPictureBox");
            this.VideoLinkPictureBox.Image = global::eVolve.DataTableTools.Revit.Properties.Resources.LinkedVideo_20x20;
            this.VideoLinkPictureBox.Name = "VideoLinkPictureBox";
            this.VideoLinkPictureBox.TabStop = false;
            // 
            // ViewTableDialog
            // 
            this.AcceptButton = this.CloseButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.Controls.Add(this.VideoLinkPictureBox);
            this.Controls.Add(this.HelpLinkPictureBox);
            this.Controls.Add(this.ViewSourceCodeLabel);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.ClearCacheButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.TableDataGridView);
            this.Controls.Add(this.DataTableComboBox);
            this.Controls.Add(this.DataTableLabel);
            this.Name = "ViewTableDialog";
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpLinkPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoLinkPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox DataTableComboBox;
    private System.Windows.Forms.Label DataTableLabel;
    private System.Windows.Forms.DataGridView TableDataGridView;
    private System.Windows.Forms.Button CloseButton;
    private System.Windows.Forms.Button ClearCacheButton;
    private System.Windows.Forms.Label ViewSourceCodeLabel;
    private System.Windows.Forms.PictureBox LogoPictureBox;
    private System.Windows.Forms.PictureBox HelpLinkPictureBox;
    private System.Windows.Forms.PictureBox VideoLinkPictureBox;
}