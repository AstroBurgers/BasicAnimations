using System;
using System.Collections.Generic;
using BasicAnimations.Animation_Classes;
using BasicAnimations.Systems;
using Rage;
using RAGENativeUI;
using RAGENativeUI.Elements;
using RAGENativeUI.PauseMenu;
using static BasicAnimations.Systems.Helper;

namespace BasicAnimations.Menus
{
    internal static class Menu
    {
        // Creating the menus
        //String Params are the same as the items
        private static readonly MenuPool MainMenuPool = new();
        private static readonly UIMenu AllAnimMain = new("All Animations", "");
        private static readonly UIMenu MiscAnims = new("Miscellaneous", "");
        private static readonly UIMenu PropAnims = new("Prop Animations", "");
        private static readonly UIMenu MainMenu = new("BasicAnimations", "");
        private static readonly UIMenu DevMenu = new("Development Menu", "");
        private static readonly UIMenu CustomAnimsMenu = new("Custom Animations", "");
        
        internal static void CreateMenu()
        {

            //Adding all the menus to the menu pool
            MainMenuPool.Add(MainMenu, AllAnimMain, MiscAnims, PropAnims, CustomAnimsMenu);

            MainMenu.MouseControlsEnabled = false;
            MainMenu.AllowCameraMovement = true;

            AllAnimMain.MouseControlsEnabled = false;
            AllAnimMain.AllowCameraMovement = true;

            MiscAnims.MouseControlsEnabled = false;
            MiscAnims.AllowCameraMovement = true;

            PropAnims.MouseControlsEnabled = false;
            PropAnims.AllowCameraMovement = true;

            CustomAnimsMenu.MouseControlsEnabled = false;
            CustomAnimsMenu.AllowCameraMovement = true;
            
            DevMenu.MouseControlsEnabled = false;
            DevMenu.AllowCameraMovement = true;

            //Calling SetupMen so I can just have CreateMenu() in Main.cs
            SetupMenu();
            GameFiber.StartNew(ProcessMenus);
        }
        //Creating menu Items
        //First String is button name
        //Second String is the button description on the bottom of the menu.
        private static readonly UIMenuItem Investigate = new("Investigate", "");
        private static readonly UIMenuItem Camera = new("Camera", "Pull Out A Camera");
        private static readonly UIMenuItem Binoculars = new("Binoculars", "Use some binoculars");
        private static readonly UIMenuItem CustomAnimationsMenuItem = new("CustomAnimations");
        private static readonly UIMenuItem MiscAnimations = new("Miscellaneous");
        private static readonly UIMenuItem PropAnimations = new("Prop Animations");
        private static readonly UIMenuItem AllAnimations = new("All Animations");
        private static readonly UIMenuItem CarryBox = new("Box", "Carry a box");
        private static readonly UIMenuItem Mocking = new("Mocking", "Plays mocking animation");
        private static readonly UIMenuItem GrabVest = new("Grab Vest", "Puts your hands on your vest");
        private static readonly UIMenuItem HandsOnBelt = new("Hands On Belt", "Puts your hands on your belt");
        private static readonly UIMenuItem Sitting = new("Sit", "Plays sitting animation");
        private static readonly UIMenuItem Salute = new("Salute", "Plays salute animation");
        private static readonly UIMenuItem Leaning = new("Lean", "Plays leaning animation");
        private static readonly UIMenuItem Kneel = new("Kneel", "Plays kneeling animation");
        private static readonly UIMenuItem Situps = new("Situps", "Plays the situp animation");
        private static readonly UIMenuItem Suicide = new("~r~Suicide", "~r~Kills ~w~the player");
        private static readonly UIMenuItem Smoking = new("Smoking", "Plays smoking animation");
        private static readonly UIMenuItem Pushup = new("Pushups", "Plays pushup animation");
        private static readonly UIMenuItem Yoga = new("Yoga", "STREEETCH");
        private static readonly UIMenuItem EndAnimation = new("~r~End Current Action", "Ends the current active animation/scenario");

        internal static Dictionary<UIMenuItem, Animation> CustomAnimations = new();
        internal static Dictionary<UIMenuItem, Scenario> CustomScenarios = new();
        
