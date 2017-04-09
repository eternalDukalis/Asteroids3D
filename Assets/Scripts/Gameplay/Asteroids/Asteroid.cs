using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Asteroid behavior
/// </summary>
public class Asteroid : MonoBehaviour {

    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float turnSpeed;
    Vector3 moveVector; //Asteroid moves with this vector per second
    Vector3 turnVector; //Asteroid rotates with this vector per second
    GameObject centerObject;

    /// <summary>
    /// When asteroid is destroyed
    /// </summary>
    public static event System.Action OnAsteroidDestroy;

	void Start ()
    {
        moveVector = RandomVector(moveSpeed);
        turnVector = RandomVector(turnSpeed);
	}

    private void Update()
    {
        transform.position += moveVector * Time.deltaTime;
        //If asteroid is too far then we need to remove it and create a new one
        if ((centerObject != null) && ((centerObject.transform.position - transform.position).magnitude > AsteroidsSpawner.MaxDistance))
        {
            AsteroidsSpawner.Instance.Remove(this);
            AsteroidsSpawner.Instance.Set();
        }
        transform.localEulerAngles += turnVector * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //When asteroid collides with missile
        if ((collision.gameObject.GetComponent<Missile>() != null) && (collision.gameObject.activeInHierarchy))
        {
            collision.gameObject.GetComponent<Missile>().Remove();
            AsteroidsSpawner.Instance.Remove(this);
            AsteroidsSpawner.Instance.Set();
            if (OnAsteroidDestroy != null)
                OnAsteroidDestroy();
        }
    }

    /// <summary>
    /// Set asteroid at given distance
    /// </summary>
    /// <param name="distance">Distance</param>
    public void SetAtDistance(float distance, GameObject center)
    {
        centerObject = center;
        transform.position = centerObject.transform.position + RandomVector(distance);
    }

    //Random Vector3 with given length
    Vector3 RandomVector(float length)
    {
        Vector3 res = (new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f))).normalized;
        return res * length;
    }
}