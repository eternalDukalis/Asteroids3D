using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Starship management
/// </summary>
public class Starship : MonoBehaviour {

    Dictionary<MoveSide, Coroutine> moveCoroutines;

#pragma warning disable
    [SerializeField]
    float moveSpeed = 1;
    [SerializeField]
    float bounceStartSpeed = 15;
    [SerializeField]
    float bounceAcceleration = 12;
    [SerializeField]
    MissilesPool mPool;
#pragma warning restore

    /// <summary>
    /// When starship collides with asteroid
    /// </summary>
    public static event System.Action OnAsteroidCollide;

	void Start ()
    {
        moveCoroutines = new Dictionary<MoveSide, Coroutine>();
        mPool.Create(mPool.Size);
        BaseInput.OnStartMoving += StartMoving;
        BaseInput.OnStopMoving += StopMoving;
        BaseInput.OnStartTurning += StartTurning;
        BaseInput.OnShot += Shoot;
	}

    //Starship collision handling
    private void OnCollisionEnter(Collision collision)
    {
        //When starship collides with asteroid
        if (collision.gameObject.GetComponent<Asteroid>() != null)
        {
            Vector3 direction = (transform.position - collision.transform.position).normalized;
            StartCoroutine(fadeMove(direction, bounceStartSpeed, bounceAcceleration));
            if (OnAsteroidCollide != null)
                OnAsteroidCollide();
        }
    }

    //Event handling methods

    private void Shoot()
    {
        mPool.Take();
    }

    private void StartTurning(Vector2 obj)
    {
        transform.localEulerAngles += new Vector3(obj.y, obj.x, 0);
    }

    private void StopMoving(MoveSide obj)
    {
        //Stopping coroutine
        if (moveCoroutines.ContainsKey(obj))
            StopCoroutine(moveCoroutines[obj]);
        else
            Debug.LogWarning("Trying to stop a nonexistent moving.");
    }

    private void StartMoving(MoveSide obj)
    {
        //Starting coroutine
        if (moveCoroutines.ContainsKey(obj))
        {
            StopCoroutine(moveCoroutines[obj]);
            moveCoroutines[obj] = StartCoroutine(move(obj));
        }
        else
            moveCoroutines.Add(obj, StartCoroutine(move(obj)));
    }

    //Coroutines

    IEnumerator move(MoveSide side)
    {
        while (true)
        {
            transform.position += MoveSideToAxis(side) * Time.deltaTime * moveSpeed;
            yield return null;
        }
    }

    //Fading moving
    IEnumerator fadeMove(Vector3 direction, float initialSpeed, float acceleration)
    {
        float speed = initialSpeed;
        while ((speed - acceleration) * Time.deltaTime > 0)
        {
            transform.position += direction * Time.deltaTime * speed;
            speed -= acceleration * Time.deltaTime;
            yield return null;
        }
        transform.position += direction * Time.deltaTime * speed;
    }

    //Additional methods

    Vector3 MoveSideToAxis(MoveSide side)
    {
        switch (side)
        {
            case MoveSide.Back:
                return -transform.forward;
            case MoveSide.Forward:
                return transform.forward;
            case MoveSide.Left:
                return -transform.right;
            case MoveSide.Right:
                return transform.right;
        }
        return new Vector3();
    }
}
