using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LSPD_First_Response;
using LSPD_First_Response.Mod.API;
using System.Threading.Tasks;
using Rage;
using System.Drawing;
using GrammarPolice.Actions;
using System.Net.Http;

namespace AutomaticTrafficControl
{
    public class Main : Plugin
    {
        internal static uint handle;
        internal static Ped MainPlayer => Game.LocalPlayer.Character;
        internal static bool CurrentlyOnDuty = false;
        internal static Blip Traffic;
        internal static bool ActiveControl;
        public override void Initialize()
        {
            LSPD_First_Response.Mod.API.Functions.OnOnDutyStateChanged += OnOnDutyStateChangedHandler;
            Game.LogTrivial("Automatic Traffic Control " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " has been initialised.");
            Game.LogTrivial("Go on duty to fully load Automatic Traffic Control.");
        }
        public override void Finally()
        {
            if (Traffic.Exists())
            {
                Traffic.Delete();
                World.RemoveSpeedZone(handle);
            }
            Game.LogTrivial("Automatic Traffic Control has been cleaned up.");
        }
        private static void OnOnDutyStateChangedHandler(bool OnDuty)
        {
            CurrentlyOnDuty = OnDuty;
            if (OnDuty)
            {
                Settings.Initialize();
                GameFiber.StartNew(Main2);
                Game.DisplayNotification("Automatic Traffic Control " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " loaded successfully!");
            }
        }
        internal static void Main2()
        {
            try
            {
                while (CurrentlyOnDuty)
                {
                    GameFiber.Yield();
                    if (CheckRequirements() && MainPlayer.IsShooting)
                    {
                        WeaponDescriptor Gun = MainPlayer.Inventory.EquippedWeapon;
                        string gunName = "WEAPON_" + Gun.Hash.ToString().ToUpper();

                        if (gunName != "WEAPON_STUNGUN" && !ActiveControl)
                        {
                            Game.LogTrivial("[LOG] AutomaticTrafficControl: User fired weapon");
                            Game.LogTrivial("[LOG] AutomaticTrafficControl: Stopping traffic");
                            Game.LogTrivial("[LOG] AutomaticTrafficControl: Creating blip");
                            ActiveControl = true;
                            handle = World.AddSpeedZone(MainPlayer.Position, (float) Settings.Size, 0);
                            Traffic = new Blip(MainPlayer.Position, (float) Settings.Size);
                            Traffic.Color = System.Drawing.Color.Maroon;
                            Traffic.Alpha = 0.5f;
                            Game.DisplayNotification("commonmenu", "mp_alerttriangle", "AutomaticTrafficControl", "Traffic Control Status", "~r~Stopping Traffic");
                            
                            Game.LogTrivial("[LOG] AutomaticTrafficControl: Blip created");

                            GameFiber.WaitUntil(() => DistanceChecker());
                            World.RemoveSpeedZone(handle);
                            ActiveControl = false;
                            Traffic.Delete();
                            Game.LogTrivial("[LOG] AutomaticTrafficControl: User no longer in range of blip");
                            Game.LogTrivial("[LOG] AutomaticTrafficControl: Deleting blip");
                            Game.LogTrivial("[LOG] AutomaticTrafficControl: Letting traffic flow again");
                            Game.DisplayNotification("commonmenu", "mp_alerttriangle", "AutomaticTrafficControl", "Traffic Control Status", "~g~Traffic Control Cleared");
                        }
                    }
                }
            }
            catch (System.IO.FileNotFoundException e3)
            {
                Game.LogTrivial("[LOG] AutomaticTrafficControl: An error occured. Exception message: " + e3);
            }
            catch (System.Threading.ThreadAbortException e2)
            {
                    
            }
            catch (Exception e)
            {
                Game.LogTrivial("[LOG] AutomaticTrafficControl: An error occured. Exception message: " + e);
            }
        }
        internal static bool CheckRequirements()
        {
            return MainPlayer.Exists() && MainPlayer.IsAlive && MainPlayer.IsValid();
        }
        internal static bool DistanceChecker()
        {
            return MainPlayer.DistanceTo(Traffic) > (float) Settings.Dist;
        }
    }
}