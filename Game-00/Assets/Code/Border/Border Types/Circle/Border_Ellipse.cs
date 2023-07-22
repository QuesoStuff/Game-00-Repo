using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_Ellipse : Border
{
    private float semiMajorAxis_;
    private float semiMinorAxis_;

    public Border_Ellipse(float semiMajorAxis, float semiMinorAxis, GameObject borderObject, float rotate = 0, Transform target = null) : base(borderObject, rotate, target)
    {
        semiMajorAxis_ = semiMajorAxis;
        semiMinorAxis_ = semiMinorAxis;
    }
    public Border_Ellipse(BorderParameters parameters, GameObject borderObject, float rotate = 0, Transform target = null) : base(parameters, borderObject, rotate, target)
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

    public override bool IsWithinBounds(Vector3 position)
    {


        // Translate the point to be relative to the ellipse center
        Vector2 relativePoint = position - center_;

        // Rotate the point back to the axis
        float theta = -Mathf.Deg2Rad * rotation_;
        Vector2 rotatedPoint = new Vector2(
            relativePoint.x * Mathf.Cos(theta) - relativePoint.y * Mathf.Sin(theta),
            relativePoint.x * Mathf.Sin(theta) + relativePoint.y * Mathf.Cos(theta));

        // Check if the point is inside the ellipse using the ellipse equation (x^2/a^2) + (y^2/b^2) <= 1
        return (Mathf.Pow(rotatedPoint.x, 2) / Mathf.Pow(semiMajorAxis_, 2)) + (Mathf.Pow(rotatedPoint.y, 2) / Mathf.Pow(semiMinorAxis_, 2)) <= 1;
    }


}
