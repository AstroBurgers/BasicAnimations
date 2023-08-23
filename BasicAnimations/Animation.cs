using Rage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAnimations
{
    internal class Animation
    {
        internal static Ped MainPlayer => Game.LocalPlayer.Character;
        string startDict;
        string startName;
        
        string mainDict;
        string mainName;
        
        string stopDict;
        string stopName;

        internal Animation(string startDict, string startName, string mainDict, string mainName, string stopDict, string stopName)
        {
            this.startDict = startDict;
            this.startName = startName;
            
            this.mainDict = mainDict;
            this.mainName = mainName;
            
            this.stopDict = stopDict;
            this.stopName = stopName;
        }

        internal void PlayIntroAnim()
        {
            if (!String.IsNullOrEmpty(startDict) && !String.IsNullOrEmpty(startName) && !CheckRequirements())
            { 
                return;
            }
            Game.LogTrivial("Playing intro animation");
            Game.LogTrivial($"Playing animation... dict/name : {startDict}, {startName}");
            MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(startDict), startName, 5f, AnimationFlags.None).WaitForCompletion();
        }

        internal void PlayMainAnimation()
        {
            if (!String.IsNullOrEmpty(mainDict) && !String.IsNullOrEmpty(mainName) && !CheckRequirements())
            {
                return;
            }
            
            Game.LogTrivial("Playing Main animation");
            Game.LogTrivial($"Playing animation... dict/name : {mainDict}, {mainName}");
            MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(mainDict), mainName, 5f, AnimationFlags.Loop);
        }

        internal void PlayStopAnimation()
        {
            if (!String.IsNullOrEmpty(stopDict) && !String.IsNullOrEmpty(stopName) && !CheckRequirements())
            {
                return;
            }

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