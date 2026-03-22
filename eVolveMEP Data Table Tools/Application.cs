// Copyright (c) 2026 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace eVolve.DataTableTools.Revit;

/// <summary> Entry point Revit uses to configure this extension. </summary>
[JetBrains.Annotations.UsedImplicitly]
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
        var splitButton = (SplitButton)IntegrationAPI.IntegrationRibbonPanel.AddItem(new SplitButtonData(Resources.ToolsButtonText, Resources.ToolsButtonText));

        splitButton.AddPushButton(IntegrationAPI.CreateButton(
            Resources.ToolsButtonText.ReplaceLineBreaks("\n"),
            System.Reflection.Assembly.GetExecutingAssembly().Location,
            typeof(Tools.ToolsCommand),
            typeof(ExtensionsCommon.Revit.CommandAvailability),
            System.Windows.Media.Imaging.BitmapFrame.Create(Tools.ToolsCommand.IconResource),
            string.Format(Resources.ToolsToolTipText, HostProductName),
            Tools.ToolsCommand.HelpLinkUrl));

        splitButton.AddPushButton(IntegrationAPI.CreateButton(
            Resources.ExternalTablesButtonText.ReplaceLineBreaks("\n"),
            System.Reflection.Assembly.GetExecutingAssembly().Location,
            typeof(ExternalTables.ExternalTablesConfigCommand),
            typeof(ExtensionsCommon.Revit.CommandAvailability),
            System.Windows.Media.Imaging.BitmapFrame.Create(ExternalTables.ExternalTablesConfigCommand.IconResource),
            string.Format(Resources.ExternalTablesToolTipText, HostProductName),
            ExternalTables.ExternalTablesConfigCommand.HelpLinkUrl));

        splitButton.AddSeparator();

        splitButton.AddPushButton(IntegrationAPI.CreateButton(
            Resources.ViewTableButtonText.ReplaceLineBreaks("\n"),
            System.Reflection.Assembly.GetExecutingAssembly().Location,
            typeof(ViewTable.ViewTableCommand),
            typeof(ExtensionsCommon.Revit.CommandAvailability),
            System.Windows.Media.Imaging.BitmapFrame.Create(ViewTable.ViewTableCommand.IconResource),
            string.Format(Resources.ViewTableToolTipText, HostProductName),
            ViewTable.ViewTableCommand.HelpLinkUrl));

        splitButton.AddSeparator();

        splitButton.AddPushButton(IntegrationAPI.CreateButton(
            Resources.CopyDataTableButtonText.ReplaceLineBreaks("\n"),
            System.Reflection.Assembly.GetExecutingAssembly().Location,
            typeof(CopyTable.CopyTableCommand),
            typeof(ExtensionsCommon.Revit.CommandAvailability),
            System.Windows.Media.Imaging.BitmapFrame.Create(CopyTable.CopyTableCommand.IconResource),
            string.Format(Resources.CopyDataTableToolTipText, HostProductName),
            CopyTable.CopyTableCommand.HelpLinkUrl));

        ProductInfoAPI.RegisterExpansionPathMarker("DataTableToolsConfigPath", ApplicationConfigurationPath);

        // Load external tables for usage.
        ExternalTables.ExternalTablesMethods.ApplySettings(ExternalTables.ExternalTablesMethods.GetSettings(ExternalTables.ExternalTablesMethods.GetExternalTablesSettingsFilePath(out _)), false);

        return Result.Succeeded;
    }

    /// <inheritdoc/>
    public Result OnShutdown(UIControlledApplication application) => Result.Succeeded;
}