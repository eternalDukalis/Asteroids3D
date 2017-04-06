using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Desktop control class
/// </summary>
public class DesktopInput : BaseInput {

    Vector3 previousMousePosition;

	void Update ()
    {
        //Keys downs and ups handling
        if (Input.GetKeyDown(KeyCode.W))
            base.StartMoving(MoveSide.Forward);
        if (Input.GetKeyUp(KeyCode.W))
            base.StopMoving(MoveSide.Forward);

        if (Input.GetKeyDown(KeyCode.A))
            base.StartMoving(MoveSide.Left);
        if (Input.GetKeyUp(KeyCode.A))
            base.StopMoving(MoveSide.Left);

        if (Input.GetKeyDown(KeyCode.S))
            base.StartMoving(MoveSide.Back);
        if (Input.GetKeyUp(KeyCode.S))
            base.StopMoving(MoveSide.Back);

        if (Input.GetKeyDown(KeyCode.D))
            base.StartMoving(MoveSide.Right);
        if (Input.GetKeyUp(KeyCode.D))
            base.StartMoving(MoveSide.Right);

        if ((Input.GetMouseButton(1)) && ((Input.mousePosition - previousMousePosition).magnitude > 0))
            base.StartTurning(Input.mousePosition - previousMousePosition);
        previousMousePosition = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
            base.Shoot();

        if (Input.mouseScrollDelta.y != 0)
            base.ChangeCameraDistance(Input.mouseScrollDelta.y);
    }
}
