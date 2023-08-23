using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAnimations.Systems
{
    internal class Hotkeys
    {
        internal static void HotKeyHandler()
        {
            while (true)
            {
                if (!(EntryPoint.CheckModKey() && Helper.CheckRequirements())) { continue; }
            }
        }
    }
}
