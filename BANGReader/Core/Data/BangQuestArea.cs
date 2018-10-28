using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core.Data
{
    public class BangQuestArea
    {
        public string Name { get; set; } = "";

        public List<BangPoint> Points { get; set; } = new List<BangPoint>();

    }
}
