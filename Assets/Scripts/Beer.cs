using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : TimeObject
{
    public override void Start()
    {
        secondsOnScreen = GameParameters.BeerSecondsOnScreen;
        base.Start();               //starts the other start function in TimeObject
    }
}
