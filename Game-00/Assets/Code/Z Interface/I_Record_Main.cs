/// <summary>
/// The I_Record_Main interface outlines the methods required to manage and maintain various game records.
/// These records include distance traveled, bullet count, kill count, total damage, total heal, and high score, among others.
/// </summary>
public interface I_Record_Main
{
    /// <summary>
    /// Sets the maximum time for the clock.
    /// </summary>
    /// <param name="newTime">The new maximum time.</param>
    void SetClockMax(float newTime);

    /// <summary>
    /// Sets the maximum time for the timer.
    /// </summary>
    /// <param name="newTime">The new maximum time.</param>
    void SetTimerMax(float newTime);

    /// <summary>
    /// Gets the maximum time for the clock.
    /// </summary>
    /// <returns>The maximum time for the clock.</returns>
    float GetClockMax();

    /// <summary>
    /// Gets the maximum time for the timer.
    /// </summary>
    /// <returns>The maximum time for the timer.</returns>
    float GetTimerMax();

    /// <summary>
    /// Updates the distance traveled.
    /// </summary>
    void UpdateDistanceTraveled();

    /// <summary>
    /// Updates the bullet count.
    /// </summary>
    void UpdateBulletCount();

    /// <summary>
    /// Gets the distance traveled.
    /// </summary>
    /// <returns>The distance traveled.</returns>
    float GetDistanceTraveled();

    /// <summary>
    /// Sets the distance traveled.
    /// </summary>
    /// <param name="newDistanceTraveled">The new distance traveled.</param>
    void SetDistanceTraveled(float newDistanceTraveled);

    /// <summary>
    /// Gets the bullet count.
    /// </summary>
    /// <returns>The bullet count.</returns>
    uint GetBulletCount();

    /// <summary>
    /// Sets the bullet count.
    /// </summary>
    /// <param name="newCount">The new bullet count.</param>
    void SetBulletCount(uint newCount);

    /// <summary>
    /// Gets the kill count.
    /// </summary>
    /// <returns>The kill count.</returns>
    uint GetKillCount();

    /// <summary>
    /// Sets the kill count.
    /// </summary>
    /// <param name="newCount">The new kill count.</param>
    void SetKillCount(uint newCount);

    /// <summary>
    /// Gets the total damage.
    /// </summary>
    /// <returns>The total damage.</returns>
    float GetTotalDamage();

    /// <summary>
    /// Sets the total damage.
    /// </summary>
    /// <param name="value">The new total damage.</param>
    void SetTotalDamage(float value);

    /// <summary>
    /// Gets the total healing done.
    /// </summary>
    /// <returns>The total healing done.</returns>
    float GetTotalHeal();

    /// <summary>
    /// Sets the total healing done.
    /// </summary>
    /// <param name="value">The new total healing done.</param>
    void SetTotalHeal(float value);

    /// <summary>
    /// Gets the high score.
    /// </summary>
    /// <returns>The high score.</returns>
    float GetHighScore();

    /// <summary>
    /// Sets the high score.
    /// </summary>
    /// <param name="newScore">The new high score.</param>
    void SetHighScore(float newScore);
}
