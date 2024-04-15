// Copyright (c) 2024 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace eVolve.DataTableTools.Revit.Tools;

/// <summary>
/// Dialog for prompting the user for multi-line input.
/// <para>Consume via <see cref="GetTextInput"/>.</para>
/// </summary>
internal sealed partial class TextInputDialog : System.Windows.Forms.Form
{
    /// <summary>
    /// Displays the <see cref="TextInputDialog"/> and returns the user entered text input. If the user cancels, <c>null</c>
    /// is returned.
    /// </summary>
    ///
    /// <param name="owner"> Owner of this dialog. </param>
    /// <param name="title"> Dialog title text. </param>
    /// <param name="instructions"> Input instructions to provide to the user. </param>
    /// <param name="existingValue"> Value which should be prefilled into the input text box. </param>
    public static string GetTextInput(System.Windows.Forms.Form owner, string title, string instructions, string existingValue)
    {
        using var dialog = new TextInputDialog();
        dialog.Owner = owner;
        dialog.Icon = owner.Icon;
        dialog.Text = title ?? "";
        dialog.InstructionsLabel.Text = instructions ?? "";
        dialog.InputTextBox.Text = existingValue ?? "";
        return dialog.ShowDialog(owner) == System.Windows.Forms.DialogResult.OK ? dialog.InputTextBox.Text : null;
    }

    /// <summary> Constructor that prevents a default instance of this class from being created. </summary>
    private TextInputDialog()
    {
        InitializeComponent();
    }
}
