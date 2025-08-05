using System.Xml.Serialization;
using Rage.Native;
using static BasicAnimations.Systems.Helper;
using static BasicAnimations.Systems.Logging;

namespace BasicAnimations.AnimationClasses;

public class Scenario
{
    [XmlAttribute("ScenarioName")] public string ScenarioName { get; set; } = string.Empty;

    [XmlText] public string MenuName { get; set; } = "CustomScenario";

    public Scenario()
    {
    }

    public Scenario(string scenarioName, string? menuName = null)
    {
        ScenarioName = scenarioName;
        if (!string.IsNullOrWhiteSpace(menuName))
            MenuName = menuName;
    }

    internal void StartScenario()
    {
        if (!CheckRequirements())
        {
            Logger.Log(LogType.Warning, $"Scenario '{ScenarioName}' cannot start — failed requirements.");
            EndScenario();
            IsAnimationActive = false;
            return;
        }

        if (IsAnimationActive)
        {
            Logger.Log(LogType.Normal, $"Scenario '{ScenarioName}' already active. Ending current one first.");
            EndScenario();
            IsAnimationActive = false;
        }

        Logger.Log(LogType.Normal, $"Starting Scenario: {ScenarioName}");
        NativeFunction.Natives.x142A02425FF02BD9(MainPlayer, ScenarioName, 0, true);
        IsAnimationActive = true;
    }

    internal void EndScenario()
    {
        Logger.Log(LogType.Normal, $"Clearing Scenario '{ScenarioName}' normally.");
        MainPlayer.Tasks.Clear();
        IsAnimationActive = false;
    }

    internal void EndScenarioImmediately()
    {
        Logger.Log(LogType.Normal, $"Force-clearing Scenario '{ScenarioName}' immediately.");
        MainPlayer.Tasks.ClearImmediately();
        IsAnimationActive = false;
    }
}