// Copyright (c) 2020 eVolve Solutions, LLC
// All rights reserved.
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

extern alias eVolve;

using System;
using System.Linq;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;
using eVolve.CsvDataExchange.Revit.Properties;

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
            var ribbonButton = eVolve::eVolve.Core.Revit.Integration.API.CreateButton(Resources.ButtonText,
                System.Reflection.Assembly.GetExecutingAssembly().Location,
                typeof(Command),
                typeof(CommandAvailability),
                BitmapFrame.Create(Command.IconResource),
                Resources.ToolTipText,
                Command.HelpLinkUrl);

            eVolve::eVolve.Core.Revit.Integration.API.IntegrationRibbonPanel.AddItem(ribbonButton);

            return Result.Succeeded;
        }

        /// <inheritdoc/>
        public Result OnShutdown(UIControlledApplication application) => Result.Succeeded;
    }
}
