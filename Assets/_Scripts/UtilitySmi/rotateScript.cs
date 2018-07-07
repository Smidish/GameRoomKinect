using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateScript : MonoBehaviour {

	//rotiert Objekt, wenn man Script attached
	void Update () {
        transform.Rotate(Time.deltaTime*-10, 0, 0);
    }
}
