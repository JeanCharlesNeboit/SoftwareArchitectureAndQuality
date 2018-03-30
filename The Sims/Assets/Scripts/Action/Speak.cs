using UnityEngine;
using System.Collections;

public class Speak : IAction
{
    public Speak() {
        isDoing = false;
    }

    public bool isDoing { get; private set; }

    public void doAction()
    {
        isDoing = true;
    }

    public void stopAction()
    {
        isDoing = false;
    }
}
