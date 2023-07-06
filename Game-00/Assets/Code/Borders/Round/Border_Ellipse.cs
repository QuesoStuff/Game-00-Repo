using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_Ellipse : Border
{
    private float semiMajorAxis_;
    private float semiMinorAxis_;

    public Border_Ellipse(float semiMajorAxis, float semiMinorAxis, GameObject borderObject, float rotate = 0) : base(borderObject, rotate)
    {
        semiMajorAxis_ = semiMajorAxis;
        semiMinorAxis_ = semiMinorAxis;
    }
    public Border_Ellipse(BorderParameters parameters, GameObject borderObject, float rotate = 0) : base(parameters, borderObject, rotate)
    {
        semiMajorAxis_ = parameters.semiMajorAxis;
        semiMinorAxis_ = parameters.semiMinorAxis;
    }
    public override void SetDimensions(float? semiMajorAxis = null, float? semiMinorAxis = null, float? param3 = null)
    {
        if (semiMajorAxis == null || semiMinorAxis == null)
        {
            throw new ArgumentException("Ellipse requires 2 dimensions.");
        }
        semiMajorAxis_ = semiMajorAxis.Value;
        semiMinorAxis_ = semiMinorAxis.Value;
    }
    public void SetDimensions(float semiMajorAxis, float semiMinorAxis)
    {
        semiMajorAxis_ = semiMajorAxis;
        semiMinorAxis_ = semiMinorAxis;
    }

    protected override void AssignPoints()
    {
        vertices_ = GENERIC.AssignPoints_Elipse(semiMajorAxis_, semiMinorAxis_, center_);

    }



}
