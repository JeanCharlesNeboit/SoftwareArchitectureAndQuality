using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FeatureFactory {
    protected float minSocialTrigger;
    protected float maxSocialTrigger;
    protected float minSocialStep;
    protected float maxSocialStep;

    protected float getSocialTrigger() {
        return Random.Range(minSocialTrigger, maxSocialTrigger);
    }

    protected float getSocialStep()
    {
        return Random.Range(minSocialStep, maxSocialStep);
    }
}
