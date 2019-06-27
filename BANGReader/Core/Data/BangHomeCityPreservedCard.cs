using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core.Data
{
    public class BangHomeCityPreservedCard
    {
        public uint Version { get; set; } = 0;

        public string UnkString { get; set; } = "";

        public int UnkInt { get; set; } = 0;

        public static BangHomeCityPreservedCard Load(BangChunkReader<BangDataHeader> chunkReader)
        {
            BangHomeCityPreservedCard bangHomeCityPreservedCard = new BangHomeCityPreservedCard();

            chunkReader.ReadExpectedTag(0x6463);

            bangHomeCityPreservedCard.Version = chunkReader.ReadUInt32();
            bangHomeCityPreservedCard.UnkString = chunkReader.ReadString();
            bangHomeCityPreservedCard.UnkInt = chunkReader.ReadInt32();

            return bangHomeCityPreservedCard;
        }
    }
}
