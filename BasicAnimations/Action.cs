namespace BasicAnimations
{
    abstract internal class Action
    {
        internal string MenuName;
        internal string MenuDescription;

        internal Action(string MenuName, string MenuDescription)
        {
            this.MenuDescription = MenuDescription;
            this.MenuName = MenuName;
        }

        abstract internal void Play();
        abstract internal void PlayEndAnimation();
    }
}