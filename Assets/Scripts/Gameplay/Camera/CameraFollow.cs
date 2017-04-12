using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera following its' target
/// </summary>
public class CameraFollow : MonoBehaviour {

    [SerializeField]
    CameraTarget target;
    [SerializeField]
    float moveSpeed = 1;

	void Start ()
    {
        transform.position = target.Position;
	}

    private void Update()
    {
        //Gradual moving to target
        Vector3 delta = (target.Position - transform.position).normalized * moveSpeed * Time.deltaTime;
        if ((target.Position - transform.position).magnitude > delta.magnitude)
            transform.position += (target.Position - transform.position).normalized * moveSpeed * Time.deltaTime;
        else
            transform.position = target.Position;
        transform.LookAt(target.TargetObject, target.TargetObject.transform.up);
    }
}
