using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Border_Triangle : Border
{
    protected float sideLength_;
    protected GameObject borderInstance;




    protected override void AssignPoints()
    {
        vertices_ = GENERIC.AssignPoints_Triangle(sideLength_, center_);
    }

    public Border_Triangle(float sideLength, GameObject borderObject, float rotate = 0) : base(borderObject, rotate)
    {
        sideLength_ = sideLength;
    }

    public Border_Triangle(BorderParameters parameters, GameObject borderObject, float rotate = 0) : base(parameters, borderObject, rotate)
    {
        sideLength_ = parameters.sideLength;
    }

    public override void SetDimensions(float? sideLength = null, float? param2 = null, float? param3 = null)
    {
        if (sideLength == null)
        {
            throw new ArgumentException("Triangle requires 1 dimension.");
        }
        sideLength_ = sideLength.Value;
    }

    public void SetSideLength(float sideLength)
    {
        sideLength_ = sideLength;
    }


    public override bool IsWithinBounds(Vector3 position)
    {
        return GENERIC.IsWithinBounds_Triangle(position, center_, sideLength_);
    }

}
