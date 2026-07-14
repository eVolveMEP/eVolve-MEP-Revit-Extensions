// Copyright (c) 2026 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace eVolve.CsvDataExchange.Revit;

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
        var ribbonButton = IntegrationAPI.CreateButton(Resources.ButtonText,
            System.Reflection.Assembly.GetExecutingAssembly().Location,
            typeof(Command),
            typeof(ExtensionsCommon.Revit.CommandAvailability),
            System.Windows.Media.Imaging.BitmapFrame.Create(Command.IconResource),
            string.Format(Resources.ToolTipText, HostProductName),
            Command.HelpLinkUrl);

        IntegrationAPI.IntegrationRibbonPanel.AddItem(ribbonButton);

        IntegrationAPI.RegisterImplementingFeature(Command.FeatureId, Resources.ButtonText.ReplaceLineBreaks(" "));

        return Result.Succeeded;
    }

    /// <inheritdoc/>
    public Result OnShutdown(UIControlledApplication application) => Result.Succeeded;
}