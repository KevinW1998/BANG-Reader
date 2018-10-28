using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core.Data
{
    public class BangTriggerGroup
    {
        public string Name { get; set; } = "";
        public List<int> TriggerIDs { get; set; } = new List<int>();
    }
}
