using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public CanvasGroup StartScreenCanvasGroup;
    public CanvasGroup GameOverScreenCanvasGroup;
    public Text ScoreText;
    public Text TimeText;
    public GameTimer GameTimer;

    public void Update()
    {
        ShowScore(ScoreKeeper.GetScore());
        ShowTime(GameTimer.GetTimeAsString());
    }

    public void ShowStartScreen()
    {
        CanvasGroupDisplayer.Show(StartScreenCanvasGroup);
        CanvasGroupDisplayer.Hide(GameOverScreenCanvasGroup);
    }

    public void ShowEndScreen()
    {
        CanvasGroupDisplayer.Show(GameOverScreenCanvasGroup);
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    }

    public void HideStartAndEndScreens()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
        CanvasGroupDisplayer.Hide(GameOverScreenCanvasGroup);
    }

    public void ShowScore(string score)
    {
        ScoreText.text = "Score: " + score;
    }

    public void ShowTime(string time)
    {
        TimeText.text = "Time: " + time;
    }
}
