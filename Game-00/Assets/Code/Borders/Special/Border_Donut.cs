using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Border_Donut : Border
{
    private float outerRadius_;
    private float innerRadius_;
    private int numberOfPoints_ = 360;
    public override void SetDimensions(float? param1 = null, float? param2 = null, float? param3 = null)
    {
        if (param1.HasValue)
            outerRadius_ = param1.Value;

        if (param2.HasValue)
            innerRadius_ = param2.Value;

    }
    public Border_Donut(float outerRadius, float innerRadius, GameObject borderObject, float rotate = 0) : base(borderObject, rotate)
    {
        outerRadius_ = outerRadius;
        innerRadius_ = innerRadius;
    }
    public Border_Donut(BorderParameters parameters, GameObject borderObject, float rotate = 0) : base(parameters, borderObject, rotate)
    {
        outerRadius_ = parameters.outerRadius;
        innerRadius_ = parameters.innerRadius;
    }

    protected override void AssignPoints()
    {
        vertices_ = GENERIC.AssignPoints_Donut(numberOfPoints_, innerRadius_, outerRadius_, center_);
    }



    public override bool IsWithinBounds(Vector3 point)
    {
        return GENERIC.IsWithinBounds_Donut(point, center_, innerRadius_, outerRadius_);
    }


}
