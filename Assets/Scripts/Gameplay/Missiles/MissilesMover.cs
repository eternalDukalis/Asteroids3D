using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes missiles move
/// </summary>
public class MissilesMover : MonoBehaviour {

	void Start ()
    {
		
	}
	
	void Update ()
    {
        foreach (Missile x in FindObjectsOfType<Missile>())
            x.Move();
	}
}
