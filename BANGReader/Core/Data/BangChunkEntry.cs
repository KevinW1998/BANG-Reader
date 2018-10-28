using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core.Data
{
    public class BangChunkEntry
    {
        public ushort Tag { get; set; } = 0;
        public uint Data { get; set; } = 0;
    }
}
