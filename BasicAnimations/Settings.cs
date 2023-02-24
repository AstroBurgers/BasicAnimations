using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using Rage.Native;
using RAGENativeUI;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

// INI File configuration

namespace BasicAnimations
{
    internal class Settings
    {
        internal static Keys PushupKey = Keys.P;
        internal static Keys SmokeKey = Keys.O;
        internal static Keys SitKey = Keys.X;
        internal static Keys KneelKey = Keys.K;
        internal static Keys SitupKey = Keys.J;
        //internal static Keys LeaningKey = Keys.T;
        internal static InitializationFile inifile;
        
        internal static void INIFile()
        {
            inifile = new InitializationFile(@"Plugins/BasicAnimations.ini");
            inifile.Create();
            PushupKey = inifile.ReadEnum("Keybindings", "PushupKey", PushupKey); // Pushup
            SmokeKey = inifile.ReadEnum("Keybindings", "SmokeKey", SmokeKey); // Smoke
            SitKey = inifile.ReadEnum("Keybindings", "SitKey", SitKey); // Sitting
            KneelKey = inifile.ReadEnum("Keybindings", "KneelKey", KneelKey); // Kneeling
            SitupKey = inifile.ReadEnum("Keybindings", "SitupKey", SitupKey); // Situp
            //LeaningKey = inifile.ReadEnum("Keybindings", "LeaningKey", LeaningKey); // Leaning
        }
    }
}
