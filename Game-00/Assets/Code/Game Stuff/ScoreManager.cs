using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float currScore_;
    public static ScoreManager instance_;

    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
    }

    // Returns the current score
    public float GetScore()
    {
        return currScore_;
    }

    // Sets the score to a new value
    public void SetScore(float newScore)
    {
        currScore_ = newScore;
    }

    // Increases the score by a specified amount
    public void ScoreIncrease(float plus)
    {
        SetScore(currScore_ + plus);
    }

    // Increases the score by the default score value
    public void ScoreIncrease()
    {
        SetScore(currScore_ + CONSTANTS.DEFAULT_SCORE);
    }

}