using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moving side
/// </summary>
public enum MoveSide { Forward, Back, Left, Right }

/// <summary>
/// Abstract control class
/// </summary>
public abstract class Control : MonoBehaviour {

    /// <summary>
    /// When object starts to move
    /// </summary>
    public static event System.Action<MoveSide> OnStartMoving;
    /// <summary>
    /// When object stops its moving
    /// </summary>
    public static event System.Action<MoveSide> OnStopMoving;
    /// <summary>
    /// When object starts to turn
    /// </summary>
    public static event System.Action<Vector2> OnStartTurning;
    /// <summary>
    /// When object shoots
    /// </summary>
    public static event System.Action OnShot;
    /// <summary>
    /// When camera approaches or leaves
    /// </summary>
    public static event System.Action<float> OnCameraDistanceChanging;

    [SerializeField]
    protected RuntimePlatform[] targetPlatforms; //Platforms for handling

	protected void Start ()
    {
        //Finding out whether target platforms list contains application platform. If it isn't there's no need to handle this platfroms type
        bool platformConfirmed = false;
        foreach (RuntimePlatform x in targetPlatforms)
            if (Application.platform == x)
            {
                platformConfirmed = true;
                break;
            }
        if (!platformConfirmed)
            this.enabled = false;
	}

    //Methods for casting events from child classes

    protected void StartMoving(MoveSide moveSide)
    {
        if (OnStartMoving != null)
            OnStartMoving(moveSide);
    }

    protected void StopMoving(MoveSide moveSide)
    {
        if (OnStopMoving != null)
            OnStopMoving(moveSide);
    }

    protected void StartTurning(Vector2 turnVector)
    {
        if (OnStartTurning != null)
            OnStartTurning(turnVector);
    }

    protected void Shoot()
    {
        if (OnShot != null)
            OnShot();
    }

    protected void ChangeCameraDistance(float moveValue)
    {
        if (OnCameraDistanceChanging != null)
            OnCameraDistanceChanging(moveValue);
    }
}
