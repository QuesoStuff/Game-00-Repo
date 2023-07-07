using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_Rectangle : Border
{
    private float width_, height_;

    public Border_Rectangle(float width, float height, GameObject borderObject, float rotate = 0) : base(borderObject, rotate)
    {
        width_ = width;
        height_ = height;
    }

    public Border_Rectangle(BorderParameters parameters, GameObject borderObject, float rotate = 0) : base(parameters, borderObject, rotate)
    {
        width_ = parameters.width;
        height_ = parameters.height;
    }

    public override void SetDimensions(float? width = null, float? height = null, float? param3 = null)
    {
        width_ = width.Value;
        height_ = height.Value;
    }

    public void SetDimensions(float width, float height)
    {
        width_ = width;
        height_ = height;
    }

    protected override void AssignPoints()
    {
        vertices_ = GENERIC.AssignPoints_Rectangle(width_, height_, center_);

        // Draw the debug lines for 5 seconds
        GENERIC.DrawDebugLines(vertices_, Color.red, 5f);
    }


    public override bool IsWithinBounds(Vector3 position)
    {
        return GENERIC.IsWithinBounds_Rectangle(position, center_, width_, height_);
    }


}
