using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Drawing;
using static BasicAnimations.EntryPoint;
using static BasicAnimations.Animations;
using Rage;
using Rage.Native;
using RAGENativeUI;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using RAGENativeUI.Elements;
using Rage.Attributes;
using RAGENativeUI.PauseMenu;
using System.ComponentModel.Design.Serialization;
using System.Net.Http.Headers;

namespace BasicAnimations
{
    internal static class Menu
    {
        internal static MenuPool MainMenuPool = new MenuPool();
        internal static UIMenu AllAnimMain = new UIMenu("All Animations", "");
        internal static UIMenu RPAnimations = new UIMenu("RP Animations", "");
        internal static UIMenu MiscAnims = new UIMenu("Miscellaneous", "");
        internal static UIMenu PropAnims = new UIMenu("Prop Animations", "");
        internal static UIMenu MainMenu = new UIMenu("BasicAnimations", "");
        internal static UIMenu Favourites = new UIMenu("Favourites", "");
        internal static void CreateMenu()
        {
            MainMenuPool.Add(MainMenu, AllAnimMain, RPAnimations, MiscAnims, PropAnims);
            MainMenu.MouseControlsEnabled = false;
            MainMenu.AllowCameraMovement = true;
            AllAnimMain.MouseControlsEnabled = false;
            AllAnimMain.AllowCameraMovement = true;
            RPAnimations.MouseControlsEnabled = false;
            RPAnimations.AllowCameraMovement = true;
            MiscAnims.MouseControlsEnabled = false;
            MiscAnims.AllowCameraMovement = true;
            PropAnims.MouseControlsEnabled = false;
            PropAnims.AllowCameraMovement = true;
            Favourites.MouseControlsEnabled = false;
            Favourites.AllowCameraMovement = true;
            SetupMenu();
            GameFiber.StartNew(ProcessMenus);
        }
        internal static UIMenuItem Camera = new UIMenuItem("Camera", "Pull Out A Camera");
        internal static UIMenuItem Binoculars = new UIMenuItem("Binoculars", "Use some binoculars");
        internal static UIMenuItem FavouritesButton = new UIMenuItem("Favourites", "");
        internal static UIMenuItem RPAnims = new UIMenuItem("RP Animations");
        internal static UIMenuItem MiscAnimations = new UIMenuItem("Miscellaneous");
        internal static UIMenuItem PropAnimations = new UIMenuItem("Prop Animations");
        internal static UIMenuItem AllAnimations = new UIMenuItem("All Animations");
        internal static UIMenuItem CarryBox = new UIMenuItem("Box", "Carry a box");
        internal static UIMenuItem Mocking = new UIMenuItem("Mocking", "Plays mocking animation");
        internal static UIMenuItem Lean2 = new UIMenuItem("Lean 2", "Improved leaning animation");
        internal static UIMenuItem DrinkingCoffee = new UIMenuItem("Drinking Coffee", "Drink some coffee");
        internal static UIMenuItem GrabVest = new UIMenuItem("Grab Vest", "Puts your hands on your vest");
        internal static UIMenuItem HandsOnBelt = new UIMenuItem("Hands On Belt", "Puts your hands on your belt");
        internal static UIMenuItem Sitting = new UIMenuItem("Sit", "Plays sitting animation");
        internal static UIMenuItem Salute = new UIMenuItem("Salute", "Plays salute animation");
        internal static UIMenuItem Leaning = new UIMenuItem("Lean", "Plays leaning animation");
        internal static UIMenuItem Kneel = new UIMenuItem("Kneel", "Plays kneeling animation");
        internal static UIMenuItem Situps = new UIMenuItem("Situps", "Plays the situp animation");
        internal static UIMenuItem Suicide = new UIMenuItem("~r~Suicide", "~r~Kills ~w~the player");
        internal static UIMenuItem Smoking = new UIMenuItem("Smoking", "Plays smoking animation");
        internal static UIMenuItem Pushup = new UIMenuItem("Pushups", "Plays pushup animation");
        internal static UIMenuItem Yoga = new UIMenuItem("Yoga", "STREEETCH");
        internal static void SetupMenu()
        {
            Game.LogTrivial("Creating menu");
            AllAnimMain.AddItems(Sitting, Leaning, Kneel, Suicide, Smoking, Situps, HandsOnBelt, Pushup, GrabVest, Salute, Lean2, Mocking, CarryBox, Yoga, Binoculars, Camera);
            MainMenu.AddItems(AllAnimations, RPAnims, MiscAnimations, PropAnimations);
            MainMenu.BindMenuToItem(AllAnimMain, AllAnimations);
            MainMenu.BindMenuToItem(RPAnimations, RPAnims);
            MainMenu.BindMenuToItem(MiscAnims, MiscAnimations);
            MainMenu.BindMenuToItem(PropAnims, PropAnimations);
            //MainMenu.BindMenuToItem(Favourites, FavouritesButton);
            RPAnimations.OnItemSelect += RPAnimations_OnItemSelect;
            PropAnims.OnItemSelect += PropAnims_OnItemSelect;
            MiscAnims.OnItemSelect += MiscAnims_OnItemSelect;
            MainMenu.OnItemSelect += MainMenu_OnItemSelect;
            AllAnimMain.OnItemSelect += AllAnimMain_OnItemSelect;
            // Favourites.OnItemSelect += Favourites_OnItemSelect;
            RPAnimations.AddItems(Sitting, Kneel, Smoking, HandsOnBelt, GrabVest, Salute, Lean2);
            MiscAnims.AddItems(Leaning, Suicide, Situps, Pushup, Mocking, Yoga);
            PropAnims.AddItems(CarryBox, Binoculars, Camera);
        }

