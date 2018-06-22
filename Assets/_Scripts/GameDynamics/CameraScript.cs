using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {	
	void Update () {
        Vector3 temp = new Vector3(moveorb.playerMovement.x, moveorb.playerMovement.y, -3.0f);
        transform.position = temp;
	}
}
