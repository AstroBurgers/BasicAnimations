using Rage;
using System.Security.Policy;
using static BasicAnimations.Settings;
using static BasicAnimations.Systems.Helper;
using static BasicAnimations.Animations;
using static BasicAnimations.Animation_Classes.Scenario;
namespace BasicAnimations.Systems
{
    internal class Hotkeys
    {
        internal static void HotKeyHandler()
        {
            while (true)
            {
                GameFiber.Yield();
                if (Game.IsKeyDown(Sit) && CheckModKey() && CheckRequirements()) { Animations.Sit.PlayAnimation(); } // Sit
                else if (Game.IsKeyDown(Kneel) && CheckModKey() && CheckRequirements()) { Animations.KneelingAnim(); } // Kneel
                else if (Game.IsKeyDown(Lean) && CheckModKey() && CheckRequirements()) { Animations.LeanWall(); } // Lean
                else if (Game.IsKeyDown(HandsOnBeltKey) && CheckModKey() && CheckRequirements()) { Animations.HandsOnBelt(); } // Hands on belt
                else if (Game.IsKeyDown(GrabVest) && CheckModKey() && CheckRequirements()) { Animations.GrabVest(); } // grab vest
                else if (Game.IsKeyDown(Suicide) && CheckModKey() && CheckRequirements()) { Animations.Suicide(); } // Suicide
                else if (Game.IsKeyDown(GrabVest) && CheckModKey() && CheckRequirements()) { Animations.GrabVest(); } // Grab Vest
                else if (Game.IsKeyDown(Pushups) && CheckModKey() && CheckRequirements()) { Animations.PushupAnim(); } // Pushups
                else if (Game.IsKeyDown(Situps) && CheckModKey() && CheckRequirements()) { Animations.SitupAnim(); } // Situps
                else if (Game.IsKeyDown(Salute) && CheckModKey() && CheckRequirements()) { Animations.Saluting(); } // Saluting
                else if (Game.IsKeyDown(Smoking) && CheckModKey() && CheckRequirements()) { Animations.SmokingInPlace(); } // Smoking
                else if (Game.IsKeyDown(Lean2) && CheckModKey() && CheckRequirements()) { Animations.Lean2(); } // Lean2
                else if (Game.IsKeyDown(Box) && CheckModKey() && CheckRequirements()) { Animations.CarryBox(); } // Carry box
                else if (Game.IsKeyDown(Mocking) && CheckModKey() && CheckRequirements()) { Animations.Mocking(); } // Mocking
                else if (Game.IsKeyDown(Settings.Camera) && CheckModKey() && CheckRequirements()) { Animations.Camera(); } // Camera
                else if (Game.IsKeyDown(Settings.Yoga) && CheckModKey() && CheckRequirements()) { Animations.Yoga(); } // Yoga
                else if (Game.IsKeyDown(Settings.Binoculars) && CheckModKey() && CheckRequirements()) { Animations.Binoculars(); } // Binoculars
                else if (Game.IsKeyDown(Settings.Investigate) && CheckModKey() && CheckRequirements()) { Animations.Investigate(); }
            }
        }
    }
}
