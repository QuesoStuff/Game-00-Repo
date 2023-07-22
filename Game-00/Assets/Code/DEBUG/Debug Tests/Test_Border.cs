using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Test_Border
{
    public static void Border_Player_InBound()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            bool inBound = Border_Main.instance_.IsInBounds(Player_Main.instance_.transform.position);
            UI_Main.instance_.UI_Debug_.Update_UI_Text(inBound.ToString());
        }
    }
    public static void BorderBuilds()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Rectangle Build Border: ");
            Border_Main.instance_.SetRectangle();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Square Build Border: ");
            Border_Main.instance_.SetSquare();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Trapezoid Build Border: ");
            Border_Main.instance_.SetTrapezoid();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Diamond Build Border: ");
            Border_Main.instance_.SetDiamond();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Crescent Moon Build Border: ");
            Border_Main.instance_.SetCrescentMoon();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Ellipse Build Border: ");
            Border_Main.instance_.SetEllipse();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Circle Build Border: ");
            Border_Main.instance_.SetCircle();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Cross Build Border: ");
            Border_Main.instance_.SetCross();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Cross Build Border: ");
            Border_Main.instance_.SetCross();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Hexagon Build Border: ");
            Border_Main.instance_.SetHexagon();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Pentagon Build Border: ");
            Border_Main.instance_.SetPentagon();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Semi-Circle Down Build Border: ");
            Border_Main.instance_.SetSemiCircleDown();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Pentagon Build Border: ");
            Border_Main.instance_.SetPentagon();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Semi-Circle Up Build Border: ");
            Border_Main.instance_.SetSemiCircleUp();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Semi-Circle Down Build Border: ");
            Border_Main.instance_.SetSemiCircleDown();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Semi-Circle Left Build Border: ");
            Border_Main.instance_.SetSemiCircleLeft();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Semi-Circle Right Build Border: ");
            Border_Main.instance_.SetSemiCircleRight();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Triangle Left Build Border: ");
            Border_Main.instance_.SetTriangleLeft();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Triangle Right Build Border: ");
            Border_Main.instance_.SetTriangleRight();
        }
    }
}
