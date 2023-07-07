using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ActiveItems : MonoBehaviour
{
    private static Dictionary<CONSTANTS.ActiveItems_CONFIG, bool> ActiveItemsConfig_ =
        System.Enum.GetValues(typeof(CONSTANTS.ActiveItems_CONFIG))
        .Cast<CONSTANTS.ActiveItems_CONFIG>()
        .ToDictionary(config => config, config => false);
    [SerializeField] private CONSTANTS.ActiveItems_CONFIG curr_Config_;

    private static bool isEmpty_ = true;
    private static bool isFull_ = false;
    private static int currCount_ = 0;


    public static void RESET()
    {
        foreach (CONSTANTS.ActiveItems_CONFIG config in System.Enum.GetValues(typeof(CONSTANTS.ActiveItems_CONFIG)))
        {
            ActiveItemsConfig_[config] = false;
        }
        UpdateEmptyAndFullStatus();
    }
    private static void UpdateEmptyAndFullStatus()
    {
        currCount_ = ActiveItemsConfig_.Values.Count(v => v);
        isEmpty_ = currCount_ == 0;
        isFull_ = currCount_ == ActiveItemsConfig_.Count;
    }
    public static bool GetIsEmpty()
    {
        return isEmpty_;
    }
    public static bool GetIsFull()
    {
        return isFull_;
    }
    public CONSTANTS.ActiveItems_CONFIG GetCurrConfig()
    {
        return curr_Config_;
    }
    public void SetCurrConfig(CONSTANTS.ActiveItems_CONFIG config)
    {
        curr_Config_ = config;
    }


    public static bool GetIsTypeCharged()
    {
        return ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.CHARGED_SHOT];
    }

    public static void SetIsTypeCharged(bool value)
    {
        ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.CHARGED_SHOT] = value;
        UpdateEmptyAndFullStatus();
    }

    public static bool GetIsTypeLazer()
    {
        return ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.LAZER];
    }

    public static void SetIsTypeLazer(bool value)
    {
        ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.LAZER] = value;
        UpdateEmptyAndFullStatus();
    }

    public static bool GetIsTypeMissle()
    {
        return ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.MISSLE];
    }

    public static void SetIsTypeMissle(bool value)
    {
        ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.MISSLE] = value;
        UpdateEmptyAndFullStatus();
    }

    public static bool GetIsStatAccelerate()
    {
        return ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.ACCELARATE];
    }

    public static void SetIsStatAccelerate(bool value)
    {
        ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.ACCELARATE] = value;
        UpdateEmptyAndFullStatus();
    }

    public static bool GetIsStatUniformSpeed()
    {
        return ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.UNIFORM_SPEED];
    }

    public static void SetIsStatUniformSpeed(bool value)
    {
        ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.UNIFORM_SPEED] = value;
        UpdateEmptyAndFullStatus();
    }

    public static bool GetIsStatIncreaseHealth()
    {
        return ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.INCREASE_HEALTH];
    }

    public static void SetIsStatIncreaseHealth(bool value)
    {
        ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.INCREASE_HEALTH] = value;
        UpdateEmptyAndFullStatus();
    }

    public static bool GetIsStatIncreasedDamage()
    {
        return ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.INCREASE_DAMAGE];
    }

    public static void SetIsStatIncreasedDamage(bool value)
    {
        ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.INCREASE_DAMAGE] = value;
        UpdateEmptyAndFullStatus();
    }

    public static bool GetIsDashing()
    {
        return ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.DASH];
    }

    public static void SetIsDashing(bool value)
    {
        ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.DASH] = value;
        UpdateEmptyAndFullStatus();
    }

    public static bool GetIsFrozen()
    {
        return ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.FROZEN];
    }

    public static void SetIsFrozen(bool value)
    {
        ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.FROZEN] = value;
        UpdateEmptyAndFullStatus();
    }

    public void Set_Bullet_Config(CONSTANTS.ActiveItems_CONFIG stat)
    {
        ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.CHARGED_SHOT] = stat == CONSTANTS.ActiveItems_CONFIG.CHARGED_SHOT;
        ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.LAZER] = stat == CONSTANTS.ActiveItems_CONFIG.LAZER;
        ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.MISSLE] = stat == CONSTANTS.ActiveItems_CONFIG.MISSLE;
        ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.ACCELARATE] = stat == CONSTANTS.ActiveItems_CONFIG.ACCELARATE;
        ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.INCREASE_DAMAGE] = stat == CONSTANTS.ActiveItems_CONFIG.INCREASE_DAMAGE;
        ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.INCREASE_HEALTH] = stat == CONSTANTS.ActiveItems_CONFIG.INCREASE_HEALTH;
        ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.UNIFORM_SPEED] = stat == CONSTANTS.ActiveItems_CONFIG.UNIFORM_SPEED;
        ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.DASH] = stat == CONSTANTS.ActiveItems_CONFIG.DASH;
        ActiveItemsConfig_[CONSTANTS.ActiveItems_CONFIG.FROZEN] = stat == CONSTANTS.ActiveItems_CONFIG.FROZEN;
        curr_Config_ = stat;
        UpdateEmptyAndFullStatus();

    }

    public IEnumerator SelectConfig(CONSTANTS.ActiveItems_CONFIG config, Action method_Start = null, Action method_Blinking = null, Action method_End = null, float delayTime = 3, float blinkTime = 1)
    {
        ActiveItemsConfig_[config] = true;
        UpdateEmptyAndFullStatus();
        method_Start?.Invoke();
        yield return new WaitForSeconds(delayTime - blinkTime);
        method_Blinking?.Invoke();
        yield return new WaitForSeconds(blinkTime);
        ActiveItemsConfig_[config] = false;
        UpdateEmptyAndFullStatus();
        method_End?.Invoke();
    }

    public IEnumerator SelectConfigRandom(Action method_Full = null, Action method_Start = null, Action method_Blinking = null, Action method_End = null, float delayTime = 3, float blinkTime = 1)
    {
        if (isFull_)
        {
            method_Full?.Invoke();
            yield break;
        }
        CONSTANTS.ActiveItems_CONFIG randomConfiguration = randomConfiguration = (CONSTANTS.ActiveItems_CONFIG)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(CONSTANTS.ActiveItems_CONFIG)).Length);
        while (ActiveItemsConfig_[randomConfiguration])
        {
            randomConfiguration = (CONSTANTS.ActiveItems_CONFIG)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(CONSTANTS.ActiveItems_CONFIG)).Length);
        }

        yield return StartCoroutine(SelectConfig(randomConfiguration, method_Start, method_Blinking, method_End, delayTime, blinkTime));
    }

    public IEnumerator SelectConfigTrueRandom(Action method_Start = null, Action method_Blinking = null, Action method_End = null, float delayTime = 3, float blinkTime = 1)
    {
        CONSTANTS.ActiveItems_CONFIG randomConfiguration = (CONSTANTS.ActiveItems_CONFIG)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(CONSTANTS.ActiveItems_CONFIG)).Length);
        yield return StartCoroutine(SelectConfig(randomConfiguration, method_Start, method_Blinking, method_End, delayTime, blinkTime));
    }

}
