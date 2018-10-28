using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core.Data
{
    public class BangDataHeader
    {
        public static readonly int MaxFileVersion = 46;

        public int FileVersion { get; set; } = 0;
        public string VersionInformation { get; set; } = "Unknown";

        public string UnkCArray { get; set; } = "";
        public string UnkStr { get; set; } = "";

        public bool UnkBool { get; set; } = false;

    }
}
