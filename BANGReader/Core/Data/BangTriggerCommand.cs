using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core.Data
{
    public class BangTriggerCommand
    {
        public string Name { get; set; } = "";
        public List<string> LoopParams { get; set; } = new List<string>();
        public bool Loaded { get; set; } = false;
    }
}
