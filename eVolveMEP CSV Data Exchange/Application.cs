// Copyright (c) 2020 eVolve Solutions, LLC
// All rights reserved.
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using System.Linq;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;

namespace eVolve.CsvDataExchange.Revit
{
    /// <summary> Entry point Revit uses to configure this extension. </summary>
    public class Application : IExternalApplication
    {
        /// <summary> Gets the icon resource. </summary>
        internal static System.IO.Stream IconResource
        {
            get
            {
                var resourceName = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames()
                    .First(name => name.EndsWith(".CSV_ImportExport_32x32.png"));

                return System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            }
        }

        /// <summary> Gets URL of the help link to open when requested by the user. </summary>
        internal static string HelpLinkUrl
        {
            get
            {
#if ELECTRICAL
                return "https://help-electrical.evolvemep.com/article/ye5k5bnwu2";
#elif MECHANICAL
                return "https://help-mechanical.evolvemep.com/article/g0p7prhwle";
#else
                return null;
#endif
            }
        }

        /// <inheritdoc/>
        public Result OnStartup(UIControlledApplication application)
        {
            var ribbonButton = eVolve.Core.Revit.Integration.API.CreateButton("CSV Data\nExchange",
                System.Reflection.Assembly.GetExecutingAssembly().Location,
                typeof(Command),
                typeof(CommandAvailability),
                BitmapFrame.Create(IconResource),
                "Imports/Exports data from Revit using the eVolve Integration Platform.",
                HelpLinkUrl);

            eVolve.Core.Revit.Integration.API.IntegrationRibbonPanel.AddItem(ribbonButton);

            return Result.Succeeded;
        }

        /// <inheritdoc/>
        public Result OnShutdown(UIControlledApplication application) => Result.Succeeded;
    }
}
