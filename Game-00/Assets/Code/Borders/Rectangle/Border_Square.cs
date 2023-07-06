using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Border_Square : Border
{
    private float sideLength_;

    public Border_Square(float sideLength, GameObject borderObject, float rotate = 0) : base(borderObject, rotate)
    {
        sideLength_ = sideLength;
    }

    public Border_Square(BorderParameters parameters, GameObject borderObject, float rotate = 0) : base(parameters, borderObject, rotate)
    {
        sideLength_ = parameters.sideLength;
    }

    public override void SetDimensions(float? sideLength = null, float? param2 = null, float? param3 = null)
    {
        if (sideLength == null)
        {
            throw new ArgumentException("Square requires 1 dimension.");
        }
        sideLength_ = sideLength.Value;
    }

    public void SetDimensions(float sideLength)
    {
        sideLength_ = sideLength;
    }


    protected override void AssignPoints()
    {
        vertices_ = GENERIC.AssignPoints_Square(sideLength_, center_);
    }



}
