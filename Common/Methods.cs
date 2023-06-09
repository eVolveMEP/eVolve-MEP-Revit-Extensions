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
}
