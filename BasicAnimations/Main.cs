using Rage;
using System;
using System.Reflection;
using System.Windows.Forms;
using static BasicAnimations.Settings;
using static BasicAnimations.Animation_Classes.Animation;
using static BasicAnimations.Systems.Helper;

[assembly: Rage.Attributes.Plugin("Basic Animations", Description = "Time to do random stuff", Author = "AstroBurgers")]

namespace BasicAnimations
{
    internal class EntryPoint
    {
        internal static bool IsActiveAnimation = false;
        internal static bool BetaVersion = false;
        internal static void Main()
        {
            Game.DisplayNotification("commonmenutu", "arrowright", "BasicAnimations", "~b~By Astro", "If your reading this have a great day!");
            {
                try
                {
                    Game.LogTrivial("Version Loaded: " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
                    if (BetaVersion)
                    {
                        Game.LogTrivial("This Is In Beta. Proceed with caution");
                        Game.DisplayNotification("commonmenu", "mp_alerttriangle", "BasicAnimations", "~b~By Astro", "~y~CAUTION: ~w~Plugin is in ~r~Beta~w~, Report any issues to the discord.");
                    }
                    //Favourites.SetFav();
                    Menu.CreateMenu();
                    INIFile();
                    GameFiber.StartNew(delegate
                    {
                        while (true)
                        {
                            GameFiber.Yield();
                            //Many Else ifs
                            if (Game.IsKeyDown(Sit) && CheckModKey() && CheckRequirements()) { Animations.SitOnGround(); } // Sit
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
        internal static bool CheckModKey()
        {
            if (ModKey == Keys.None)
            {
                return true;
            }
            return Game.IsKeyDownRightNow(Settings.ModKey);
        }
    }
}