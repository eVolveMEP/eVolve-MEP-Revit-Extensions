// Copyright (c) 2024 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using System.Windows.Forms;

namespace eVolve.DataTableTools.Revit.ExternalTables;

/// <summary> Control for definiting input required by <see cref="ExternalTableSourceBase"/>. </summary>
internal partial class ExternalTableSourceBaseControl : UserControl
{
    /// <summary> Default constructor. </summary>
    public ExternalTableSourceBaseControl()
    {
        InitializeComponent();

        ToolTip.SetToolTip(NameTextBox, ToolTip.GetToolTip(NameLabel));
    }

    /// <summary> Validates the data. </summary>
    ///
    /// <typeparam name="T"> Concrete implementation of <see cref="ExternalTableSourceBase"/>. </typeparam>
    /// <param name="data"> Fully populated <typeparamref name="T"/> instance to validate. </param>
    /// <param name="additionalFields"> Additional data to validate. </param>
    internal bool ValidateData<T>(T data, IEnumerable<(string Value, string InputLabel)> additionalFields) where T : ExternalTableSourceBase
    {
        var messages = new[] { (data.Name, NameLabel.Text) }
            .Concat(additionalFields)
            .Where(input => !string.IsNullOrWhiteSpace(input.Item1))
            .Select(input => string.Format(Resources.ValueMustBeProvided1Error, input.Item2))
            .ToArray();

        if (messages.Any())
        {
            ShowErrorMessage(this.ParentForm, string.Join("\n- ", messages.Prepend("")).Trim());
        }
        return !messages.Any();
    }

    /// <summary> Gets a new <typeparamref name="T"/> instance filled with data entered on this control. </summary>
    ///
    /// <typeparam name="T"> Concrete implementation of <see cref="ExternalTableSourceBase"/>. </typeparam>
    public T GetData<T>() where T : ExternalTableSourceBase, new() => new()
    {
        Name = NameTextBox.Text.Trim(),
        Cache = CacheCheckBox.Checked,
    };

    /// <summary> Sets the values from <paramref name="data"/> into the user input fields. </summary>
    ///
    /// <typeparam name="T"> Concrete implementation of <see cref="ExternalTableSourceBase"/>. </typeparam>
    /// <param name="data"> Source to popuplate into data entry fields. </param>
    public void SetData<T>(T data) where T : ExternalTableSourceBase
    {
        NameTextBox.Text = data.Name;
        CacheCheckBox.Checked = data.Cache;
    }
}
