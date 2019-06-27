using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core.Data
{
    public class BangHomeCityManager
    {

        public int UnkDword4 { get; set; } = 0;

        public List<BangHomeCity> HomeCities { get; set; } = new List<BangHomeCity>();

        public static BangHomeCityManager Load(BangChunkReader<BangDataHeader> chunkReader)
        {
            BangHomeCityManager bangHomeCityManager = new BangHomeCityManager();

            chunkReader.ReadExpectedTag(0x4853);

            uint unkVal = chunkReader.ReadUInt32();
            bangHomeCityManager.UnkDword4 = chunkReader.ReadInt32();
            
            // Only in Age3
            if (chunkReader.Header.GameTarget == BangGameTarget.AgeOfEmpires3)
            {
                int numOfHomeCity = chunkReader.ReadInt32();
                
                for(int i = 0; i < numOfHomeCity; i++)
                {
                    bangHomeCityManager.HomeCities.Add(BangHomeCity.Load(chunkReader));
                }
            }

            return bangHomeCityManager;
        }
    }
}
