using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Border_SemiCircle_Up : Border_SemiCircle
{
    public Border_SemiCircle_Up(float radius, GameObject borderObject) : base(radius, borderObject, 0)
    {
    }

    public Border_SemiCircle_Up(BorderParameters parameters, GameObject borderObject) : base(parameters, borderObject, 0)
    {
    }


}
