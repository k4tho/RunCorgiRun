using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game 
{
    public static UI UI;
    public static GameTimer GameTimer;
    private static bool isRunning;

    public static void Initialize(UI ui, GameTimer gameTimer)
    {
        UI = ui;
        GameTimer = gameTimer;
        UI.ShowStartScreen();
    }

    public static bool GameJustEnded()
    {
        if (isRunning && !GameTimer.IsRunning())
            return true;
        return false;
    }

    public static void StartGame()
    {
        isRunning = true;

        UI.HideStartAndEndScreens();
        ScoreKeeper.Reset();
        GameTimer.StartTimer(5);
    }

    public static void EndGame()
    {
        isRunning = false;

        UI.ShowEndScreen();
        GameTimer.StopTimer();
    }

    public static bool IsRunning()
    {
        return isRunning;
    }
}
