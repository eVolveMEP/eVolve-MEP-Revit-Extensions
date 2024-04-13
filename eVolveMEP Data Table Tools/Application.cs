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
        var ribbonButton = eVolve::eVolve.Core.Revit.Integration.API.CreateButton(Resources.ToolsButtonText,
            System.Reflection.Assembly.GetExecutingAssembly().Location,
            typeof(ToolsCommand),
            typeof(ExtensionsCommon.Revit.CommandAvailability),
            System.Windows.Media.Imaging.BitmapFrame.Create(ToolsCommand.IconResource),
            string.Format(Resources.ToolsToolTipText, HostProductName),
            ToolsCommand.HelpLinkUrl);

        eVolve::eVolve.Core.Revit.Integration.API.IntegrationRibbonPanel.AddItem(ribbonButton);

        return Result.Succeeded;
    }

    /// <inheritdoc/>
    public Result OnShutdown(UIControlledApplication application) => Result.Succeeded;
}