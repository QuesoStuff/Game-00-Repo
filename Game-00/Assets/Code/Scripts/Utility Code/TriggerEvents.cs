using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerEvents
{
    public static event Action<bool> OnGameFrozenChanged;
    public static event Action<bool> OnGamePausedChanged;
    public static event Action OnGameRestarted; // Added

    public static void TriggerEvent_FrozenEnemy(bool value)
    {
        OnGameFrozenChanged?.Invoke(value);
    }

    public static void TriggerEvent_DoorFlashing(bool value)
    {
        OnGamePausedChanged?.Invoke(value);
    }

    public static void TriggerEvent_GameRestarted() // Added IMPLEMENT FOR BETTER LEVEL TRNAITION
    {
        OnGameRestarted?.Invoke();
    }
}