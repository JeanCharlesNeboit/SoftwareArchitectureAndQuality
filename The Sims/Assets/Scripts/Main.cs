using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental;
using UnityEngine.UI;

[RequireComponent(typeof(CameraMove))]
public class Main : MonoBehaviour, Observable
{
    public GameObject Human;
    public int CurrentFollowHuman { get; private set; }

    public Button PreviousButton;
    public Button NextButton;

    private CameraMove cameraMove;
    private List<GameObject> humans = new List<GameObject>();
    private List<Observer> observers = new List<Observer>();

	// Use this for initialization
	void Start ()
    {
        CurrentFollowHuman = 0;
        CameraMove cameraMove = (CameraMove)GetComponent("CameraMove");
        attach(cameraMove);
        UpdateUI();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    /*
     * Terrain
     */
    public static Vector3 GetRandomPositionInMainScene()
    {
        Terrain terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
        float minX = terrain.transform.position.x;
        float maxX = minX + terrain.terrainData.size.x;
        float x = Random.Range(minX, minX + maxX);

        float minZ = terrain.transform.position.z;
        float maxZ = minZ + terrain.terrainData.size.z;
        float z = Random.Range(minZ, minZ + maxZ);

        Vector3 position = new Vector3(x, 0, z);
        return position;
    }

    /* 
     * User Interface
     */
    public void Previous()
    {
        CurrentFollowHuman = (CurrentFollowHuman > 0) ? CurrentFollowHuman-- : humans.Count - 1;
    }

    public void Next()
    {
        CurrentFollowHuman = (CurrentFollowHuman < humans.Count - 1) ? CurrentFollowHuman++ : 0;
    }

    public void Add()
    {
        Vector3 position = Main.GetRandomPositionInMainScene();
        humans.Add(Instantiate(Human, position, Quaternion.identity));

        UpdateUI();
    }

    public void Remove()
    {
        humans.RemoveAt(CurrentFollowHuman);
        Next();
        UpdateUI();
    }

    private void UpdateUI()
    {
        PreviousButton.enabled = (humans.Count > 1);
        NextButton.enabled = (humans.Count > 1);
    }

    /*
     * Observable interface
     */
    public void attach(Observer observer)
    {
        observers.Add(observer);
    }

    public void dettach(Observer observer)
    {
        observers.Remove(observer);
    }

    public void notify()
    {
        foreach(Observer observer in observers)
        {
            observer.update(this);
        }
    }
}
