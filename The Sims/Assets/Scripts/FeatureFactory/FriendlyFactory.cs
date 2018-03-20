using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyFactory : FeatureFactory {
    private static FriendlyFactory instance = null;

    private FriendlyFactory() {
        minSocialTrigger = 70.0f;
        maxSocialTrigger = 80.0f;
        minSocialStep = 0.1f;
        maxSocialStep = 0.2f;
    }

    public static FriendlyFactory GetInstance() {
        if (instance == null) {
            instance = new FriendlyFactory();
        }
        return instance;
    }

    public Friendly GetFriendlyFeature() {
        return new Friendly(getSocialTrigger(), getSocialStep());
    }
}
