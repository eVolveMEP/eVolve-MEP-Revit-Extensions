// Copyright (c) 2026 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using System.Windows.Forms;

namespace eVolve.ExtensionsCommon.Revit;

/// <summary> Common methods useful across all projects in this solution. </summary>
internal static class Methods
{
    /// <summary>
    /// Loads the provided <paramref name="filePath"/> from disk and deserializes it to <typeparamref name="TSettings"/>.
    /// <para>If the operation fails, <see langword="null"/> is returned and the user is notified.</para>
    /// </summary>
    ///
    /// <typeparam name="TSettings"> Serializable settings object. </typeparam>
    /// <param name="filePath"> Full pathname of the file where a serialized <typeparamref name="TSettings"/> is stored. </param>
    internal static TSettings LoadSettings<TSettings>(string filePath) where TSettings : class
    {
        try
        {
            return filePath.DeserializeObject<TSettings>(true, true);
        }
        catch (Exception ex)
        {
            ShowErrorMessage(null, $"{Resources.SettingsLoadErrorNotice}\n{filePath}\n\n{ex.Message}", Resources.FileLoadFailure);
        }
        return null;
    }

    /// <summary>
    /// Saves the provided <paramref name="settings"/> to <paramref name="filePath"/> and returns if the operation was
    /// successful.
    /// <para>The user is notified if any errors occur.</para>
    /// </summary>
    ///
    /// <typeparam name="TSettings"> Type of the settings. </typeparam>
    /// <param name="settings"> Serializable <typeparamref name="TSettings"/> object to save. </param>
    /// <param name="filePath"> Full pathname of the file to save <paramref name="settings"/> to. </param>
    internal static bool SaveSettings<TSettings>(TSettings settings, string filePath) where TSettings : class
    {
        try
        {
            settings.SerializeObjectToDisk(filePath);
            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMessage(null, $"{Resources.SettingsSaveErrorNotice}\n{filePath}\n\n{ex.Message}", Resources.FileSaveFailure);
            return false;
        }
    }

    /// <summary> Prepares the specified <paramref name="form"/> for display in a standard/consistent way. </summary>
    ///
    /// <param name="form"> The form to manipulate. </param>
    /// <param name="dialogText"> (Optional) <paramref name="form"/> dialog title text. </param>
    /// <param name="iconResource"> (Optional) Icon resource to set. If not provided, the <paramref name="form"/>'s owner
    ///     icon is used. </param>
    /// <param name="helpUrl"> (Optional) URL for help information for <paramref name="form"/>. </param>
    /// <param name="helpIcon"> (Optional) Help icon displayed on the <paramref name="form"/>. </param>
    /// <param name="videoUrl"> (Optional) URL of the video link displayed on the <paramref name="form"/>. </param>
    /// <param name="videoIcon"> (Optional) The video icon displayed on the <paramref name="form"/>. </param>
    /// <param name="linkToSourceLabel"> (Optional) Label which is used to provide a link to the source code. </param>
    internal static void PrepDialog(this System.Windows.Forms.Form form, string dialogText = null, System.IO.Stream iconResource = null,
        string helpUrl = null, PictureBox helpIcon = null, string videoUrl = null, PictureBox videoIcon = null, Label linkToSourceLabel = null)
    {
        // Perform these actions within an event so the parent (if any) will be defined at the time of execution.
        form.Load += (_, _) =>
        {
            if (dialogText != null)
            {
                form.Text = dialogText.ReplaceLineBreaks(" ");
            }

            form.Icon = iconResource != null
                ? System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)System.Drawing.Image.FromStream(iconResource)).GetHicon())
                : form.Owner?.Icon;

            form.AcceptButton?.DialogResult = DialogResult.OK;
            form.CancelButton?.DialogResult = DialogResult.Cancel;
        };

        form.Shown += (_, _) => form.MinimumSize = form.Size;

        // This will center within the Revit document when no owner is specified.
        form.StartPosition = FormStartPosition.CenterParent;

        if (!string.IsNullOrEmpty(helpUrl))
        {
            void openHelpUrl() => Files.StartProcess(helpUrl);
            form.HelpRequested += (_, e) =>
            {
                e.Handled = true;
                openHelpUrl();
            };

            helpIcon?.Click += (_, _) => openHelpUrl();
        }
        else
        {
            helpIcon?.Visible = false;
        }

        if (!string.IsNullOrEmpty(videoUrl) && (videoIcon != null))
        {
            videoIcon.Click += (_, _) => Files.StartProcess(videoUrl);
        }
        else
        {
            videoIcon?.Visible = false;
        }

        if (linkToSourceLabel != null)
        {
            linkToSourceLabel.Text = Resources.ViewSourceCodeOnGitHub;
            linkToSourceLabel.ForeColor = System.Drawing.Color.Blue;
            linkToSourceLabel.Font = new System.Drawing.Font(linkToSourceLabel.Font, System.Drawing.FontStyle.Underline);
            linkToSourceLabel.Cursor = Cursors.Hand;
            linkToSourceLabel.Click += (_, _) => Files.StartProcess("https://github.com/eVolveMEP/eVolve-MEP-Revit-Extensions");
        }
    }

    /// <summary> Shows an error message dialog box. </summary>
    ///
    /// <inheritdoc cref="ShowMessage"/>
    internal static void ShowErrorMessage(System.Windows.Forms.Form owner, string message, string title = null) => ShowMessage(MessageBoxIcon.Error, owner, message, title);

    /// <summary> Shows an informational message dialog box. </summary>
    ///
    /// <inheritdoc cref="ShowMessage"/>
    internal static void ShowNoticeMessage(System.Windows.Forms.Form owner, string message, string title = null) => ShowMessage(MessageBoxIcon.Information, owner, message, title);

    /// <summary> Shows a warning message dialog box. </summary>
    ///
    /// <inheritdoc cref="ShowMessage"/>
    internal static void ShowWarningMessage(System.Windows.Forms.Form owner, string message, string title = null) => ShowMessage(MessageBoxIcon.Warning, owner, message, title);

    /// <summary> Shows a prompt which offers a Yes/No response. Returns if the user selected Yes. </summary>
    ///
    /// <inheritdoc cref="ShowMessage"/>
    internal static bool ShowConfirmationPrompt(System.Windows.Forms.Form owner, string message, string title = null) => ShowMessage(MessageBoxIcon.Question, owner, message, title, MessageBoxButtons.YesNo) == DialogResult.Yes;

    /// <summary> Shows a dialog message box to the user and returns the response result. </summary>
    ///
    /// <param name="icon"> Icon to display. </param>
    /// <param name="owner"> Dialog owner. </param>
    /// <param name="message"> Text message to display to the user. </param>
    /// <param name="title"> Dialog title. </param>
    /// <param name="buttons"> (Optional) Buttons available. </param>
    private static DialogResult ShowMessage(MessageBoxIcon icon, System.Windows.Forms.Form owner, string message, string title, MessageBoxButtons buttons = MessageBoxButtons.OK)
    {
        return MessageBox.Show(owner, message, title ?? owner?.Text ?? icon.ToString(), buttons, icon);
    }
}
