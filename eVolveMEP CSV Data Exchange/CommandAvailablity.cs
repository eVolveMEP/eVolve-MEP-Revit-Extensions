// Copyright (c) 2023 eVolve MEP, LLC
// All rights reserved.
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace eVolve.CsvDataExchange.Revit;

/// <summary> Determines if a Revit document is currently loaded. </summary>
internal class CommandAvailability : IExternalCommandAvailability
{
    /// <inheritdoc/>
    public bool IsCommandAvailable(UIApplication application, CategorySet b) => application?.ActiveUIDocument != null;
}