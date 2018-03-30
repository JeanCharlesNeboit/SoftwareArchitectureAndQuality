using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {

    private float _social;
    public float Social
    {
        get
        {
            return _social;
        }
        private set
        {
            _social = value;
            UpdateInfoTextMesh();
        }
    }

    public TextMesh SocialTextMesh;
    public TextMesh TypeTextMesh;

    private Dictionary<string, IAction> actions = new Dictionary<string, IAction>();
    private Feature feature;

    private int nextUpdate = 0;
    private int nextUpdate1 = 0;

    public Human() {
        _social = 100;
    }

    private void SetAction(string name, bool activate)
    {
        IAction action;
        actions.TryGetValue(name, out action);
        if (activate == true)
        {
            action.doAction();
        }
        else
        {
            action.stopAction();
        }
    }

    private bool IsDoing(string name)
    {
        IAction action;
        actions.TryGetValue(name, out action);
        return action.isDoing;
    }

    private void UpdateSocial()
    {
        if (Social > feature.SocialStep)
        {
            Social -= feature.SocialStep;
        }
    }

    private void UpdateInfoTextMesh()
    {
        SocialTextMesh.text = "Social: " + Social.ToString("F1");

        if (Social <= feature.SocialTrigger)
        {
            SocialTextMesh.color = Color.red;
        }
        else
        {
            SocialTextMesh.color = Color.green;
        }
    }

    private void Awake()
    {
        int seed = Mathf.CeilToInt(Random.Range(0, 3));
        switch (seed)
        {
            case 0:
                feature = CharismaticFactory.GetInstance().GetCharismaticFeature();
                break;
            case 1:
                feature = FriendlyFactory.GetInstance().GetFriendlyFeature();
                break;
            case 2:
                feature = ShyFactory.GetInstance().GetShyFeature();
                break;
            default:
                break;
        }
    }

    // Use this for initialization
    void Start () {
        /*locomotionSMB = animator.GetBehaviour<LocomotionSMB>();
        /actions.Add("Walk", new Walk(locomotionSMB));*/
        actions.Add("Run", new Run(gameObject));
        TypeTextMesh.text = feature.Type;
        actions.Add("Speak", new Speak());
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextUpdate)
        {
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateSocial();
        }

        if (Time.time > nextUpdate1)
        {
            nextUpdate1 = Mathf.FloorToInt(Time.time) + 10;

            int nextAction = Random.Range(0, 5);

            if (IsDoing("Speak") == false)
            {
                if (nextAction < 3)
                {

                    //SetAction("Walk", true);
                    SetAction("Run", true);
                }
                else
                {
                    //SetAction("Walk", false);
                    SetAction("Run", false);
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log(other);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.tag == "Player")
        {
            /*if (feature.NeedSpeaking(Social))
            {*/
                SetAction("Run", false);
                SetAction("Speak", true);
            //}
        }
    }
}
