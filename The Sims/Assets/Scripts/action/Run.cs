using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : IAction {

    public Run() {
        isDoing = false;
    }

    public bool isDoing { get; private set; }

    public void doAction()
    {

    }

    public void stopAction()
    {

    }
}
