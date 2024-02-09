using System.Xml.Serialization;
using Rage;
using static BasicAnimations.Systems.Helper;
using static BasicAnimations.Systems.Logging;

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
        [XmlAttribute("IntroDict")]
        public string StartDict = string.Empty;
        [XmlAttribute("IntroName")]
        public string StartName = string.Empty;
        
        [XmlAttribute("MainDict")]
        public string MainDict = string.Empty;
        [XmlAttribute("MainName")]
        public string MainName = string.Empty;
        
        [XmlAttribute("OutroDict")]
        public string StopDict = string.Empty;
        [XmlAttribute("OutroName")]
        public string StopName = string.Empty;
        
        [XmlAttribute("Looped")]
        public bool Looped = false;
        [XmlAttribute("CanPlayerMove")]
        public bool CanMove = false;
        
        [XmlAttribute("StayInAnimEndFrame")]
        public bool StayInEndFrame = false;

        [XmlAttribute("StayInAnimEndFrameTime")]
        public int StayInEndFrameTime = 0;

        [XmlAttribute("StayInAnimEndFrameStage")]
        public AnimationStage StayInEndFrameStage = AnimationStage.None;
        
        [XmlText]
        public string MenuName = "CustomAnimation";
        
        public Animation() {}
        
        public Animation(string startDict, string startName, string mainDict, string mainName, string stopDict, string stopName, bool looped, bool stayInEndFrame = false, int stayInEndFrameTime = 0, AnimationStage stayInEndFrameStage = AnimationStage.None, bool canMove = false)
        {
            StartDict = startDict;
            StartName = startName;

            MainDict = mainDict;
            MainName = mainName;

            StopDict = stopDict;
            StopName = stopName;

            Looped = looped;
            CanMove = canMove;

            StayInEndFrame = stayInEndFrame;
            StayInEndFrameTime = stayInEndFrameTime;

            StayInEndFrameStage = stayInEndFrameStage;
        }
        
        public Animation(string menuName, string startDict, string startName, string mainDict, string mainName, string stopDict, string stopName, bool looped, bool stayInEndFrame = false, int stayInEndFrameTime = 0, AnimationStage stayInEndFrameStage = AnimationStage.None, bool canMove = false)
        {
            MenuName = menuName;
            
            StartDict = startDict;
            StartName = startName;

            MainDict = mainDict;
            MainName = mainName;

            StopDict = stopDict;
            StopName = stopName;

            Looped = looped;
            CanMove = canMove;

            StayInEndFrame = stayInEndFrame;
            StayInEndFrameTime = stayInEndFrameTime;

            StayInEndFrameStage = stayInEndFrameStage;
        }

        public void PlayAnimation()
        {
            if (!CheckRequirements()) { return; }

            switch (IsAnimationActive)
            {
                case true when !string.IsNullOrEmpty(StopName) && !string.IsNullOrEmpty(StopDict):
                    Logger.Log(LogType.Normal, $"Playing animation: {StopName}");
                    MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(StopDict), StopName, 5f, AnimationFlags.None).WaitForCompletion();
                    IsAnimationActive = false;
                    MainPlayer.Tasks.Clear();
                    return;
                
                case true:
                    Logger.Log(LogType.Normal, "Clearing player tasks");
                    MainPlayer.Tasks.Clear();
                    IsAnimationActive = false;
                    return;
                
                case false when StayInEndFrame && (StayInEndFrameStage == AnimationStage.Start):
                    Logger.Log(LogType.Normal, $"Playing animation: {StartName}");
                    MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(StartDict), StartName, 5f, SetFlags()).WaitForStatus(TaskStatus.NoTask, StayInEndFrameTime);
                    IsAnimationActive = true;
                    break;
               
                case false when Looped && !string.IsNullOrEmpty(StartName) && !string.IsNullOrEmpty(StartDict) && CheckRequirements():
                    Logger.Log(LogType.Normal, $"Playing animation: {StartName}");
                    MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(StartDict), StartName, 5f, SetFlags());
                    IsAnimationActive = true;
                    break;
                
                case false when !string.IsNullOrEmpty(StartName) && !string.IsNullOrEmpty(StartDict) && CheckRequirements():
                    Logger.Log(LogType.Normal, $"Playing animation: {StartName}");
                    MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(StartDict), StartName, 5f, SetFlags()).WaitForCompletion();
                    IsAnimationActive = true;
                    break;
            }


            PlaySecondaryAnimation();
        }

        private void PlaySecondaryAnimation()
        {
            if (!CheckRequirements() || string.IsNullOrEmpty(MainName) || string.IsNullOrEmpty(MainDict)) { return; }
            Logger.Log(LogType.Normal, $"Playing animation: {MainName}");
            if (StayInEndFrame && (StayInEndFrameStage == AnimationStage.Main))
            {
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(MainDict), MainName, 5f, SetFlags()).WaitForStatus(TaskStatus.NoTask, StayInEndFrameTime);
                IsAnimationActive = true;
                return;
            }
            IsAnimationActive = true;
            MainPlayer.Tasks.PlayAnimation(new AnimationDictionary(MainDict), MainName, 5f, SetFlags());
        }

        private AnimationFlags SetFlags()
        {
            var flags = AnimationFlags.None;

            if (StayInEndFrame)
            {
                flags = AnimationFlags.StayInEndFrame;
                if (Looped)
                {
                    flags = AnimationFlags.StayInEndFrame | AnimationFlags.Loop;
                }
            }
            else if (CanMove)
            {
                flags = AnimationFlags.Unknown65536 | AnimationFlags.UpperBodyOnly | AnimationFlags.SecondaryTask | AnimationFlags.Loop;
            }
            else if (Looped)
            {
                flags = AnimationFlags.Loop;
            }

            return flags;
        }
    }
}