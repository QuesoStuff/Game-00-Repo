using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Border_Hexagon : Border
{
    private float sideLength_;

    public Border_Hexagon(float sideLength, GameObject borderObject, float rotate = 0, Transform target = null) : base(borderObject, rotate, target)
    {
        sideLength_ = sideLength;
    }

    public Border_Hexagon(BorderParameters parameters, GameObject borderObject, float rotate = 0, Transform target = null) : base(parameters, borderObject, rotate, target)
    {
        sideLength_ = parameters.sideLength;
    }

    public override void SetDimensions(float? sideLength = null, float? param2 = null, float? param3 = null)
    {
        if (sideLength == null)
        {
            throw new ArgumentException("Hexagon requires 1 dimension.");
        }
        sideLength_ = sideLength.Value;
    }
    /*
        protected override Vector3[] AssignPoints()
        {
            Vector3[] vertices = new Vector3[7];

            for (int i = 0; i < 6; i++)
            {
                float angle_deg = 60 * i - 30;
                float angle_rad = Mathf.PI / 180 * angle_deg;
                vertices[i] = new Vector3(center_.x + sideLength_ * Mathf.Cos(angle_rad), center_.y + sideLength_ * Mathf.Sin(angle_rad), center_.z);
            }
            vertices[6] = vertices[0]; // Close the loop

            return vertices;
        }
        */
    protected override void AssignPoints()
    {
        vertices_ = new Vector3[7];

        for (int i = 0; i < 6; i++)
        {
            float angle_deg = 60 * i - 30;
            float angle_rad = Mathf.PI / 180 * angle_deg;
            vertices_[i] = new Vector3(center_.x + sideLength_ * Mathf.Cos(angle_rad), center_.y + sideLength_ * Mathf.Sin(angle_rad), center_.z);
        }
        vertices_[6] = vertices_[0]; // Close the loop
    }

    public override bool IsWithinBounds(Vector3 position)
    {
        return GENERIC.IsWithinBounds_Hexagon(position, center_, sideLength_);
    }
}
