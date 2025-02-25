// Copyright (c) 2025 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using Autodesk.Revit.Attributes;

namespace eVolve.DataTableTools.Revit.Tools;

/// <summary> Opens the <see cref="ToolsDialog"/> for working with data tables. </summary>
[Transaction(TransactionMode.Manual)]
[Regeneration(RegenerationOption.Manual)]
internal class ToolsCommand : IExternalCommand
{
    /// <summary> Gets the icon resource. </summary>
    internal static System.IO.Stream IconResource => GetIconResource("DataTableTools_32x32.png");

    /// <summary> Gets URL of the help link to open when requested by the user. </summary>
    internal static string HelpLinkUrl
    {
        get
        {
#if ELECTRICAL
            return "https://help-electrical.evolvemep.com/article/q68ll2jlyf";
#elif MECHANICAL
            return "https://help-mechanical.evolvemep.com/article/9mgugym789";
#endif
        }
    }

    /// <summary> Gets URL of the video tutorial link to open when requested by the user. </summary>
    internal static string VideoUrl
    {
        get
        {
#if ELECTRICAL
            return "https://help-electrical.evolvemep.com/article/fh5yvefrwq";
#elif MECHANICAL
            return "https://help-mechanical.evolvemep.com/article/5c92yyzvgw";
#endif
        }
    }

    /// <inheritdoc/>
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        using var dialog = new ToolsDialog(commandData.Application.ActiveUIDocument.Document);
        dialog.ShowDialog();
        return Result.Succeeded;
    }
}