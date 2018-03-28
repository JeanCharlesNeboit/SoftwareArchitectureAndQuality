using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour, Observer
{
    public GameObject GameObjectToFollow { get; private set; }
    private Vector3 offset = new Vector3(0, 8, 10);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    public void Move()
    {
        /*camera.transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * 10);
        camera.transform.Rotate(new Vector3(Input.GetAxis("VerticalRight"), Input.GetAxis("HorizontalRight"), Input.GetAxis("Lean")) * 1);*/

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
            Debug.Log(main.CurrentFollowHuman);
        }
    }
}
