using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Config : Config, I_Init_Values
{
    [SerializeField] public Door_Main door_Main_;
    List<float> thresholds_ = new List<float> { CONSTANTS.DEFAULT_DOOR_DISTANCE_1, CONSTANTS.DEFAULT_DOOR_DISTANCE_2 };
    List<Color> colors_ = new List<Color> { CONSTANTS_COLOR.DEFAULT_DOOR_1, CONSTANTS_COLOR.DEFAULT_DOOR_2, CONSTANTS_COLOR.DEFAULT_DOOR_3 };
    CollectionRange<float, Color> collectionColorRange_;

    public override void Revive()
    {
        door_Main_.door_Controller_.Revive();
    }
    public override void Config_OnDeath()
    {
        throw new System.NotImplementedException();
    }
    public override void Init_Values()
    {
        throw new System.NotImplementedException();
    }
    public override void Config_Init()
    {
        door_Main_.door_Controller_.FadeInOut();
    }
    public void Init_Color(float distance)
    {
        collectionColorRange_ = new CollectionRange<float, Color>(thresholds_, colors_);
        Color doorColor = collectionColorRange_.GetResultBasedOnThreshold(distance);
        door_Main_.door_Color_.SetCurrentColor_SetColor(doorColor);
        // update the fade color.
        door_Main_.door_Controller_.StopCurrentCoroutine();
        door_Main_.door_Controller_.FadeInOut();
    }


}
