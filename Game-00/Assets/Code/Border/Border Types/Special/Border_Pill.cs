using UnityEngine;
using System;

public class Border_Pill : Border
{
    private float length_;
    private float radius_;

    public Border_Pill(float length, float radius, GameObject borderObject, float rotate = 0, Transform target = null) : base(borderObject, rotate, target)
    {
        length_ = length;
        radius_ = radius;
    }
    public Border_Pill(BorderParameters parameters, GameObject borderObject, float rotate = 0, Transform target = null) : base(parameters, borderObject, rotate, target)
    {
        length_ = parameters.pillLength;
        radius_ = parameters.pillDiameter;
    }
    public override void SetDimensions(float? length = null, float? radius = null, float? param3 = null)
    {
        if (length == null || radius == null)
        {
            throw new ArgumentException("Pill requires 2 dimensions: length and radius.");
        }
        length_ = length.Value;
        radius_ = radius.Value;
    }

    protected override void AssignPoints()
    {
        vertices_ = GENERIC.AssignPoints_Pill(length_, radius_, center_);

    }

    public override bool IsWithinBounds(Vector3 position)
    {
        return GENERIC.IsWithinBounds_Pill(position, center_, length_, radius_);
    }

}
