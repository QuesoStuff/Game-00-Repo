using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The I_Input interface is designed for managing player inputs. It contains methods to handle
/// all the possible inputs a player can make, including movement, shooting and dashing actions.
/// </summary>
public interface I_Input
{
    /// <summary>
    /// Checks for a single tap on the Up arrow key.
    /// </summary>
    bool Input_Tap_Up();

    /// <summary>
    /// Checks for a single tap on the Down arrow key.
    /// </summary>
    bool Input_Tap_Down();

    /// <summary>
    /// Checks for a single tap on the Left arrow key.
    /// </summary>
    bool Input_Tap_Left();

    /// <summary>
    /// Checks for a single tap on the Right arrow key.
    /// </summary>
    bool Input_Tap_Right();

    /// <summary>
    /// Checks for continuous movement upwards.
    /// </summary>
    bool Input_Move_Up();

    /// <summary>
    /// Checks for continuous movement downwards.
    /// </summary>
    bool Input_Move_Down();

    /// <summary>
    /// Checks for continuous movement to the left.
    /// </summary>
    bool Input_Move_Left();

    /// <summary>
    /// Checks for continuous movement to the right.
    /// </summary>
    bool Input_Move_Right();

    /// <summary>
    /// Checks if upward movement has stopped.
    /// </summary>
    bool Input_Move_Up_Stop();

    /// <summary>
    /// Checks if downward movement has stopped.
    /// </summary>
    bool Input_Move_Down_Stop();

    /// <summary>
    /// Checks if movement to the left has stopped.
    /// </summary>
    bool Input_Move_Left_Stop();

    /// <summary>
    /// Checks if movement to the right has stopped.
    /// </summary>
    bool Input_Move_Right_Stop();

    /// <summary>
    /// Checks if the trigger has been pulled (Space bar pressed).
    /// </summary>
    bool Input_Trigger_Pulled();

    /// <summary>
    /// Checks if the trigger has been released (Space bar released).
    /// </summary>
    bool Input_Trigger_Release();

    /// <summary>
    /// Checks if the trigger is being rapidly pressed.
    /// </summary>
    bool Input_Trigger_Rapid();

    /// <summary>
    /// Checks if no key is currently being pressed.
    /// </summary>
    bool Input_Idle();

    /// <summary>
    /// Checks if the game is being paused/resumed (Return key pressed).
    /// </summary>
    bool Input_Pause_Resume();

    /// <summary>
    /// Checks if a double tap movement has been initiated.
    /// </summary>
    bool Input_Dash_Move();

    /// <summary>
    /// Checks if a rapid shot action has been initiated.
    /// </summary>
    bool Input_Shot_Rapid();

    /// <summary>
    /// Checks if a charged shot action has been initiated.
    /// </summary>
    bool Input_Shot_Charged();

    /// <summary>
    /// Checks if a charged shot action is valid.
    /// </summary>
    bool Input_Charged_Valid();

    /// <summary>
    /// Validates a double tap action.
    /// </summary>
    bool Input_Double_Tap(ref float timer, float duration, Func<bool> conditionPress);
}
