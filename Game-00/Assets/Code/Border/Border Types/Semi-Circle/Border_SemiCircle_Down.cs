using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Border_SemiCircle_Down : Border_SemiCircle
{
    public Border_SemiCircle_Down(float radius, GameObject borderObject) : base(radius, borderObject, 180)
    {
    }

    public Border_SemiCircle_Down(BorderParameters parameters, GameObject borderObject) : base(parameters, borderObject, 180)
    {
    }


}
