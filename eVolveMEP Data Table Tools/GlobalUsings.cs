// Copyright (c) 2026 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

// Global using directives

extern alias eVolveProduct;
global using eVolveProduct::eVolve.Core.Revit.General;
global using eVolveProduct::eVolve.Core.Revit.Integration;
global using IntegrationAPI = eVolveProduct::eVolve.Core.Revit.Integration.API;
global using ProductInfoAPI = eVolveProduct::eVolve.Core.Revit.ProductInfo.API;
global using eVolveProduct::eVolve.Core.Revit.Reporting;
global using ReportingAPI = eVolveProduct::eVolve.Core.Revit.Reporting.API;

global using System;
global using System.Collections.Generic;
global using System.Linq;
global using Autodesk.Revit.DB;
global using Autodesk.Revit.UI;
global using eVolve.DataTableTools.Revit.Properties;
global using static eVolve.DataTableTools.Revit.ApplicationMethods;
global using static eVolve.ExtensionsCommon.Revit.Methods;