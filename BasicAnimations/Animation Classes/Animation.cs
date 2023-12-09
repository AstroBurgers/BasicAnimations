using System;
using Rage;
using static BasicAnimations.Systems.Helper;
using static BasicAnimations.Systems.Logging;
using System.Xml;
using System.Xml.Serialization;

namespace BasicAnimations.Animation_Classes
{
    public enum AnimationStage
    {
        Start,
        Main,
        End,
        None
    }
    
    public class Animation
    {
        private readonly string _startDict = string.Empty;
        private readonly string _startName = string.Empty;
        
        private readonly string _mainDict = string.Empty;
        private readonly string _mainName = string.Empty;
        
        private readonly string _stopDict = string.Empty;
        private readonly string _stopName = string.Empty;
        
        private readonly bool _looped = false;
        private readonly bool _canMove = false;
        
        private readonly bool _stayInEndFrame = false;

        private readonly int _stayInEndFrameTime = 0;

        private readonly AnimationStage _stayInEndFrameStage = AnimationStage.None;
        
        
        public Animation(string startDict, string startName, string mainDict, string mainName, string stopDict, string stopName, bool looped, bool stayInEndFrame = false, int stayInEndFrameTime = 0, AnimationStage stayInEndFrameStage = AnimationStage.None, bool canMove = false)
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

        public void PlayAnimation()
        {
            if (!CheckRequirements()) { return; }

            switch (IsAnimationActive)
            {
                case true when !string.IsNullOrEmpty(_stopName) && !string.IsNullOrEmpty(_stopDict):
                    Logger.Log(LogType.Normal, $"Playing animation: {_stopName}");
                    MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(_stopDict), _stopName, 5f, AnimationFlags.None).WaitForCompletion();
                    IsAnimationActive = false;
                    MainPlayer.Tasks.Clear();
                    return;
                case true:
                    Logger.Log(LogType.Normal, "Clearing player tasks");
                    MainPlayer.Tasks.Clear();
                    IsAnimationActive = false;
                    return;
                case false when _stayInEndFrame && (_stayInEndFrameStage == AnimationStage.Start):
                    Logger.Log(LogType.Normal, $"Playing animation: {_startName}");
                    MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(_startDict), _startName, 5f, SetFlags()).WaitForStatus(TaskStatus.NoTask, _stayInEndFrameTime);
                    IsAnimationActive = true;
                    break;
                case false when _looped && !string.IsNullOrEmpty(_startName) && !string.IsNullOrEmpty(_startDict) && CheckRequirements():
                    Logger.Log(LogType.Normal, $"Playing animation: {_startName}");
                    MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(_startDict), _startName, 5f, SetFlags());
                    IsAnimationActive = true;
                    break;
                case false when !string.IsNullOrEmpty(_startName) && !string.IsNullOrEmpty(_startDict) && CheckRequirements():
                    Logger.Log(LogType.Normal, $"Playing animation: {_startName}");
                    MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(_startDict), _startName, 5f, SetFlags()).WaitForCompletion();
                    IsAnimationActive = true;
                    break;
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
            var flags = AnimationFlags.None;

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