using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {

    public float Social { get; set; }
    private IMotion motion;

    public 

	// Use this for initialization
	void Start () {
        Social = 100;
        motion = new Walk();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
