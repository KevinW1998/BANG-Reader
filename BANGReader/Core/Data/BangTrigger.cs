using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core.Data
{
    public class BangTrigger
    {
        public int Version { get; set; } = 9; // Latest
        public int ID { get; set; } = 0;
        public int GroupID { get; set; } = 0;
        public int Priority { get; set; } = 4;
        public string Name { get; set; } = "";
        public bool Loop { get; set; } = false;
        public bool IsActive { get; set; } = false;
        public bool RunImmediatly { get; set; } = false;
        public bool Not { get; set; } = false;
        public bool Or { get; set; } = false;

        // Unknown //
        public int Unk2C { get; set; } = 0;

        public List<BangTriggerType> Conditions = new List<BangTriggerType>();
        public List<BangTriggerType> Effects = new List<BangTriggerType>();
    }
}