        private static void SetupMenu()
        {
            AllAnimMain.AddItems(Sitting, Leaning, Kneel, Suicide, Smoking, Situps, HandsOnBelt, Pushup, GrabVest, Salute, Mocking, CarryBox, Yoga, Binoculars, Camera, Investigate); // Adding all animations to the AllAnimations Menu
            MainMenu.AddItems(AllAnimations, MiscAnimations, PropAnimations, CustomAnimationsMenuItem, EndAnimation);
            MainMenu.BindMenuToItem(AllAnimMain, AllAnimations); //Binding the item defined before to a defined menu
            MainMenu.BindMenuToItem(MiscAnims, MiscAnimations); //Binding the item defined before to a defined menu
            MainMenu.BindMenuToItem(PropAnims, PropAnimations); //Binding the item defined before to a defined menu
            MainMenu.BindMenuToItem(CustomAnimsMenu, CustomAnimationsMenuItem); //Binding the item defined before to a defined menu
            
            foreach (var anim in CustomAnimationsStuff.CustomAnimations.customAnimations.CustomAnimationsArray)
            {
                UIMenuItem customAnimMenuItem = new(anim.MenuName);
                CustomAnimsMenu.AddItem(customAnimMenuItem);
                CustomAnimations.Add(customAnimMenuItem, anim);
            }

            foreach (var scen in CustomAnimationsStuff.CustomAnimations.customAnimations.CustomScenariosArray)
            {
                UIMenuItem customScenarioMenuItem = new(scen.MenuName);
                CustomAnimsMenu.AddItem(customScenarioMenuItem);
                CustomScenarios.Add(customScenarioMenuItem, scen);
            }
            
            PropAnims.OnItemSelect += PropAnims_OnItemSelect; // Event handler
            MiscAnims.OnItemSelect += MiscAnims_OnItemSelect; // Event handler
            MainMenu.OnItemSelect += MainMenu_OnItemSelect; // Event handler
            AllAnimMain.OnItemSelect += AllAnimMain_OnItemSelect;
            CustomAnimsMenu.OnItemSelect += CustomAnimsMenuOnOnItemSelect;
            
            MiscAnims.AddItems(Leaning, Suicide, Situps, Pushup, Mocking, Yoga);
            PropAnims.AddItems(CarryBox, Binoculars, Camera);
        }

        private static void CustomAnimsMenuOnOnItemSelect(UIMenu sender, UIMenuItem selecteditem, int index)
        {
            foreach (var i in CustomAnimations)
            {
                if (selecteditem == i.Key)
                {
                    i.Value.PlayAnimation();
                }
            }

            foreach (var i in CustomScenarios)
            {
                if (selecteditem == i.Key)
                {
                    i.Value.StartScenario();
                }
            }
        }

        private static void MiscAnims_OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            GameFiber.StartNew(delegate
            {
                switch (index)
                {
                    case 0:
                        Animations.Lean.StartScenario();
                        break;
                    case 1:
                        Animations.Suicide();
                        break;
                    case 2:
                        Animations.Situp.PlayAnimation();
                        break;
                    case 3:
                        Animations.Pushup.PlayAnimation();
                        break;
                    case 4:
                        Animations.Mocking.PlayAnimation();
                        break;
                    case 5:
                        Animations.Yoga.StartScenario();
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
                        Animations.Binoculars.StartScenario();
                        break;
                    case 2:
                        Animations.Camera.StartScenario();
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
                            Animations.Sit.PlayAnimation();
                            break;
                        case 1:
                            Animations.Lean.StartScenario();
                            break;
                        case 2:
                            Animations.Kneeling.StartScenario();
                            break;
                        case 3:
                            Animations.Suicide();
                            break;
                        case 4:
                            Animations.Smoking.StartScenario();
                            break;
                        case 5:
                            Animations.Situp.PlayAnimation();
                            break;
                        case 6:
                            Animations.GrabBelt.PlayAnimation();
                            break;
                        case 7:
                            Animations.Pushup.PlayAnimation();
                            break;
                        case 8:
                            Animations.GrabVest.PlayAnimation();
                            break;
                        case 9:
                            Animations.Salute.PlayAnimation();
                            break;
                        case 10:
                            Animations.Mocking.PlayAnimation();
                            break;
                        case 11:
                            Animations.CarryBox();
                            break;
                        case 12:
                            Animations.Yoga.StartScenario();
                            break;
                        case 13:
                            Animations.Binoculars.StartScenario();
                            break;
                        case 14:
                            Animations.Camera.StartScenario();
                            break;
                        case 15:
                            Animations.Investigate.StartScenario();
                            break;
                        default:
                            Game.LogTrivial("");
                            break;
                    }
                }
                catch (Exception error)
                {
                    Logging.Logger.LogException("Menu.cs", error.ToString());
                }
            });
        }
        private static void MainMenu_OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            if (selectedItem.Equals(EndAnimation))
            {
                EndAction();
            }
        }
        private static void ProcessMenus()
        {
            try
            {
                while (true)
                {
                    GameFiber.Yield();
                    MainMenuPool.ProcessMenus();
                    if (!CheckModKey() || !Game.IsKeyDown(Settings.Menu)) continue; // If the button defined in the INI Is pressed trigger the IF State meant
                    if (MenuRequirements()) // Checking menu requirements defined below
                    {
                        MainMenu.Visible = true; // Making the menu visible
                    }
                    else if (MainMenu.Visible)
                    {
                        MainMenu.CurrentItem.Selected = false;
                        PropAnims.CurrentItem.Selected = false;
                        MiscAnims.CurrentItem.Selected = false;
                        AllAnimMain.CurrentItem.Selected = false;
                        
                        MainMenu.Visible = false; // Making the menu no longer visible
                    }
                }
            }
            catch (Exception e)
            {
                Logging.Logger.LogException("Menu.cs - ProcessMenus", e.ToString()); // Error handling :GIGACHAD:
            }
        }
        private static bool MenuRequirements() // The aforementioned menu requirements
        {
            return !UIMenu.IsAnyMenuVisible && !TabView.IsAnyPauseMenuVisible; // Makes sure that the player is not paused/in a Compulite style menu. Checks if any other menus are open
        }
    }
}