using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core.Data
{
    public class BangHomeCity
    {
        public uint Version { get; set; } = 0;

        public string CivName { get; set; } = "";

        public BangHomeCityDataLocation DataLoc { get; set; } = BangHomeCityDataLocation.DirListData;

        public string Filename { get; set; } = "";

        public string Type { get; set; } = "";

        public string Description { get; set; } = "";

        public string HeroName { get; set; } = "";

        public string HeroDogName { get; set; } = "";

        public List<string> UnkStrList { get; set; } = new List<string>();

        public string ShipName { get; set; } = "";

        public string ID { get; set; } = "";

        public bool UnkByte4 { get; set; } = false;

        public int Level { get; set; } = 0;

        public int NumberShips { get; set; } = 0;

        public int UnkDword1E4 { get; set; } = 0;

        public float UnkHomeCityFactorRelated { get; set; } = 0.0f;

        public int NumPropUnlocksEarned { get; set; } = 0;

        public List<BangHomeCityDeck> Decks { get; set; } = new List<BangHomeCityDeck>();

        public List<BangHomeCityPreservedCard> PreservedCards { get; set; } = new List<BangHomeCityPreservedCard>();

        public List<string> TechNames { get; set; } = new List<string>();

        public static BangHomeCity Load(BangChunkReader<BangDataHeader> chunkReader)
        {
            BangHomeCity bangHomeCity = new BangHomeCity();

            chunkReader.ReadExpectedTag(0x4853);

            bangHomeCity.Version = chunkReader.ReadUInt32();

            bangHomeCity.CivName = chunkReader.ReadString();
            bangHomeCity.DataLoc = chunkReader.ReadEnum<BangHomeCityDataLocation>();
            bangHomeCity.Filename = chunkReader.ReadString();
            bangHomeCity.Type = chunkReader.ReadString();
            bangHomeCity.Description = chunkReader.ReadString();
            bangHomeCity.HeroName = chunkReader.ReadString();

            if(bangHomeCity.Version >= 2)
            {
                int numOfUnk = chunkReader.ReadInt32();
                for (int i = 0; i < numOfUnk; i++)
                {
                    bangHomeCity.UnkStrList.Add(chunkReader.ReadString());
                }
            }

            bangHomeCity.HeroDogName = chunkReader.ReadString();
            bangHomeCity.ShipName = chunkReader.ReadString();
            bangHomeCity.ID = chunkReader.ReadString();

            bangHomeCity.UnkByte4 = chunkReader.ReadBoolean();
            bangHomeCity.Level = chunkReader.ReadInt32();
            bangHomeCity.NumberShips = chunkReader.ReadInt32();
            bangHomeCity.UnkDword1E4 = chunkReader.ReadInt32();
            bangHomeCity.UnkHomeCityFactorRelated = chunkReader.ReadFloat();
            bangHomeCity.NumPropUnlocksEarned = chunkReader.ReadInt32();

            int numOfDecks = chunkReader.ReadInt32();
            for(int i = 0; i < numOfDecks; i++)
            {
                bangHomeCity.Decks.Add(BangHomeCityDeck.Load(chunkReader));
            }

            int numOfPreservedCards = chunkReader.ReadInt32();
            for(int i = 0; i < numOfPreservedCards; i++)
            {
                bangHomeCity.PreservedCards.Add(BangHomeCityPreservedCard.Load(chunkReader));
            }

            int numOfTechs = chunkReader.ReadInt32();
            for(int i = 0; i < numOfTechs; i++)
            {
                bangHomeCity.TechNames.Add(chunkReader.ReadString());
            }

            bangHomeCity.PreservedCards.Clear(); // ???
            numOfPreservedCards = chunkReader.ReadInt32();
            for (int i = 0; i < numOfPreservedCards; i++)
            {
                bangHomeCity.PreservedCards.Add(BangHomeCityPreservedCard.Load(chunkReader));
            }




            return bangHomeCity;
        }

    }
}
