/// <summary>
/// The I_PrevFile interface outlines the methods required to load and compare file records.
/// </summary>
public interface I_PrevFile
{
    /// <summary>
    /// Loads file data into memory.
    /// </summary>
    void LoadFile();

    /// <summary>
    /// Compares the current distance traveled with the previously recorded maximum.
    /// </summary>
    /// <returns>True if the current distance traveled is greater, false otherwise.</returns>
    bool CompareDistanceTraveled();

    /// <summary>
    /// Compares the current bullet count with the previously recorded maximum.
    /// </summary>
    /// <returns>True if the current bullet count is greater, false otherwise.</returns>
    bool CompareBulletCount();

    /// <summary>
    /// Compares the current kill count with the previously recorded maximum.
    /// </summary>
    /// <returns>True if the current kill count is greater, false otherwise.</returns>
    bool CompareKillCount();

    /// <summary>
    /// Compares the current total damage with the previously recorded maximum.
    /// </summary>
    /// <returns>True if the current total damage is greater, false otherwise.</returns>
    bool CompareTotalDamage();

    /// <summary>
    /// Compares the current total healing with the previously recorded maximum.
    /// </summary>
    /// <returns>True if the current total healing is greater, false otherwise.</returns>
    bool CompareTotalHeal();

    /// <summary>
    /// Compares the current high score with the previously recorded maximum.
    /// </summary>
    /// <returns>True if the current high score is greater, false otherwise.</returns>
    bool CompareHighScore();

    /// <summary>
    /// Compares the current timer time with the previously recorded maximum.
    /// </summary>
    /// <returns>True if the current timer time is less, false otherwise.</returns>
    bool CompareTimerTime();

    /// <summary>
    /// Compares the current clock time with the previously recorded maximum.
    /// </summary>
    /// <returns>True if the current clock time is greater, false otherwise.</returns>
    bool CompareClockTime();
}
