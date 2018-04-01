using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charismatic : Feature {
    
    public Charismatic(float socialTrigger, float socialStep) {
        this.SocialTrigger = socialTrigger;
        this.SocialStep = socialStep;
    }

    public override string Type
    {
        get
        {
            return "Charismatic";
        }
    }

    public override bool NeedSpeaking(float social) {
        return (social <= SocialTrigger);
    }
}
