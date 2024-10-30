// Copyright (c) 2024 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

extern alias eVolve;

using System.Data;

namespace eVolve.DataTableTools.Revit.ExternalTables;

/// <summary> Constructor. </summary>
///
/// <param name="source"> <inheritdoc cref="Source" path="/summary"/>. </param>
internal class DataTableSource(SerializedDataTableSource source) : eVolve::eVolve.Core.Revit.Reporting.IExternalDataTable
{
    /// <summary> Source definition which defines how data is pulled. </summary>
    private SerializedDataTableSource Source { get; } = source;

    /// <inheritdoc />
    public string Id => $"{nameof(DataTableSource)}_{Source.Name}";

    /// <inheritdoc />
    public string Name => Source.Name;

    /// <inheritdoc />
    public string Description => Source.Description;

    /// <inheritdoc />
    public bool CacheData => Source.Cache;

    /// <summary> Backing field for <see cref="GetLastUpdatedOn"/>. </summary>
    private DateTime LastUpdated { get; set; } = DateTime.MinValue;

    /// <inheritdoc />
    public DateTime GetLastUpdatedOn(Document document) => LastUpdated;

    /// <remarks>
    /// The format of <see cref="SerializedDataTableSource.FilePath"/> is expected to be that persisted by <see cref="SaveDataTableToFile"/>.
    /// </remarks>
    ///
    /// <inheritdoc/>
    public DataTable GetData(Document document, out string metadata)
    {
        metadata = null;
        if (!System.IO.File.Exists(Source.FilePath))
        {
            return null;
        }

        try
        {
            using var compressedStream = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(Source.FilePath));
            using var decompressedStream = new System.IO.MemoryStream();
            using (var decompressor = new System.IO.Compression.GZipStream(compressedStream, System.IO.Compression.CompressionMode.Decompress))
            {
                decompressor.CopyTo(decompressedStream);
            }

            var tableXml = System.Text.Encoding.UTF8.GetString(decompressedStream.ToArray());
            var table = new DataTable();
            using var reader = new System.IO.StringReader(tableXml);
            table.ReadXml(reader);
            table.TableName = Source.Name;

            LastUpdated = DateTime.Now;
            return table;
        }
        catch (Exception ex)
        {
            throw new Exception(Resources.ReadingDataTableError + Environment.NewLine + ex.Message);
        }
    }

    /// <summary> Save the provided <paramref name="table"/> to <paramref name="filepath"/> in the format which is read by <see cref="GetData"/>. </summary>
    ///
    /// <param name="table"> The table to serialize. </param>
    /// <param name="filepath"> The filepath to save the data. </param>
    internal static void SaveDataTableToFile(DataTable table, string filepath)
    {
        using var writer = new System.IO.StringWriter();
        using var xmlWriter = new System.Xml.XmlTextWriter(writer);
        xmlWriter.Formatting = System.Xml.Formatting.None;
        table.WriteXml(xmlWriter, XmlWriteMode.WriteSchema);
        var tableXml = writer.ToString();

        using var uncompressedStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(tableXml));
        using var compressedStream = new System.IO.MemoryStream();
        using (var compressor = new System.IO.Compression.GZipStream(compressedStream, System.IO.Compression.CompressionLevel.Optimal, true))
        {
            uncompressedStream.CopyTo(compressor);
        }

        using var fileStream = System.IO.File.Create(filepath);
        compressedStream.WriteTo(fileStream);
    }
}
