using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Observable {
    void attach(Observer observer);
    void dettach(Observer observer);
    void notify();
}
