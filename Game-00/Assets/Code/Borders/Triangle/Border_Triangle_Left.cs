using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_Triangle_Left : Border_Triangle
{
    public Border_Triangle_Left(float sideLength, GameObject borderObject) : base(sideLength, borderObject, 90) { }

    public Border_Triangle_Left(BorderParameters parameters, GameObject borderObject) : base(parameters, borderObject, 90) { }

}
