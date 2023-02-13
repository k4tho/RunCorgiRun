using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillPlacer : RandomObjectPlacer
{
    public void Start()
    {
        minimumTimeToCreate = GameParameters.PillMinimumSecondsUntilCreation;
        maximumTimeToCreate = GameParameters.PillMaximumSecondsUntilCreation;
    }
}
