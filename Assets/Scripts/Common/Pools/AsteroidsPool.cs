using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AsteroidsPool
/// </summary>
public class AsteroidsPool : GameObjectsPool {

    [SerializeField]
    float minDistance = 5;
    [SerializeField]
    float maxDistance = 50;
    [SerializeField]
    GameObject centerObject;

    /// <summary>
    /// Max distance for asteroids
    /// </summary>
    public float MaxDistance { get { return maxDistance; } }

    /// <summary>
    /// Create asteroids pool
    /// </summary>
    /// <param name="size">Pool size</param>
    public override void Create(int size)
    {
        //Checking whether object is asteroid
        if (objectPrefab.GetComponent<Asteroid>() == null)
        {
            Debug.LogError("This object is not asteroid. Unable to create pool.");
        }
        base.Create(size);
    }

    /// <summary>
    /// Return asteroid to pool
    /// </summary>
    /// <param name="obj">Asteroid game object</param>
    public override void Release(GameObject obj)
    {
        //Checking whether object is asteroid
        if (obj.GetComponent<Asteroid>() == null)
        {
            Debug.LogError("This object is not asteroid. You cannot return this to asteroids pool.");
            return;
        }
        base.Release(obj);
    }

    /// <summary>
    /// Set asteroid
    /// </summary>
    /// <param name="obj">Asteroid game object</param>
    public override void Init(GameObject obj)
    {
        //Randomizing posiiton
        float distance = Random.Range(minDistance, maxDistance);
        obj.GetComponent<Asteroid>().SetAtDistance(distance, centerObject);
        base.Init(obj);
    }
}
