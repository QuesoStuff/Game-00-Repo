using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border_Main : MonoBehaviour
{
    public static Border_Main instance_;
    public Border currentBorder_;

    [Header("Border Parameters")]
    [SerializeField] private BorderParameters parameters_;
    [SerializeField] private GameObject borderObject_;

    public void SetDefaultParameters()
    {
        parameters_ = new BorderParameters
        {
            sideLength = 100,
            width = 100,
            height = 100,
            radius = 100,
            semiMajorAxis = 100,
            semiMinorAxis = 100,
            base1 = 100,
            base2 = 100,
            armLength = 100,
            outerRadius = 100,
            innerRadius = 50,  // Inner radius is usually smaller for star shape
            pillLength = 100,
            pillDiameter = 50,  // Pill diameter is usually smaller than pill length
            length = 100
        };


    }

    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
        SetDefaultParameters();
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
    public void SetMaze_Easy()
    {
        SetBorder(new Border_Maze(GameObject.Instantiate(borderObject_), CONSTANTS_LEVEL.instance_.LEVEL_EASY));
    }
    public void SetMaze_Medium()
    {
        SetBorder(new Border_Maze(GameObject.Instantiate(borderObject_), CONSTANTS_LEVEL.instance_.LEVEL_MEDIUM));
    }
    public void SetMaze_Hard()
    {
        SetBorder(new Border_Maze(GameObject.Instantiate(borderObject_), CONSTANTS_LEVEL.instance_.LEVEL_HARD));
    }
    /*
        public void SetMazeSimple()
        {
            SetBorder(new SimpleMaze(GameObject.Instantiate(borderObject_)));
        }
        public void SetMazeMedium()
        {
            SetBorder(new MediumMaze(GameObject.Instantiate(borderObject_)));
        }
        public void SetMazeHard()
        {
            SetBorder(new ComplexMaze(GameObject.Instantiate(borderObject_)));
        }
        public void SetmazeRandom()
        {
            SetBorder(new ComplexMaze(GameObject.Instantiate(borderObject_)));
        }
        */
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
            GameObject.Destroy(currentBorder_.GetBorderObject());
            currentBorder_ = null;
        }
        else
        {
            Debug.Log("No border currently exists to destroy.");
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
            Debug.LogWarning("No border currently exists to check.");
            return false;
        }
    }
}
