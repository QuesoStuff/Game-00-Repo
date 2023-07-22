using UnityEngine;
using System.Linq;

public abstract class Border
{
    protected Vector3 center_;
    protected Transform target_;
    protected LineRenderer lineRenderer_;
    protected EdgeCollider2D edgeCollider_;
    protected GameObject borderObject_;
    protected Vector3[] vertices_;
    protected float rotation_;

    public GameObject GetBorderObject()
    {
        Vector3 scale = borderObject_.transform.localScale;
        return borderObject_;
    }
    protected Border(GameObject borderObject, float rotate = 0, Transform target = null)
    {
        borderObject_ = borderObject;
        lineRenderer_ = borderObject_.GetComponent<LineRenderer>();
        edgeCollider_ = borderObject_.GetComponent<EdgeCollider2D>();
        if (target)
            center_ = target_.position;
        else
            center_ = CONSTANTS.DEFAULT_START_POINT;
        rotation_ = rotate;
    }
    protected Border(BorderParameters parameters, GameObject borderObject, float rotate = 0, Transform target = null) : this(borderObject, rotate, target)
    {
    }
    public Vector3 GetCenter()
    {
        return center_;
    }

    public abstract void SetDimensions(float? param1 = null, float? param2 = null, float? param3 = null);






    public void MakeBorder()
    {
        AssignPoints();
        if (rotation_ % 360 != 0)
            RotatePointAroundPivot();
        SetPositions();
        SetColliderPoints();
        //  ConfigLineRenderer();
    }






    protected void SetColliderPoints(Vector3[] vertices)
    {
        Vector2[] colliderPoints = new Vector2[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            colliderPoints[i] = new Vector2(vertices[i].x, vertices[i].y);
        }
        edgeCollider_.points = colliderPoints;
    }


    protected abstract void AssignPoints();

    private void RotatePointAroundPivot()
    {
        for (int i = 0; i < vertices_.Length; i++)
        {
            vertices_[i] = GENERIC.RotatePointAroundPivot(vertices_[i], center_, rotation_);
        }
    }
    protected void SetColliderPoints()
    {
        Vector2[] colliderPoints = new Vector2[vertices_.Length];
        for (int i = 0; i < vertices_.Length; i++)
        {
            colliderPoints[i] = new Vector2(vertices_[i].x, vertices_[i].y);
        }
        edgeCollider_.points = colliderPoints;
    }
    public virtual void SetPositions()
    {
        lineRenderer_.positionCount = vertices_.Length;
        lineRenderer_.SetPositions(vertices_);
    }
    public virtual bool IsWithinBounds(Vector3 position)
    {
        // Adjust the Z coordinate of the position to match that of the Border object
        position.z = center_.z;

        return edgeCollider_.OverlapPoint(new Vector2(position.x, position.y));
    }


}
