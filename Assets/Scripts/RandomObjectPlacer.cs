using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectPlacer : MonoBehaviour
{
    public GameObject ObjectPrefab;

    private bool isOkayToStartTimer = true;
    private int secondsUntilCreation =3;

    protected int minimumTimeToCreate = 1;
    protected int maximumTimeToCreate = 3;

    private bool isStillPlaying = false;
    private Coroutine TimerCoroutine;

    void Update()
    {
        if (IsPlaying())
        {
            if (isOkayToStartTimer)
            {
                isOkayToStartTimer = false;
                TimerCoroutine = StartCoroutine(CountDownUntilCreation());
            }
        }
    }

    private bool IsPlaying()
    {
        if (Game.IsRunning())
        {
            return true;
        }
        else
        {
            Reset();
            return false;
        }
    }

    private void Reset()
    {
        isStillPlaying = false;
        isOkayToStartTimer = true;
        DeleteAllObjects();
        if (TimerCoroutine != null)
            StopCoroutine(TimerCoroutine);
    }

    private void DeleteAllObjects()
    {
        foreach (GameObject placedObject in GameObject.FindGameObjectsWithTag(ObjectPrefab.tag))
        {
            Destroy(placedObject);
        }
    }

    IEnumerator CountDownUntilCreation()
    {
        secondsUntilCreation = Random.Range(minimumTimeToCreate, maximumTimeToCreate + 1);
        yield return new WaitForSeconds(secondsUntilCreation);
        Place();
        isOkayToStartTimer = true;
    }

    protected virtual void Place()
    {
        Vector3 location = SpriteTools.RandomWorldLocation();
        Instantiate(ObjectPrefab, location, Quaternion.identity);
    }
}
