using Rage;
using static BasicAnimations.Systems.Helper;
using static BasicAnimations.Systems.Logging;
using System.Xml;
using System.Xml.Serialization;

namespace BasicAnimations.Animation_Classes
{
    internal enum AnimationStage
    {
        Start,
        Main,
        End,
        None
    }

    internal class Animation
    {
        private readonly string _startDict;
        private readonly string _startName;

        private readonly string _mainDict;
        private readonly string _mainName;

        private readonly string _stopDict;
        private readonly string _stopName;

        private readonly bool _looped;
        private readonly bool _canMove;

        private readonly bool _stayInEndFrame;
        private readonly int _stayInEndFrameTime;

        private readonly AnimationStage _stayInEndFrameStage;

        internal Animation() {}
        
        internal Animation(string startDict, string startName, string mainDict, string mainName, string stopDict, string stopName, bool looped, bool stayInEndFrame = false, int stayInEndFrameTime = 0, AnimationStage stayInEndFrameStage = AnimationStage.None, bool canMove = false)
        {
            this._startDict = startDict;
            this._startName = startName;

            this._mainDict = mainDict;
            this._mainName = mainName;

            this._stopDict = stopDict;
            this._stopName = stopName;

            this._looped = looped;
            this._canMove = canMove;

            this._stayInEndFrame = stayInEndFrame;
            this._stayInEndFrameTime = stayInEndFrameTime;

            this._stayInEndFrameStage = stayInEndFrameStage;
        }

        internal void PlayAnimation()
        {
            if (!CheckRequirements()) { return; }

            if (IsAnimationActive && !string.IsNullOrEmpty(_stopName) && !string.IsNullOrEmpty(_stopDict))
            {
                Logger.Log(LogType.Normal, $"Playing animation: {_stopName}");
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(_stopDict), _stopName, 5f, AnimationFlags.None).WaitForCompletion();
                IsAnimationActive = false;
                MainPlayer.Tasks.Clear();
                return;
            }

            else if (IsAnimationActive)
            {
                Logger.Log(LogType.Normal, "Clearing player tasks");
                MainPlayer.Tasks.Clear();
                IsAnimationActive = false;
                return;
            }

            else if (!IsAnimationActive && _stayInEndFrame && (_stayInEndFrameStage == AnimationStage.Start))
            {
                Logger.Log(LogType.Normal, $"Playing animation: {_startName}");
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(_startDict), _startName, 5f, SetFlags()).WaitForStatus(TaskStatus.NoTask, _stayInEndFrameTime);
                IsAnimationActive = true;
            }

            else if (!IsAnimationActive && _looped && !string.IsNullOrEmpty(_startName) && !string.IsNullOrEmpty(_startDict) && CheckRequirements())
            {
                Logger.Log(LogType.Normal, $"Playing animation: {_startName}");
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(_startDict), _startName, 5f, SetFlags());
                IsAnimationActive = true;
            }

            else if (!IsAnimationActive && !string.IsNullOrEmpty(_startName) && !string.IsNullOrEmpty(_startDict) && CheckRequirements())
            {
                Logger.Log(LogType.Normal, $"Playing animation: {_startName}");
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(_startDict), _startName, 5f, SetFlags()).WaitForCompletion();
                IsAnimationActive = true;
            }


            PlaySecondaryAnimation();
        }

        private void PlaySecondaryAnimation()
        {
            if (!CheckRequirements() || string.IsNullOrEmpty(_mainName) || string.IsNullOrEmpty(_mainDict)) { return; }
            Logger.Log(LogType.Normal, $"Playing animation: {_mainName}");
            if (_stayInEndFrame && (_stayInEndFrameStage == AnimationStage.Main))
            {
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(_mainDict), _mainName, 5f, SetFlags()).WaitForStatus(TaskStatus.NoTask, _stayInEndFrameTime);
                IsAnimationActive = true;
                return;
            }
            IsAnimationActive = true;
            MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(_mainDict), _mainName, 5f, SetFlags());
        }

        private AnimationFlags SetFlags()
        {
            AnimationFlags flags = AnimationFlags.None;

            if (_stayInEndFrame)
            {
                flags = AnimationFlags.StayInEndFrame;
                if (_looped)
                {
                    flags = AnimationFlags.StayInEndFrame | AnimationFlags.Loop;
                }
            }
            else if (_canMove)
            {
                flags = AnimationFlags.Unknown65536 | AnimationFlags.UpperBodyOnly | AnimationFlags.SecondaryTask | AnimationFlags.Loop;
            }
            else if (_looped)
            {
                flags = AnimationFlags.Loop;
            }

            return flags;
        }
    }
}