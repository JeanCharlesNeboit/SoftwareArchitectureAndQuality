using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : IAction {

    private LocomotionSMB locomotionSMB;

    public Walk(LocomotionSMB l) {
        locomotionSMB = l;
    }

    public void doAction() {  
        float horizontal = Random.Range(Mathf.Max(locomotionSMB.horizontal - 0.5f, -1), Mathf.Min(locomotionSMB.horizontal + 0.5f, 1));
        float vertical = Random.Range(Mathf.Max(locomotionSMB.vertical - 0.5f, -1), Mathf.Min(locomotionSMB.vertical + 0.5f, 1));
        locomotionSMB.horizontal = horizontal;
        locomotionSMB.vertical = vertical;
    }

    public void stopAction()
    {
        locomotionSMB.horizontal = 0;
        locomotionSMB.vertical = 0;
    }
}
