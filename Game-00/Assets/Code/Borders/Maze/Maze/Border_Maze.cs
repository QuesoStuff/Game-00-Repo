
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_Maze : Border
{
    protected int[,] mazePattern_;

    public Border_Maze(GameObject borderObject, int[,] mazePattern, float rotate = 0) : base(borderObject, rotate)
    {
        mazePattern_ = mazePattern;
        MakeBorder();
    }

    public override void SetDimensions(float? param1 = null, float? param2 = null, float? param3 = null) { }

    protected override void AssignPoints()
    {
        List<Vector3> vertices = new List<Vector3>();
        float xOffset = -mazePattern_.GetLength(1) / 2f;
        float yOffset = -mazePattern_.GetLength(0) / 2f;

        for (int i = 0; i < mazePattern_.GetLength(0); i++)
        {
            for (int j = 0; j < mazePattern_.GetLength(1); j++)
            {
                if (mazePattern_[i, j] == 1)
                {
                    vertices.Add(new Vector3(center_.x + j + xOffset, center_.y + i + yOffset, center_.z));
                }
            }
        }

        vertices_ = vertices.ToArray();
    }


}
