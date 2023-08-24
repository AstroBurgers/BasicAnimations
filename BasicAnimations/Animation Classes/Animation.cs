using Rage;
using System;
using System.Text;
using static BasicAnimations.Systems.Helper;
using static BasicAnimations.Systems.Logging;

namespace BasicAnimations.Animation_Classes
{
    enum AnimationStage
    {
        Start,
        Main,
        End,
        None
    }

    internal class Animation
    {
        string startDict;
        string startName;

        string mainDict;
        string mainName;

        string stopDict;
        string stopName;

        bool looped;
        bool canMove;

        bool stayInEndFrame;
        int stayInEndFrameTime;

        AnimationStage stayInEndFrameStage;

        internal Animation(string startDict, string startName, string mainDict, string mainName, string stopDict, string stopName, bool looped, bool stayInEndFrame, int stayInEndFrameTime, AnimationStage stayInEndFrameStage, bool canMove)
        {
            this.startDict = startDict;
            this.startName = startName;

            this.mainDict = mainDict;
            this.mainName = mainName;

            this.stopDict = stopDict;
            this.stopName = stopName;

            this.looped = looped;
            this.canMove = canMove;

            this.stayInEndFrame = stayInEndFrame;
            this.stayInEndFrameTime = stayInEndFrameTime;

            this.stayInEndFrameStage = stayInEndFrameStage;
        }

        internal void PlayAnimation()
        {
            if (!CheckRequirements()) { return; }

            if (IsAnimationActive && !string.IsNullOrEmpty(stopName) && !string.IsNullOrEmpty(stopDict))
            {
                Logger.Log(LogType.Normal, $"Playing animation: {stopName}");
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(stopDict), stopName, 5f, AnimationFlags.None).WaitForCompletion();
                IsAnimationActive = false;
                MainPlayer.Tasks.Clear();
                return;
            }

            else if (IsAnimationActive || string.IsNullOrEmpty(stopName) || string.IsNullOrEmpty(stopDict))
            {
                Logger.Log(LogType.Normal, "Clearing player tasks");
                MainPlayer.Tasks.Clear();
                IsAnimationActive = false;
                return;
            }

            if (IsAnimationActive || string.IsNullOrEmpty(startName) || string.IsNullOrEmpty(startDict) || !CheckRequirements()) { return; }

            else if (stayInEndFrame && (stayInEndFrameStage == AnimationStage.Start))
            {
                Logger.Log(LogType.Normal, $"Playing animation: {startName}");
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(startDict), startName, 5f, SetFlags()).WaitForStatus(TaskStatus.NoTask, stayInEndFrameTime);
                IsAnimationActive = true;
            }

            else
            {
                Logger.Log(LogType.Normal, $"Playing animation: {startName}");
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(startDict), startName, 5f, SetFlags()).WaitForCompletion();
                IsAnimationActive = true;
            }

            PlaySecondaryAnimation();
        }

        internal void PlaySecondaryAnimation()
        {
            if (!CheckRequirements() || string.IsNullOrEmpty(mainName) || string.IsNullOrEmpty(mainDict)) { return; }
            Logger.Log(LogType.Normal, $"Playing animation: {mainName}");
            if (stayInEndFrame && (stayInEndFrameStage == AnimationStage.Main))
            {
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(mainDict), mainName, 5f, SetFlags()).WaitForStatus(TaskStatus.NoTask, stayInEndFrameTime);
                IsAnimationActive = true;
                return;
            }
            IsAnimationActive = true;
            MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(mainDict), mainName, 5f, SetFlags());
        }

        internal AnimationFlags SetFlags()
        {
            var flags = AnimationFlags.None;

            if (stayInEndFrame)
            {
                flags = AnimationFlags.StayInEndFrame;
            }
            else if (canMove)
            {
                flags = AnimationFlags.Unknown65536 | AnimationFlags.UpperBodyOnly | AnimationFlags.SecondaryTask | AnimationFlags.Loop;
            }
            else if (looped)
            {
                flags = AnimationFlags.Loop;
            }

            return flags;
        }
    }
}