﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Missile behavior
/// </summary>
public class Missile : MonoBehaviour {

    [SerializeField]
    float moveSpeed = 1;
    MissilesPool _pool;

	void Start ()
    {
		
	}

    //Missile should be removed if it collides with something (except asteroids and starship)
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.GetComponent<Asteroid>() == null) && (collision.gameObject.GetComponent<Starship>() == null))
        {
            Remove();
        }
    }

    /// <summary>
    /// Moves missile by step
    /// </summary>
    public void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        if ((_pool == null) || ((transform.position - _pool.CenterPosition).magnitude > _pool.MaxDistance))
            Remove();
    }

    /// <summary>
    /// Set missile
    /// </summary>
    /// <param name="position">New position</param>
    /// <param name="angle">New angle</param>
    /// <param name="pool">Pool for returning</param>
    public void Set(Vector3 position, Vector3 angle, MissilesPool pool)
    {
        transform.position = position;
        transform.eulerAngles = angle;
        _pool = pool;
    }

    /// <summary>
    /// Remove missile
    /// </summary>
    public void Remove()
    {
        if (_pool != null)
            _pool.Release(this.gameObject);
        else
            Destroy(gameObject);
    }
}
