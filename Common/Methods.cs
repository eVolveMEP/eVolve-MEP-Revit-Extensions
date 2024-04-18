// Copyright (c) 2024 eVolve MEP, LLC
// All rights reserved.
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using System.Windows.Forms;

namespace eVolve.ExtensionsCommon.Revit;

/// <summary> Common methods useful across all projects in this solution. </summary>
internal static class Methods
{
    /// <summary> Gets the <paramref name="text"/> with all line breaks normalized to a <c>\n</c> character. </summary>
    ///
    /// <remarks> This is typically needed when making <see cref="SplitButton"/> text so it appears "correctly". </remarks>
    ///
    /// <param name="text"> The button text as it appears in the Revit ribbon. </param>
    internal static string GetTextWithNormalizedLineBreaks(string text) => string.Join("\n", text.Split(["\r\n", "\r", "\n"], StringSplitOptions.RemoveEmptyEntries));

    /// <summary> Gets the <paramref name="text"/> as a single line text with all linebreaks removed. </summary>
    ///
    /// <param name="text"> Text to process. </param>
    internal static string GetTextWithNoLineBreaks(string text) => GetTextWithNormalizedLineBreaks(text)
        .Replace("\n", " ")
        .Replace("  ", " ")
        .Replace("  ", " ");

    /// <summary>
    /// Gets the icon resource. It is assumed this is an embedded resource within the respective library.
    /// </summary>
    ///
    /// <param name="imageFileName"> Filename of the image file which is embedded within the library. </param>
    internal static System.IO.Stream GetIconResource(string imageFileName)
    {
        var resourceName = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames()
                .First(name => name.EndsWith("." + imageFileName));

        return System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
    }

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
            if (System.IO.File.Exists(filePath))
            {
                var data = System.IO.File.ReadAllText(filePath);
                using var stream = new System.IO.StringReader(data);
                return (TSettings)new System.Xml.Serialization.XmlSerializer(typeof(TSettings)).Deserialize(stream);
            }
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
            using var stream = new System.IO.StringWriter();
            new System.Xml.Serialization.XmlSerializer(typeof(TSettings)).Serialize(stream, settings);

            var targetDirectory = System.IO.Path.GetDirectoryName(filePath);
            if (!System.IO.Directory.Exists(targetDirectory))
            {
                System.IO.Directory.CreateDirectory(targetDirectory!);
            }
            System.IO.File.WriteAllText(filePath, stream.ToString());
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
    /// <param name="iconResource"> (Optional) Icon resource to set. If not provided, the <paramref name="form"/>'s owner icon is used. </param>
    /// <param name="helpUrl"> (Optional) URL for help information for <paramref name="form"/>. </param>
    /// <param name="helpIcon"> (Optional) Help icon displayed on the <paramref name="form"/>. </param>
    /// <param name="linkToSourceLabel"> (Optional) Label which is used to provide a link to the source code. </param>
    internal static void PrepDialog(this System.Windows.Forms.Form form, string dialogText = null, System.IO.Stream iconResource = null, string helpUrl = null, PictureBox helpIcon = null, Label linkToSourceLabel = null)
    {
        // Perform these actions within an event so the parent (if any) will be defined at the time of execution.
        form.Load += (_, _) =>
        {
            if (dialogText != null)
            {
                form.Text = GetTextWithNoLineBreaks(dialogText);
            }

            form.Icon = iconResource != null
                ? System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)System.Drawing.Image.FromStream(iconResource)).GetHicon())
                : form.Owner?.Icon;

            if (form.AcceptButton != null)
            {
                form.AcceptButton.DialogResult = DialogResult.OK;
            }
            if (form.CancelButton != null)
            {
                form.CancelButton.DialogResult = DialogResult.Cancel;
            }
        };

        form.Shown += (_, _) => form.MinimumSize = form.Size;

        // This will center within the Revit document when no owner is specified.
        form.StartPosition = FormStartPosition.CenterParent;

        if (!string.IsNullOrEmpty(helpUrl))
        {
            void openHelpUrl() => System.Diagnostics.Process.Start(helpUrl);
            form.HelpRequested += (_, e) =>
            {
                e.Handled = true;
                openHelpUrl();
            };

            if (helpIcon != null)
            {
                helpIcon.Click += (_, _) => openHelpUrl();
            }
        }
        else if (helpIcon != null)
        {
            helpIcon.Visible = false;
        }

        if (linkToSourceLabel != null)
        {
            linkToSourceLabel.Text = Resources.ViewSourceCodeOnGitHub;
            linkToSourceLabel.ForeColor = System.Drawing.Color.Blue;
            linkToSourceLabel.Font = new System.Drawing.Font(linkToSourceLabel.Font, System.Drawing.FontStyle.Underline);
            linkToSourceLabel.Cursor = Cursors.Hand;
            linkToSourceLabel.Click += (_, _) => System.Diagnostics.Process.Start("https://github.com/eVolveMEP/eVolve-MEP-Revit-Extensions");
        }
    }

    /// <summary> Performs base64 encoding on the specified <paramref name="text"/>. </summary>
    ///
    /// <param name="text"> Value to encode. </param>
    public static string ToBase64(string text) => string.IsNullOrEmpty(text) ? "" : Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(text.ToCharArray()));

    /// <summary>
    /// Performs base64 decoding on the specified <paramref name="text"/>. If the provided value is malformed, an empty
    /// string is returned.
    /// </summary>
    ///
    /// <param name="text"> Value to decode. </param>
    public static string FromBase64(string text)
    {
        try
        {
            return System.Text.Encoding.Default.GetString(Convert.FromBase64String(text));
        }
        catch (Exception)
        {
            return "";
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
