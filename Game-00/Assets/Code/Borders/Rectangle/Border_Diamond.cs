using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_Diamond : Border
{
    private float width_;
    private float height_;

    public Border_Diamond(float width, float height, GameObject borderObject, float rotate = 0) : base(borderObject, rotate)
    {
        width_ = width;
        height_ = height;
    }
    public Border_Diamond(BorderParameters parameters, GameObject borderObject, float rotate = 0) : base(parameters, borderObject, rotate)
    {
        width_ = parameters.width;
        height_ = parameters.height;
    }

    public override void SetDimensions(float? width = null, float? height = null, float? param3 = null)
    {
        if (width == null || height == null)
        {
            throw new ArgumentException("Diamond requires 2 dimensions.");
        }
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
        vertices_ = GENERIC.AssignPoints_Diamond(width_, height_, center_);
    }

    public override bool IsWithinBounds(Vector3 position)
    {
        return GENERIC.IsWithinBounds_Diamond(position, center_, width_, height_);
    }
}
