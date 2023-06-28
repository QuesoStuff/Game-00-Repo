using System.Collections.Generic;

/// <summary>
/// The I_GameState interface provides the functionality for managing the state of the game.
/// </summary>
public interface I_GameState
{
    /// <summary>
    /// Handles input from the user to control the state of the game.
    /// </summary>
    void HandleInput();

    /// <summary>
    /// Gets the current state of the game.
    /// </summary>
    CONSTANTS.GAME_STATE GetGameState();

    /// <summary>
    /// Toggles the game state.
    /// </summary>
    void Toggle();

    /// <summary>
    /// Saves the game when the application is closing.
    /// </summary>
    void SaveGameOnExit();
}
