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
        internal static UIMenu MainMenu = new UIMenu("BasicAnimations", "");
        internal static UIMenu Favourites = new UIMenu("Favourites", "");
        internal static UIMenuItem StopAllAnimations = new UIMenuItem("Stop All Animations");
        internal static UIMenuItem FavouritesButton = new UIMenuItem("Favourites", "");
        internal static UIMenuItem AllAnimations = new UIMenuItem("All Animations");
        internal static UIMenuItem Suicide = new UIMenuItem("Suicide", "Commit Suicide");
        internal static UIMenuItem CarryBox = new UIMenuItem("Carry Box", "Carry a box");
        
        internal static void CreateMenu()
        {
            //Adding all the menus to the menu pool.
            MainMenuPool.Add(MainMenu, AllAnimMain);
            MainMenu.MouseControlsEnabled = false;
            MainMenu.AllowCameraMovement = true;
            
            AllAnimMain.MouseControlsEnabled = false;
            AllAnimMain.AllowCameraMovement = true;
            //Calling SetupMen so I can just have CreateMenu() in Main.cs
            SetupMenu();
            GameFiber.StartNew(ProcessMenus);
        }
        internal static void AddMenuItems()
        {
            AllAnimMain.AddItem(StopAllAnimations);
            for (int i = 0; i < actions.Count; i++)
            {
                AllAnimMain.AddItem(new UIMenuItem(actions[i].MenuName, actions[i].MenuDescription));
                Game.LogTrivial("Adding Menu Item: " + actions[i].MenuName);
            }
            AllAnimMain.AddItems(Suicide, CarryBox);
        }
        
        internal static void SetupMenu()
        {
            Game.LogTrivial("Creating menu");
            AddMenuItems();
            MainMenu.AddItems(AllAnimations);
            MainMenu.BindMenuToItem(AllAnimMain, AllAnimations); //Binding the item defined before to a defined menu
            //MainMenu.BindMenuToItem(Favourites, FavouritesButton);
            MainMenu.OnItemSelect += MainMenu_OnItemSelect; // Event handler
            AllAnimMain.OnItemSelect += AllAnimMain_OnItemSelect;
            // Favourites.OnItemSelect += Favourites_OnItemSelect;
        }

        /*private static void Favourites_OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            throw new NotImplementedException();
        }*/

        private static void AllAnimMain_OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            GameFiber.StartNew(delegate
            {
                try
                {
                    if (selectedItem.Equals(StopAllAnimations))
                    {
                        EndAction(ActiveAnimation);
                    }
                    else if (selectedItem.Equals(Suicide))
                    {
                        Animations.Suicide();
                    }
                    else if (selectedItem.Equals(CarryBox))
                    {
                        Animations.CarryBox();
                    }
                    else
                    {
                        PlayAction(actions[index -1]);
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
                    if (Game.IsKeyDown(Settings.Menu)) // If the button defined in the INI Is pressed trigger the IF State ment
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
    }
}