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
        internal static Keys SitKey = Keys.X;
        internal static Keys KneelKey = Keys.K;
        internal static Keys LeaningKey = Keys.T;
        internal static Keys Menu = Keys.I;
        internal static InitializationFile inifile;
        internal static Keys HandsOnBeltKey = Keys.B;
        internal static void INIFile()
        {
            inifile = new InitializationFile(@"Plugins/BasicAnimations.ini");
            inifile.Create();
            SitKey = inifile.ReadEnum("Keybindings", "SitKey", SitKey); // Sitting
            KneelKey = inifile.ReadEnum("Keybindings", "KneelKey", KneelKey); // Kneeling
            LeaningKey = inifile.ReadEnum("Keybindings", "LeaningKey", LeaningKey); // Leaning
            HandsOnBeltKey = inifile.ReadEnum("Keybindings", "HandsOnBeltKey", HandsOnBeltKey);
            Menu = inifile.ReadEnum("Keybindings", "Menu", Menu);
        }
    }
}
