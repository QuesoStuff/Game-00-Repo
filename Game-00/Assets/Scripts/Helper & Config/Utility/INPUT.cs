using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INPUT : MonoBehaviour
{
    public static INPUT instance_;

    private float timer_input_press_up_ = 0;
    private float timer_input_press_down_ = 0;
    private float timer_input_press_left_ = 0;
    private float timer_input_press_right_ = 0;
    private float timer_input_press_shoot_rapid_ = 0;
    private float timer_input_press_shoot_charged_ = 0;
    private float timer_input_press_charging_ = 0;

    private void Awake()
    {
        // Singleton pattern
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
    }

    // Tap Inputs
    public bool Input_Tap_Up()
    {
        return Input.GetKeyDown(KeyCode.UpArrow);
    }

    public bool Input_Tap_Down()
    {
        return Input.GetKeyDown(KeyCode.DownArrow);
    }

    public bool Input_Tap_Left()
    {
        return Input.GetKeyDown(KeyCode.LeftArrow);
    }

    public bool Input_Tap_Right()
    {
        return Input.GetKeyDown(KeyCode.RightArrow);
    }

    // Movement Inputs
    public bool Input_Move_Up()
    {
        return Input.GetKey(KeyCode.UpArrow);
    }

    public bool Input_Move_Down()
    {
        return Input.GetKey(KeyCode.DownArrow);
    }

    public bool Input_Move_Left()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    public bool Input_Move_Right()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }

    // Movement Stop Inputs
    public bool Input_Move_Up_Stop()
    {
        return Input.GetKey(KeyCode.UpArrow);
    }

    public bool Input_Move_Down_Stop()
    {
        return Input.GetKey(KeyCode.DownArrow);
    }

    public bool Input_Move_Left_Stop()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    public bool Input_Move_Right_Stop()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }

    // Trigger Inputs
    public bool Input_Trigger_Pulled()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public bool Input_Trigger_Release()
    {
        return Input.GetKeyUp(KeyCode.Space);
    }

    public bool Input_Trigger_Rapid()
    {
        return Input.GetKey(KeyCode.Space);
    }

    // Idle Input
    public bool Input_Idle()
    {
        return !Input.anyKeyDown;
    }

    // Complex Input
    public bool Input_Double_Tap(ref float timer, float duration, Func<bool> conditionPress)
    {
        return GENERIC.Valid_DoubleTap(ref timer, duration, conditionPress);
    }

    public bool Input_Dash_Move()
    {
        bool dash_up = Input_Double_Tap(ref timer_input_press_up_, CONSTANTS.PLAYER_DEFAULT_TAP_DURATION, Input_Tap_Up);
        bool dash_down = Input_Double_Tap(ref timer_input_press_down_, CONSTANTS.PLAYER_DEFAULT_TAP_DURATION, Input_Tap_Down);
        bool dash_left = Input_Double_Tap(ref timer_input_press_left_, CONSTANTS.PLAYER_DEFAULT_TAP_DURATION, Input_Tap_Left);
        bool dash_right = Input_Double_Tap(ref timer_input_press_right_, CONSTANTS.PLAYER_DEFAULT_TAP_DURATION, Input_Tap_Right);
        return dash_up || dash_down || dash_left || dash_right;
    }

    public bool Input_Shot_Rapid()
    {
        return Input_Double_Tap(ref timer_input_press_shoot_rapid_, CONSTANTS.PLAYER_DEFAULT_TAP_DURATION, Input_Trigger_Pulled);
    }

    public bool Input_Shot_Charged()
    {
        return GENERIC.Valid_Duration(ref timer_input_press_shoot_charged_, CONSTANTS.PLAYER_DEFAULT_CHARGED_TIME, Input_Trigger_Pulled, Input_Trigger_Release);
    }
    public bool Input_Charged_Valid()
    {
        return GENERIC.IsButtonHeld(KeyCode.Space, ref timer_input_press_charging_, CONSTANTS.PLAYER_DEFAULT_CHARGED_TIME * 0.95f);

    }

    public bool Input_Pause_Resume()
    {
        return Input.GetKeyDown(KeyCode.Return);
    }
}
