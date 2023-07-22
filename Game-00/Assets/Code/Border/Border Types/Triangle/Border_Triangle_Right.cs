using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_Triangle_Right : Border_Triangle
{
    public Border_Triangle_Right(float sideLength, GameObject borderObject, Transform target = null) : base(sideLength, borderObject, 270, target) { }

    public Border_Triangle_Right(BorderParameters parameters, GameObject borderObject, Transform target = null) : base(parameters, borderObject, 270, target) { }




}
