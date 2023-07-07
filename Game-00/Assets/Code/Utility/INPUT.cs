using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INPUT : MonoBehaviour
{
    //Singleton Instance
    public static INPUT instance_;

    private bool isInputActiveItems_ = true;
    public bool GetInputTime() => isInputActiveItems_;
    public void SetInputTime(bool value) => isInputActiveItems_ = value;
    public void ToggleInputTime() => isInputActiveItems_ = !isInputActiveItems_;
    public void DisableInputForDuration(float delay = 5)
    {
        isInputActiveItems_ = false;
        this.DelayMethod(delay, () => isInputActiveItems_ = true);
    }
    //Timers
    private float timer_input_press_up_ = 0;
    private float timer_input_press_down_ = 0;
    private float timer_input_press_left_ = 0;
    private float timer_input_press_right_ = 0;
    private float timer_input_press_shoot_rapid_ = 0;
    private float timer_input_press_shoot_charged_ = 0;
    private float timer_input_press_charging_ = 0;

    //Awake method for creating Singleton
    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
    }

    //Input methods for single and double taps
    public bool Input_Tap_Up() => isInputActiveItems_ && Input.GetKeyDown(KeyCode.UpArrow);
    public bool Input_Tap_Down() => isInputActiveItems_ && Input.GetKeyDown(KeyCode.DownArrow);
    public bool Input_Tap_Left() => isInputActiveItems_ && Input.GetKeyDown(KeyCode.LeftArrow);
    public bool Input_Tap_Right() => isInputActiveItems_ && Input.GetKeyDown(KeyCode.RightArrow);

    //Input methods for continuous movement
    public bool Input_Move_Up() => isInputActiveItems_ && Input.GetKey(KeyCode.UpArrow);
    public bool Input_Move_Down() => isInputActiveItems_ && Input.GetKey(KeyCode.DownArrow);
    public bool Input_Move_Left() => isInputActiveItems_ && Input.GetKey(KeyCode.LeftArrow);
    public bool Input_Move_Right() => isInputActiveItems_ && Input.GetKey(KeyCode.RightArrow);
    public bool Input_Move_Any() => isInputActiveItems_ && (Input_Move_Up() || Input_Move_Down() || Input_Move_Left() || Input_Move_Right());

    //Input methods for stopping movement
    public bool Input_Move_Up_Stop() => isInputActiveItems_ && Input.GetKeyUp(KeyCode.UpArrow);
    public bool Input_Move_Down_Stop() => isInputActiveItems_ && Input.GetKeyUp(KeyCode.DownArrow);
    public bool Input_Move_Left_Stop() => isInputActiveItems_ && Input.GetKeyUp(KeyCode.LeftArrow);
    public bool Input_Move_Right_Stop() => isInputActiveItems_ && Input.GetKeyUp(KeyCode.RightArrow);

    //Input methods related to the trigger
    public bool Input_Trigger_Pulled() => isInputActiveItems_ && Input.GetKeyDown(KeyCode.Space);
    public bool Input_Trigger_Release() => isInputActiveItems_ && Input.GetKeyUp(KeyCode.Space);
    public bool Input_Trigger_Rapid() => isInputActiveItems_ && Input.GetKey(KeyCode.Space);

    //Input methods for idle state and pause/resume
    public bool Input_Idle() => isInputActiveItems_ && !Input.anyKeyDown;
    public bool Input_Pause_Resume() => isInputActiveItems_ && Input.GetKeyDown(KeyCode.Return);

    //Input methods for double tap movements and shooting actions
    public bool Input_Dash_Move()
    {
        bool dash_up = Input_Double_Tap(ref timer_input_press_up_, CONSTANTS.PLAYER_DEFAULT_TAP_DURATION, Input_Tap_Up);
        bool dash_down = Input_Double_Tap(ref timer_input_press_down_, CONSTANTS.PLAYER_DEFAULT_TAP_DURATION, Input_Tap_Down);
        bool dash_left = Input_Double_Tap(ref timer_input_press_left_, CONSTANTS.PLAYER_DEFAULT_TAP_DURATION, Input_Tap_Left);
        bool dash_right = Input_Double_Tap(ref timer_input_press_right_, CONSTANTS.PLAYER_DEFAULT_TAP_DURATION, Input_Tap_Right);
        return isInputActiveItems_ && (dash_up || dash_down || dash_left || dash_right);
    }

    public bool Input_Shot_Rapid() => isInputActiveItems_ && Input_Double_Tap(ref timer_input_press_shoot_rapid_, CONSTANTS.PLAYER_DEFAULT_TAP_DURATION, Input_Trigger_Pulled);

    //Methods for shooting charged shot
    public bool Input_Shot_Charged() => isInputActiveItems_ && GENERIC.Valid_Duration(ref timer_input_press_shoot_charged_, CONSTANTS.PLAYER_DEFAULT_CHARGED_TIME, Input_Trigger_Pulled, Input_Trigger_Release);
    public bool Input_Charged_Valid() => isInputActiveItems_ && GENERIC.Valid_Duration(ref timer_input_press_charging_, CONSTANTS.PLAYER_DEFAULT_CHARGED_TIME * 0.95f, () => Input.GetKeyDown(KeyCode.Space), () => Input.GetKey(KeyCode.Space));

    //Method for double tap validation
    public bool Input_Double_Tap(ref float timer, float duration, Func<bool> conditionPress)
    {
        return isInputActiveItems_ && GENERIC.Valid_DoubleTap(ref timer, duration, conditionPress);
    }
}