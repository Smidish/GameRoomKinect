using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//passt die Kamera der Position des Spielers im Raum an
public class CameraScript : MonoBehaviour {	
	void Update () {
        Vector3 temp = new Vector3(BodySourceView.PlayerMovementHead.x, BodySourceView.PlayerMovementHead.y, BodySourceView.PlayerMovementHead.z-1);
        transform.position = temp;
    }
}
