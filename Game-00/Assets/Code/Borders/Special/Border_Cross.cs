using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_Cross : Border
{
    private float armLength_;

    public Border_Cross(float armLength, GameObject borderObject, float rotate = 0) : base(borderObject, rotate)
    {
        armLength_ = armLength;
        MakeBorder();
    }

    public Border_Cross(BorderParameters parameters, GameObject borderObject, float rotate = 0) : base(parameters, borderObject, rotate)
    {
        armLength_ = parameters.armLength;
        MakeBorder();
    }

    public override void SetDimensions(float? armLength = null, float? param2 = null, float? param3 = null)
    {
        if (armLength == null)
        {
            throw new ArgumentException("Cross requires 1 dimension.");
        }
        armLength_ = armLength.Value;
    }

    protected override void AssignPoints()
    {
        vertices_ = GENERIC.AssignPoints_Cross(armLength_, center_);

    }

    public override bool IsWithinBounds(Vector3 position)
    {
        return GENERIC.IsWithinBounds_Cross(position, center_, armLength_);
    }

}
