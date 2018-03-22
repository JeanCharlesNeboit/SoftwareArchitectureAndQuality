using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject Human;
    private Vector3 offset = new Vector3(0, 8, 10);
    private int currentHuman = 0;
    private List<GameObject> Humans = new List<GameObject>();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        MoveCamera();
    }

    // Follow
    public void Previous()
    {
        if (currentHuman > 0)
        {
            currentHuman--;
        }
    }

    public void Next()
    {
        if (currentHuman < Humans.Count-1)
        {
            currentHuman++;
        }
    }

    private void MoveCamera()
    {
        /*camera.transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * 10);
        camera.transform.Rotate(new Vector3(Input.GetAxis("VerticalRight"), Input.GetAxis("HorizontalRight"), Input.GetAxis("Lean")) * 1);*/

        if (Humans.Count > 0)
        {
            transform.position = Humans[currentHuman].transform.position + offset;
        }
    }

    // Add
    public void AddHuman()
    {
        Humans.Add(Instantiate(Human));
    }
}
