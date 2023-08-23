using Rage;
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
        int stayInEndFrameTime;

        internal Animation(string startDict, string startName, string mainDict, string mainName, string stopDict, string stopName, bool looped, bool stayInEndFrame, int stayInEndFrameTime)
        {
            this.startDict = startDict;
            this.startName = startName;

            this.mainDict = mainDict;
            this.mainName = mainName;

            this.stopDict = stopDict;
            this.stopName = stopName;

            this.looped = looped;

            this.stayInEndFrame = stayInEndFrame;
            this.stayInEndFrameTime = stayInEndFrameTime;
        }

        internal void PlayAnimation()
        {
            if (!CheckRequirements()) { return; }
            if (IsAnimationActive && !string.IsNullOrEmpty(stopName) && !string.IsNullOrEmpty(stopDict))
            {
                Logger.Log(LogType.Normal, $"Playing animation: {stopName}");
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(stopDict), stopName, 5f, AnimationFlags.None).WaitForCompletion();
                IsAnimationActive = false;
                return;
            }
            else if (IsAnimationActive || string.IsNullOrEmpty(stopName) || string.IsNullOrEmpty(stopDict))
            {
                Logger.Log(LogType.Normal, "Clearing player tasks");
                MainPlayer.Tasks.Clear();
            }
            else if (stayInEndFrame && !IsAnimationActive && !string.IsNullOrEmpty(startName) && !string.IsNullOrEmpty(startDict))
            {
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(startDict), startName, 5f, AnimationFlags.StayInEndFrame).WaitForStatus(TaskStatus.NoTask, stayInEndFrameTime);
            }
            Logger.Log(LogType.Normal, $"Playing animation: {startName}");
            MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(startDict), startName, 5f, AnimationFlags.None).WaitForCompletion();
            IsAnimationActive = true;
            PlaySecondaryAnimation();
        }

        internal void PlaySecondaryAnimation()
        {
            if (!CheckRequirements() || string.IsNullOrEmpty(mainName) || string.IsNullOrEmpty(mainDict))
            {
                return;
            }
            Logger.Log(LogType.Normal, $"Playing animation: {mainName}");
            if (looped)
            {
                IsAnimationActive = true;
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(mainDict), mainName, 5f, AnimationFlags.Loop);
            }
            else
            {
                IsAnimationActive = true;
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(mainDict), mainName, 5f, AnimationFlags.None);
            }
        }
    }
}