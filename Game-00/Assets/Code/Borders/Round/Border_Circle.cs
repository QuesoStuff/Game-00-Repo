using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_Circle : Border
{
    private float radius_;

    public Border_Circle(float radius, GameObject borderObject) : base(borderObject, 0)
    {
        radius_ = radius;
    }
    public Border_Circle(BorderParameters parameters, GameObject borderObject) : base(parameters, borderObject, 0)
    {
        radius_ = parameters.radius;
    }
    public override void SetDimensions(float? radius = null, float? param2 = null, float? param3 = null)
    {
        if (radius == null)
        {
            throw new ArgumentException("Circle requires 1 dimension.");
        }
        radius_ = radius.Value;
    }
    public void SetRadius(float radius)
    {
        radius_ = radius;
    }

    protected override void AssignPoints()
    {
        vertices_ = GENERIC.AssignPoints_Circle(radius_, center_);

    }



}
