using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Run : IAction
{
    private NavMeshAgent agent;

    public Run(GameObject gameObject) {
        isDoing = false;
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    public bool isDoing { get; private set; }

    public void doAction()
    {
        isDoing = true;
        //Vector3 position = Main.GetRandomPositionInMainScene();
        Vector3 position = Main.GetRandomPositionInNavMesh(agent);
        agent.destination = position;
    }

    public void stopAction()
    {
        isDoing = false;
        agent.destination = agent.transform.position;
    }
}
