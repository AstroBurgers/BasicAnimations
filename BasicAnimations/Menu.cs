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
        // Creating the menus
        //String Params are the same as the items
        internal static MenuPool MainMenuPool = new MenuPool();
        internal static UIMenu AllAnimMain = new UIMenu("All Animations", "");
        internal static UIMenu RPAnimations = new UIMenu("RP Animations", "");
        internal static UIMenu MiscAnims = new UIMenu("Miscellaneous", "");
        internal static UIMenu PropAnims = new UIMenu("Prop Animations", "");
        internal static UIMenu MainMenu = new UIMenu("BasicAnimations", "");
        internal static UIMenu Favourites = new UIMenu("Favourites", "");
        internal static UIMenu CustomAnims = new UIMenu("Custom Animations", "");
        internal static void CreateMenu()
        {
            //Adding all the menus to the menu pool.
            MainMenuPool.Add(MainMenu, AllAnimMain, RPAnimations, MiscAnims, PropAnims, CustomAnims);
            
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

            CustomAnims.MouseControlsEnabled = false;
            CustomAnims.AllowCameraMovement = true;
            //Calling SetupMen so I can just have CreateMenu() in Main.cs
            SetupMenu();
            GameFiber.StartNew(ProcessMenus);
        }
        //Creating menu Items
        //First String is button name
        //Second String is the button description on the bottom of the menu.
        internal static UIMenuItem Investigate = new UIMenuItem("Investigate", "");
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
        internal static UIMenuItem CustomMenus = new UIMenuItem("Custom Animations", "Where all of the custom animations in CustomAnimations.txt are");
        internal static void SetupMenu()
        {
            Game.LogTrivial("Creating menu");
            Game.LogTrivial("");
            Game.LogTrivial("Adding Menu Items to Menus");
            Game.LogTrivial("");
            Game.LogTrivial("Adding Item: Sitting");
            Game.LogTrivial("Adding Item: Leaning");
            Game.LogTrivial("Adding Item: Kneel");
            Game.LogTrivial("Adding Item: Smoking");
            Game.LogTrivial("Adding Item: Situps");
            Game.LogTrivial("Adding Item: HandsOnBelt");
            Game.LogTrivial("Adding Item: Salute");
            Game.LogTrivial("Adding Item: Lean2");
            Game.LogTrivial("Adding Item: Mocking");
            Game.LogTrivial("Adding Item: CarryBox");
            Game.LogTrivial("Adding Item: Yoga");
            Game.LogTrivial("Adding Item: Binoculars");
            Game.LogTrivial("Adding Item: Camera");
            Game.LogTrivial("Adding Item: Investigate");
            Game.LogTrivial("");
            AllAnimMain.AddItems(Sitting, Leaning, Kneel, Suicide, Smoking, Situps, HandsOnBelt, Pushup, GrabVest, Salute, Lean2, Mocking, CarryBox, Yoga, Binoculars, Camera, Investigate); // Adding all animations to the AllAnimations Menu
            MainMenu.AddItems(AllAnimations, RPAnims, MiscAnimations, PropAnimations, CustomMenus);
            MainMenu.BindMenuToItem(CustomAnims, CustomMenus);
            MainMenu.BindMenuToItem(AllAnimMain, AllAnimations); //Binding the item defined before to a defined menu
            MainMenu.BindMenuToItem(RPAnimations, RPAnims); //Binding the item defined before to a defined menu
            MainMenu.BindMenuToItem(MiscAnims, MiscAnimations); //Binding the item defined before to a defined menu
            MainMenu.BindMenuToItem(PropAnims, PropAnimations); //Binding the item defined before to a defined menu
            //MainMenu.BindMenuToItem(Favourites, FavouritesButton);
            RPAnimations.OnItemSelect += RPAnimations_OnItemSelect; // Event handler
            PropAnims.OnItemSelect += PropAnims_OnItemSelect; // Event handler
            MiscAnims.OnItemSelect += MiscAnims_OnItemSelect; // Event handler
            MainMenu.OnItemSelect += MainMenu_OnItemSelect; // Event handler
            AllAnimMain.OnItemSelect += AllAnimMain_OnItemSelect;
            // Favourites.OnItemSelect += Favourites_OnItemSelect;
            RPAnimations.AddItems(Sitting, Kneel, Smoking, HandsOnBelt, GrabVest, Salute, Lean2, Investigate);
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
                    case 7:
                        Investigate();
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
                    switch (index) // All animations event handler
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
                        case 16:
                            Investigate();
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
            //Unused handler
        }
        internal static void ProcessMenus()
        {
            try
            {
                while (true)
                {
                    GameFiber.Yield();
                    MainMenuPool.ProcessMenus();
                    if (Game.IsKeyDown(Settings.Menu) && CheckModKey()) // If the button defined in the INI Is pressed trigger the IF State ment
                    {
                        if (MenuRequirements()) // Checking menu requirements defined below
                        {
                            MainMenu.Visible = true; // Making the menu visible
                        }
                        else if (MainMenu.Visible)
                        {
                            MainMenu.Visible = false; // Making the menu no longer visible
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Game.LogTrivial("BasicAnimations " + e); // Errror handling :GIGACHAD:
            }
        }
        internal static bool MenuRequirements() // The afformentioned menu requirements
        {
            return !UIMenu.IsAnyMenuVisible && !TabView.IsAnyPauseMenuVisible; // Makes sure that the player is not paused/in a compulite style menu. Checks if any other menus are open
        }

        internal static bool CheckModKey()
        {
            if (Settings.MenuModKey == Keys.None)
            {
                return true;
            }
            return Game.IsKeyDownRightNow(Settings.MenuModKey);
        }
    }
}