using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Run : IAction
{
    private GameObject go;
    private NavMeshAgent agent;
    private Human human;

    public Run(GameObject gameObject) {
        isDoing = false;
        go = gameObject;
        agent = gameObject.GetComponent<NavMeshAgent>();
        human = gameObject.GetComponent<Human>();
    }

    public bool isDoing { get; private set; }

    public void doAction()
    {
        isDoing = true;
        //Vector3 position = Main.GetRandomPositionInMainScene();
        Vector3 position = Vector3.zero;
        if (human != null && human.NeedSpeaking())
        {
            Debug.Log("Looking");
            position = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Main>().GetClosestHuman(human.transform.position).transform.position;
        }
        else
        {
            position = Main.GetRandomPositionInNavMesh(agent);
        }
        agent.destination = position;
    }

    public void stopAction()
    {
        isDoing = false;
        agent.destination = agent.transform.position;
    }
}
