using Rage;
using static BasicAnimations.EntryPoint;

namespace BasicAnimations
{
    internal class AnimationSequence : Action
    {
        internal Animation startAnim;
        internal Animation secondStartAnim;
        internal Animation endAnim;

        internal AnimationSequence(Animation startAnim, Animation secondStartAnim, Animation endAnim, string MenuName = "", string MenuDescription="") : base(MenuName, MenuDescription)
        {
            this.startAnim = startAnim;
            this.secondStartAnim = secondStartAnim;
            this.endAnim = endAnim;
            this.MenuName = startAnim.MenuName;
            this.MenuDescription = startAnim.MenuDescription;
        }

        override internal void Play()
        {
            startAnim.Play();
            Game.LogTrivial($"Started {startAnim.MenuName}");
            if (secondStartAnim != null)
            {
                secondStartAnim.Play();
                Game.LogTrivial($"Started {startAnim.MenuName}");
            }
        }
        
        override internal void PlayEndAnimation()
        {
            if (endAnim != null)
            {
                endAnim.Play(); //Clearing task
            }
            else
            {
                MainPlayer.Tasks.ClearImmediately(); //clearing task
            }
        }
    }
}