using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_CrescentMoon : Border
{
    private float outerRadius_;
    private float innerRadius_;
    private int numberOfPoints_ = 360;

    public Border_CrescentMoon(float outerRadius, float innerRadius, GameObject borderObject, float rotate = 0, Transform target = null) : base(borderObject, rotate, target)
    {
        outerRadius_ = outerRadius;
        innerRadius_ = innerRadius;
    }
    public Border_CrescentMoon(BorderParameters parameters, GameObject borderObject, float rotate = 0, Transform target = null) : base(parameters, borderObject, rotate, target)
    {
        outerRadius_ = parameters.outerRadius;
        innerRadius_ = parameters.innerRadius;

    }
    public override void SetDimensions(float? param1 = null, float? param2 = null, float? param3 = null)
    {
        if (param1.HasValue)
            outerRadius_ = param1.Value;

        if (param2.HasValue)
            innerRadius_ = param2.Value;


    }

    protected override void AssignPoints()
    {
        vertices_ = GENERIC.AssignPoints_Moon(numberOfPoints_, innerRadius_, outerRadius_, center_);

    }


}
