using Rage.Native;
using static BasicAnimations.Systems.Helper;
using static BasicAnimations.Systems.Logging;

namespace BasicAnimations.Animation_Classes
{
    internal class Scenario
    {
        private readonly string _scenarioName;

        internal Scenario(string scenarioName)
        {
            this._scenarioName = scenarioName;
        }

        internal void StartScenario()
        {
            if (IsAnimationActive || !CheckRequirements())
            {
                EndScenario();
                IsAnimationActive = false;
            }

            else if (!IsAnimationActive && CheckRequirements())
            {
                Logger.Log(LogType.Normal, $"Starting Scenario {_scenarioName}");
                NativeFunction.Natives.x142A02425FF02BD9(MainPlayer, _scenarioName, 0, true);
                IsAnimationActive = true;
            }
        }

        private void EndScenario()
        {
            Logger.Log(LogType.Normal, $"Clearing Scenario normally");
            MainPlayer.Tasks.Clear();
        }

        internal void EndScenarioImmediately()
        {
            Logger.Log(LogType.Normal, $"Clearing Scenario Immediately");
            MainPlayer.Tasks.ClearImmediately();
        }
    }
}
