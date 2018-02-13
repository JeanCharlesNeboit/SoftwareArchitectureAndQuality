using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyFactory : FeatureFactory {
    private static FriendlyFactory instance = null;

    private FriendlyFactory() {
        min = 70.0f;
        max = 80.0f;
    }

    public static FriendlyFactory GetInstance() {
        if (instance == null) {
            instance = new FriendlyFactory();
        }
        return instance;
    }

    public Friendly GetFriendlyFeature() {
        return new Friendly(setSocialTrigger());
    }
}
