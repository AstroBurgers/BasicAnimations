﻿using System;
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
                            Animations.SitOnGround();
                        }
                        if (Game.IsKeyDown(Settings.SmokeKey) && MainPlayer.IsOnFoot)
                        {
                            Animations.SmokingInPlace();
                        }
                        if (Game.IsKeyDown(Settings.KneelKey) && MainPlayer.IsOnFoot)
                        {
                            Animations.KneelingAnim();
                        }
                        if (Game.IsKeyDown(Settings.PushupKey) && MainPlayer.IsOnFoot)
                        {
                            Animations.PushupAnim();
                        }
                        if (Game.IsKeyDown(Settings.SitupKey) && MainPlayer.IsOnFoot)
                        {
                            Animations.SitupAnim();
                        }
                    }
                }
                catch (Exception e)
                {
                    Game.LogTrivial("Crashed at: " + e);
                }
            }
        }
    }
}