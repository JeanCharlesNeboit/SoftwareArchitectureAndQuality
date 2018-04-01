using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Sociable {
    Feature Feature { get; }
    float Social { get; set; }
    bool NeedSpeaking();
}
