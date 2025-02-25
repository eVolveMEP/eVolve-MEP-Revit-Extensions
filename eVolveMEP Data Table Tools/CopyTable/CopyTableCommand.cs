﻿// Copyright (c) 2025 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using Autodesk.Revit.Attributes;

namespace eVolve.DataTableTools.Revit.CopyTable;

/// <summary> Opens a dialog for viewing the contents of data tables. </summary>
[Transaction(TransactionMode.Manual)]
[Regeneration(RegenerationOption.Manual)]
internal class CopyTableCommand : IExternalCommand
{
    /// <summary> Gets the icon resource. </summary>
    internal static System.IO.Stream IconResource => GetIconResource("CopyDataTable_32x32.png");

    /// <summary> Gets URL of the help link to open when requested by the user. </summary>
    internal static string HelpLinkUrl
    {
        get
        {
#if ELECTRICAL
            return "https://help-electrical.evolvemep.com/article/8e78i6s1b1";
#elif MECHANICAL
            return "https://help-mechanical.evolvemep.com/article/cugcppz3e6";
#endif
        }
    }

    /// <summary> Gets URL of the video tutorial link to open when requested by the user. </summary>
    internal static string VideoUrl
    {
        get
        {
#if ELECTRICAL
            return "https://help-electrical.evolvemep.com/article/riv04ya68p";
#elif MECHANICAL
            return "https://help-mechanical.evolvemep.com/article/jwgi7rthxd";
#endif
        }
    }

    /// <inheritdoc />
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        try
        {
            using var dialog = new CopyTableDialog(commandData.Application.ActiveUIDocument.Document);
            dialog.ShowDialog();
        }
        catch (Exception ex)
        {
            ShowErrorMessage(null, ex.Message, GetTextWithNoLineBreaks(Resources.CopyDataTableButtonText));
        }
        return Result.Succeeded;
    }
}
