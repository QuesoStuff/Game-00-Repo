using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Border_Main : MonoBehaviour
{
    public static Border_Main instance_;
    public Border currentBorder_;
    [SerializeField] private BorderParameters parameters_;
    [SerializeField] private GameObject borderObject_;
    private List<Action> borderShapeSetters_;

    public void SetDefaultParameters(float scale = 1)
    {
        parameters_ = new BorderParameters
        {
            sideLength = CONSTANTS.DEFAULT_SIDE_LENGTH * scale,
            width = CONSTANTS.DEFAULT_WIDTH * scale,
            height = CONSTANTS.DEFAULT_HEIGHT * scale,
            radius = CONSTANTS.DEFAULT_RADIUS * scale,
            semiMajorAxis = CONSTANTS.DEFAULT_SEMI_MAJOR_AXIS * scale,
            semiMinorAxis = CONSTANTS.DEFAULT_SEMI_MINOR_AXIS * scale,
            base1 = CONSTANTS.DEFAULT_BASE1 * scale,
            base2 = CONSTANTS.DEFAULT_BASE2 * scale,
            armLength = CONSTANTS.DEFAULT_ARM_LENGTH * scale,
            outerRadius = CONSTANTS.DEFAULT_OUTER_RADIUS * scale,
            innerRadius = CONSTANTS.DEFAULT_INNER_RADIUS * scale,
            pillLength = CONSTANTS.DEFAULT_PILL_LENGTH * scale,
            pillDiameter = CONSTANTS.DEFAULT_PILL_DIAMETER * scale,
            length = CONSTANTS.DEFAULT_LENGTH * scale
        };


    }

    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject, false);
        //SetDefaultParameters();
        InitBorderShapeSetters();
    }


    public void SetSquare()
    {
        SetBorder(new Border_Square(parameters_, GameObject.Instantiate(borderObject_)));
    }

    public void SetRectangle()
    {
        SetBorder(new Border_Rectangle(parameters_, GameObject.Instantiate(borderObject_)));
    }

    public void SetCircle()
    {
        SetBorder(new Border_Circle(parameters_, GameObject.Instantiate(borderObject_)));
    }

    public void SetPentagon()
    {
        SetBorder(new Border_Pentagon(parameters_, GameObject.Instantiate(borderObject_)));
    }

    public void SetTriangleUp()
    {
        SetBorder(new Border_Triangle_Up(parameters_, GameObject.Instantiate(borderObject_)));
    }

    public void SetTriangleDown()
    {
        SetBorder(new Border_Triangle_Down(parameters_, GameObject.Instantiate(borderObject_)));
    }

    public void SetTriangleLeft()
    {
        SetBorder(new Border_Triangle_Left(parameters_, GameObject.Instantiate(borderObject_)));
    }

    public void SetTriangleRight()
    {
        SetBorder(new Border_Triangle_Right(parameters_, GameObject.Instantiate(borderObject_)));
    }

    public void SetTrapezoid()
    {
        SetBorder(new Border_Trapezoid(parameters_, GameObject.Instantiate(borderObject_)));
    }

    public void SetEllipse()
    {
        SetBorder(new Border_Ellipse(parameters_, GameObject.Instantiate(borderObject_)));
    }

    public void SetDiamond()
    {
        SetBorder(new Border_Diamond(parameters_, GameObject.Instantiate(borderObject_)));
    }
    public void SetSemiCircleLeft()
    {
        SetBorder(new Border_SemiCircle_Left(parameters_, GameObject.Instantiate(borderObject_)));
    }

    public void SetSemiCircleRight()
    {
        SetBorder(new Border_SemiCircle_Right(parameters_, GameObject.Instantiate(borderObject_)));
    }

    public void SetSemiCircleUp()
    {
        SetBorder(new Border_SemiCircle_Up(parameters_, GameObject.Instantiate(borderObject_)));
    }

    public void SetSemiCircleDown()
    {
        SetBorder(new Border_SemiCircle_Down(parameters_, GameObject.Instantiate(borderObject_)));
    }

    public void SetCrescentMoon()
    {
        SetBorder(new Border_CrescentMoon(parameters_, GameObject.Instantiate(borderObject_)));
    }

    public void SetCross()
    {
        SetBorder(new Border_Cross(parameters_, GameObject.Instantiate(borderObject_)));
    }

    public void SetDonut()
    {
        SetBorder(new Border_Donut(parameters_, GameObject.Instantiate(borderObject_)));
    }

    public void SetHexagon()
    {
        SetBorder(new Border_Hexagon(parameters_, GameObject.Instantiate(borderObject_)));
    }

    public void SetStar()
    {
        SetBorder(new Border_Star(parameters_, GameObject.Instantiate(borderObject_)));
    }
    public void SetPill()
    {
        SetBorder(new Border_Pill(parameters_, GameObject.Instantiate(borderObject_)));
    }

    private void InitBorderShapeSetters()
    {
        borderShapeSetters_ = new List<Action>
    {
        SetSquare,
        SetRectangle,
        SetCircle,
        SetPentagon,
        SetTriangleUp,
        SetTriangleDown,
        SetTriangleLeft,
        SetTriangleRight,
        SetTrapezoid,
        SetEllipse,
        SetDiamond,
        SetSemiCircleLeft,
        SetSemiCircleRight,
        SetSemiCircleUp,
        SetSemiCircleDown,
        SetCrescentMoon,
        SetCross,
        SetDonut,
        SetHexagon,
        SetStar,
        SetPill
    };
    }

    // Randomly select a method from the list and invoke it
    public void SetRandomShape()
    {
        System.Random rand = new System.Random();
        int randomIndex = rand.Next(borderShapeSetters_.Count);
        borderShapeSetters_[randomIndex].Invoke();
    }
    public void SetBorder(Border border)
    {
        DestroyBorder();
        currentBorder_ = border;
        currentBorder_.MakeBorder();
    }




    public void DestroyBorder()
    {

        if (currentBorder_ != null)
        {
            currentBorder_ = null;
        }
        else
        {
            //Debug.LogWarning("No border currently exists to destroy.");
        }

    }

    public bool IsInBounds(Vector3 position)
    {
        if (currentBorder_ != null)
        {
            return currentBorder_.IsWithinBounds(position);
        }
        else
        {
            //Debug.LogWarning("No border currently exists to check.");
            return false;
        }
    }
}
