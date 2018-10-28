using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core.Data
{
    public class BangTriggerType
    {
        public int Version { get; set; } = 0;
        public string Unk0 { get; set; } = "";
        public string Name { get; set; } = "";
        public string Expression { get; set; } = "";
        public List<BangTriggerParam> Params { get; set; } = new List<BangTriggerParam>();
        public List<BangTriggerCommand> Commands { get; set; } = new List<BangTriggerCommand>();
    }
}
