using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core.Data
{
    public class BangTriggerParam
    {
        public int Version { get; set; } = 0;
        public string Name { get; set; } = "";
        public string DispName { get; set; } = "";

        public List<string> ParamStringList { get; set; } = new List<string>();
        public List<int> ParamIntList { get; set; } = new List<int>(); // Loc ID related?

        // UNKNOWN //
        public int Unk20 { get; set; } = 0;

    }
}
