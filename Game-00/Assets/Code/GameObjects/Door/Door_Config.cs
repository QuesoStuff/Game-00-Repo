using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Config : MonoBehaviour
{
    [SerializeField] public Door_Main door_Main_;

    public void Config_Random()
    {
        float distance;
        if (GENERIC.CoinToss(60, 40))
        {
            distance = UnityEngine.Random.Range(1, 10);
        }
        else
        {
            distance = UnityEngine.Random.Range(0.5f, 1.5f);
        }
        door_Main_.AdjustChildDistance_All(distance);
    }


}
