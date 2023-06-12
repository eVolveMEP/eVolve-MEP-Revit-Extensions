// Copyright (c) 2023 eVolve MEP, LLC
// All rights reserved.
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace eVolve.ExtensionsCommon.Revit;

/// <summary> Common methods useful across all projects in this solution. </summary>
internal static class Methods
{
    /// <summary> Gets the <paramref name="buttonText"/> as a single line text with all linebreaks removed. </summary>
    ///
    /// <param name="buttonText"> The button text as it appears in the Revit ribbon. </param>
    internal static string GetButtonTextWithNoLineBreaks(string buttonText) => buttonText
        .Replace("\r", " ")
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

    /// <summary> Gets the base directory where extensions should persist their settings. </summary>
    internal static string BaseSaveSettingsFileFolder { get; } = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "eVolve");

    /// <summary>
    /// Loads the provided <paramref name="filePath"/> from disk and deserializes it to <typeparamref name="TSettings"/>.
    /// <para>If the operation fails, <c>null</c> is returned and the user is notified.</para>
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
            System.Windows.Forms.MessageBox.Show($"{Resources.SettingsLoadErrorNotice}\n{filePath}\n\n{ex.Message}", Resources.FileLoadFailure,
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
        return null;
    }

    /// <summary>
    /// Saves the provided <paramref name="settings"/> to <paramref name="filePath"/> and returns if the operation was
    /// successful.
    /// <para>The user is notified if any error occur.</para>
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
            System.Windows.Forms.MessageBox.Show($"{Resources.SettingsSaveErrorNotice}\n{filePath}\n\n{ex.Message}", Resources.FileSaveFailure,
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            return false;
        }
    }
}
