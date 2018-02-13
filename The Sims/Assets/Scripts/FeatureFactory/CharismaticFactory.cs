using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharismaticFactory : FeatureFactory {
    private static CharismaticFactory instance = null;

    private CharismaticFactory() {
        min = 80.0f;
        max = 90.0f;
    }

    public static CharismaticFactory GetInstance() {
        if (instance == null) {
            instance = new CharismaticFactory();
        }
        return instance;
    }

    public Charismatic GetCharismaticFeature() {
        return new Charismatic(setSocialTrigger());
    }
}
