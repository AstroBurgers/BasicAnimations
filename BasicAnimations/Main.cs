using BasicAnimations.Systems;
using Rage;
using System;
using System.Reflection;
using static BasicAnimations.Settings;
using static BasicAnimations.Systems.Helper;
using Menu = BasicAnimations.Menus.Menu;

[assembly: Rage.Attributes.Plugin("Basic Animations", Description = "Time to do random stuff", Author = "AstroBurgers")]

namespace BasicAnimations
{
    internal class EntryPoint
    {
        internal static void Main()
        {
            Game.DisplayNotification("commonmenutu", "arrowright", "BasicAnimations", "~b~By Astro", "If your reading this have a great day!");
            {
                try
                {
                    Game.LogTrivial("Version Loaded: " + Assembly.GetExecutingAssembly().GetName().Version);
                    if (BetaVersion)
                    {
                        Game.LogTrivial("This Is In Beta. Proceed with caution");
                        Game.DisplayNotification("commonmenu", "mp_alerttriangle", "BasicAnimations", "~b~By Astro", "~y~CAUTION: ~w~Plugin is in ~r~Beta~w~, Report any issues to the discord.");
                    }
                    Menu.CreateMenu();
                    //Menus.testing.TestingIK();
                    IniFile();
                    Hotkeys.HotKeyHandler();
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