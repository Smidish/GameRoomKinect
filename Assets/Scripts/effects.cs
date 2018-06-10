using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effects : MonoBehaviour {

    public float speed = -4;
    public float v = 1.0f;

	
	// Update is called once per frame // das ist mein Versuch den Speed anzupassen..spakt aber rum...
	void Update () {
        // if (GM.timeTotal > 10)
        //{
        // v = 1 - Mathf.Floor(GM.timeTotal / 100) * 0.5f;
        // speed = speed * v;
        // StartCoroutine(Example());
        //}

   

        GetComponent<Rigidbody>().velocity = new Vector3(0, GM.vertVel, speed); // Bewegung nach vorne



        if (gameObject.name == "Capsule(Clone)")
        {
            transform.Rotate(3, 0, 0);           // Kapsel rotiert
        }

        if (gameObject.name == "coin(Clone)")
        {
            transform.Rotate(0, 0, 3);          // Münze rotiert
        }

     

    }
    /*
    IEnumerator Example()
    {
      // print(Time.time);
        yield return new WaitForSeconds(5);
      //  print(Time.time);
    }
    */
}
