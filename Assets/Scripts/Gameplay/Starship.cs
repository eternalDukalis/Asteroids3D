using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Starship management
/// </summary>
public class Starship : MonoBehaviour {

    Dictionary<MoveSide, Coroutine> moveCoroutines;

    [SerializeField]
    float moveSpeed = 1;

	void Start ()
    {
        moveCoroutines = new Dictionary<MoveSide, Coroutine>();
        BaseInput.OnStartMoving += StartMoving;
        BaseInput.OnStopMoving += StopMoving;
        BaseInput.OnStartTurning += StartTurning;
        BaseInput.OnShot += Shoot;
	}

    //Event handling methods

    private void Shoot()
    {
        throw new System.NotImplementedException();
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
