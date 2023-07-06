using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Config : MonoBehaviour
{
    [SerializeField] public Wall_Main wall_Main_;

    private bool isNormal_ = false;
    private bool isMoving_ = false;
    private bool isBreakable_ = false;
    private float currWallSpeed_;
    private float currWallAcc_;

    public void Config_Init()
    {

        isNormal_ = GENERIC.CoinToss(90, 10);
        isMoving_ = GENERIC.CoinToss(30, 70);
        isBreakable_ = GENERIC.CoinToss(30, 70);



    }

    // Getter methods for the boolean fields
    public bool GetIsNormal()
    {
        return isNormal_;
    }

    public bool GetIsMoving()
    {
        return isMoving_;
    }

    public bool GetIsBreakable()
    {
        return isBreakable_;
    }

}
