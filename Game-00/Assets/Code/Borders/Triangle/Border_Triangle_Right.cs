using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_Triangle_Right : Border_Triangle
{
    public Border_Triangle_Right(float sideLength, GameObject borderObject) : base(sideLength, borderObject, 270) { }

    public Border_Triangle_Right(BorderParameters parameters, GameObject borderObject) : base(parameters, borderObject, 270) { }




}
