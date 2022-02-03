// Copyright (c) 2020 eVolve Solutions, LLC
// All rights reserved.
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

extern alias eVolve;
using System.Linq;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;

namespace eVolve.CsvDataExchange.Revit
{
    /// <summary> Entry point Revit uses to configure this extension. </summary>
#if ELECTRICAL
    public class ApplicationElectrical : IExternalApplication
#elif MECHANICAL
    public class ApplicationMechanical : IExternalApplication
#endif
    {
        /// <inheritdoc/>
        public Result OnStartup(UIControlledApplication application)
        {
            var ribbonButton = eVolve::eVolve.Core.Revit.Integration.API.CreateButton("CSV Data\nExchange",
                System.Reflection.Assembly.GetExecutingAssembly().Location,
                typeof(Command),
                typeof(CommandAvailability),
                BitmapFrame.Create(Command.IconResource),
                "Imports/Exports data from Revit using the eVolve Integration Platform.",
                Command.HelpLinkUrl);

            eVolve::eVolve.Core.Revit.Integration.API.IntegrationRibbonPanel.AddItem(ribbonButton);

            return Result.Succeeded;
        }

        /// <inheritdoc/>
        public Result OnShutdown(UIControlledApplication application) => Result.Succeeded;
    }
}
