using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Feature {
    public float SocialTrigger { get; set; }

    public abstract bool NeedSpeaking();
}
