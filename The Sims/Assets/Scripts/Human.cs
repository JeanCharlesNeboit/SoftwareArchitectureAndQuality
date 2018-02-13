using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {

    public float Social { get; set; }
    private IAction actions;
    private Feature feature;

    private Animator animator;
    private LocomotionSMB behaviour;

    public Human() {
        Social = 100;
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
        behaviour = animator.GetBehaviour<LocomotionSMB>();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
