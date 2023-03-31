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

        override internal void Play(){ }
    }
}