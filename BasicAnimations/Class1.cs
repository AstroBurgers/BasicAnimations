using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rage;
using Rage.Native;
using System.Windows.Forms;
using RAGENativeUI;
using RAGENativeUI.PauseMenu;
using System.Threading.Tasks;

[assembly: Rage.Attributes.Plugin("Basic Animations", Description = "Time to do random stuff", Author = "AstroBurgers")]

namespace BasicAnimations
{
    internal class EntryPoint
    {
        internal static bool IsActiveAnimation = false;
        internal static Ped MainPlayer => Game.LocalPlayer.Character;
        internal static void Main()
        {
            Game.DisplayNotification("~g~Basic Animations loaded!");
            {
                try
                {
                    Game.LogTrivial("Loaded Successfully!!");
                    Settings.INIFile();
                    while (true)
                    {
                        GameFiber.Yield();
                        if (Game.IsKeyDown(Settings.SitKey) && MainPlayer.IsOnFoot)
                        {
                            Animations.SitOnGround(); // Triggering sitting Method
                        }
                        if (Game.IsKeyDown(Settings.SmokeKey) && MainPlayer.IsOnFoot)
                        {
                            Animations.SmokingInPlace(); // Triggering smoking Method
                        }
                        if (Game.IsKeyDown(Settings.KneelKey) && MainPlayer.IsOnFoot)
                        {
                            Animations.KneelingAnim(); // Triggering kneeling Method
                        }
                        if (Game.IsKeyDown(Settings.PushupKey) && MainPlayer.IsOnFoot)
                        {
                            Animations.PushupAnim(); // Triggering pushup Method
                        }
                        if (Game.IsKeyDown(Settings.SitupKey) && MainPlayer.IsOnFoot)
                        {
                            Animations.SitupAnim(); // Triggering Situp Method
                        }
                        if (Game.IsKeyDown(Settings.LeaningKey) && MainPlayer.IsOnFoot)
                        {
                            Animations.LeanWall(); // Triggering Leaning Method
                        }
                        if (Game.IsKeyDown(Settings.HandsOnBeltKey) && MainPlayer.IsOnFoot)
                        {
                            Animations.HandsOnBelt(); // Triggering HandsOnBeltKey Method
                        }
                        if (Game.IsKeyDown(Settings.Suicide))
                        {
                            Animations.Suicide(); // Triggering Suicide Method
                        }
                        if (Game.IsKeyDown(Settings.Cleanup))
                        {
                            Animations.CleanUp();
                        }
                    }
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
    }
}