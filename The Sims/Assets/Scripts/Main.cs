using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject Human;
    public Terrain Terrain;

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
        float minX = Terrain.transform.position.x;
        float maxX = minX + Terrain.terrainData.size.x;
        float x = Random.Range(minX, minX + maxX);

        float minZ = Terrain.transform.position.z;
        float maxZ = minZ + Terrain.terrainData.size.z;
        float z = Random.Range(minZ, minZ + maxZ);

        Vector3 position = new Vector3(x,0,z);
        Humans.Add(Instantiate(Human, position, Quaternion.identity));
    }
}
