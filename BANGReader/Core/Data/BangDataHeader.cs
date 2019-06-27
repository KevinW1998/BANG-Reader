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

        public bool IsMultiplayerSave { get; set; } = false;

        // Provided by user
        public BangGameTarget GameTarget { get; set; } = BangGameTarget.AgeOfMythology;
        public BangGameType GameType { get; set; } = BangGameType.Scenario;

        public static BangDataHeader Load(BangChunkReader<BangDataHeader> chunkReader, BangGameTarget target, BangGameType type)
        {
            BangDataHeader header = new BangDataHeader();

            chunkReader.ReadExpectedTag(0x4742);
            header.FileVersion = chunkReader.ReadInt32();
            header.VersionInformation = header.FileVersion >= 25 ? chunkReader.ReadString() : "Unknown";

            var lenUnkArray = header.FileVersion >= 4 ? chunkReader.ReadInt32() : 0;
            header.UnkCArray = chunkReader.ReadASCIIString(lenUnkArray);

            if (header.FileVersion >= 23)
            {
                int unkLangId = chunkReader.ReadInt32(); // TODO: This is lang id --> would need to load lang xml files
                header.UnkStr = chunkReader.ReadString();
            }

            if (header.FileVersion >= 33)
            {
                header.IsMultiplayerSave = chunkReader.ReadBoolean();
            }

            chunkReader.Header = header;
            chunkReader.Header.GameTarget = target;
            chunkReader.Header.GameType = type;

            return header;
        }
    }
}
