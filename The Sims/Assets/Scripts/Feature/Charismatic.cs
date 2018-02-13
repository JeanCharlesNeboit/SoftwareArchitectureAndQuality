using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charismatic : Feature {
    
    public Charismatic(float socialTrigger) {
        this.SocialTrigger = socialTrigger;
    }

    public override bool NeedSpeaking(float social) {
        return (social <= SocialTrigger);
    }
}
