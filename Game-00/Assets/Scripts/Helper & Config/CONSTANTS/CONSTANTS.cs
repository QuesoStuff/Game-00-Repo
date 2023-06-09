using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CONSTANTS
{
    // General purpose values

    // Name tags
    public const string Player_Tag = "Player";
    public const string Enemy_Tag = "Enemy";
    public const string Bullet_Tag = "Bullet";
    public const string Wall_Tag = "Wall";
    public const string Item_Tag = "item";
    public const string Door_Tag = "Door";

    // Player related info

    // HP
    public const float HP_PLAYER_STARTING = 5;
    public const float HP_DEFAULT_HEAL = 1;
    public const float HP_DEFAULT_DAMAGE = 1;
    public const float HP_DEFAULT_MAXLIFE = 999999;

    // Movement
    public const float PLAYER_DEFAULT_SPEED = 5;
    public const float PLAYER_DEFAULT_TAP_DURATION = 1f;
    public const float PLAYER_DEFAULT_CHARGED_TIME = 0.5f;

    // Timer and Clock stuff

    public const float TIME_MAX_TIMER = 2000;
    public enum TIME_MODE { TIMER_MODE, CLOCK_MODE }
    public enum GAME_STATE { PAUSE, PLAY }
    public enum CAMERA_FOLLOW_MODE { CAMERA_FIXED_SPEED, CAMERA_TRACKING_TARGET }
    public enum UI_TEXT_BLINKING_STATE { NO_BLINK, FIXED_BLINK, INF_BLINK }
    public enum BULLET_TYPE { NORMAL, LAZER, CHARGED_SHOT, MISSLE };
    public enum BULLET_STAT { NORMAL, ACCELARATE, UNIFORM_SPEED, INCREASE_DAMAGE, INCREASE_HEALTH };


    // Miscellaneous

    public const float TRAVELING_DISTANCE_RATE = 225;
    public const float DEFAULT_SCORE = 1;



    // newly added 
    public const float CLOCK_TIME_LIMIT = 20 * 60;
    public const float TIMER_START = 5 * 60;
    public const float HALF_SECOND_BLINK_SPEED = 2 * Mathf.PI;
    public const float ONE_SECOND_BLINK_SPEED = 4 * Mathf.PI;
    public const float DEFAULT_DASHING_TIME = 1.75f;
    // bullet related 
    public const float DEFSULT_BULLET_LIFE = 1.35f;

    // loading contetns 
}
