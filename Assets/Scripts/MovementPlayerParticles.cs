using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayerParticles : MonoBehaviour
{
    void Start()
    {
        ParticleSystem.MainModule main = GetComponent<ParticleSystem>().main;
        main.startColor = GameObject.Find("Player").GetComponent<SpriteRenderer>().color;
    }
}
