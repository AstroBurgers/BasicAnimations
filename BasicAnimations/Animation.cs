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
            MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(startDict), startName, 5f, AnimationFlags.None).WaitForCompletion();
        }

        internal void PlayMainAnimation()
        {
            MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(mainDict), mainName, 5f, AnimationFlags.Loop);
        }

        internal void PlayStopAnimation()
        {
            MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(stopDict), stopName, 5f, AnimationFlags.None).WaitForCompletion();
        }
    }
}