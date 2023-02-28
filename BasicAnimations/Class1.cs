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
                    Menu.CreateMenu();
                    Settings.INIFile();
                    while (true)
                    {
                        GameFiber.Yield();
                        if (Game.IsKeyDown(Settings.SitKey) && CheckRequirements())
                        {
                            Animations.SitOnGround(); // Triggering sitting Method
                        }
                        if (Game.IsKeyDown(Settings.KneelKey) && CheckRequirements())
                        {
                            Animations.KneelingAnim(); // Triggering kneeling Method
                        }
                        if (Game.IsKeyDown(Settings.SitupKey) && CheckRequirements())
                        {
                            Animations.SitupAnim(); // Triggering Situp Method
                        }
                        if (Game.IsKeyDown(Settings.LeaningKey) && CheckRequirements())
                        {
                            Animations.LeanWall(); // Triggering Leaning Method
                        }
                        if (Game.IsKeyDown(Settings.HandsOnBeltKey) && CheckRequirements())
                        {
                            Animations.HandsOnBelt(); // Triggering HandsOnBeltKey Method
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
        internal static bool CheckRequirements()
        {
            return MainPlayer.Exists() && MainPlayer.IsAlive && MainPlayer.IsValid() && MainPlayer.IsOnFoot && !MainPlayer.IsRagdoll && !MainPlayer.IsReloading && !MainPlayer.IsFalling && !MainPlayer.IsInAir && !MainPlayer.IsJumping && !MainPlayer.IsInWater;
        }
        internal static void Startup()
        {
            Game.Console.Print();
            Game.Console.Print("========================================= BasicAnimations by Astro ==========================================");
            Game.Console.Print();
            Game.Console.Print();
            Game.Console.Print("BasicAnimations Loaded Successfully");
            Game.Console.Print("INI File Loaded Successfully From Pathway Plugins/BasicAnimations.ini");
            Game.Console.Print("Time To Sit Down");
            Game.Console.Print();
            Game.Console.Print();
            Game.Console.Print("========================================= BasicAnimations by Astro ==========================================");
            Game.Console.Print();
        }
    }
}