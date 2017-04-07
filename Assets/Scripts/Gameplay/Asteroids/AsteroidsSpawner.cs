using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns asteroids
/// </summary>
public class AsteroidsSpawner : MonoBehaviour {

    [SerializeField]
    AsteroidsPool aPool; //The pool where asteroids are took from
    [SerializeField]
    int asteroidsCount; //Count of asteroids on scene

    static AsteroidsSpawner _instance;

    /// <summary>
    /// Current AsteroidsSpawner instance
    /// </summary>
    static public AsteroidsSpawner Instance { get { return _instance; } }

    /// <summary>
    /// Max distance for asteroids
    /// </summary>
    static public float MaxDistance { get { return _instance.aPool.MaxDistance; } }

	void Start ()
    {
        if (_instance != null)
            Destroy(_instance);
        _instance = this;
        //Creating pool and taking asteroids
        aPool.Create(aPool.Size);
        for (int i = 0; i < asteroidsCount; i++)
            Set();
	}

    /// <summary>
    /// Set asteroid on scene
    /// </summary>
    public void Set()
    {
        aPool.Take();
    }

    /// <summary>
    /// Remove asteroid from scene
    /// </summary>
    /// <param name="obj">Asteroid game object</param>
    public void Remove(Asteroid obj)
    {
        aPool.Release(obj.gameObject);
    }
}
