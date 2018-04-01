using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friendly : Feature {

    public Friendly(float socialTrigger, float socialStep)
    {
        this.SocialTrigger = socialTrigger;
        this.SocialStep = socialStep;
    }

    public override string Type
    {
        get
        {
            return "Friendly";
        }
    }

    public override bool NeedSpeaking(float social) {
        return (social <= SocialTrigger);
    }
}
