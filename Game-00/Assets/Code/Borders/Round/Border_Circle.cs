using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_Circle : Border
{
    private float radius_;

    public Border_Circle(float radius, GameObject borderObject) : base(borderObject, 0)
    {
        radius_ = radius;
    }
    public Border_Circle(BorderParameters parameters, GameObject borderObject) : base(parameters, borderObject, 0)
    {
        radius_ = parameters.radius;
    }
    public override void SetDimensions(float? radius = null, float? param2 = null, float? param3 = null)
    {
        if (radius == null)
        {
            throw new ArgumentException("Circle requires 1 dimension.");
        }
        radius_ = radius.Value;
    }
    public void SetRadius(float radius)
    {
        radius_ = radius;
    }

    protected override void AssignPoints()
    {
        vertices_ = GENERIC.AssignPoints_Circle(radius_, center_);

    }

    public override bool IsWithinBounds(Vector3 position)
    {
        // Convert the position to 2D
        Vector2 point = new Vector2(position.x, position.y);

        // Calculate the distance between the point and the center of the circle
        float distance = Vector2.Distance(center_, point);

        // The point is within the circle if the distance is less than or equal to the radius
        return distance <= radius_;
    }


}
