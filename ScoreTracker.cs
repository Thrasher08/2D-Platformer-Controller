using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker: MonoBehaviour
{
    [SerializeField]
    int score = 0;

    int coinScore = 1;

    public TextMeshProUGUI scoreValue;

    public int getScore()
    {
        return score;
    }

    public int getCoinScore()
    {
        return coinScore;
    }

    public void updateScore(int value)
    {
        score += value;
    }

    public void setScore(int value)
    {
        score = value;
    }

}
