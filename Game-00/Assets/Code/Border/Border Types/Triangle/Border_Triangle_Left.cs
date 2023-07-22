using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_Triangle_Left : Border_Triangle
{
    public Border_Triangle_Left(float sideLength, GameObject borderObject, Transform target = null) : base(sideLength, borderObject, 90, target) { }

    public Border_Triangle_Left(BorderParameters parameters, GameObject borderObject, Transform target = null) : base(parameters, borderObject, 90, target) { }

}
