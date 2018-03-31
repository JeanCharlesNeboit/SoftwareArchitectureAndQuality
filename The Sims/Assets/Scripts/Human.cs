using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour, Sociable {

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

    public TextMesh SocialTextMesh;
    public TextMesh TypeTextMesh;

    private Dictionary<string, IAction> actions = new Dictionary<string, IAction>();
    public Feature Feature { get; private set; }

    private int nextUpdateSocial = 0;
    private int nextUpdateMove = 0;

    public Human() {
        _social = 100;
    }

    /*
     * Action
     */
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

    public bool IsDoing(string name)
    {
        IAction action;
        actions.TryGetValue(name, out action);
        return (action != null) ? action.isDoing : false;
    }

    private void UpdateSocial()
    {
        if (IsDoing("Speak") == false && Social > Feature.SocialStep)
        {
            Social -= Feature.SocialStep;
        }
        else {
            SetAction("Speak", true);
        }
    }

    private void UpdateInfoTextMesh()
    {
        SocialTextMesh.text = "Social: " + Social.ToString("F1");

        if (NeedSpeaking())
        {
            SocialTextMesh.color = Color.red;
        }
        else
        {
            SocialTextMesh.color = Color.green;
        }
    }

    public bool NeedSpeaking()
    {
        return Feature.NeedSpeaking(Social);
    }

    /*
     * GameObject
     */
    private void Awake()
    {
        int seed = Mathf.CeilToInt(Random.Range(0, 3));
        switch (seed)
        {
            case 0:
                Feature = CharismaticFactory.GetInstance().GetCharismaticFeature();
                break;
            case 1:
                Feature = FriendlyFactory.GetInstance().GetFriendlyFeature();
                break;
            case 2:
                Feature = ShyFactory.GetInstance().GetShyFeature();
                break;
            default:
                break;
        }
    }

    void Start () {
        /*locomotionSMB = animator.GetBehaviour<LocomotionSMB>();
        actions.Add("Walk", new Walk(locomotionSMB));*/
        actions.Add("Run", new Run(gameObject));
        TypeTextMesh.text = Feature.Type;
        actions.Add("Speak", new Speak(this));
	}

	void Update () {
        if (Time.time > nextUpdateSocial)
        {
            nextUpdateSocial = Mathf.FloorToInt(Time.time) + 1;
            UpdateSocial();
        }

        if (Time.time > nextUpdateMove)
        {
            nextUpdateMove = Mathf.FloorToInt(Time.time) + 10;

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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Human otherHuman = other.GetComponent<Human>();
            if (NeedSpeaking() || otherHuman.NeedSpeaking())
            {
                SetAction("Run", false);
                SetAction("Speak", true);
            }
        }
    }
}
