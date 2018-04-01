using UnityEngine;
using System.Collections;

public class Speak : IAction
{
    private Sociable sociable;

    public Speak(Sociable sociable) {
        this.sociable = sociable;
        isDoing = false;
    }

    public bool isDoing { get; private set; }

    public void doAction()
    {
        isDoing = true;

        sociable.Social += sociable.Feature.SocialStep;
        if (sociable.Social >= 100)
        {
            sociable.Social = 100;
            isDoing = false;
        }
    }

    public void stopAction()
    {
        isDoing = false;
    }
}
