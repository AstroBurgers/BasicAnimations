using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rage;
using static BasicAnimations.Settings;
using Rage.Native;
using System.Windows.Forms;
using RAGENativeUI;
using RAGENativeUI.PauseMenu;
using System.Threading.Tasks;
using System.Reflection;

[assembly: Rage.Attributes.Plugin("Basic Animations", Description = "Time to do random stuff", Author = "AstroBurgers")]

namespace BasicAnimations
{
    internal class EntryPoint
    {
        internal static bool IsActiveAnimation = false;
        internal static Ped MainPlayer => Game.LocalPlayer.Character;
        internal static void Main()
        {
            Game.DisplayNotification("commonmenutu", "arrowright", "BasicAnimations", "~b~By Astro", "If your reading this have a great day!");
            {
                try
                {
                    Game.LogTrivial("Version Loaded: " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
                    Game.LogTrivial("This Is In Beta. Proceed with caution");
                    //Favourites.SetFav();
                    Menu.CreateMenu();
                    INIFile();
                    GameFiber.StartNew(delegate
                    {
                        while (true)
                        {
                            GameFiber.Yield();
                            //Many Else ifs
                            if (Game.IsKeyDown(Sit) && CheckRequirements()) { Animations.KeybindPlayAnimation("Sit"); } // Sit
                            else if (Game.IsKeyDown(Kneel) && CheckRequirements()) { Animations.KeybindPlayAnimation("Kneel"); } // Kneel
                            else if (Game.IsKeyDown(HandsOnBeltKey) && CheckRequirements()) { Animations.KeybindPlayAnimation("Hands On Belt"); } // Hands on belt
                            else if (Game.IsKeyDown(GrabVest) && CheckRequirements()) { Animations.KeybindPlayAnimation("Grab Vest"); } // grab vest
                            else if (Game.IsKeyDown(Suicide) && CheckRequirements()) { Animations.Suicide(); } // Suicide
                            else if (Game.IsKeyDown(Pushups) && CheckRequirements()) { Animations.KeybindPlayAnimation("Pushups"); } // Pushups
                            else if (Game.IsKeyDown(Situps) && CheckRequirements()) { Animations.KeybindPlayAnimation("Situps"); } // Situps
                            else if (Game.IsKeyDown(Salute) && CheckRequirements()) { Animations.KeybindPlayAnimation("Salute"); } // Saluting
                            else if (Game.IsKeyDown(Smoking)) { Animations.KeybindPlayAnimation("Smoking"); } // Smoking
                            else if (Game.IsKeyDown(Leaning)) { Animations.KeybindPlayAnimation("Leaning"); } // Leaning
                            else if (Game.IsKeyDown(Box)) { Animations.CarryBox(); } // Carry box
                            else if (Game.IsKeyDown(Mocking)) { Animations.KeybindPlayAnimation("Mocking"); } // Mocking
                            else if (Game.IsKeyDown(Settings.Camera)) { Animations.KeybindPlayAnimation("Camera"); } // Camera
                            else if (Game.IsKeyDown(Settings.Yoga)) { Animations.KeybindPlayAnimation("Yoga"); } // Yoga
                            else if (Game.IsKeyDown(Settings.Binoculars)) { Animations.KeybindPlayAnimation("Binoculars"); } // Binoculars
                        }
                    });
                }
                catch (System.Threading.ThreadAbortException e1)
                {
                    Game.LogTrivial("Plugin most likely unloaded: " + e1); // Error handling
                }
                catch (Exception e)
                {
                    Game.LogTrivial("Crashed at: " + e); // Error handling
                }
            }
        }
        internal static bool CheckRequirements()
        {
            return MainPlayer.Exists() && MainPlayer.IsAlive && MainPlayer.IsValid() && MainPlayer.IsOnFoot && !MainPlayer.IsRagdoll && !MainPlayer.IsReloading && !MainPlayer.IsFalling && !MainPlayer.IsInAir && !MainPlayer.IsJumping && !MainPlayer.IsInWater && !MainPlayer.IsGettingIntoVehicle;
        }
    }
}