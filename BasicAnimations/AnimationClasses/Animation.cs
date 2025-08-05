#nullable enable
using Rage;
using static BasicAnimations.Systems.Helper;
using static BasicAnimations.Systems.Logging;

namespace BasicAnimations.AnimationClasses;

public enum AnimationStage
{
    Start,
    Main,
    End,
    None
}

public class Animation
{
    public string StartDict { get; set; } = string.Empty;
    public string StartName { get; set; } = string.Empty;

    public string MainDict { get; set; } = string.Empty;
    public string MainName { get; set; } = string.Empty;

    public string StopDict { get; set; } = string.Empty;
    public string StopName { get; set; } = string.Empty;

    public bool Looped { get; set; }
    public bool CanMove { get; set; }

    public bool StayInEndFrame { get; set; }
    public int StayInEndFrameTime { get; set; }
    public AnimationStage StayInEndFrameStage { get; set; } = AnimationStage.None;

    public string MenuName { get; set; } = "CustomAnimation";

    public string? Keybind { get; set; } // Optional: user-defined hotkey (e.g. "F5", "NumPad1")

    public Animation()
    {
    }

    public Animation(
        string startDict,
        string startName,
        string mainDict,
        string mainName,
        string stopDict,
        string stopName,
        bool looped,
        bool stayInEndFrame = false,
        int stayInEndFrameTime = 0,
        AnimationStage stayInEndFrameStage = AnimationStage.None,
        bool canMove = false,
        string? menuName = null,
        string? keybind = null
    )
    {
        StartDict = startDict;
        StartName = startName;
        MainDict = mainDict;
        MainName = mainName;
        StopDict = stopDict;
        StopName = stopName;

        Looped = looped;
        CanMove = canMove;

        StayInEndFrame = stayInEndFrame;
        StayInEndFrameTime = stayInEndFrameTime;
        StayInEndFrameStage = stayInEndFrameStage;

        MenuName = (string.IsNullOrWhiteSpace(menuName) ? "CustomAnimation" : menuName) ?? string.Empty;
        Keybind = keybind;
    }

    public void PlayAnimation()
    {
        if (!CheckRequirements())
            return;

        if (IsAnimationActive)
        {
            PlayStopAnimation();
            return;
        }

        PlayStartAnimation();
        PlaySecondaryAnimation();
    }

    private void PlayStopAnimation()
    {
        if (!string.IsNullOrEmpty(StopName) && !string.IsNullOrEmpty(StopDict))
        {
            Logger.Log(LogType.Normal, $"Playing stop animation: {StopName}");
            MainPlayer.Tasks
                .PlayAnimation(new AnimationDictionary(StopDict), StopName, 5f, AnimationFlags.None)
                .WaitForCompletion();
        }
        else
        {
            Logger.Log(LogType.Normal, "Clearing player tasks");
        }

        MainPlayer.Tasks.Clear();
        IsAnimationActive = false;
    }

    private void PlayStartAnimation()
    {
        if (string.IsNullOrEmpty(StartName) || string.IsNullOrEmpty(StartDict))
            return;

        Logger.Log(LogType.Normal, $"Playing start animation: {StartName}");

        var dict = new AnimationDictionary(StartDict);
        var flags = GetAnimationFlags();

        if (StayInEndFrame && StayInEndFrameStage == AnimationStage.Start)
        {
            MainPlayer.Tasks
                .PlayAnimation(dict, StartName, 5f, flags)
                .WaitForStatus(TaskStatus.NoTask, StayInEndFrameTime);
        }
        else if (Looped)
        {
            MainPlayer.Tasks.PlayAnimation(dict, StartName, 5f, flags);
        }
        else
        {
            MainPlayer.Tasks
                .PlayAnimation(dict, StartName, 5f, flags)
                .WaitForCompletion();
        }

        IsAnimationActive = true;
    }

    private void PlaySecondaryAnimation()
    {
        if (!CheckRequirements() || string.IsNullOrEmpty(MainName) || string.IsNullOrEmpty(MainDict))
            return;

        Logger.Log(LogType.Normal, $"Playing main animation: {MainName}");

        var dict = new AnimationDictionary(MainDict);
        var flags = GetAnimationFlags();

        if (StayInEndFrame && StayInEndFrameStage == AnimationStage.Main)
        {
            MainPlayer.Tasks
                .PlayAnimation(dict, MainName, 5f, flags)
                .WaitForStatus(TaskStatus.NoTask, StayInEndFrameTime);
        }
        else
        {
            MainPlayer.Tasks.PlayAnimation(dict, MainName, 5f, flags);
        }

        IsAnimationActive = true;
    }

    private AnimationFlags GetAnimationFlags()
    {
        switch (StayInEndFrame)
        {
            case true when Looped:
                return AnimationFlags.StayInEndFrame | AnimationFlags.Loop;
            case true:
                return AnimationFlags.StayInEndFrame;
        }

        if (CanMove)
            return AnimationFlags.Unknown65536 | AnimationFlags.UpperBodyOnly | AnimationFlags.SecondaryTask |
                   AnimationFlags.Loop;

        return Looped ? AnimationFlags.Loop : AnimationFlags.None;
    }
}