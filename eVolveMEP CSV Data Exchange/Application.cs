// Copyright (c) 2023 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

extern alias eVolve;
using eVolve::eVolve.Core.Revit.Integration;

namespace eVolve.CsvDataExchange.Revit;

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
        var ribbonButton = API.CreateButton(Resources.ButtonText,
            System.Reflection.Assembly.GetExecutingAssembly().Location,
            typeof(Command),
            typeof(CommandAvailability),
            System.Windows.Media.Imaging.BitmapFrame.Create(Command.IconResource),
            string.Format(Resources.ToolTipText, HostProductName),
            Command.HelpLinkUrl);

        API.IntegrationRibbonPanel.AddItem(ribbonButton);

        API.RegisterImplementingFeature(Command.FeatureId, Command.ButtonTextWithNoLineBreaks);

        return Result.Succeeded;
    }

    /// <inheritdoc/>
    public Result OnShutdown(UIControlledApplication application) => Result.Succeeded;
}