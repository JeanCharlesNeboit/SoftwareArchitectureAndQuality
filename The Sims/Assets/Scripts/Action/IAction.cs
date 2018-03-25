using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction {
    bool isDoing { get; }
    void doAction();
    void stopAction();
}
