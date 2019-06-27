using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core.Data
{
    [Flags]
    public enum BangGameRequirements
    {
        RequiresBaseGame = 1,
        RequiresXPack = 2,
        RequiresYPack = 4
    }
}
