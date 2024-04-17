// Copyright (c) 2024 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using Autodesk.Revit.Attributes;

namespace eVolve.DataTableTools.Revit.ExternalTables;

/// <summary> Opens a <see cref="ExternalTablesConfigDialog"/>. </summary>
[Transaction(TransactionMode.Manual)]
[Regeneration(RegenerationOption.Manual)]
internal class ExternalTablesConfigCommand : IExternalCommand
{
    /// <summary> Gets the icon resource. </summary>
    internal static System.IO.Stream IconResource => GetIconResource("DataTableTools_32x32.png");

    /// <summary> Gets URL of the help link to open when requested by the user. </summary>
    internal static string HelpLinkUrl
    {
        get
        {
#if ELECTRICAL
            return "";
#elif MECHANICAL
            return "";
#endif
        }
    }

    /// <inheritdoc />
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        using var dialog = new ExternalTablesConfigDialog();
        dialog.ShowDialog();
        return Result.Succeeded;
    }
}
