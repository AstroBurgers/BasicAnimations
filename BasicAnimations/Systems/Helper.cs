using Rage;
namespace BasicAnimations.Systems
{
    internal class Helper
    {
        internal static Ped MainPlayer => Game.LocalPlayer.Character;
        internal static bool IsAnimationActive;
    }
}
