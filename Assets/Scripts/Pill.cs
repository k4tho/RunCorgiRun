using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : TimeObject
{
    public override void Start()
    {
        secondsOnScreen = GameParameters.PillSecondsOnScreen;
        base.Start();               //start the other start function
    }
}
