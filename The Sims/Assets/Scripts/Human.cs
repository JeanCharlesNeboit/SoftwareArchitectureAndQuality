using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {

    public float Social { get; set; }
    public TextMesh infoTextMesh;
    public TextMesh typeTextMesh;

    private Dictionary<string, IAction> actions = new Dictionary<string, IAction>();
    private Feature feature;
    private Animator animator;
    private LocomotionSMB locomotionSMB;

    private int nextUpdate = 0;
    private int nextUpdate1 = 0;

    public Human() {
        Social = 100;
    }

    public LocomotionSMB GetLocomotion()
    {
        return locomotionSMB;
    }

    private void UpdateSocial()
    {
        Social -= feature.SocialStep;
        infoTextMesh.text = "My Social: " + Social.ToString("F1");

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
            nextUpdate1 = Mathf.FloorToInt(Time.time) + 4;

            IAction walk;
            actions.TryGetValue("Walk", out walk);
            walk.doAction();
        }
    }
}
