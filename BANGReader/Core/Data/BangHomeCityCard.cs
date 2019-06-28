using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core.Data
{
    public class BangHomeCityCard
    {
        public uint Version { get; set; } = 0;

        public int TechID { get; set; } = 0;
        public int MaxCount { get; set; } = 0;
        public int Tier { get; set; } = 0;
        public int Level { get; set; } = 0;
        public int SPCAct { get; set; } = -1; // TODO: Check offsets
        public int UnkDword1C { get; set; } = 0;
        public int PreReqTechID { get; set; } = 0;
        public int UnkDword14 { get; set; } = 0;
        public int DisplayUnitCount { get; set; } = 0;

        public bool IsInfiniteInLastAge { get; set; } = false;
        public bool IsRevolt { get; set; } = false;

        public static BangHomeCityCard Load(BangChunkReader<BangDataHeader> chunkReader)
        {
            BangHomeCityCard bangHomeCityCard = new BangHomeCityCard();

            chunkReader.ReadExpectedTag(0x6463);

            bangHomeCityCard.Version = chunkReader.ReadUInt32();
            bangHomeCityCard.TechID = chunkReader.ReadInt32();
            bangHomeCityCard.MaxCount = chunkReader.ReadInt32();
            bangHomeCityCard.Tier = chunkReader.ReadInt32();
            bangHomeCityCard.Level = chunkReader.ReadInt32();

            if(bangHomeCityCard.Version > 3)
            {
                bangHomeCityCard.SPCAct = chunkReader.ReadInt32();
            }

            bangHomeCityCard.UnkDword1C = chunkReader.ReadInt32();
            bangHomeCityCard.PreReqTechID = chunkReader.ReadInt32();
            bangHomeCityCard.UnkDword14 = chunkReader.ReadInt32();

            if(bangHomeCityCard.Version > 0)
                bangHomeCityCard.DisplayUnitCount = chunkReader.ReadInt32();

            if (bangHomeCityCard.Version > 1)
                bangHomeCityCard.IsInfiniteInLastAge = chunkReader.ReadBoolean();

            if (bangHomeCityCard.Version > 2)
                bangHomeCityCard.IsRevolt = chunkReader.ReadBoolean();

            return bangHomeCityCard;
        }
    }
}
