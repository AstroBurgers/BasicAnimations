using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rage;
using static BasicAnimations.EntryPoint;
using TaskStatus = Rage.TaskStatus;
namespace BasicAnimations
{
    internal class Animation : Action
    {
        internal AnimationDictionary animationDict;
        internal string AnimName;
        internal AnimationFlags AnimFlags;
        internal float blendSpeed;
        internal bool WaitForCompletion;
        internal bool WaitForStatus;
        internal int WaitForStatusInt;

       internal Animation(AnimationDictionary animationDict, string AnimName, float blendSpeed,AnimationFlags AnimFlags, bool WaitForCompletion, bool WaitForStatus,int WaitForStatusInt, string MenuName, string MenuDescription) : base(MenuName, MenuDescription)
        {
            this.animationDict = animationDict;
            this.AnimName = AnimName;
            this.AnimFlags = AnimFlags;
            this.blendSpeed = blendSpeed;
            this.WaitForCompletion = WaitForCompletion;
            this.WaitForStatus = WaitForStatus;
            this.WaitForStatusInt = WaitForStatusInt;
        }

        override 
        internal void Play()
        {
            if (WaitForCompletion)
            {
                MainPlayer.Tasks.PlayAnimation(animationDict, AnimName, blendSpeed, AnimFlags).WaitForCompletion();
            }
            else if (WaitForStatus)
            {
                MainPlayer.Tasks.PlayAnimation(animationDict, AnimName, blendSpeed, AnimFlags).WaitForStatus(TaskStatus.NoTask, WaitForStatusInt);
            }
            else
            {
                MainPlayer.Tasks.PlayAnimation(animationDict, AnimName, blendSpeed, AnimFlags);
            }
        }
        override internal void PlayEndAnimation(){}
    }
}
