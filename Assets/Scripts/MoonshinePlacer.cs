using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonshinePlacer : RandomObjectPlacer
{
    public void Start()
    {
        minimumTimeToCreate = GameParameters.MoonshineMinimumSecondsUntilCreation;
        maximumTimeToCreate = GameParameters.MoonshineMaximumSecondsUntilCreation;
    }

    protected override void Place()
    {
        Vector3 location = SpriteTools.RandomTopOfScreenWorldLocation();
        Instantiate(ObjectPrefab, location, Quaternion.identity);
    }
}
