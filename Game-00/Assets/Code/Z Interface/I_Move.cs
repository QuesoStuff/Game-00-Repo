using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The I_Move interface is used for objects that are capable of moving within the game environment.
/// It provides methods for controlling speed, direction, and special actions such as dashing and knockback.
/// </summary>
public interface I_Move
{
    /// <summary>
    /// Get the state of the object's movement.
    /// </summary>
    bool GetIsMoving();

    /// <summary>
    /// Get the object's ability to dash.
    /// </summary>
    bool GetCanDash();

    /// <summary>
    /// Set the object's ability to dash.
    /// </summary>
    void SetCanDash(bool state);

    /// <summary>
    /// Set the state of the object's movement.
    /// </summary>
    void SetIsMoving(bool state);

    /// <summary>
    /// Check if the object is currently dashing.
    /// </summary>
    bool GetIsDashing();

    /// <summary>
    /// Get the current velocity of the object.
    /// </summary>
    Vector2 GetVelocity();

    /// <summary>
    /// Get the current speed of the object.
    /// </summary>
    float GetCurrSpeed();

    /// <summary>
    /// Get the current acceleration speed of the object.
    /// </summary>
    float Get_AccelerateSpeed();

    /// <summary>
    /// Set the current acceleration speed of the object.
    /// </summary>
    void Set_AccelerateSpeed(float newAcc);

    /// <summary>
    /// Set the new direction for the object.
    /// </summary>
    void Set(float x, float y);

    /// <summary>
    /// Set the new direction for the object based on a Vector2.
    /// </summary>
    void Set(Vector2 velocity);

    /// <summary>
    /// Scale the object's current direction.
    /// </summary>
    void Set(float scale);

    /// <summary>
    /// Update the object's velocity based on its direction.
    /// </summary>
    void SetVelocity();

    /// <summary>
    /// Move the object upwards.
    /// </summary>
    void Move_Up();

    /// <summary>
    /// Move the object downwards.
    /// </summary>
    void Move_Down();

    /// <summary>
    /// Move the object to the left.
    /// </summary>
    void Move_Left();

    /// <summary>
    /// Move the object to the right.
    /// </summary>
    void Move_Right();

    /// <summary>
    /// Stop the object's movement.
    /// </summary>
    void Move_None();

    /// <summary>
    /// Move the object upwards at a slow speed.
    /// </summary>
    void Move_Up_Slow();

    /// <summary>
    /// Move the object downwards at a slow speed.
    /// </summary>
    void Move_Down_Slow();

    /// <summary>
    /// Move the object to the left at a slow speed.
    /// </summary>
    void Move_Left_Slow();

    /// <summary>
    /// Move the object to the right at a slow speed.
    /// </summary>
    void Move_Right_Slow();

    /// <summary>
    /// Move the object upwards at a normal speed.
    /// </summary>
    void Move_Up_Normal();

    /// <summary>
    /// Move the object downwards at a normal speed.
    /// </summary>
    void Move_Down_Normal();

    /// <summary>
    /// Move the object to the left at a normal speed.
    /// </summary>
    void Move_Left_Normal();

    /// <summary>
    /// Move the object to the right at a normal speed.
    /// </summary>
    void Move_Right_Normal();

    /// <summary>
    /// Move the object upwards at a fast speed.
    /// </summary>
    void Move_Up_Fast();

    /// <summary>
    /// Move the object downwards at a fast speed.
    /// </summary>
    void Move_Down_Fast();

    /// <summary>
    /// Move the object to the left at a fast speed.
    /// </summary>
    void Move_Left_Fast();

    /// <summary>
    /// Move the object to the right at a fast speed.
    /// </summary>
    void Move_Right_Fast();

    /// <summary>
    /// Move the object at a 45 degree angle.
    /// </summary>
    void Move_45();

    /// <summary>
    /// Move the object at a 135 degree angle.
    /// </summary>
    void Move_135();

    /// <summary>
    /// Move the object at a 225 degree angle.
    /// </summary>
    void Move_225();

    /// <summary>
    /// Move the object at a 315 degree angle.
    /// </summary>
    void Move_315();

    /// <summary>
    /// Move the object at a 45 degree angle at a slow speed.
    /// </summary>
    void Move_45_Slow();

    /// <summary>
    /// Move the object at a 135 degree angle at a slow speed.
    /// </summary>
    void Move_135_Slow();

    /// <summary>
    /// Move the object at a 225 degree angle at a slow speed.
    /// </summary>
    void Move_225_Slow();

    /// <summary>
    /// Move the object at a 315 degree angle at a slow speed.
    /// </summary>
    void Move_315_Slow();

    /// <summary>
    /// Move the object at a 45 degree angle at a fast speed.
    /// </summary>
    void Move_45_Fast();

    /// <summary>
    /// Move the object at a 135 degree angle at a fast speed.
    /// </summary>
    void Move_135_Fast();

    /// <summary>
    /// Move the object at a 225 degree angle at a fast speed.
    /// </summary>
    void Move_225_Fast();

    /// <summary>
    /// Move the object at a 315 degree angle at a fast speed.
    /// </summary>
    void Move_315_Fast();

    /// <summary>
    /// Update the object's movement state and return its new position.
    /// </summary>
    Vector2 Moving();

    /// <summary>
    /// Update the object's movement state with acceleration and return its new position.
    /// </summary>
    Vector2 Moving_Accelarate();

    /// <summary>
    /// Initiate a dash action.
    /// </summary>
    IEnumerator StartDash();

    /// <summary>
    /// Initiate a dash action for a specified duration.
    /// </summary>
    IEnumerator StartDash(float dashDuration);

    /// <summary>
    /// Initiate a knockback action.
    /// </summary>
    IEnumerator KnockbackCoroutine();

    /// <summary>
    /// Trigger a knockback action.
    /// </summary>
    void KnockBack();

    /// <summary>
    /// Set a random speed for the object within a range.
    /// </summary>
    void Set_Random_Speed();
}
