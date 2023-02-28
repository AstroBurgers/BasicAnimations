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
        internal static UIMenu AllAnimMain = new UIMenu("All Animations", "");
        internal static UIMenu MainMenu = new UIMenu("BasicAnimations", "");
        internal static void CreateMenu()
        {
            MainMenuPool.Add(MainMenu);
            MainMenu.MouseControlsEnabled = false;
            MainMenu.AllowCameraMovement = true;
            SetupMenu();
            GameFiber.StartNew(ProcessMenus);
        }
        internal static UIMenuItem Sitting = new UIMenuItem("Sit", "Plays sitting animation");
        internal static UIMenuItem Leaning = new UIMenuItem("Lean", "Plays leaning animation");
        internal static UIMenuItem Kneel = new UIMenuItem("Kneel", "Plays kneeling animation");
        internal static UIMenuItem Situps = new UIMenuItem("Situps", "Plays the situp animation");
        internal static UIMenuItem Suicide = new UIMenuItem("Suicide", "Kills the player");
        internal static UIMenuItem Smoking = new UIMenuItem("Smoking", "Plays smoking animation");
        internal static UIMenuItem Pushup = new UIMenuItem("Pushups", "Plays pushup animation");
        internal static UIMenuItem CleanUp = new UIMenuItem("~r~Clear Active Animations", "Clears all active animations");
        internal static void SetupMenu()
        {
            Game.LogTrivial("BasicAnimations: Creating menu");
            MainMenu.AddItem(Sitting);
            MainMenu.AddItem(Leaning);
            MainMenu.AddItem(Kneel);
            MainMenu.AddItem(Suicide);
            MainMenu.AddItem(Smoking);
            MainMenu.AddItem(Pushup);
            MainMenu.AddItem(CleanUp);
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
                else if (selectedItem.Equals(Pushup))
                {
                    Animations.PushupAnim();
                }
                else if (selectedItem.Equals(CleanUp))
                {
                    Animations.CleanUp();
                }
                else if (selectedItem.Equals(Sitting))
                {
                    Animations.SitOnGround();
                }
                else if (selectedItem.Equals(Leaning))
                {
                    Animations.LeanWall();
                }
                else if (selectedItem.Equals(Kneel))
                {
                    Animations.KneelingAnim();
                }
                else if (true)
                {

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

                    if (Game.IsKeyDown(Settings.Menu))
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
