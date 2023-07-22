using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CONSTANTS
{

    public const float DEFAULT_SMALL_SIZE_FACTOR = 1;
    public const float DEFAULT_NORMAL_SIZE_FACTOR = 1.75f;
    public const float DEFAULT_LARGE_SIZE_FACTOR = 2.5f;

    // Default shape constants
    public const float DEFAULT_SIDE_LENGTH = 100f; // for Square, Hexagon
    public const float DEFAULT_WIDTH = 150f; // for Rectangle
    public const float DEFAULT_HEIGHT = 80f; // for Rectangle
    public const float DEFAULT_RADIUS = 70f; // for Circle, SemiCircle, Crescent
    public const float DEFAULT_SEMI_MAJOR_AXIS = 130f; // for Ellipse
    public const float DEFAULT_SEMI_MINOR_AXIS = 60f; // for Ellipse
    public const float DEFAULT_BASE1 = 90f; // for Trapezoid
    public const float DEFAULT_BASE2 = 110f; // for Trapezoid
    public const float DEFAULT_ARM_LENGTH = 85f; // for Cross
    public const float DEFAULT_OUTER_RADIUS = 100f; // for Star
    public const float DEFAULT_INNER_RADIUS = 40f; // for Star
    public const float DEFAULT_PILL_LENGTH = 120f; // for Pill shape
    public const float DEFAULT_PILL_DIAMETER = 50f; // for Pill shape
    public const float DEFAULT_LENGTH = 80f; // for Line shape

    // Default speed constants
    public const float DEFAULT_SPEED = 10;
    public const float DEFAULT_SPEED_FAST = 10;
    public const float DEFAULT_SPEED_SLOW = 2.5f;
    public const float DEFAULT_SPEED_DASH = 25;
    public const float DEFAULT_SPEED_ACC = 0;
    public const float DEFAULT_SPEED_ACC_SMALL = 0.3f;

    // Default health constants
    public const float DEFAULT_HP_HEAL = 1;
    public const float DEFAULT_HP_DAMAGE = 1;
    public const float DEFAULT_STARTER_HEALTH = 10;
    public const float DEFAULT_MAX_HEALTH = 15;
    public const float DEFAULT_PLAYER_STARTER_HEALTH = 5;
    public const float DEFAULT_WALL_STARTER_HEALTH = 3;
    public const float DEFAULT_BULLET_STARTER_HEALTH = 1;
    public const float DEFAULT_BULLET_STARTER_HEALTH_PLUS = 3;

    // Default wall constants
    public const float DEFAULT_WALL_SPEED = 2;
    public const float DEFAULT_WALL_SPEED_MIN = 1;
    public const float DEFAULT_WALL_SPEED_MAX = 5;

    // Default door constants
    public const int DEFAULT_DOOR_DISTANCE_1 = 10;
    public const int DEFAULT_DOOR_DISTANCE_2 = 50;
    public const int DEFAULT_DELAY = 5;

    // Default enemy constants
    public const float DEFAULT_ENEMY_SPEED = 5;
    public const float DEFAULT_ENEMY_DAMAGE = 2;
    public const float DEFAULT_ENEMY_DAMAGE_MIN = 1;
    public const float DEFAULT_ENEMY_DAMAGE_MAX = 10;
    public const float DEFAULT_ENEMY_SPEED_MIN = 1;
    public const float DEFAULT_ENEMY_SPEED_MAX = 7;

    // Default bullet constants
    public const float DEFAULT_BULLET_SPEED = 5;
    public const float DEFAULT_BULLET_DAMAGE = 2;
    public const float DEFAULT_BULLET_DAMAGE_MIN = 1;
    public const float DEFAULT_BULLET_DAMAGE_MAX = 10;
    public const int DEFAULT_BULLET_COUNT_LIMIT = 30;
    public const float DEFAULT_OFFSCREEN_BULLET_LIFETIME_ADJUSTMENT = 1.75f;
    public const float DEFSULT_BULLET_LIFETIME = 6.25f;

    // Other game constants
    public const float DEFAULT_INPUT_TAP_DURATION = 1f;
    public const float DEFAULT_INPUT_CHARGED_TIME = 0.5f;
    public const float DEFAULT_KNOCKBACK = 250;
    public const float DEFAULT_KNOCKBACK_DURATION = 1;
    public const float DEFAULT_TRAVEL_COEFFICIENT = 225;
    public const float DEFAULT_SCORE = 1;
    public const float DEFAULT_SCORE_EXTRA = 4;
    public const float DEFAULT_SPAWN_DELAY = 10;
    public const int DEFAULT_MAX_SPAWNING_COUNT = 100;
    public const int DEFAULT_MIN_DISTANCE_FROM_TARGET = -50;
    public const int DEFAULT_MAX_DISTANCE_FROM_TARGET = 50;
    public const float DEFAULT_TIME_DURATION = 3 * MIN;
    public const float DEFAULT_TIME_DURATION_CLOCK = 5 * MIN;
    public const float DEFAULT_TIME_DURATION_TIMER = 5 * MIN;
    public const float DEFAULT_DURATION_ITEM_LIFETIME = 25;
    public const float DEFAULT_DURATION_BLINKING_UI = 3;
    public const float DEFAULT_DASHING_TIME = 2.5f;
    public const float HALF_SECOND_BLINK_SPEED = 2 * PI;
    public const float ONE_SECOND_BLINK_SPEED = 4 * PI;
    public const float DEFAULT_BORDER_THICKNESS = 0.5f;
    public const float DEFAULT_BORDER_WIDTH = 5;
    public const float DEFAULT_CAMERA_FOLLOWSPEED = 2;
    public const float DEFAULT_CAMERA_TRACKSPEED = 0.5f;
    public const float DEFAULT_CAMERA_OFFSET_Y = 1;
    public const float DEFAULT_CAMERA_OFFSET_Z = -10;
    public const float DEFAULT_CAMERA_ZOOM = 10;
    public const int DEFAULT_START_COUNTDOWN = 4;
    public const int DEFAULT_START_COUNTDOWN_WAIT_TIME = 1;

    // Explosion constants
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

    // Other constants
    public const float PI = Mathf.PI;
    public static readonly float DIAGNOL = Mathf.Sqrt(2);
    public const int LOOP_LIMIT = 1000;
    public const int MIN = 60;
    public const float DEFAULT_DURATION = 2;
    public const float DEFAULT_RESPANW_RATE = 0.001F;

    public const float DEFAULT_MENU_ICON_OFFSET_X = -60;
    public const float DEFAULT_MENU_ICON_OFFSET_Y = 8;
    public const int DEFAULT_LOADING_INDEX = 2;

    public static readonly Vector3 DEFAULT_START_POINT = Vector3.zero;

}
