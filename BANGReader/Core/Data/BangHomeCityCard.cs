using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core.Data
{
    public class BangHomeCityCard
    {
        public uint Version { get; set; } = 0;

        public int UnkDword0 { get; set; } = 0;
        public int UnkDword4 { get; set; } = 0;
        public int UnkDword8 { get; set; } = 0;
        public int UnkDwordC { get; set; } = 0;
        public int UnkDword { get; set; } = -1; // TODO: Check offsets
        public int UnkDword1C { get; set; } = 0;
        public int UnkDword10 { get; set; } = 0;
        public int UnkDword14 { get; set; } = 0;
        public int UnkDword18 { get; set; } = 0;

        public bool UnkBool20 { get; set; } = false;
        public bool UnkBool { get; set; } = false;

        public static BangHomeCityCard Load(BangChunkReader<BangDataHeader> chunkReader)
        {
            BangHomeCityCard bangHomeCityCard = new BangHomeCityCard();

            chunkReader.ReadExpectedTag(0x6463);

            bangHomeCityCard.Version = chunkReader.ReadUInt32();
            bangHomeCityCard.UnkDword0 = chunkReader.ReadInt32();
            bangHomeCityCard.UnkDword4 = chunkReader.ReadInt32();
            bangHomeCityCard.UnkDword8 = chunkReader.ReadInt32();
            bangHomeCityCard.UnkDwordC = chunkReader.ReadInt32();

            if(bangHomeCityCard.Version > 3)
            {
                bangHomeCityCard.UnkDword = chunkReader.ReadInt32();
            }

            bangHomeCityCard.UnkDword1C = chunkReader.ReadInt32();
            bangHomeCityCard.UnkDword10 = chunkReader.ReadInt32();
            bangHomeCityCard.UnkDword14 = chunkReader.ReadInt32();

            if(bangHomeCityCard.Version > 0)
                bangHomeCityCard.UnkDword18 = chunkReader.ReadInt32();

            if (bangHomeCityCard.Version > 1)
                bangHomeCityCard.UnkBool20 = chunkReader.ReadBoolean();

            if (bangHomeCityCard.Version > 2)
                bangHomeCityCard.UnkBool = chunkReader.ReadBoolean();

            return bangHomeCityCard;
        }
    }
}
