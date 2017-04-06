using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spaceship fire
/// </summary>
public class Fire : MonoBehaviour {

    //When spaceship is moving start speed of particles increases, otherwise it decreases
    [SerializeField]
    float movingMultiplier = 20;
    float currentSpeed;
    ParticleSystem particles;

	void Start ()
    {
        particles = GetComponent<ParticleSystem>();
        currentSpeed = particles.main.startSpeed.constant;
        BaseInput.OnStartMoving += StartMoving;
        BaseInput.OnStopMoving += StopMoving;
	}

    private void StopMoving(MoveSide obj)
    {
        SetSpeed(false);
    }

    private void StartMoving(MoveSide obj)
    {
        SetSpeed(true);
    }

    void SetSpeed(bool isMoving)
    {
        ParticleSystem.MainModule main = particles.main;
        main.startSpeed = new ParticleSystem.MinMaxCurve(currentSpeed * (isMoving.GetHashCode() * (movingMultiplier - 1) + 1));
    }
}
