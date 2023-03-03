using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Drawing;
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
            MainMenuPool.Add(MainMenu, AllAnimMain);
            MainMenu.MouseControlsEnabled = false;
            MainMenu.AllowCameraMovement = true;
            AllAnimMain.MouseControlsEnabled = false;
            AllAnimMain.AllowCameraMovement = true;
            SetupMenu();
            GameFiber.StartNew(ProcessMenus);
        }
        internal static UIMenuItem AllAnimations = new UIMenuItem("All Animations");
        //internal static UIMenuItem IdleOnPhone = new UIMenuItem("Phone", "Plays idle on phone animation");
        internal static UIMenuItem GrabVest = new UIMenuItem("Grab Vest", "Puts your hands on your vest");
        internal static UIMenuItem HandsOnBelt = new UIMenuItem("Hands On Belt", "Puts your hands on your belt");
        internal static UIMenuItem Sitting = new UIMenuItem("Sit", "Plays sitting animation");
        internal static UIMenuItem Leaning = new UIMenuItem("Lean", "Plays leaning animation");
        internal static UIMenuItem Kneel = new UIMenuItem("Kneel", "Plays kneeling animation");
        internal static UIMenuItem Situps = new UIMenuItem("Situps", "Plays the situp animation");
        internal static UIMenuItem Suicide = new UIMenuItem("~r~Suicide", "~r~Kills ~w~the player");
        internal static UIMenuItem Smoking = new UIMenuItem("Smoking", "Plays smoking animation");
        internal static UIMenuItem Pushup = new UIMenuItem("Pushups", "Plays pushup animation");
        internal static void SetupMenu()
        {
            Game.LogTrivial("Creating menu");
            AllAnimMain.AddItems(Sitting, Leaning, Kneel, Suicide, Smoking, Situps, HandsOnBelt, Pushup, GrabVest);
            MainMenu.AddItem(AllAnimations);
            MainMenu.BindMenuToItem(AllAnimMain, AllAnimations);
            MainMenu.OnItemSelect += MainMenu_OnItemSelect;
            AllAnimMain.OnItemSelect += AllAnimMain_OnItemSelect;
        }
        private static void AllAnimMain_OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            GameFiber.StartNew(delegate
            {
                try
                {
                    switch (index)
                    {
                        case 0:
                            Animations.SitOnGround();
                            break;
                        case 1:
                            Animations.LeanWall();
                            break;
                        case 2:
                            Animations.KneelingAnim();
                            break;
                        case 3:
                            Animations.Suicide();
                            break;
                        case 4:
                            Animations.SmokingInPlace();
                            break;
                        case 5:
                            Animations.SitupAnim();
                            break;
                        case 6:
                            Animations.HandsOnBelt();
                            break;
                        case 7:
                            Animations.PushupAnim();
                            break;
                        case 8:
                            Animations.GrabVest();
                            break;
                        default:
                            Game.LogTrivial("");
                            break;
                    }
                }
                catch (Exception error)
                {
                    Game.LogTrivial("An error occured in the Menu.cs " + error);
                }
            });
        }
        private static void MainMenu_OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
        
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
