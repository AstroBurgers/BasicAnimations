using Rage;
using System;
using static BasicAnimations.Systems.Helper;
using static BasicAnimations.Systems.Logging;

namespace BasicAnimations.Animation_Classes
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
        bool stayInEndFrame;

        internal Animation(string startDict, string startName, string mainDict, string mainName, string stopDict, string stopName, bool looped, bool stayInEndFrame)
        {
            this.startDict = startDict;
            this.startName = startName;

            this.mainDict = mainDict;
            this.mainName = mainName;

            this.stopDict = stopDict;
            this.stopName = stopName;

            this.looped = looped;
            this.stayInEndFrame = stayInEndFrame;
        }

        internal void PlayIntroAnim()
        {
            if (!CheckRequirements()) { return; }
            if (IsAnimationActive)
            {
                Logger.Log(LogType.Normal, $"Playing animation: {stopName}");
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(stopDict), stopName, 5f, AnimationFlags.None).WaitForCompletion();
                return;
            }
            Logger.Log(LogType.Normal, $"Playing animation: {startName}");
            MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(startDict), startName, 5f, AnimationFlags.None).WaitForCompletion();
        }

        internal void PlayMainAnimation()
        {
            if (IsAnimationActive || !CheckRequirements())
            {
                return;
            }
            Logger.Log(LogType.Normal, $"Playing animation: {mainName}");
            if (looped)
            {
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(mainDict), mainName, 5f, AnimationFlags.Loop);
            }
            else
            {
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(mainDict), mainName, 5f, AnimationFlags.None);
            }
        }
    }
}