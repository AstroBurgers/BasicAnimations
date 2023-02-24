using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using Rage.Native;
using RAGENativeUI;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace BasicAnimations
{
    internal class Settings
    {
        internal static Keys PushupKey = Keys.P;
        internal static Keys SmokeKey = Keys.O;
        internal static Keys SitKey = Keys.X;
        internal static Keys KneelKey = Keys.K;
        internal static Keys SitupKey = Keys.J;

        internal static InitializationFile inifile;
        internal static void INIFile()
        {
            inifile = new InitializationFile(@"Plugins/BasicAnimations.ini");
            inifile.Create();
            PushupKey = inifile.ReadEnum("Keybindings", "PushupKey", PushupKey);
            SmokeKey = inifile.ReadEnum("Keybindings", "SmokeKey", SmokeKey);
            SitKey = inifile.ReadEnum("Keybindings", "SitKey", SitKey);
            KneelKey = inifile.ReadEnum("Keybindings", "KneelKey", KneelKey);
            SitupKey = inifile.ReadEnum("Keybindings", "SitupKey", SitupKey);
        }
    }
}
