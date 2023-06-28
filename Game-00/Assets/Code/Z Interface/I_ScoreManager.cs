using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The I_ScoreManager interface outlines the basic methods required to manage a game score. 
/// These include getting the current score, setting the score, and increasing the score.
/// </summary>
public interface I_ScoreManager
{
    /// <summary>
    /// Gets the current score.
    /// </summary>
    /// <returns>The current score.</returns>
    float GetScore();

    /// <summary>
    /// Sets the current score to a new value.
    /// </summary>
    /// <param name="newScore">The new score.</param>
    void SetScore(float newScore);

    /// <summary>
    /// Increases the score by a specific amount. 
    /// If no amount is provided, it increases the score by a default value.
    /// </summary>
    /// <param name="addedScore">The amount to increase the score by. Default value is set in CONSTANTS.DEFAULT_SCORE.</param>
    void ScoreIncrease(float addedScore);

    /// <summary>
    /// Increases the score by the default score value defined in CONSTANTS.DEFAULT_SCORE.
    /// </summary>
    void ScoreIncrease();
}
