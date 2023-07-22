using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CONSTANTS_ENUM
{
    public enum TIME_MODE { TIMER_MODE, CLOCK_MODE }
    public enum GAME_STATE { PAUSE, PLAY }
    public enum CAMERA_FOLLOW_MODE { CAMERA_FIXED_SPEED, CAMERA_TRACKING_TARGET }
    public enum ACTIVE_ITEM_CONFIG { CHARGED_SHOT, LAZER, MISSLE, ACCELARATE, UNIFORM_SPEED, INCREASE_HEALTH, INCREASE_DAMAGE, DASH, FROZEN }
    public enum ITEM_TYPE { HP, SCORE, HP_AND_SCORE, CHARGED_SHOT, LAZER, MISSLE, ACCELARATE, UNIFORM_SPEED, INCREASE_HEALTH, INCREASE_DAMAGE, DASH, FROZEN }
    public enum BORDER_TYPE { RECTANGLE, PENTAGON, CIRCLE, SQUARE, TRIANGLE, TRAPEZOID, ELIPSE, DIAMOND, SEMICIRCLE_LEFT, SEMICIRCLE_RIGHT, SEMICIRCLE_UP, SEMICIRCLE_DOWN, CRESCENTMOON, CROSS, DONUT, HEXAGON, STAR, RANDOM };
    public enum MAZE_TYPE { SIMPLE, MEDIUM, HARD, RANDOM, PREDEFINED };
    public enum MUISC_MODE { QUEUE, RANDOM, REPEAT };
    public enum MUISC_TYPE { OST, MENU, PAUSE };
    public enum EXPLOSION_TYPES { DEATH, DEATH_ITEM, HURT, DASH, BULLET_WALL_COLLISION };
}