        /*private static void Favourites_OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            throw new NotImplementedException();
        }*/

        private static void MiscAnims_OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            GameFiber.StartNew(delegate
            {
                switch (index)
                {
                    case 0:
                        LeanWall();
                        break;
                    case 1:
                        Suicide();
                        break;
                    case 2:
                        SitupAnim();
                        break;
                    case 3:
                        PushupAnim();
                        break;
                    case 4:
                        Mocking();
                        break;
                    case 5:
                        Yoga();
                        break;
                    default:
                        Game.LogTrivial("");
                        break;
                }

            });
        }

        private static void PropAnims_OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            GameFiber.StartNew(delegate
            {
                switch (index)
                {
                    case 0:
                        CarryBox();
                        break;
                    case 1:
                        Binoculars();
                        break;
                    case 2:
                        Camera();
                        break;
                    default:
                        Game.LogTrivial("");
                        break;
                }

            });
        }

        private static void RPAnimations_OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            GameFiber.StartNew(delegate
            {
                switch (index)
                {
                    case 0:
                        SitOnGround();
                        break;
                    case 1:
                        KneelingAnim();
                        break;
                    case 2:
                        SmokingInPlace();
                        break;
                    case 3:
                        HandsOnBelt();
                        break;
                    case 4:
                        GrabVest();
                        break;
                    case 5:
                        Saluting();
                        break;
                    case 6:
                        Lean2();
                        break;
                    default:
                        Game.LogTrivial("");
                        break;
                }

            });
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
                            SitOnGround();
                            break;
                        case 1:
                            LeanWall();
                            break;
                        case 2:
                            KneelingAnim();
                            break;
                        case 3:
                            Suicide();
                            break;
                        case 4:
                            SmokingInPlace();
                            break;
                        case 5:
                            SitupAnim();
                            break;
                        case 6:
                            HandsOnBelt();
                            break;
                        case 7:
                            PushupAnim();
                            break;
                        case 8:
                            GrabVest();
                            break;
                        case 9:
                            Saluting();
                            break;
                        case 10:
                            Lean2();
                            break;
                        case 11:
                            Mocking();
                            break;
                        case 12:
                            CarryBox();
                            break;
                        case 13:
                            Yoga();
                            break;
                        case 14:
                            Binoculars();
                            break;
                        case 15:
                            Camera();
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