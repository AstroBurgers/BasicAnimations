using BasicAnimations.Systems;
using Rage;
using System;
using System.Reflection;
using BasicAnimations.CustomAnimationsStuff;
using static BasicAnimations.Settings;
using static BasicAnimations.Systems.Helper;
using Menu = BasicAnimations.Menus.Menu;
using static BasicAnimations.Systems.Logging;

[assembly: Rage.Attributes.Plugin("Basic Animations", Description = "Time to do random stuff", Author = "Astro")]

namespace BasicAnimations;

internal class EntryPoint
{
    internal static void Main()
    {
        try
        {
            Game.DisplayNotification("commonmenutu", "arrowright",
                "BasicAnimations",
                "~b~By Astro",
                "If your reading this have a great day!");

            Logger.Log(LogType.Normal, "Version Loaded: " + Assembly.GetExecutingAssembly().GetName().Version);
            if (BetaVersion)
            {
                Logger.Log(LogType.Warning, "This Is In Beta. Proceed with caution");
                Game.DisplayNotification("commonmenu", "mp_alerttriangle",
                    "BasicAnimations",
                    "~b~By Astro",
                    "~y~CAUTION~s~: This is a beta version of BA, please report any issues that occur to the discord.");
            }

            CustomAnimations.DeserializeCustomAnimations();
            GameFiber.StartNew(Menu.CreateMenu);
            GameFiber.StartNew(SetupIniFile);
            GameFiber.StartNew(Hotkeys.HotKeyHandler);
        }
        catch (Exception e)
        {
            if (e is System.Threading.ThreadAbortException) return;
            Logger.LogException("Main.cs", e.ToString()); // Error handling
        }
    }

}