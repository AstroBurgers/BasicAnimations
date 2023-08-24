using Rage;
using static BasicAnimations.Systems.Helper;

namespace BasicAnimations.Systems
{
    internal class Hotkeys
    {
        internal static void HotKeyHandler()
        {
            while (true)
            {
                GameFiber.Yield();

                if (Game.IsKeyDown(Settings.Sit) && CheckModKey() && CheckRequirements()) { Animations.Sit.PlayAnimation(); } // Sit
                else if (Game.IsKeyDown(Settings.Kneel) && CheckModKey() && CheckRequirements()) { Animations.Kneeling.StartScenario(); } // Kneel
                else if (Game.IsKeyDown(Settings.Lean) && CheckModKey() && CheckRequirements()) { Animations.Lean.StartScenario(); } // Lean
                else if (Game.IsKeyDown(Settings.HandsOnBeltKey) && CheckModKey() && CheckRequirements()) { Animations.GrabBelt.PlayAnimation(); } // Hands on belt
                else if (Game.IsKeyDown(Settings.GrabVest) && CheckModKey() && CheckRequirements()) { Animations.GrabVest.PlayAnimation(); } // Grab vest
                else if (Game.IsKeyDown(Settings.Suicide) && CheckModKey() && CheckRequirements()) { Animations.Suicide(); } // Suicide
                else if (Game.IsKeyDown(Settings.Pushups) && CheckModKey() && CheckRequirements()) { Animations.Pushup.PlayAnimation(); } // Pushups
                else if (Game.IsKeyDown(Settings.Situps) && CheckModKey() && CheckRequirements()) { Animations.Situp.PlayAnimation(); } // Situps
                else if (Game.IsKeyDown(Settings.Salute) && CheckModKey() && CheckRequirements()) { Animations.Salute.PlayAnimation(); } // Saluting
                else if (Game.IsKeyDown(Settings.Smoking) && CheckModKey() && CheckRequirements()) { Animations.Smoking.StartScenario(); } // Smoking
                else if (Game.IsKeyDown(Settings.Box) && CheckModKey() && CheckRequirements()) { Animations.CarryBox(); } // Carry box
                else if (Game.IsKeyDown(Settings.Mocking) && CheckModKey() && CheckRequirements()) { Animations.Mocking.PlayAnimation(); } // Mocking
                else if (Game.IsKeyDown(Settings.Camera) && CheckModKey() && CheckRequirements()) { Animations.Camera.StartScenario(); } // Camera
                else if (Game.IsKeyDown(Settings.Yoga) && CheckModKey() && CheckRequirements()) { Animations.Yoga.StartScenario(); } // Yoga
                else if (Game.IsKeyDown(Settings.Binoculars) && CheckModKey() && CheckRequirements()) { Animations.Binoculars.StartScenario(); } // Binoculars
                else if (Game.IsKeyDown(Settings.Investigate) && CheckModKey() && CheckRequirements()) { Animations.Investigate.StartScenario(); } // Investigate
            }
        }
    }
}
