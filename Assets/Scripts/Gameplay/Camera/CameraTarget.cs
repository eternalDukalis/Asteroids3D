using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A place where camera should be
/// </summary>
public class CameraTarget : MonoBehaviour {

#pragma warning disable
    [SerializeField]
    [Range(1, 100)]
    float distance, minDistance, maxDistance; //Distance from parent object
#pragma warning restore

    /// <summary>
    /// Current position of camera target
    /// </summary>
    public Vector3 Position { get { return transform.position; } }
    /// <summary>
    /// Object the camera is looking at
    /// </summary>
    public Transform TargetObject { get { return transform.parent; } }

    void Awake () {
        BaseInput.OnCameraDistanceChanging += ChangeDistance;
        if (transform.localPosition.magnitude > 0)
            transform.localPosition *= distance / transform.localPosition.magnitude;
	}

    private void OnDestroy()
    {
        BaseInput.OnCameraDistanceChanging -= ChangeDistance;
    }

    private void ChangeDistance(float obj)
    {
        //Calculating and applying new distance
        float oldDistance = distance;
        distance += obj;
        if (distance > maxDistance)
            distance = maxDistance;
        if (distance < minDistance)
            distance = minDistance;
        transform.localPosition *= distance / oldDistance;
    }
}
