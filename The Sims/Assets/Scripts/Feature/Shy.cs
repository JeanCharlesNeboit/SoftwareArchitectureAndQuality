using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shy : Feature {

    public Shy(float socialTrigger, float socialStep)
    {
        this.SocialTrigger = socialTrigger;
        this.SocialStep = socialStep;
    }

    public override string Type
    {
        get
        {
            return "Shy";
        }
    }

    public override bool NeedSpeaking(float social) {
        return (social <= SocialTrigger);
    }
}
