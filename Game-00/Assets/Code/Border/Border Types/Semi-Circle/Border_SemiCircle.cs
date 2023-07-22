using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Border_SemiCircle : Border
{
    protected float radius_;

    protected Border_SemiCircle(float radius, GameObject borderObject, float rotate = 0) : base(borderObject, rotate)
    {
        radius_ = radius;
    }
    public Border_SemiCircle(BorderParameters parameters, GameObject borderObject, float rotate = 0) : base(parameters, borderObject, rotate)
    {
        radius_ = parameters.radius;
    }

    public override void SetDimensions(float? radius = null, float? param2 = null, float? param3 = null)
    {
        if (radius == null)
        {
            throw new ArgumentException("SemiCircle requires 1 dimension.");
        }
        radius_ = radius.Value;
    }
    protected override void AssignPoints()
    {
        vertices_ = GENERIC.AssignPoints_SemiCircle(radius_, center_);

    }
    public override bool IsWithinBounds(Vector3 position)
    {
        return GENERIC.IsWithinBounds_SemiCircle(position, center_, radius_);
    }

}
