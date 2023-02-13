using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerPlacer : RandomObjectPlacer
{
    public void Start()
    {
        minimumTimeToCreate = GameParameters.BeerMinimumSecondsUntilCreation;
        maximumTimeToCreate = GameParameters.BeerMaximumSecondsUntilCreation;
    }
}
