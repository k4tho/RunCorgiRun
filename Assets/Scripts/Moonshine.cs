using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonshine : TimeObject
{
    public override void Start()
    {
        secondsOnScreen = GameParameters.MoonshineSecondsOnScreen;
        base.Start();               //start the other start function
    }
}
