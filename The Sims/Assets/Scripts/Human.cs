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
        set
        {
            _social = value;
            UpdateInfoTextMesh();
        }
    }

    public TextMesh infoTextMesh;
    public TextMesh typeTextMesh;

    private Dictionary<string, IAction> actions = new Dictionary<string, IAction>();
    private Feature feature;
    private Animator animator;
    private LocomotionSMB locomotionSMB;

    private int nextUpdate = 0;
    private int nextUpdate1 = 0;

    public Human() {
        _social = 100;
    }

    public LocomotionSMB GetLocomotion()
    {
        return locomotionSMB;
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
        infoTextMesh.text = "Social: " + Social.ToString("F1");

        if (Social <= feature.SocialTrigger)
        {
            infoTextMesh.color = Color.red;
        }
        else
        {
            infoTextMesh.color = Color.green;
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
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
        locomotionSMB = animator.GetBehaviour<LocomotionSMB>();
        actions.Add("Walk", new Walk(locomotionSMB));
        typeTextMesh.text = feature.Type;
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

            if (nextAction < 3)
            {
                if (IsDoing("Speak") == false)
                {
                    SetAction("Walk", true);
                }
            }
            else
            {
                SetAction("Walk", false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.tag == "Player")
        {
            if (feature.NeedSpeaking(Social))
            {
                SetAction("Walk", false);
                SetAction("Speak", true);
            }
        }
    }
}
