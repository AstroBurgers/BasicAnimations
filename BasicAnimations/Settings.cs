﻿using Rage;
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
        internal static InitializationFile inifile;
        internal static Keys HandsOnBeltKey = Keys.None;
        internal static Keys Lean2 = Keys.None;
        internal static Keys Mocking = Keys.None;
        internal static Keys Box = Keys.None;
        internal static void INIFile()
        {
            inifile = new InitializationFile(@"Plugins/BasicAnimations.ini");
            inifile.Create();
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
            Lean2 = inifile.ReadEnum("Keybindings", "Lean 2", Lean2);
            Mocking = inifile.ReadEnum("Keybindings", "Mock", Mocking);
            Box = inifile.ReadEnum("Keybindings", "Hold box", Box);
            Yoga = inifile.ReadEnum("Keybindings", "Yoga", Yoga);
            Binoculars = inifile.ReadEnum("Keybindings", "Binoculars", Binoculars);
            Camera = inifile.ReadEnum("Keybindings", "Camera", Camera);
        }
    }
}
