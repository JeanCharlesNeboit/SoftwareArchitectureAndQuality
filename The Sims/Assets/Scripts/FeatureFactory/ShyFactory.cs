using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShyFactory : FeatureFactory {
    private static ShyFactory instance = null;

    private ShyFactory() {
        min = 60.0f;
        max = 70.0f;
    }

    public static ShyFactory GetInstance() {
        if (instance == null) {
            instance = new ShyFactory();
        }
        return instance;
    }

    public Shy GetShyFeature() {
        return new Shy(setSocialTrigger());
    }
}
