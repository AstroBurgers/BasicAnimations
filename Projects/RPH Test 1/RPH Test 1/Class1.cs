using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rage;
using Rage.Native;
using System.Windows.Forms;
using System.Threading.Tasks;

[assembly: Rage.Attributes.Plugin("RPH Test plugin", Description = "Lets hope this shit works", Author = "Astro")]
namespace RPH_Test_1
{
    public static class EntryPoint
    {
        public static void Main()
        {
            Game.DisplayNotification("It ~r~ worked ~g~ lets go!");
            
            while (true)
            {
                GameFiber.Yield();
                if (Game.IsKeyDown(Keys.U)) 
                {
                    //Ped[] Peds = Game.LocalPlayer.Character.GetNearbyPeds(15);
                    //int KilledPeds = 0;
                    //for (int i = 0; i < Peds.Length; i++)
                    //{
                    //    GameFiber.Yield();
                    //
                    //    Peds[i].Kill();
                    //    KilledPeds = KilledPeds + 1;
                    //}
                    //NativeFunction.Natives.xCEA04D83135264CC(Game.LocalPlayer.Character, 100);
                    NativeFunction.Natives.x6B83617E04503888(Game.LocalPlayer.Character.GetOffsetPositionFront(7f), 25, true);
                    //Vehicle i = new Vehicle("DOMINATOR", Game.LocalPlayer.Character.GetOffsetPositionFront(7f), Game.LocalPlayer.Character.Heading);
                    Game.DisplayNotification("~g~ Fire made!");
                }

                
            
            }


        }
        
    }
}
