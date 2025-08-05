#nullable enable
using Rage;
using System;
using System.Linq;
using System.Collections.Generic;
using static BasicAnimations.Systems.Helper;
using static BasicAnimations.Systems.Logging;
using BasicAnimations.CustomAnimations;
using Keys = System.Windows.Forms.Keys;

namespace BasicAnimations.Systems;

internal static class Hotkeys
{
    private static readonly Dictionary<Keys, Action> StaticBindings = new();
    private static readonly Dictionary<Keys, Action> DynamicBindings = new();

    internal static void Initialize()
    {
        RegisterStaticBindings();
        RegisterDynamicBindings();
        Logger.Log(LogType.Normal, "Hotkey system initialized.");
    }

    internal static void HotKeyHandler()
    {
        while (true)
        {
            GameFiber.Yield();

            foreach (var kvp in StaticBindings.Concat(DynamicBindings))
            {
                var key = kvp.Key;
                var action = kvp.Value;

                if (Game.IsKeyDown(key) && CheckModKey() && CheckRequirements())
                {
                    action();
                }
            }
        }
        // ReSharper disable once FunctionNeverReturns
    }

    private static void RegisterStaticBindings()
    {
        StaticBindings[Settings.Sit] = () => Animations.Sit.PlayAnimation();
        StaticBindings[Settings.Kneel] = () => Animations.Kneeling.StartScenario();
        StaticBindings[Settings.Lean] = () => Animations.Lean.StartScenario();
        StaticBindings[Settings.HandsOnBeltKey] = () => Animations.GrabBelt.PlayAnimation();
        StaticBindings[Settings.GrabVest] = () => Animations.GrabVest.PlayAnimation();
        StaticBindings[Settings.Suicide] = Animations.Suicide;
        StaticBindings[Settings.Pushups] = () => Animations.Pushup.PlayAnimation();
        StaticBindings[Settings.Situps] = () => Animations.Situp.PlayAnimation();
        StaticBindings[Settings.Salute] = () => Animations.Salute.PlayAnimation();
        StaticBindings[Settings.Smoking] = () => Animations.Smoking.StartScenario();
        StaticBindings[Settings.Box] = Animations.CarryBox;
        StaticBindings[Settings.Mocking] = () => Animations.Mocking.PlayAnimation();
        StaticBindings[Settings.Camera] = () => Animations.Camera.StartScenario();
        StaticBindings[Settings.Yoga] = () => Animations.Yoga.StartScenario();
        StaticBindings[Settings.Binoculars] = () => Animations.Binoculars.StartScenario();
        StaticBindings[Settings.Investigate] = () => Animations.Investigate.StartScenario();
    }

    private static void RegisterDynamicBindings()
    {
        if (CustomAnimationsLoader.LoadedData == null)
            return;

        foreach (var anim in CustomAnimationsLoader.LoadedData.Animations)
        {
            if (TryParseKey(anim.Keybind, out var key))
            {
                DynamicBindings[key] = () => anim.PlayAnimation();
            }
        }

        foreach (var scenario in CustomAnimationsLoader.LoadedData.Scenarios)
        {
            if (TryParseKey(scenario.Keybind, out var key))
            {
                DynamicBindings[key] = () => scenario.StartScenario();
            }
        }
    }

    private static bool TryParseKey(string? keybind, out Keys key)
    {
        if (!string.IsNullOrWhiteSpace(keybind) && Enum.TryParse(keybind, true, out key))
            return true;

        key = Keys.None;
        return false;
    }
}
