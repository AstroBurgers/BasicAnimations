using Rage;
using Rage.Native;
using static BasicAnimations.EntryPoint;

namespace BasicAnimations
{
    internal class Scenario : Action
    {
        internal Ped Ped;
        internal string ScenarioName;
        internal int delay;
        internal bool playEnterAnim;

        internal Scenario(Ped Ped, string ScenarioName, int delay, bool playEnterAnim, string MenuName, string MenuDescription) :base(MenuName, MenuDescription)
        {
            this.Ped = Ped;
            this.ScenarioName = ScenarioName;
            this.delay = delay;
            this.playEnterAnim = playEnterAnim;
        }

       
        override internal void Play()
        {
            NativeFunction.Natives.x142A02425FF02BD9(Ped, ScenarioName, delay, playEnterAnim); 
        }
        
        override internal void PlayEndAnimation()
        {
                MainPlayer.Tasks.ClearImmediately(); //clearing task
        }
    }
}