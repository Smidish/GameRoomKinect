using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {	
	void Update () {
        //Vector3 temp = new Vector3(movePlayer.playerMovementCamera.x, movePlayer.playerMovementCamera.y, movePlayer.playerMovementCamera.z);
        Vector3 temp = new Vector3(BodySourceView.PlayerMovementHead.x, BodySourceView.PlayerMovementHead.y, BodySourceView.PlayerMovementHead.z);
        //transform.position = BodySourceView.PlayerMovementHead;
        transform.position = temp;
    }
}
