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
        internal static InitializationFile Inifile; // Defining a new INI File
        internal static Keys HandsOnBeltKey = Keys.None; // Defining a new Keys var
        internal static Keys Lean2 = Keys.None; // Defining a new Keys var
        internal static Keys Mocking = Keys.None; // Defining a new Keys var
        internal static Keys Box = Keys.None; // Defining a new Keys var
        internal static Keys MenuModKey = Keys.None;

        // Custom Keybinds
        internal static Keys HoldVest = Keys.None;
        internal static Keys HugWeapon = Keys.None;

        internal static void SetupIniFile()
        {
            Inifile = new InitializationFile(@"Plugins/BasicAnimations.ini");
            Inifile.Create();
            // INI File items
            ModKey = Inifile.ReadEnum("Keybindings", "Modifier Key", ModKey);
            Sit = Inifile.ReadEnum("Keybindings", "Sit On The Ground", Sit); // Sitting
            Kneel = Inifile.ReadEnum("Keybindings", "Kneel", Kneel); // Kneeling
            Lean = Inifile.ReadEnum("Keybindings", "Lean", Lean); // Leaning
            HandsOnBeltKey = Inifile.ReadEnum("Keybindings", "Put your hands on your belt", HandsOnBeltKey);
            Menu = Inifile.ReadEnum("Keybindings", "Open menu button", Menu);
            GrabVest = Inifile.ReadEnum("Keybindings", "Grabbing vest", GrabVest);
            Suicide = Inifile.ReadEnum("Keybindings", "Commit suicide", Suicide);
            Smoking = Inifile.ReadEnum("Keybindings", "Smoking", Smoking);
            Situps = Inifile.ReadEnum("Keybindings", "Do situps", Situps);
            Pushups = Inifile.ReadEnum("Keybindings", "Do pushups", Pushups);
            Salute = Inifile.ReadEnum("Keybindings", "Salute", Salute);
            Mocking = Inifile.ReadEnum("Keybindings", "Mock", Mocking);
            Box = Inifile.ReadEnum("Keybindings", "Hold box", Box);
            Yoga = Inifile.ReadEnum("Keybindings", "Yoga", Yoga);
            Binoculars = Inifile.ReadEnum("Keybindings", "Binoculars", Binoculars);
            Camera = Inifile.ReadEnum("Keybindings", "Camera", Camera);
            Investigate = Inifile.ReadEnum("Keybindings", "Investigate", Investigate);

            HoldVest = Inifile.ReadEnum("Keybindings", "Holding Vest", HoldVest);
            HugWeapon = Inifile.ReadEnum("Keybindings", "Hug Weapon", HugWeapon);
        }
    }
}
