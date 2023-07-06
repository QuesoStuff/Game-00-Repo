using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Border_Trapezoid : Border
{
    private float base1_, base2_, height_;
    private GameObject borderInstance;

    public Border_Trapezoid(float base1, float base2, float height, GameObject borderObject, float rotate = 0) : base(borderObject, rotate)
    {
        base1_ = base1;
        base2_ = base2;
        height_ = height;
        MakeBorder();

    }

    public Border_Trapezoid(BorderParameters parameters, GameObject borderObject, float rotate = 0) : base(parameters, borderObject, rotate)
    {
        base1_ = parameters.base1;
        base2_ = parameters.base2;
        height_ = parameters.height;
        MakeBorder();

    }

    public override void SetDimensions(float? base1 = null, float? base2 = null, float? height = null)
    {
        if (base1 == null || base2 == null || height == null)
        {
            throw new ArgumentException("Trapezoid requires 3 dimensions.");
        }
        base1_ = base1.Value;
        base2_ = base2.Value;
        height_ = height.Value;
    }

    public void SetDimensions(float base1, float base2, float height)
    {
        base1_ = base1;
        base2_ = base2;
        height_ = height;
    }


    protected override void AssignPoints()
    {
        vertices_ = GENERIC.AssignPoints_Trapezoid(base1_, base2_, height_, center_);
    }



}
