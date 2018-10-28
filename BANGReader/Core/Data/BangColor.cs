using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core.Data
{
    public struct BangColor
    {
        float R;
        float G;
        float B;

        public static BangColor Read(BangChunkReader reader)
        {
            BangColor ret;
            ret.R = reader.ReadFloat();
            ret.G = reader.ReadFloat();
            ret.B = reader.ReadFloat();

            return ret;
        }
    }
}
