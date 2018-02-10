using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMotion {
    public bool IsMove { get; set; }

    public IMotion()
    {
        IsMove = false;
    }

    public abstract void Move(GameObject gameObject);
}
