using Rage;
using System;
using static BasicAnimations.Systems.Helper;
using static BasicAnimations.Systems.Logging;

namespace BasicAnimations
{
    internal class Animation
    {
        string startDict;
        string startName;

        string mainDict;
        string mainName;

        string stopDict;
        string stopName;

        bool looped;

        internal Animation(string startDict, string startName, string mainDict, string mainName, string stopDict, string stopName, bool looped)
        {
            this.startDict = startDict;
            this.startName = startName;

            this.mainDict = mainDict;
            this.mainName = mainName;

            this.stopDict = stopDict;
            this.stopName = stopName;

            this.looped = looped;
        }

        internal void PlayIntroAnim()
        {
            if (IsAnimationActive)
            {
                return;
            }
            Game.LogTrivial("Playing intro animation");
            Game.LogTrivial($"Playing animation... dict/name : {startDict}, {startName}");
            MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(startDict), startName, 5f, AnimationFlags.None).WaitForCompletion();
        }

        internal void PlayMainAnimation()
        {
            if (IsAnimationActive)
            {
                return;
            }
            Game.LogTrivial("Playing Main animation");
            Game.LogTrivial($"Playing animation... dict/name : {mainDict}, {mainName}");
            MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(mainDict), mainName, 5f, AnimationFlags.Loop);
        }

        internal void PlayStopAnimation()
        {
            Game.LogTrivial("Playing Exit animation");
            Game.LogTrivial($"Playing animation... dict/name : {stopDict}, {stopName}");
            MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(stopDict), stopName, 5f, AnimationFlags.None).WaitForCompletion();
        }

        internal static bool CheckRequirements()
        {
            return MainPlayer.Exists() && MainPlayer.IsAlive && MainPlayer.IsValid() && MainPlayer.IsOnFoot && !MainPlayer.IsRagdoll && !MainPlayer.IsReloading && !MainPlayer.IsFalling && !MainPlayer.IsInAir && !MainPlayer.IsJumping && !MainPlayer.IsInWater && !MainPlayer.IsGettingIntoVehicle;
        }
    }
}