using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core.Data
{
    public class BangHomeCityPreservedCard
    {
        public uint Version { get; set; } = 0;

        public string Name { get; set; } = "";

        public int ID { get; set; } = 0;

        public static BangHomeCityPreservedCard Load(BangChunkReader<BangDataHeader> chunkReader)
        {
            BangHomeCityPreservedCard bangHomeCityPreservedCard = new BangHomeCityPreservedCard();

            chunkReader.ReadExpectedTag(0x6463);

            bangHomeCityPreservedCard.Version = chunkReader.ReadUInt32();
            bangHomeCityPreservedCard.Name = chunkReader.ReadString();
            bangHomeCityPreservedCard.ID = chunkReader.ReadInt32();

            return bangHomeCityPreservedCard;
        }
    }
}
