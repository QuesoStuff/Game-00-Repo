using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INPUT : MonoBehaviour, I_Input
{
    //Singleton Instance
    public static INPUT instance_;

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
    public bool Input_Tap_Up() => Input.GetKeyDown(KeyCode.UpArrow);
    public bool Input_Tap_Down() => Input.GetKeyDown(KeyCode.DownArrow);
    public bool Input_Tap_Left() => Input.GetKeyDown(KeyCode.LeftArrow);
    public bool Input_Tap_Right() => Input.GetKeyDown(KeyCode.RightArrow);

    //Input methods for continuous movement
    public bool Input_Move_Up() => Input.GetKey(KeyCode.UpArrow);
    public bool Input_Move_Down() => Input.GetKey(KeyCode.DownArrow);
    public bool Input_Move_Left() => Input.GetKey(KeyCode.LeftArrow);
    public bool Input_Move_Right() => Input.GetKey(KeyCode.RightArrow);

    //Input methods for stopping movement
    public bool Input_Move_Up_Stop() => Input.GetKeyUp(KeyCode.UpArrow);
    public bool Input_Move_Down_Stop() => Input.GetKeyUp(KeyCode.DownArrow);
    public bool Input_Move_Left_Stop() => Input.GetKeyUp(KeyCode.LeftArrow);
    public bool Input_Move_Right_Stop() => Input.GetKeyUp(KeyCode.RightArrow);

    //Input methods related to the trigger
    public bool Input_Trigger_Pulled() => Input.GetKeyDown(KeyCode.Space);
    public bool Input_Trigger_Release() => Input.GetKeyUp(KeyCode.Space);
    public bool Input_Trigger_Rapid() => Input.GetKey(KeyCode.Space);

    //Input methods for idle state and pause/resume
    public bool Input_Idle() => !Input.anyKeyDown;
    public bool Input_Pause_Resume() => Input.GetKeyDown(KeyCode.Return);

    //Input methods for double tap movements and shooting actions
    public bool Input_Dash_Move()
    {
        bool dash_up = Input_Double_Tap(ref timer_input_press_up_, CONSTANTS.PLAYER_DEFAULT_TAP_DURATION, Input_Tap_Up);
        bool dash_down = Input_Double_Tap(ref timer_input_press_down_, CONSTANTS.PLAYER_DEFAULT_TAP_DURATION, Input_Tap_Down);
        bool dash_left = Input_Double_Tap(ref timer_input_press_left_, CONSTANTS.PLAYER_DEFAULT_TAP_DURATION, Input_Tap_Left);
        bool dash_right = Input_Double_Tap(ref timer_input_press_right_, CONSTANTS.PLAYER_DEFAULT_TAP_DURATION, Input_Tap_Right);
        return dash_up || dash_down || dash_left || dash_right;
    }

    public bool Input_Shot_Rapid() => Input_Double_Tap(ref timer_input_press_shoot_rapid_, CONSTANTS.PLAYER_DEFAULT_TAP_DURATION, Input_Trigger_Pulled);

    //Methods for shooting charged shot
    public bool Input_Shot_Charged() => GENERIC.Valid_Duration(ref timer_input_press_shoot_charged_, CONSTANTS.PLAYER_DEFAULT_CHARGED_TIME, Input_Trigger_Pulled, Input_Trigger_Release);
    public bool Input_Charged_Valid() => GENERIC.IsButtonHeld(KeyCode.Space, ref timer_input_press_charging_, CONSTANTS.PLAYER_DEFAULT_CHARGED_TIME * 0.95f);

    //Method for double tap validation
    public bool Input_Double_Tap(ref float timer, float duration, Func<bool> conditionPress)
    {
        return GENERIC.Valid_DoubleTap(ref timer, duration, conditionPress);
    }
}
