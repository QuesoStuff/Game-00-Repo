using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Test_Bullets
{
    public static void Shoot_All()
    {
        Shoot_type();
        Shoot_Stat();
    }
    public static void Shoot_type()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ActiveItems.SetIsTypeCharged(false);
            ActiveItems.SetIsTypeLazer(false);
            ActiveItems.SetIsTypeMissle(false);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- All bullet types reset --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            ActiveItems.SetIsTypeCharged(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Charged --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            ActiveItems.SetIsTypeLazer(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Lazer --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            ActiveItems.SetIsTypeMissle(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Missile --");
        }
    }
    public static void Shoot_Stat()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ActiveItems.SetIsStatAccelerate(false);
            ActiveItems.SetIsStatUniformSpeed(false);
            ActiveItems.SetIsStatIncreaseHealth(false);
            ActiveItems.SetIsStatIncreasedDamage(false);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- All bullet stats reset --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActiveItems.SetIsStatAccelerate(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Accelerate --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActiveItems.SetIsStatUniformSpeed(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Uniform Speed --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActiveItems.SetIsStatIncreaseHealth(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Increase Health --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ActiveItems.SetIsStatIncreasedDamage(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Increased Damage --");
        }
    }
}
