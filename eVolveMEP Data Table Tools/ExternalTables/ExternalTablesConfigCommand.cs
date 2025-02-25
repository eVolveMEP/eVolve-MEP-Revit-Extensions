// Copyright (c) 2025 eVolve MEP, LLC
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
    internal static System.IO.Stream IconResource => GetIconResource("ExternalTablesConfiguration_32x32.png");

    /// <summary> Gets URL of the help link to open when requested by the user. </summary>
    internal static string HelpLinkUrl
    {
        get
        {
#if ELECTRICAL
            return "https://help-electrical.evolvemep.com/article/x1ttgpllk2";
#elif MECHANICAL
            return "https://help-mechanical.evolvemep.com/article/dofelbuc87";
#endif
        }
    }

    /// <summary> Gets URL of the video tutorial link to open when requested by the user. </summary>
    internal static string VideoUrl
    {
        get
        {
#if ELECTRICAL
            return "https://help-electrical.evolvemep.com/article/kd5msk830k";
#elif MECHANICAL
            return "https://help-mechanical.evolvemep.com/article/pdf0kysh1n";
#endif
        }
    }

    /// <inheritdoc />
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        using var dialog = new ExternalTablesConfigDialog(commandData.Application.ActiveUIDocument.Document);
        dialog.ShowDialog();
        return Result.Succeeded;
    }
}
