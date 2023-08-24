using Rage;
using System.Windows.Forms;

namespace BasicAnimations.Systems
{
    internal class Helper
    {
        internal static Ped MainPlayer => Game.LocalPlayer.Character;
        internal static bool IsAnimationActive;

        internal static bool CheckRequirements()
        {
            return MainPlayer.Exists() && MainPlayer.IsAlive && MainPlayer.IsValid() && MainPlayer.IsOnFoot && !MainPlayer.IsRagdoll && !MainPlayer.IsReloading && !MainPlayer.IsFalling && !MainPlayer.IsInAir && !MainPlayer.IsJumping && !MainPlayer.IsInWater && !MainPlayer.IsGettingIntoVehicle;
        }

        internal static bool CheckModKey()
        {
            if (ModKey == Keys.None)
            {
                return true;
            }
            return Game.IsKeyDownRightNow(Settings.ModKey);
        }
    }
}
