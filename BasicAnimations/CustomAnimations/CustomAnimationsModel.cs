using System.Collections.Generic;
using BasicAnimations.AnimationClasses;

namespace BasicAnimations.CustomAnimations;

public class CustomAnimationsModel
{
    public List<Animation> Animations { get; set; } = new();
    public List<Scenario> Scenarios { get; set; } = new();
}