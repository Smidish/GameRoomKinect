using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {	
	void Update () {
        Vector3 temp = new Vector3(moveorb.playerMovementCamera.x, moveorb.playerMovementCamera.y, -1.0f);
        transform.position = temp;
	}
}
