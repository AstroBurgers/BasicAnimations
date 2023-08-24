using Rage;
using System.Windows.Forms;

// INI File configuration

namespace BasicAnimations
{
    internal class Settings
    {
        internal static Keys Investigate = Keys.None;
        internal static Keys ModKey = Keys.None; // Modifier key
        internal static Keys Camera = Keys.None; // Defining a new Keys var
        internal static Keys Binoculars = Keys.None; // Defining a new Keys var
        internal static Keys Yoga = Keys.None; // Defining a new Keys var
        internal static Keys Suicide = Keys.None; // Defining a new Keys var
        internal static Keys Smoking = Keys.None; // Defining a new Keys var
        internal static Keys Situps = Keys.None; // Defining a new Keys var
        internal static Keys Pushups = Keys.None; // Defining a new Keys var
        internal static Keys Salute = Keys.None; // Defining a new Keys var
        internal static Keys GrabVest = Keys.None; // Defining a new Keys var
        internal static Keys Sit = Keys.None; // Defining a new Keys var
        internal static Keys Kneel = Keys.None; // Defining a new Keys var
        internal static Keys Lean = Keys.None; // Defining a new Keys var
        internal static Keys Menu = Keys.None; // Defining a new Keys var
        internal static InitializationFile inifile; // Defining a new INI File
        internal static Keys HandsOnBeltKey = Keys.None; // Defining a new Keys var
        internal static Keys Lean2 = Keys.None; // Defining a new Keys var
        internal static Keys Mocking = Keys.None; // Defining a new Keys var
        internal static Keys Box = Keys.None; // Defining a new Keys var
        internal static Keys MenuModKey = Keys.None;
        internal static void INIFile()
        {
            inifile = new InitializationFile(@"Plugins/BasicAnimations.ini");
            inifile.Create();
            // INI File items
            ModKey = inifile.ReadEnum("Keybindings", "Modifier Key", ModKey);
            Sit = inifile.ReadEnum("Keybindings", "Sit On The Ground", Sit); // Sitting
            Kneel = inifile.ReadEnum("Keybindings", "Kneel", Kneel); // Kneeling
            Lean = inifile.ReadEnum("Keybindings", "Lean", Lean); // Leaning
            HandsOnBeltKey = inifile.ReadEnum("Keybindings", "Put your hands on your belt", HandsOnBeltKey);
            Menu = inifile.ReadEnum("Keybindings", "Open menu button", Menu);
            GrabVest = inifile.ReadEnum("Keybindings", "Grabbing vest", GrabVest);
            Suicide = inifile.ReadEnum("Keybindings", "Commit suicide", Suicide);
            Smoking = inifile.ReadEnum("Keybindings", "Smoking", Smoking);
            Situps = inifile.ReadEnum("Keybindings", "Do situps", Situps);
            Pushups = inifile.ReadEnum("Keybindings", "Do pushups", Pushups);
            Salute = inifile.ReadEnum("Keybindings", "Salute", Salute);
            Mocking = inifile.ReadEnum("Keybindings", "Mock", Mocking);
            Box = inifile.ReadEnum("Keybindings", "Hold box", Box);
            Yoga = inifile.ReadEnum("Keybindings", "Yoga", Yoga);
            Binoculars = inifile.ReadEnum("Keybindings", "Binoculars", Binoculars);
            Camera = inifile.ReadEnum("Keybindings", "Camera", Camera);
            Investigate = inifile.ReadEnum("Keybindings", "Investigate", Investigate);
        }
    }
}
