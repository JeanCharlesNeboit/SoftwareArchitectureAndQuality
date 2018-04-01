using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Feature {
    public float SocialTrigger { get; set; }
    public float SocialStep { get; set; }

    public abstract string Type { get; }
    public abstract bool NeedSpeaking(float social);
}
