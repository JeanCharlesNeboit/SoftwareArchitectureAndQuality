using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FeatureFactory {
    protected float min;
    protected float max;

    protected float setSocialTrigger() {
        return Random.Range(min, max);
    }
}
