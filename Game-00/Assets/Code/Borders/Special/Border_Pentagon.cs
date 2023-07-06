using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_Pentagon : Border
{
    private float sideLength_;

    public Border_Pentagon(float sideLength, GameObject borderObject, float rotate = 0) : base(borderObject, rotate)
    {
        sideLength_ = sideLength;
    }

    public Border_Pentagon(BorderParameters parameters, GameObject borderObject, float rotate = 0) : base(parameters, borderObject, rotate)
    {
        sideLength_ = parameters.sideLength;
    }



    public override void SetDimensions(float? sideLength = null, float? param2 = null, float? param3 = null)
    {
        if (sideLength == null)
        {
            throw new ArgumentException("Pentagon requires 1 dimension.");
        }
        sideLength_ = sideLength.Value;
        MakeBorder();
    }

    protected override void AssignPoints()
    {
        vertices_ = GENERIC.AssignPoints_Pentagon(center_, sideLength_);


    }

}