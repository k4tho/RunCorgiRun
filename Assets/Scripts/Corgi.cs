using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    public SpriteRenderer CorgiSpriteRenderer;
    public Sprite SoberSprite;
    public Sprite DrunkSprite;

    private bool isDrunk = false;
    private bool isPlastered = false;
    private int randomMoveCountdown = 0;
    private int lastRandomDirection = 0;
    private bool isPlaying = false;

    void Update()
    {
        if (HasGameJustEnded())
            Reset();
        if (isPlastered)
            MoveRandomly();
    }

    public void StartGame()
    {
        isPlaying = true;
    }

    private void Reset()
    {
        isPlaying = false;
        isDrunk = false;
        isPlastered = false;
        ChangeToSoberSprite();
        ResetPosition();
        DestroyAllPoop();
    }

    private void DestroyAllPoop()
    {
        foreach (GameObject poopObject in GameObject.FindGameObjectsWithTag("Poop"))
        {
            Destroy(poopObject);
        }
    }

    private void ResetPosition()
    {
        CorgiSpriteRenderer.transform.position = new Vector3(0f, 0f, 0f);
        CorgiSpriteRenderer.flipX = false;
    }

    private bool HasGameJustEnded()
    {
        if (!Game.IsRunning() && isPlaying)
        {
            return true;
        }
        return false;
    }

    private void MoveRandomly()
    {
        int direction = lastRandomDirection;

        if (randomMoveCountdown == 0)
        {
            direction = UnityEngine.Random.Range(1, 5);
            randomMoveCountdown = UnityEngine.Random.Range(10, 30);
            lastRandomDirection = direction;
        }

        switch (direction)
        {
            case 1:
                Move(new Vector2(1, 0));
                break;
            case 2:
                Move(new Vector2(-1, 0));
                break;
            case 3:
                Move(new Vector2(0, 1));
                break;
            case 4:
                Move(new Vector2(0, -1));
                break;
        }

        randomMoveCountdown -= 1;
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Beer")
        {
            GetDrunk();
        }
        else if (col.gameObject.tag == "Pill")
        {
            SoberUp();
        }
        else if (col.gameObject.tag == "Bone")
        {
            ScoreKeeper.Add(1);
        }
        else if (col.gameObject.tag == "Moonshine")
        {
            GetPlastered();
        }
        else if (col.gameObject.tag == "Poop")
        {
            return;
        }

        Destroy(col.gameObject);
    }

    private void GetPlastered()
    {
        isPlastered = true;
        Inebriate();
    }

    private void Inebriate()
    {
        ChangeToDrunkSprite();
        StartCoroutine(waitToSoberUp());
    }

    private Vector2 ApplyDrunkeness(Vector2 direction)
    {
        if (isDrunk)
        {
            direction.x = direction.x * -1;
            direction.y = direction.y * -1;
        }
        return direction;
    }

    private void GetDrunk()
    {
        isDrunk = true;
        Inebriate();
    }

    private void SoberUp()
    {
        ChangeToSoberSprite();
        isDrunk = false;
        isPlastered = false;
    }

    IEnumerator waitToSoberUp()
    {
        yield return new WaitForSeconds(GameParameters.SecondsDrunk);
        SoberUp();
    }

    private void ChangeToDrunkSprite()
    {
        CorgiSpriteRenderer.sprite = DrunkSprite;
    }

    private void ChangeToSoberSprite()
    {
        CorgiSpriteRenderer.sprite = SoberSprite;
    }

    public void MoveManually(Vector2 direction)
    {
        if (isPlastered)
            return;

        Move(direction);
    }

    public void Move(Vector2 direction)
    {
        direction = ApplyDrunkeness(direction);

        FaceCorrectDirection(direction);
        CorgiSpriteRenderer.transform.Translate(new Vector3(direction.x * GameParameters.corgiMoveAmount, direction.y * GameParameters.corgiMoveAmount, 0f));
        KeepOnScreen();
    }

    private void KeepOnScreen()
    {
        CorgiSpriteRenderer.transform.position = SpriteTools.ConstrainToScreen(CorgiSpriteRenderer);
    }

    private void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x > 0)
            CorgiSpriteRenderer.flipX = false;
        else
            CorgiSpriteRenderer.flipX = true;    
    }
}
