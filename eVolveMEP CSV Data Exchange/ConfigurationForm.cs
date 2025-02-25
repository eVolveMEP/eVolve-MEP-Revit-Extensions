﻿// Copyright (c) 2025 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

extern alias eVolve;
using eVolve::eVolve.Core.Revit.Integration;
using static eVolve::eVolve.Core.Revit.Integration.API;
using System.Windows.Forms;

namespace eVolve.CsvDataExchange.Revit;

/// <summary> Configures and saves <see cref="Settings"/>. Use <see cref="TryGetSettings"/> to consume. </summary>
internal sealed partial class ConfigurationForm : System.Windows.Forms.Form
{
    /// <summary>
    /// Displays the dialog to the user and returns if the user accepted the dialog/clicked OK. If the user cancels, <c>false</c> is
    /// returned. When the return value is <c>true</c>, the configuration is returned via the <paramref name="settings"/> parameter.
    /// <para>All saving/loading is handled by this method.</para>
    /// </summary>
    ///
    /// <param name="document"> The current Revit document. </param>
    /// <param name="settings"> [out] User configured settings. This will be <c>null</c> if the user canceled. </param>
    public static bool TryGetSettings(Document document, out Settings settings)
    {
        settings = null;
        using var dialog = new ConfigurationForm(document);
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            settings = dialog.LastSavedSettings;
            return true;
        }
        return false;
    }


    /// <summary> Gets or sets the last successfully saved <see cref="Settings"/>. </summary>
    private Settings LastSavedSettings { get; set; }

    /// <summary> Gets the current Revit document. </summary>
    private Document Document { get; }

    /// <summary> Constructor that prevents a default instance of this class from being created. </summary>
    ///
    /// <param name="document"> The current Revit document. </param>
    private ConfigurationForm(Document document)
    {
        InitializeComponent();

        this.PrepDialog(Resources.ButtonText, Command.IconResource,
            Command.HelpLinkUrl, HelpLinkPictureBox, Command.VideoUrl, VideoLinkPictureBox, ViewSourceCodeLabel);

        Document = document;

        ExportRadioButton.CheckedChanged += DirectionRadioButton_CheckedChanged;
        ImportRadioButton.CheckedChanged += DirectionRadioButton_CheckedChanged;

        OptionalExportColumnsGroupBox.Text = string.Format(OptionalExportColumnsGroupBox.Text, ExportRadioButton.Text);
            
        // Add all available optional columns to the list for the user to select from.
        OptionalExportColumnsCheckedListBox.Items.Clear();
        OptionalExportColumnsCheckedListBox.Items.AddRange(typeof(Command.OptionalExportColumns).GetProperties()
            .Select(propertyInfo => (string)propertyInfo.GetValue(null))
            .OrderBy(value => value)
            .ToArray());

        FormClosing += ConfigurationForm_FormClosing;
    }
        
    /// <summary> Loads saved configuration values into the editors. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void ConfigurationForm_Load(object sender, EventArgs e)
    {
        LoadSettings();
    }

    /// <summary> When the user accepts the dialog, validates data is correct before closing. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Form closing event information. </param>
    private void ConfigurationForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (DialogResult == DialogResult.OK)
        {
            if (ValidateData())
            {
                SaveSettings();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }

    /// <summary> Opens the Data Profiles configuration dialog and refreshes available selections. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void OpenConfigurationPictureBox_Click(object sender, EventArgs e)
    {
        Document.OpenDataProfilesDialog();

        // Refresh the profiles list, preserving the existing selection if possible.
        var currentProfileSelection = ProfileComboBox.Text;
        DirectionRadioButton_CheckedChanged(ExportRadioButton.Checked ? ExportRadioButton : ImportRadioButton.Checked ? ImportRadioButton : null, EventArgs.Empty);
        if (ProfileComboBox.Items.Contains(currentProfileSelection))
        {
            ProfileComboBox.Text = currentProfileSelection;
        }
    }

    /// <summary> Rebuilds the <see cref="ProfileComboBox"/> selections based on the selected direction. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void DirectionRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        ProfileComboBox.Items.Clear();
        if (sender.Equals(ExportRadioButton))
        {
            ProfileComboBox.Items.AddRange(Document.GetProfileNames(ProfileDirection.Export, Command.FeatureId, null));
        }
        else if (sender.Equals(ImportRadioButton))
        {
            ProfileComboBox.Items.AddRange(Document.GetProfileNames(ProfileDirection.Import, Command.FeatureId, null));
        }
    }

    /// <summary> Prompts the user to select a file appropriate for the current direction. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void FileBrowseButton_Click(object sender, EventArgs e)
    {
        const string FileExtension = ".csv";
        var fileFilter = Resources.CsvFiles + $" (*{FileExtension})|*{FileExtension}";

        if (ExportRadioButton.Checked)
        {
            using var dialog = new SaveFileDialog();
            dialog.OverwritePrompt = true;
            dialog.DefaultExt = FileExtension;
            dialog.FileName = FileTextBox.Text;
            dialog.Filter = fileFilter;
            dialog.Title = ExportRadioButton.Text;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                FileTextBox.Text = dialog.FileName;
            }
        }
        else if (ImportRadioButton.Checked)
        {
            using var dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.FileName = FileTextBox.Text;
            dialog.Filter = fileFilter;
            dialog.Title = ImportRadioButton.Text;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                FileTextBox.Text = dialog.FileName;
            }
        }
    }

    /// <summary> Saves the current configuration settings on the form. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Event information. </param>
    private void ApplyButton_Click(object sender, EventArgs e)
    {
        if (ValidateData())
        {
            SaveSettings();
        }
    }


    #region Settings

    /// <summary> Gets the full pathname of the settings file store location on disk. </summary>
    private static string SettingsFilePath { get; } = System.IO.Path.Combine(eVolve::eVolve.Core.Revit.ProductInfo.API.UserConfigurationFolderPath, "CSV Data Exchange", "Settings.xml");

    /// <summary>
    /// Saves the saved options from <see cref="SettingsFilePath"/> into the form. If an error occurs, the user is notified.
    /// </summary>
    private void LoadSettings()
    {
        if (LoadSettings<Settings>(SettingsFilePath) is { } settings)
        {
            ExportRadioButton.Checked = settings.Direction == Direction.Export;
            ImportRadioButton.Checked = settings.Direction == Direction.Import;
            if (!string.IsNullOrEmpty(settings.ProfileName) && ProfileComboBox.Items.Contains(settings.ProfileName))
            {
                ProfileComboBox.Text = settings.ProfileName;
            }

            FileTextBox.Text = settings.FilePath ?? "";
            DelimiterCommaRadioButton.Checked = settings.Delimiter == DelimiterChars.Comma;
            DelimiterTabRadioButton.Checked = settings.Delimiter == DelimiterChars.Tab;

            for (var index = 0; index < OptionalExportColumnsCheckedListBox.Items.Count; index++)
            {
                var entryText = OptionalExportColumnsCheckedListBox.Items[index].ToString();
                OptionalExportColumnsCheckedListBox.SetItemChecked(index, settings.IncludeExportColumns.Contains(entryText));
            }
        }
    }

    /// <summary>
    /// Saves the currently configured options to <see cref="SettingsFilePath"/>. If an error occurs, the user is notified.
    /// </summary>
    private void SaveSettings()
    {
        var settings = new Settings()
        {
            Direction = ExportRadioButton.Checked ? Direction.Export : Direction.Import,
            ProfileName = ProfileComboBox.Text,
            FilePath = FileTextBox.Text,
            Delimiter = DelimiterTabRadioButton.Checked ? DelimiterChars.Tab : DelimiterChars.Comma,
            IncludeExportColumns = OptionalExportColumnsCheckedListBox.CheckedItems.Cast<string>().ToArray(),
        };

        if (ExtensionsCommon.Revit.Methods.SaveSettings(settings, SettingsFilePath))
        {
            LastSavedSettings = settings;
        }
    }

    #endregion


    /// <summary> Validates the entered data and returns if all checks pass. The user is notified of any issues. </summary>
    private bool ValidateData()
    {
        var messages = new List<string>();

        if (!(ExportRadioButton.Checked ^ ImportRadioButton.Checked))
        {
            messages.Add(string.Format(Resources.SingleValueMustBeSelectedError, DirectionGroupBox.Text));
        }
        if (string.IsNullOrEmpty(ProfileComboBox.Text))
        {
            messages.Add(string.Format(Resources.ValueMustBeSelectedError, ProfileGroupBox.Text));
        }

        var filePath = FileTextBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(filePath))
        {
            messages.Add(string.Format(Resources.ValueMustBeSelectedError, FileGroupBox.Text));
        }
        else
        {
            if (ExportRadioButton.Checked
                && !System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(filePath)))
            {
                messages.Add(string.Format(Resources.WhenXSelectedFolderYMustExistError, ExportRadioButton.Text, FileGroupBox.Text));
            }
            if (ImportRadioButton.Checked
                && !System.IO.File.Exists(filePath))
            {
                messages.Add(string.Format(Resources.WhenXSelectedYMustExistError, ImportRadioButton.Text, FileGroupBox.Text));
            }
        }

        if (!(DelimiterCommaRadioButton.Checked ^ DelimiterTabRadioButton.Checked))
        {
            messages.Add(string.Format(Resources.SingleValueMustBeSelectedError, DelimiterGroupBox.Text));
        }

        if (messages.Any())
        {
            messages.Insert(0, Resources.IssuesMustBeAddressedNotice);
            ShowErrorMessage(this, string.Join("\n - ", messages), Resources.ValidationErrors);
        }
        return !messages.Any();
    }
}