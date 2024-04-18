// Copyright (c) 2024 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

extern alias eVolve;

namespace eVolve.DataTableTools.Revit;

/// <summary> Entry point Revit uses to configure this extension. </summary>
#if ELECTRICAL
public class ApplicationElectrical : IExternalApplication
#elif MECHANICAL
public class ApplicationMechanical : IExternalApplication
#endif
{
    /// <summary> Name of the eVolve host product. </summary>
    private static string HostProductName =>
#if ELECTRICAL
        Resources.eVolveElectrical;
#elif MECHANICAL
        Resources.eVolveMechanical;
#endif

    /// <inheritdoc/>
    public Result OnStartup(UIControlledApplication application)
    {
        var splitButton = (SplitButton)eVolve::eVolve.Core.Revit.Integration.API.IntegrationRibbonPanel.AddItem(new SplitButtonData(Resources.ToolsButtonText, Resources.ToolsButtonText));

        splitButton.AddPushButton(eVolve::eVolve.Core.Revit.Integration.API.CreateButton(
            GetTextWithNormalizedLineBreaks(Resources.ToolsButtonText),
            System.Reflection.Assembly.GetExecutingAssembly().Location,
            typeof(Tools.ToolsCommand),
            typeof(ExtensionsCommon.Revit.CommandAvailability),
            System.Windows.Media.Imaging.BitmapFrame.Create(Tools.ToolsCommand.IconResource),
            string.Format(Resources.ToolsToolTipText, HostProductName),
            Tools.ToolsCommand.HelpLinkUrl));

        splitButton.AddPushButton(eVolve::eVolve.Core.Revit.Integration.API.CreateButton(
            GetTextWithNormalizedLineBreaks(Resources.ExternalTablesButtonText),
            System.Reflection.Assembly.GetExecutingAssembly().Location,
            typeof(ExternalTables.ExternalTablesConfigCommand),
            typeof(ExtensionsCommon.Revit.CommandAvailability),
            System.Windows.Media.Imaging.BitmapFrame.Create(ExternalTables.ExternalTablesConfigCommand.IconResource),
            string.Format(Resources.ExternalTablesToolTipText, HostProductName),
            ExternalTables.ExternalTablesConfigCommand.HelpLinkUrl));

        splitButton.AddSeparator();

        splitButton.AddPushButton(eVolve::eVolve.Core.Revit.Integration.API.CreateButton(
            GetTextWithNormalizedLineBreaks(Resources.ViewTableButtonText),
            System.Reflection.Assembly.GetExecutingAssembly().Location,
            typeof(ViewTable.ViewTableCommand),
            typeof(ExtensionsCommon.Revit.CommandAvailability),
            System.Windows.Media.Imaging.BitmapFrame.Create(ViewTable.ViewTableCommand.IconResource),
            string.Format(Resources.ViewTableToolTipText, HostProductName),
            ViewTable.ViewTableCommand.HelpLinkUrl));

        // Load external tables for usage.
        ExternalTables.ExternalTablesMethods.ApplySettings(ExternalTables.ExternalTablesMethods.GetSettings());

        return Result.Succeeded;
    }

    /// <inheritdoc/>
    public Result OnShutdown(UIControlledApplication application) => Result.Succeeded;
}