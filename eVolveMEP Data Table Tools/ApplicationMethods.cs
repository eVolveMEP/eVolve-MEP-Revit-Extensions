// Copyright (c) 2024 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace eVolve.DataTableTools.Revit;

/// <summary> Methods specific to this application. </summary>
internal static class ApplicationMethods
{
    /// <summary> Gets a lookup of column data type display names (key) with each one's respective data type (value). </summary>
    internal static Dictionary<string, Type> ColumnDataTypeLookup { get; } = new()
    {
        { nameof(String), typeof(string) },
        { nameof(Int32), typeof(int) },
        { nameof(Int64), typeof(long) },
        { nameof(Double), typeof(double) },
        { nameof(Decimal), typeof(decimal) },
        { nameof(Boolean), typeof(bool) },
        { nameof(DateTime), typeof(DateTime) },
    };
}
