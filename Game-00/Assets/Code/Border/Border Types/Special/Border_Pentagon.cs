using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_Pentagon : Border
{
    private float sideLength_;

    public Border_Pentagon(float sideLength, GameObject borderObject, float rotate = 0, Transform target = null) : base(borderObject, rotate, target)
    {
        sideLength_ = sideLength;
    }

    public Border_Pentagon(BorderParameters parameters, GameObject borderObject, float rotate = 0, Transform target = null) : base(parameters, borderObject, rotate, target)
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
    public override bool IsWithinBounds(Vector3 position)
    {
        return GENERIC.IsWithinBounds_Pentagon(position, center_, sideLength_);
    }

}
