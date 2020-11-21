// Copyright (c) 2020 eVolve Solutions, LLC
// All rights reserved.
//
// This source code is licensed under the BSD-style license found in the
// LICENSE.txt file in the root directory of this source tree.

using System;

namespace eVolve.CsvDataExchange.Revit
{
    /// <summary> Data delimiter options. </summary>
    [Serializable]
    public enum DelimiterChars
    {
        /// <summary> <c>,</c> </summary>
        Comma,
        /// <summary> <c>\t</c> </summary>
        Tab,
    }

    /// <summary> Stores settings configured on <see cref="ConfigurationForm"/>. </summary>
    [Serializable]
    public class Settings
    {
        /// <summary> Gets or sets the exchange direction. </summary>
        public eVolve.Core.Revit.Integration.IntegrationDirection Direction { get; set; }

        /// <summary> Gets or sets the name of the profile. </summary>
        public string ProfileName { get; set; }

        /// <summary> Gets or sets the full pathname of the target file. </summary>
        public string FilePath { get; set; }

        /// <summary> Gets or sets the delimiter used for separating data. </summary>
        public DelimiterChars Delimiter { get; set; } = DelimiterChars.Comma;

        /// <summary>
        /// Gets or sets a list of the optional export columns to be included. Entries here should reconcile with
        /// <see cref="Command.OptionalExportColumns"/>.
        /// </summary>
        public string[] IncludeExportColumns { get; set; } = Array.Empty<string>();
    }
}
