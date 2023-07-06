using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Border_SemiCircle_Left : Border_SemiCircle
{
    public Border_SemiCircle_Left(float radius, GameObject borderObject) : base(radius, borderObject, 90)
    {
    }

    public Border_SemiCircle_Left(BorderParameters parameters, GameObject borderObject) : base(parameters, borderObject, 90)
    {
    }



}
