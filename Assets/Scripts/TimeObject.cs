using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeObject : MonoBehaviour
{
    public int secondsOnScreen = 2;

    public virtual void Start()
    {
        StartCoroutine(CountdownTilDeath());
    }

    IEnumerator CountdownTilDeath()
    {
        yield return new WaitForSeconds(secondsOnScreen);
        Destroy(gameObject);
    }
}
