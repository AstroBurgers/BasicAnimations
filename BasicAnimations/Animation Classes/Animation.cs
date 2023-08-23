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
            if (IsAnimationActive || !CheckRequirements())
            {
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

        internal void PlayStopAnimation()
        {
            if (!CheckRequirements())
            {
                return;
            }
            Logger.Log(LogType.Normal, $"Playing animation: {stopName}");
            MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(stopDict), stopName, 5f, AnimationFlags.None).WaitForCompletion();
        }

        internal void ExecuteAnimation(Animation animation, bool intro, bool main, bool stop, bool looped)
        {

        }
    }
}