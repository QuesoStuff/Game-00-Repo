using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour, I_ScoreManager
{
    private float currScore_;
    public static ScoreManager instance_;

    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
    }

    public float GetScore()
    {
        return currScore_;
    }

    public void SetScore(float newScore)
    {
        currScore_ = newScore;
    }



    public void ScoreIncrease(float addedScore = CONSTANTS.DEFAULT_SCORE)
    {
        SetScore(currScore_ + addedScore);
    }
    public void ScoreIncrease()
    {
        ScoreIncrease(CONSTANTS.DEFAULT_SCORE);
    }

}