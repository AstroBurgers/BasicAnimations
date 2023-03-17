using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rage;
using Rage.Native;
using System.Windows.Forms;
using System.Threading.Tasks;
[assembly: Rage.Attributes.Plugin("Bodycam", Description = "Bodycam POV Activate", Author = "Astro")]



namespace Bodycam
{
    public class EntryPoint
    {
        internal static Ped MainPlayer => Game.LocalPlayer.Character;
        public static void Main()
        {
            try
            {



                Camera cam = new Camera(true);
                while (true)
                {
                    GameFiber.Yield();



                    cam.Position = new Vector3(MainPlayer.Position.X, MainPlayer.Position.Y, (MainPlayer.Position.Z - 0.010f));
                    cam.Rotation = new Rotator(0f, 0f, MainPlayer.Heading);
                    cam.Rotation = new Rotator(0f, 0f, MainPlayer.Heading);
                }

            }
            catch (Exception e)
            {
                Game.LogTrivial("Plugin crashed at: " + e);
            }


        }
    
    }
}
