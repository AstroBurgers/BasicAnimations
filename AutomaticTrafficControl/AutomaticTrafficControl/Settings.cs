using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using Rage.Native;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;

namespace AutomaticTrafficControl
{
    internal class Settings
    {
        internal static int Dist = 80;
        internal static int Size = 40;
        internal static InitializationFile inifile;

        internal static void Initialize()
        {
            inifile = new InitializationFile(@"plugins/LSPDFR/AutomaticTrafficControl.ini");
            inifile.Create();
            Dist = inifile.ReadInt32("Values", "Distance before speed zone disappears", Dist);
            Size = inifile.ReadInt32("Values", "Size of speed zone", Size);
        }
    }
}
