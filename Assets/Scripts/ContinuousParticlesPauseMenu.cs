using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class makes sure that the particle system of the pause menu canvas to continue even if the Time.timescale is set to 0
/// </summary>
public class ContinuousParticlesPauseMenu: MonoBehaviour
{
    private float lastTime;
    private ParticleSystem ps;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Start()
    {
        lastTime = Time.realtimeSinceStartup;
    }

    void Update()
    {
        float deltaTime = Time.realtimeSinceStartup - lastTime;
        ps.Simulate(deltaTime, true, false);
        lastTime = Time.realtimeSinceStartup;
    }
}