using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : TimeObject
{
    public override void Start()
    {
        secondsOnScreen = GameParameters.BoneSecondsOnScreen;
        base.Start();               //start the other start function
    }
}
