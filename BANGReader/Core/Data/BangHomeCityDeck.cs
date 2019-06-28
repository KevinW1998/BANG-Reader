using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core.Data
{
    public class BangHomeCityDeck
    {
        public uint Version { get; set; } = 0;

        public int ID { get; set; } = 0;

        public string Name { get; set; } = "My Deck";

        public int GameID { get; set; } = 1; // Related to BangGameRequirements?

        public bool IsDefault { get; set; } = false;

        public List<int> TechIDs { get; set; } = new List<int>();

        public List<BangHomeCityCard> Cards { get; set; } = new List<BangHomeCityCard>();

        public List<BangHomeCityPreservedCard> PreservedCards { get; set; } = new List<BangHomeCityPreservedCard>();

        public static BangHomeCityDeck Load(BangChunkReader<BangDataHeader> chunkReader)
        {
            BangHomeCityDeck bangHomeCityDeck = new BangHomeCityDeck();

            chunkReader.ReadExpectedTag(0x6B44);

            bangHomeCityDeck.Version = chunkReader.ReadUInt32();
            bangHomeCityDeck.ID = chunkReader.ReadInt32();
            bangHomeCityDeck.Name = chunkReader.ReadString();
            if(bangHomeCityDeck.Version > 2)
            {
                bangHomeCityDeck.GameID = chunkReader.ReadInt32();
            }

            if(bangHomeCityDeck.Version > 0)
            {
                bangHomeCityDeck.IsDefault = chunkReader.ReadBoolean();
            }

            int numOfUnkArray10 = chunkReader.ReadInt32();
            for(int i = 0; i < numOfUnkArray10; i++)
            {
                bangHomeCityDeck.TechIDs.Add(chunkReader.ReadInt32());
            }

            if(bangHomeCityDeck.Version > 1)
            {
                int numOfCards = chunkReader.ReadInt32();
                for(int i = 0; i < numOfCards; i++)
                {
                    bangHomeCityDeck.Cards.Add(BangHomeCityCard.Load(chunkReader));
                }
            }

            if(bangHomeCityDeck.Version > 3)
            {
                int numOfPreservedCards = chunkReader.ReadInt32();
                for(int i = 0; i < numOfPreservedCards; i++)
                {
                    bangHomeCityDeck.PreservedCards.Add(BangHomeCityPreservedCard.Load(chunkReader));
                }
            }


            return bangHomeCityDeck;
        }
    }
}
