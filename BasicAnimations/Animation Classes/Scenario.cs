using System.Xml.Serialization;
using Rage.Native;
using static BasicAnimations.Systems.Helper;
using static BasicAnimations.Systems.Logging;

namespace BasicAnimations.Animation_Classes
{
    public class Scenario
    {
        [XmlAttribute("Scenario")]
        public string ScenarioName;

        public Scenario(string scenarioName)
        {
            this.ScenarioName = scenarioName;
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
                Logger.Log(LogType.Normal, $"Starting Scenario {ScenarioName}");
                NativeFunction.Natives.x142A02425FF02BD9(MainPlayer, ScenarioName, 0, true);
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
