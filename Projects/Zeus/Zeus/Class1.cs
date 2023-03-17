using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rage;
using Rage.Native;
using System.Windows.Forms;
using System.Threading.Tasks;
[assembly: Rage.Attributes.Plugin("ZEUS", Description = "ZIPPITY ZAP", Author = "Astro")]
namespace Zeus
{
    public class EntryPoint
    {
        public static void Main()
        {
            GameFiber.StartNew(delegate
            {
                try
                {
                    Game.DisplayNotification("~b~Zeus ~g~Loaded with no issues!");                    
                        
                        while (true)
                        {
                            GameFiber.Yield();
                            if (Game.IsKeyDown(Keys.Y))
                            {

                                Game.DisplayNotification("~r~ZAP");
                                NativeFunction.Natives.xF6062E089251C898();
                                World.Weather = WeatherType.Neutral;
                                GameFiber.Wait(10000);
                                NativeFunction.Natives.xF6062E089251C898();
                                World.Weather = WeatherType.Overcast;
                                GameFiber.Wait(10000);
                                NativeFunction.Natives.xF6062E089251C898();
                                World.Weather = WeatherType.Rain;
                                GameFiber.Wait(10000);
                                NativeFunction.Natives.xF6062E089251C898();
                                World.Weather = WeatherType.Thunder;
                                
                            }


                        }
                    
                }
                catch (System.Threading.ThreadAbortException)
                {
                    Game.LogTrivial("Something fucking broke dumbass");
                }
                catch (Exception e)
                {
                    Game.LogTrivial("ZEUS: Something fucking broke: " + e);
                }

            });
    }   }
}
