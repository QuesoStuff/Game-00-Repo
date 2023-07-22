using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    private static float currScore_;


    static public float GetScore()
    {
        return currScore_;
    }

    static public void SetScore(float newScore)
    {
        currScore_ = newScore;
    }


    static public float AssignScore(float? scores = null)
    {
        if (scores == null)
            return UnityEngine.Random.Range(0, currScore_) / 2;
        else
            return scores.Value;
    }


    public static void ScoreIncrease(float addedScore = CONSTANTS.DEFAULT_SCORE)
    {
        SetScore(currScore_ + addedScore);
    }
    public static void ScoreIncrease()
    {
        ScoreIncrease(CONSTANTS.DEFAULT_SCORE);
    }

}