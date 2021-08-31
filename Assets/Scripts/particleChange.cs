using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleChange : MonoBehaviour
{
    private ParticleSystem ps;
    public float particleStartSpeed;
    public float multiplier;
    [System.Obsolete]
    void Start()
    {
         ps = GetComponent<ParticleSystem>();
        //var speed = particleSystem.startSpeed()
        ps.startSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        particleStartSpeed += multiplier;
        var main = ps.main;
        main.startSpeed = particleStartSpeed + multiplier;
    }
}
