using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : TimeObject
{
    public override void Start()
    {
        secondsOnScreen = GameParameters.PoopSecondsOnScreen;
        base.Start();               //start the other start function
    }
}
