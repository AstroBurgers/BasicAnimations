using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using Rage;
using Rage.Native;
using RAGENativeUI;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using RAGENativeUI.Elements;
using Rage.Attributes;
using RAGENativeUI.PauseMenu;

namespace BasicAnimations
{
    internal static class Menu
    {
        internal static MenuPool MainMenuPool = new MenuPool();
        internal static UIMenu MainMenu = new UIMenu("BasicAnimations", "");
        internal static void CreateMenu()
        {
            MainMenuPool.Add(MainMenu);
            MainMenu.MouseControlsEnabled = false;
            MainMenu.AllowCameraMovement = true;
            SetupMenu();
            GameFiber.StartNew(ProcessMenus);
        }
        internal static UIMenuItem Suicide = new UIMenuItem("Suicide", "Kills the player");
        internal static UIMenuItem Smoking = new UIMenuItem("Smoking", "Plays smoking animation");
        internal static UIMenuItem Pushups = new UIMenuItem("Pushups", "Plays pushup animation");

        internal static void SetupMenu()
        {
            Game.LogTrivial("BasicAnimations: Creating menu");
            MainMenu.AddItem(Suicide);
            MainMenu.AddItem(Smoking);
            MainMenu.AddItem(Pushups);
            MainMenu.OnItemSelect += MainMenu_OnItemSelect;
        }

        private static void MainMenu_OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            GameFiber.StartNew(delegate
            {
                if (selectedItem.Equals(Suicide))
                {
                    Animations.Suicide();
                }
                else if (selectedItem.Equals(Smoking))
                {
                    Animations.SmokingInPlace();
                }
                else if (selectedItem.Equals(Pushups))
                {
                    Animations.PushupAnim();
                }
            });
            }   

        internal static void ProcessMenus()
        {
            try
            {
                while (true)
                {
                    GameFiber.Yield();

                    MainMenuPool.ProcessMenus();

                    if (Game.IsKeyDown(Keys.I))
                    {
                        if (MenuRequirements())
                        {
                            MainMenu.Visible = true;
                        }
                        else if (MainMenu.Visible)
                        {
                            MainMenu.Visible = false;
                        }
                    }
                }
            }
            catch (System.NullReferenceException e)
            {
                Game.LogTrivial("BasicAnimations " + e);
            }

        }
        internal static bool MenuRequirements()
        {
            return !UIMenu.IsAnyMenuVisible && !TabView.IsAnyPauseMenuVisible;
        }
    }
}
