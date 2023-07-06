using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_Triangle_Down : Border_Triangle
{
    public Border_Triangle_Down(float sideLength, GameObject borderObject) : base(sideLength, borderObject, 180) { }

    public Border_Triangle_Down(BorderParameters parameters, GameObject borderObject) : base(parameters, borderObject, 180) { }


}
