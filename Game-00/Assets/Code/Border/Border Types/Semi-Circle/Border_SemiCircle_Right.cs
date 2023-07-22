using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_SemiCircle_Right : Border_SemiCircle
{
    public Border_SemiCircle_Right(float radius, GameObject borderObject) : base(radius, borderObject, 270)
    {
    }

    public Border_SemiCircle_Right(BorderParameters parameters, GameObject borderObject) : base(parameters, borderObject, 270)
    {
    }


}
