using System; // needed for Unity Action Events (Type of Delegate)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_Move
{
    void Move_None();
    void Move_Up();
    void Move_Down();
    void Move_Left();
    void Move_Right();

    void Move_Up_Slow();
    void Move_Down_Slow();
    void Move_Left_Slow();
    void Move_Right_Slow();

    void Move_Up_Fast();
    void Move_Down_Fast();
    void Move_Left_Fast();
    void Move_Right_Fast();

    void Move_45();
    void Move_135();
    void Move_225();
    void Move_315();

    void Move_45_Slow();
    void Move_135_Slow();
    void Move_225_Slow();
    void Move_315_Slow();

    void Move_45_Fast();
    void Move_135_Fast();
    void Move_225_Fast();
    void Move_315_Fast();

    Vector2 Moving();


}
