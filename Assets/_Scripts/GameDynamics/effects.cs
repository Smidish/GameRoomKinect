using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effects : MonoBehaviour
{

    public float speed = -4;

    private void Start()
    {
        speed = speed * Random.Range(10, 100) * 0.035f;
    }

    void Update()
    {
        //IMPORTANT
        GetComponent<Rigidbody>().velocity = new Vector3(0, GM.vertVel, speed); // Bewegung nach vorne
    }
}