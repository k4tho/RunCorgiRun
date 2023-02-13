using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMonoWrapper : MonoBehaviour
{
    public UI UI;
    public GameTimer GameTimer;
    
    void Start()
    {
        Game.Initialize(UI, GameTimer);
    }

    
    void Update()
    {
        if (Game.GameJustEnded())
        {
            Game.EndGame();
        }
    }

    public void StartGame()
    {
        Game.StartGame();
    }
}
