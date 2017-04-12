using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes asteroids move
/// </summary>
public class AsteroidsMover : MonoBehaviour {

	void Start ()
    {
		
	}
	
	void Update ()
    {
        foreach (Asteroid x in FindObjectsOfType<Asteroid>())
            x.Move();
	}
}
