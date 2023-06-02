using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAnimations
{
    internal struct Animation
    {
        internal string Dict;
        internal string AnimName;
        internal string MenuName;

        internal Animation(string Dict, string AnimName, string MenuName)
        {
            this.Dict = Dict;
            this.AnimName = AnimName;
            this.MenuName =  MenuName;
        }
    }
}