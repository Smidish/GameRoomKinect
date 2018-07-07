﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Bewegt gespornte Objekte nach vorne, mit unterschiedlicher Geschwindigkeit
public class moveObjects : MonoBehaviour
{
    public float speed = -4;
    public static float plusminusspeed = 0;

    private void Start()
    {
        speed = speed * Random.Range(1, 5) * 0.35f;
    }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, GM.vertVel, speed + plusminusspeed);
    }
}