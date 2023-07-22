using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_Triangle_Up : Border_Triangle
{
    public Border_Triangle_Up(float sideLength, GameObject borderObject, Transform target = null) : base(sideLength, borderObject, 0, target) { }

    public Border_Triangle_Up(BorderParameters parameters, GameObject borderObject, Transform target = null) : base(parameters, borderObject, 0, target) { }




}
