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
                            if (Game.IsKeyDown(Sit) && CheckRequirements()) { Animations.SitOnGround(); } // Sit
                            else if (Game.IsKeyDown(Kneel) && CheckRequirements()) { Animations.KneelingAnim(); } // Kneel
                            else if (Game.IsKeyDown(Lean) && CheckRequirements()) { Animations.LeanWall(); } // Lean
                            else if (Game.IsKeyDown(HandsOnBeltKey) && CheckRequirements()) { Animations.HandsOnBelt(); } // Hands on belt
                            else if (Game.IsKeyDown(GrabVest) && CheckRequirements()) { Animations.GrabVest(); } // grab vest
                            else if (Game.IsKeyDown(Suicide) && CheckRequirements()) { Animations.Suicide(); } // Suicide
                            else if (Game.IsKeyDown(GrabVest) && CheckRequirements()) { Animations.GrabVest(); } // Grab Vest
                            else if (Game.IsKeyDown(Pushups) && CheckRequirements()) { Animations.PushupAnim(); } // Pushups
                            else if (Game.IsKeyDown(Situps) && CheckRequirements()) { Animations.SitupAnim(); } // Situps
                            else if (Game.IsKeyDown(Salute) && CheckRequirements()) { Animations.Saluting(); } // Saluting
                            else if (Game.IsKeyDown(Smoking)) { Animations.SmokingInPlace(); } // Smoking
                            else if (Game.IsKeyDown(Lean2)) { Animations.Lean2(); } // Lean2
                            else if (Game.IsKeyDown(Box)) { Animations.CarryBox(); } // Carry box
                            else if (Game.IsKeyDown(Mocking)) { Animations.Mocking(); } // Mocking
                            else if (Game.IsKeyDown(Settings.Camera)) { Animations.Camera(); } // Camera
                            else if (Game.IsKeyDown(Settings.Yoga)) { Animations.Yoga(); } // Yoga
                            else if (Game.IsKeyDown(Settings.Binoculars)) { Animations.Binoculars(); } // Binoculars
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