using UnityEngine;
using System.Linq;

public abstract class Border
{
    protected Vector3 center_;
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
    protected Border(GameObject borderObject, float rotate = 0)
    {
        borderObject_ = borderObject;
        lineRenderer_ = borderObject_.GetComponent<LineRenderer>();
        edgeCollider_ = borderObject_.GetComponent<EdgeCollider2D>();
        center_ = borderObject_.transform.position;
        rotation_ = rotate;
    }
    protected Border(BorderParameters parameters, GameObject borderObject, float rotate = 0) : this(borderObject)
    {
        rotation_ = rotate;
    }
    public Vector3 GetCenter()
    {
        return center_;
    }

    public abstract void SetDimensions(float? param1 = null, float? param2 = null, float? param3 = null);

    public void ConfigLineRenderer()
    {
        lineRenderer_.useWorldSpace = true;
        lineRenderer_.loop = true;
        lineRenderer_.widthMultiplier = 0.5f;  // Change this value to change the thickness of the line

        // Create a gradient with 4 keys for a seamless transition
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] {
                new GradientColorKey(Color.green, 0.0f),
                new GradientColorKey(Color.blue, 0.5f),
                new GradientColorKey(Color.green, 1.0f) },
            new GradientAlphaKey[] {
                new GradientAlphaKey(1.0f, 0.0f),
                new GradientAlphaKey(1.0f, 1.0f) }
        );

        // Apply the gradient to the LineRenderer
        lineRenderer_.colorGradient = gradient;

        // Set LineRenderer width properties to be large and noticeable
        lineRenderer_.startWidth = 5f;
        lineRenderer_.endWidth = 5f;
        lineRenderer_.sortingLayerName = "Top"; // Replace "Top" with your sorting layer name
        lineRenderer_.sortingOrder = 1;
    }





    public void MakeBorder()
    {
        AssignPoints();
        if (rotation_ % 360 != 0)
            RotatePointAroundPivot();
        SetPositions();
        SetColliderPoints();
        ConfigLineRenderer();
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
