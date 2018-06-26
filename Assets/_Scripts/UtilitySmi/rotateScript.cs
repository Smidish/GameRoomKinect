using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.Rotate(Time.deltaTime*-10, 0, 0);
    }
}
