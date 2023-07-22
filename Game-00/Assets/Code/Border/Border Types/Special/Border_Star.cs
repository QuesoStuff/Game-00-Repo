using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_Star : Border
{
    private float outerRadius_, innerRadius_;

    public Border_Star(float outerRadius, float innerRadius, GameObject borderObject, float rotate = 0, Transform target = null) : base(borderObject, rotate, target)
    {
        outerRadius_ = outerRadius;
        innerRadius_ = innerRadius;
        MakeBorder();
    }

    public Border_Star(BorderParameters parameters, GameObject borderObject, float rotate = 0, Transform target = null) : base(parameters, borderObject, rotate, target)
    {
        outerRadius_ = parameters.outerRadius;
        innerRadius_ = parameters.innerRadius;
        MakeBorder();
    }

    public override void SetDimensions(float? outerRadius = null, float? innerRadius = null, float? param3 = null)
    {
        if (outerRadius == null || innerRadius == null)
        {
            throw new ArgumentException("Star requires 2 dimensions.");
        }
        outerRadius_ = outerRadius.Value;
        innerRadius_ = innerRadius.Value;
    }
    /*

    */
    protected override void AssignPoints()
    {
        vertices_ = GENERIC.AssignPoints_Star(outerRadius_, innerRadius_, center_);
    }
    public override bool IsWithinBounds(Vector3 position)
    {
        return GENERIC.IsWithinBounds_Star(position, center_, outerRadius_, innerRadius_);
    }


}