using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental;
using UnityEngine.UI;

[RequireComponent(typeof(CameraMove))]
public class Main : MonoBehaviour, Observable
{
    public GameObject Human;
    public Text Information;
    public Button PreviousButton;
    public Button NextButton;

    private CameraMove cameraMove;
    private int CurrentFollowHuman { get; set; }
    private List<GameObject> humans = new List<GameObject>();
    private List<Observer> observers = new List<Observer>();

	// Use this for initialization
	void Start ()
    {
        CurrentFollowHuman = -1;
        CameraMove cameraMove = (CameraMove)GetComponent("CameraMove");
        attach(cameraMove);
        UpdateUI();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (CurrentFollowHuman != -1)
        {
            Human human = humans[CurrentFollowHuman].GetComponent<Human>();
            
            Information.text = "Type : " + human.Feature;
            string color = (human.Social > human.Feature.SocialTrigger) ? "green" : "red";
            Information.text += ", Social : " + "<color=" + color + ">" + human.Social.ToString("F1") + "</color>";
            Information.text += ", SocialTrigger : " + human.Feature.SocialTrigger.ToString("F1");

            if (human.IsDoing("Speak"))
            {
                Information.text += ", <color=blue>is speaking</color>";
            }
        }
    }

    public GameObject GetCurrentHuman()
    {
        return humans[CurrentFollowHuman];
    } 

    public GameObject GetClosestHuman(Vector3 position)
    {
        GameObject closest = null;
        float distance = Mathf.Infinity;

        foreach(GameObject go in humans)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
            }
        }

        return closest;
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

    public static Vector3 GetRandomPositionInNavMesh(NavMeshAgent agent)
    {
        Vector3 randomDirection = Random.insideUnitSphere * 100;
        randomDirection += agent.transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 100, 1);
        Vector3 finalPosition = hit.position;
        return finalPosition;
    }

    /* 
     * User Interface
     */
    public void Previous()
    {
        CurrentFollowHuman = (CurrentFollowHuman > 0) ? CurrentFollowHuman - 1 : humans.Count - 1;
        notify();
    }

    public void Next()
    {
        CurrentFollowHuman = (CurrentFollowHuman < humans.Count - 1) ? CurrentFollowHuman + 1 : 0;
        notify();
    }

    public void Add()
    {
        Vector3 position = Main.GetRandomPositionInMainScene();
        humans.Add(Instantiate(Human, position, Quaternion.identity));
        UpdateUI();
        if (CurrentFollowHuman == -1)
        {
            CurrentFollowHuman = 0;
            notify();
        }
    }

    public void Remove()
    {
        GameObject.Destroy(humans[CurrentFollowHuman]);
        humans.RemoveAt(CurrentFollowHuman);
        Next();
        UpdateUI();
    }

    private void UpdateUI()
    {
        PreviousButton.interactable = (humans.Count > 1);
        NextButton.interactable = (humans.Count > 1);
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
