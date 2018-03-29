using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Run : IAction
{
    RaycastHit hitInfo = new RaycastHit();
    private NavMeshAgent agent;

    public Run(GameObject gameObject) {
        isDoing = false;
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    public bool isDoing { get; private set; }

    public void doAction()
    {
        Vector3 position = Main.GetRandomPositionInMainScene();
        agent.destination = position;
    }

    public void stopAction()
    {
        agent.destination = agent.transform.position;
    }
}
