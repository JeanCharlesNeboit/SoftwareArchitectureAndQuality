using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour, Observer
{
    public GameObject GameObjectToFollow { get; private set; }
    private Vector3 offset = new Vector3(0, 0.8f, 2);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    public void Move()
    {
        //transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * 1);
        //transform.Rotate(new Vector3(Input.GetAxis("VerticalRotate"), 0/*Input.GetAxis("HorizontalRotate")*/, 0) * 1);

        offset += new Vector3(0, Input.GetAxis("Vertical") * 0.5f, Input.GetAxis("Mouse ScrollWheel"));

        if (GameObjectToFollow)
        {
            transform.position = GameObjectToFollow.transform.position + offset;
        }
    }

    // Observer interface
    public void update(Observable observable)
    {
        if (observable is Main)
        {
            Main main = (Main)observable;
            GameObjectToFollow = main.GetCurrentHuman();
        }
    }
}
