// Copyright (c) 2024 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using Autodesk.Revit.Attributes;

namespace eVolve.DataTableTools.Revit.ViewTable;

/// <summary> Opens a dialog for viewing the contents of data tables. </summary>
[Transaction(TransactionMode.Manual)]
[Regeneration(RegenerationOption.Manual)]
internal class ViewTableCommand : IExternalCommand
{
    /// <summary> Gets the icon resource. </summary>
    internal static System.IO.Stream IconResource => GetIconResource("ViewDataTables_32x32.png");

    /// <summary> Gets URL of the help link to open when requested by the user. </summary>
    internal static string HelpLinkUrl
    {
        get
        {
#if ELECTRICAL
            return "https://help-electrical.evolvemep.com/article/6g1tvdhzn2";
#elif MECHANICAL
            return "https://help-mechanical.evolvemep.com/article/k7d9liw314";
#endif
        }
    }

    /// <inheritdoc />
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        try
        {
            using var dialog = new ViewTableDialog(commandData.Application.ActiveUIDocument.Document);
            dialog.ShowDialog();
        }
        catch (Exception ex)
        {
            ShowErrorMessage(null, ex.Message, GetTextWithNoLineBreaks(Resources.ViewTableButtonText));
        }
        return Result.Succeeded;
    }
}
