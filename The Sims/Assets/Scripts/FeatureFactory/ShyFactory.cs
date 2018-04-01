using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShyFactory : FeatureFactory {
    private static ShyFactory instance = null;

    private ShyFactory() {
        minSocialTrigger = 60.0f;
        maxSocialTrigger = 70.0f;
        minSocialStep = 0.05f;
        maxSocialStep = 0.1f;
    }

    public static ShyFactory GetInstance() {
        if (instance == null) {
            instance = new ShyFactory();
        }
        return instance;
    }

    public Shy GetShyFeature() {
        return new Shy(getSocialTrigger(), getSocialStep());
    }
}
