using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CONSTANTS
{

    public const string Player_Tag = "Player";
    public const string Enemy_Tag = "Enemy";
    public const string Bullet_Tag = "Bullet";
    public const string Wall_Tag = "Wall";

    public const string Item_Tag = "Item";
    public const string Item_Score_Tag = "Item_Score";
    public const string Item_Health_Tag = "Item_Health";
    public const string Item_Special_Tag = "Item_Special";

    public const string ActiveItems_Tag = "ActiveItems";

    public const string Door_Tag = "Door";
    public const string Door_Exit_Tag = "DoorExit";


    public const float HP_PLAYER_STARTING = 5;
    public const float HP_DEFAULT_HEAL = 1;
    public const float HP_DEFAULT_DAMAGE = 1;
    public const float HP_DEFAULT_MAXLIFE = 999999;

    public const float PLAYER_DEFAULT_SPEED = 5;
    public const float PLAYER_DEFAULT_TAP_DURATION = 1f;
    public const float PLAYER_DEFAULT_CHARGED_TIME = 0.5f;


    public const int MIN_TO_SEC = 60;

    public const float TIME_MAX_TIMER = 2000;
    public enum TIME_MODE { TIMER_MODE, CLOCK_MODE }
    public enum GAME_STATE { PAUSE, PLAY }
    public enum CAMERA_FOLLOW_MODE { CAMERA_FIXED_SPEED, CAMERA_TRACKING_TARGET }
    public enum ActiveItems_CONFIG { CHARGED_SHOT, LAZER, MISSLE, ACCELARATE, UNIFORM_SPEED, INCREASE_HEALTH, INCREASE_DAMAGE, DASH, FROZEN }
    public enum ITEM_TYPE { HP, SCORE, HP_AND_SCORE, CHARGED_SHOT, LAZER, MISSLE, ACCELARATE, UNIFORM_SPEED, INCREASE_HEALTH, INCREASE_DAMAGE, DASH, FROZEN }
    public enum BORDER_TYPE { RECTANGLE, PENTAGON, CIRCLE, SQUARE, TRIANGLE, TRAPEZOID, ELIPSE, DIAMOND, SEMICIRCLE_LEFT, SEMICIRCLE_RIGHT, SEMICIRCLE_UP, SEMICIRCLE_DOWN, CRESCENTMOON, CROSS, DONUT, HEXAGON, STAR };
    public enum MAZE_TYPE { SIMPLE, MEDIUM, HARD, RANDOM, PREDEFINED };
    public enum MUISC_MODE { QUEUE, RANDOM, REPEAT };
    public enum EXPLOSION_TYPES { DEATH, DEATH_ITEM, HURT, DASH, BULLET_WALL_COLLISION };
    public const float TRAVELING_DISTANCE_RATE = 225;
    public const float DEFAULT_SCORE = 1;
    public const float DEFAULT_SCORE_EXTRA = 4;


    public const float DEFAULT_SPAWN_DELAY = 10;
    public const int DEFAULT_MAX_SPAWNING_COUNT = 100;

    public const float CLOCK_TIME_LIMIT = 20 * 60;
    public const float TIMER_START = 5 * 60;
    public const float HALF_SECOND_BLINK_SPEED = 2 * Mathf.PI;
    public const float ONE_SECOND_BLINK_SPEED = 4 * Mathf.PI;
    public const float DEFAULT_DASHING_TIME = 1.75f;
    public const float DEFSULT_BULLET_LIFE = 1.35f;

    public const int SPAWN_MIN_DISTANCE_FROM_PLAYER = -50;
    public const int SPAWN_MAX_DISTANCE_FROM_PLAYER = 50;


    public const int EXPLOSION_SIM_SPEED_MIN = 1;
    public const int EXPLOSION_SIM_SPEED_MAX = 5;
    public const float EXPLOSION_SIM_START_SIZE_MIN = 0.1f;
    public const float EXPLOSION_SIM_START_SIZE_MAX = 0.3f;
    public const int EXPLOSION_PARTICLE_COUNT_MIN = 150;
    public const int EXPLOSION_PARTICLE_COUNT_MAX = 1000;
    public const float EXPLOSION_END_LIFE_MIN = 0.5f;
    public const float EXPLOSION_END_LIFE_MAX = 1.5f;
    public const float EXPLOSION_DURATION_MIN = 0.5f;
    public const float EXPLOSION_DURATION_MAX = 2.7f;
    public const int BULLET_SIM_SPEED_MIN = 2;
    public const int BULLET_SIM_SPEED_MAX = 8;
    public const float BULLET_SIM_START_SIZE_MIN = 0.07f;
    public const float BULLET_SIM_START_SIZE_MAX = 0.2f;
    public const int BULLET_PARTICLE_COUNT_MIN = 1;
    public const int BULLET_PARTICLE_COUNT_MAX = 10;
    public const float BULLET_END_LIFE_MIN = 0.5f;
    public const float BULLET_END_LIFE_MAX = 1.5f;
    public const float BULLET_DURATION_MIN = 0.05f;
    public const float BULLET_DURATION_MAX = 0.25f;

    public const int LOOP_LIMIT = 1000;

}
