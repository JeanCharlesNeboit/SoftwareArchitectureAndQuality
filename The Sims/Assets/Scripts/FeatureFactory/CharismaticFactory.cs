using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharismaticFactory : FeatureFactory {
    private static CharismaticFactory instance = null;

    private CharismaticFactory() {
        minSocialTrigger = 80.0f;
        maxSocialTrigger = 90.0f;
        minSocialStep = 0.05f;
        maxSocialStep = 0.1f;
    }

    public static CharismaticFactory GetInstance() {
        if (instance == null) {
            instance = new CharismaticFactory();
        }
        return instance;
    }

    public Charismatic GetCharismaticFeature() {
        return new Charismatic(getSocialTrigger(), getSocialStep());
    }
}
