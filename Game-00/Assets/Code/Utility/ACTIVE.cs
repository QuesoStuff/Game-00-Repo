using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ACTIVE : MonoBehaviour
{
    private static Dictionary<CONSTANTS.ACTIVE_CONFIG, bool> activeConfig_ =
        System.Enum.GetValues(typeof(CONSTANTS.ACTIVE_CONFIG))
        .Cast<CONSTANTS.ACTIVE_CONFIG>()
        .ToDictionary(config => config, config => false);
    [SerializeField] private CONSTANTS.ACTIVE_CONFIG curr_Config_;

    private static bool isEmpty_ = true;
    private static bool isFull_ = false;
    private static int currCount_ = 0;

    public static event Action<bool> OnGameFrozenChanged;
    public static event Action<bool> OnGamePausedChanged;

    public static void TriggerEvent_FrozenEnemy(bool value)
    {
        OnGameFrozenChanged?.Invoke(value);
    }
    public static void TriggerEvent_DoorFlashing(bool value)
    {
        OnGamePausedChanged?.Invoke(value);
    }
    public static void RESET()
    {
        foreach (CONSTANTS.ACTIVE_CONFIG config in System.Enum.GetValues(typeof(CONSTANTS.ACTIVE_CONFIG)))
        {
            activeConfig_[config] = false;
        }
        UpdateEmptyAndFullStatus();
    }
    private static void UpdateEmptyAndFullStatus()
    {
        currCount_ = activeConfig_.Values.Count(v => v);
        isEmpty_ = currCount_ == 0;
        isFull_ = currCount_ == activeConfig_.Count;
    }
    public static bool GetIsEmpty()
    {
        return isEmpty_;
    }
    public static bool GetIsFull()
    {
        return isFull_;
    }
    public CONSTANTS.ACTIVE_CONFIG GetCurrConfig()
    {
        return curr_Config_;
    }
    public void SetCurrConfig(CONSTANTS.ACTIVE_CONFIG config)
    {
        curr_Config_ = config;
    }


    public static bool GetIsTypeCharged()
    {
        return activeConfig_[CONSTANTS.ACTIVE_CONFIG.CHARGED_SHOT];
    }

    public static void SetIsTypeCharged(bool value)
    {
        activeConfig_[CONSTANTS.ACTIVE_CONFIG.CHARGED_SHOT] = value;
        UpdateEmptyAndFullStatus();
    }

    public static bool GetIsTypeLazer()
    {
        return activeConfig_[CONSTANTS.ACTIVE_CONFIG.LAZER];
    }

    public static void SetIsTypeLazer(bool value)
    {
        activeConfig_[CONSTANTS.ACTIVE_CONFIG.LAZER] = value;
        UpdateEmptyAndFullStatus();
    }

    public static bool GetIsTypeMissle()
    {
        return activeConfig_[CONSTANTS.ACTIVE_CONFIG.MISSLE];
    }

    public static void SetIsTypeMissle(bool value)
    {
        activeConfig_[CONSTANTS.ACTIVE_CONFIG.MISSLE] = value;
        UpdateEmptyAndFullStatus();
    }

    public static bool GetIsStatAccelerate()
    {
        return activeConfig_[CONSTANTS.ACTIVE_CONFIG.ACCELARATE];
    }

    public static void SetIsStatAccelerate(bool value)
    {
        activeConfig_[CONSTANTS.ACTIVE_CONFIG.ACCELARATE] = value;
        UpdateEmptyAndFullStatus();
    }

    public static bool GetIsStatUniformSpeed()
    {
        return activeConfig_[CONSTANTS.ACTIVE_CONFIG.UNIFORM_SPEED];
    }

    public static void SetIsStatUniformSpeed(bool value)
    {
        activeConfig_[CONSTANTS.ACTIVE_CONFIG.UNIFORM_SPEED] = value;
        UpdateEmptyAndFullStatus();
    }

    public static bool GetIsStatIncreaseHealth()
    {
        return activeConfig_[CONSTANTS.ACTIVE_CONFIG.INCREASE_HEALTH];
    }

    public static void SetIsStatIncreaseHealth(bool value)
    {
        activeConfig_[CONSTANTS.ACTIVE_CONFIG.INCREASE_HEALTH] = value;
        UpdateEmptyAndFullStatus();
    }

    public static bool GetIsStatIncreasedDamage()
    {
        return activeConfig_[CONSTANTS.ACTIVE_CONFIG.INCREASE_DAMAGE];
    }

    public static void SetIsStatIncreasedDamage(bool value)
    {
        activeConfig_[CONSTANTS.ACTIVE_CONFIG.INCREASE_DAMAGE] = value;
        UpdateEmptyAndFullStatus();
    }

    public static bool GetIsDashing()
    {
        return activeConfig_[CONSTANTS.ACTIVE_CONFIG.DASH];
    }

    public static void SetIsDashing(bool value)
    {
        activeConfig_[CONSTANTS.ACTIVE_CONFIG.DASH] = value;
        UpdateEmptyAndFullStatus();
    }

    public static bool GetIsFrozen()
    {
        return activeConfig_[CONSTANTS.ACTIVE_CONFIG.FROZEN];
    }

    public static void SetIsFrozen(bool value)
    {
        activeConfig_[CONSTANTS.ACTIVE_CONFIG.FROZEN] = value;
        UpdateEmptyAndFullStatus();
    }

    public void Set_Bullet_Config(CONSTANTS.ACTIVE_CONFIG stat)
    {
        activeConfig_[CONSTANTS.ACTIVE_CONFIG.CHARGED_SHOT] = stat == CONSTANTS.ACTIVE_CONFIG.CHARGED_SHOT;
        activeConfig_[CONSTANTS.ACTIVE_CONFIG.LAZER] = stat == CONSTANTS.ACTIVE_CONFIG.LAZER;
        activeConfig_[CONSTANTS.ACTIVE_CONFIG.MISSLE] = stat == CONSTANTS.ACTIVE_CONFIG.MISSLE;
        activeConfig_[CONSTANTS.ACTIVE_CONFIG.ACCELARATE] = stat == CONSTANTS.ACTIVE_CONFIG.ACCELARATE;
        activeConfig_[CONSTANTS.ACTIVE_CONFIG.INCREASE_DAMAGE] = stat == CONSTANTS.ACTIVE_CONFIG.INCREASE_DAMAGE;
        activeConfig_[CONSTANTS.ACTIVE_CONFIG.INCREASE_HEALTH] = stat == CONSTANTS.ACTIVE_CONFIG.INCREASE_HEALTH;
        activeConfig_[CONSTANTS.ACTIVE_CONFIG.UNIFORM_SPEED] = stat == CONSTANTS.ACTIVE_CONFIG.UNIFORM_SPEED;
        activeConfig_[CONSTANTS.ACTIVE_CONFIG.DASH] = stat == CONSTANTS.ACTIVE_CONFIG.DASH;
        activeConfig_[CONSTANTS.ACTIVE_CONFIG.FROZEN] = stat == CONSTANTS.ACTIVE_CONFIG.FROZEN;
        curr_Config_ = stat;
        UpdateEmptyAndFullStatus();

    }

    public IEnumerator SelectConfig(CONSTANTS.ACTIVE_CONFIG config, Action method_Start = null, Action method_Blinking = null, Action method_End = null, float delayTime = 3, float blinkTime = 1)
    {
        activeConfig_[config] = true;
        UpdateEmptyAndFullStatus();
        method_Start?.Invoke();
        yield return new WaitForSeconds(delayTime - blinkTime);
        method_Blinking?.Invoke();
        yield return new WaitForSeconds(blinkTime);
        activeConfig_[config] = false;
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
        CONSTANTS.ACTIVE_CONFIG randomConfiguration = randomConfiguration = (CONSTANTS.ACTIVE_CONFIG)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(CONSTANTS.ACTIVE_CONFIG)).Length);
        while (activeConfig_[randomConfiguration])
        {
            randomConfiguration = (CONSTANTS.ACTIVE_CONFIG)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(CONSTANTS.ACTIVE_CONFIG)).Length);
        }

        yield return StartCoroutine(SelectConfig(randomConfiguration, method_Start, method_Blinking, method_End, delayTime, blinkTime));
    }

    public IEnumerator SelectConfigTrueRandom(Action method_Start = null, Action method_Blinking = null, Action method_End = null, float delayTime = 3, float blinkTime = 1)
    {
        CONSTANTS.ACTIVE_CONFIG randomConfiguration = (CONSTANTS.ACTIVE_CONFIG)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(CONSTANTS.ACTIVE_CONFIG)).Length);
        yield return StartCoroutine(SelectConfig(randomConfiguration, method_Start, method_Blinking, method_End, delayTime, blinkTime));
    }

}
