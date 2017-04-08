using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Missiles pool
/// </summary>
public class MissilesPool : GameObjectsPool {

#pragma warning disable
    [SerializeField]
    float maxDistance = 50;
    [SerializeField]
    GameObject centerObject, emissionPlace;
#pragma warning restore

    /// <summary>
    /// Max distance for missiles
    /// </summary>
    public float MaxDistance { get { return maxDistance; } }

    /// <summary>
    /// Position of center object;
    /// </summary>
    public Vector3 CenterPosition { get { return centerObject.transform.position; } }

    /// <summary>
    /// Create missiles pool
    /// </summary>
    /// <param name="size">Pool size</param>
    public override void Create(int size)
    {
        //Checking whether object is missile
        if (objectPrefab.GetComponent<Missile>() == null)
        {
            Debug.LogError("This object is not missile. Unable to create pool.");
        }
        base.Create(size);
    }

    /// <summary>
    /// Return missile to missiles pool
    /// </summary>
    /// <param name="obj">Missile game object</param>
    public override void Release(GameObject obj)
    {
        //Checking whether object is missile
        if (obj.GetComponent<Missile>() == null)
        {
            Debug.LogError("This object is not missile. You cannot return this to missiles pool.");
            return;
        }
        base.Release(obj);
    }

    /// <summary>
    /// Set missile
    /// </summary>
    /// <param name="obj"></param>
    public override void Init(GameObject obj)
    {
        //Setting position and angle
        obj.GetComponent<Missile>().Set(emissionPlace.transform.position, centerObject.transform.eulerAngles, this);
        base.Init(obj);
    }
}
