using System.Windows.Forms;
using Rage;

// INI File configuration

namespace BasicAnimations.Systems;

internal static class Settings
{
    # region Keys Variables
    // Modifier Keys
    internal static Keys ModKey = Keys.None;
    internal static Keys MenuModKey = Keys.None;
    
    // Animation Keys
    internal static Keys Investigate = Keys.None;
    internal static Keys Camera = Keys.None;
    internal static Keys Binoculars = Keys.None;
    internal static Keys Yoga = Keys.None;
    internal static Keys Suicide = Keys.None;
    internal static Keys Smoking = Keys.None;
    internal static Keys Situps = Keys.None;
    internal static Keys Pushups = Keys.None;
    internal static Keys Salute = Keys.None;
    internal static Keys GrabVest = Keys.None;
    internal static Keys Sit = Keys.None;
    internal static Keys Kneel = Keys.None;
    internal static Keys Lean = Keys.None;
    internal static Keys Menu = Keys.None;
    internal static Keys HandsOnBeltKey = Keys.None;
    internal static Keys Lean2 = Keys.None;
    internal static Keys Mocking = Keys.None;
    internal static Keys Box = Keys.None;
    
    internal static InitializationFile Inifile; // Defining a new INI File
    
    #endregion

    // Custom Keybinds

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
    }
}