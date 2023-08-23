using Rage;
using RAGENativeUI;
using RAGENativeUI.Elements;
using RAGENativeUI.PauseMenu;
using System;
using System.Windows.Forms;
using static BasicAnimations.Animations;

namespace BasicAnimations
{
    internal static class Menu
    {
        // Creating the menus
        //String Params are the same as the items
        internal static MenuPool MainMenuPool = new MenuPool();
        internal static UIMenu AllAnimMain = new UIMenu("All Animations", "");
        internal static UIMenu MiscAnims = new UIMenu("Miscellaneous", "");
        internal static UIMenu PropAnims = new UIMenu("Prop Animations", "");
        internal static UIMenu MainMenu = new UIMenu("BasicAnimations", "");
        internal static UIMenu Favourites = new UIMenu("Favourites", "");
        internal static UIMenu CustomAnims = new UIMenu("Custom Animations", "");
        internal static void CreateMenu()
        {

            //Adding all the menus to the menu pool.
            MainMenuPool.Add(MainMenu, AllAnimMain, MiscAnims, PropAnims, CustomAnims);

            MainMenu.MouseControlsEnabled = false;
            MainMenu.AllowCameraMovement = true;

            AllAnimMain.MouseControlsEnabled = false;
            AllAnimMain.AllowCameraMovement = true;

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
            AllAnimMain.AddItems(Sitting, Leaning, Kneel, Suicide, Smoking, Situps, HandsOnBelt, Pushup, GrabVest, Salute, Lean2, Mocking, CarryBox, Yoga, Binoculars, Camera, Investigate); // Adding all animations to the AllAnimations Menu
            MainMenu.AddItems(AllAnimations, RPAnims, MiscAnimations, PropAnimations, CustomMenus);
            MainMenu.BindMenuToItem(CustomAnims, CustomMenus);
            MainMenu.BindMenuToItem(AllAnimMain, AllAnimations); //Binding the item defined before to a defined menu
            MainMenu.BindMenuToItem(MiscAnims, MiscAnimations); //Binding the item defined before to a defined menu
            MainMenu.BindMenuToItem(PropAnims, PropAnimations); //Binding the item defined before to a defined menu
            //MainMenu.BindMenuToItem(Favourites, FavouritesButton);
            PropAnims.OnItemSelect += PropAnims_OnItemSelect; // Event handler
            MiscAnims.OnItemSelect += MiscAnims_OnItemSelect; // Event handler
            MainMenu.OnItemSelect += MainMenu_OnItemSelect; // Event handler
            AllAnimMain.OnItemSelect += AllAnimMain_OnItemSelect;
            // Favourites.OnItemSelect += Favourites_OnItemSelect;
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
                        Animations.LeanWall();
                        break;
                    case 1:
                        Animations.Suicide();
                        break;
                    case 2:
                        Animations.SitupAnim();
                        break;
                    case 3:
                        Animations.PushupAnim();
                        break;
                    case 4:
                        Animations.Mocking();
                        break;
                    case 5:
                        Animations.Yoga();
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
                        Animations.CarryBox();
                        break;
                    case 1:
                        Animations.Binoculars();
                        break;
                    case 2:
                        Animations.Camera();
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
                        case 9:
                            Animations.Saluting();
                            break;
                        case 10:
                            Animations.Lean2();
                            break;
                        case 11:
                            Animations.Mocking();
                            break;
                        case 12:
                            Animations.CarryBox();
                            break;
                        case 13:
                            Animations.Yoga();
                            break;
                        case 14:
                            Animations.Binoculars();
                            break;
                        case 15:
                            Animations.Camera();
                            break;
                        case 16:
                            Animations.Investigate();
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
                    if (Game.IsKeyDownRightNow(Keys.LShiftKey) && Game.IsKeyDown(Keys.B)) // If the button defined in the INI Is pressed trigger the IF State ment
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