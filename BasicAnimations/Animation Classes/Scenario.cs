using Rage.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BasicAnimations.Systems.Helper;
using static BasicAnimations.Systems.Logging;

namespace BasicAnimations.Animation_Classes
{
    internal class Scenario
    {
        string scenarioName;

        internal Scenario(string scenarioName)
        {
            this.scenarioName = scenarioName;
        }

        internal void StartScenario()
        {
            if (IsAnimationActive || !CheckRequirements())
            {
                return;
            }

            Logger.Log(LogType.Normal, $"Starting Scenario {scenarioName}");

            NativeFunction.Natives.x142A02425FF02BD9(MainPlayer, scenarioName, 0, true);
        }

        internal void EndScenario()
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
