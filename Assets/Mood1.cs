using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mood1 : MonoBehaviour {

    public float engineRevs;
    public float exhaustRate;

    ParticleSystem exhaust;

    float time;

    void Start()
    {
        exhaust = GetComponent<ParticleSystem>();
        time = 0f;
    }


    void Update()
    {
        exhaust.
        time += Time.deltaTime;
        exhaust.emissionRate = engineRevs * exhaustRate;
        if (time == 5f)
        {
            exhaust.enableEmission = false;
        }
    }
}
