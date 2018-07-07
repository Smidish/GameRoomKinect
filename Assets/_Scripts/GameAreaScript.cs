using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//passt die Position der Stage dem Spieler an
public class GameAreaScript : MonoBehaviour {

    bool isStart;

	void Start () {
        isStart = true;
	}
	
	void Update () {
		if(BodySourceView.PlayerMovement.y != 0 && isStart)
        {
            //-2
            Vector3 temp = new Vector3(3.5f, BodySourceView.PlayerMovement.y-1, -65.7f);
            this.gameObject.transform.position = temp;
            isStart = false;
        }
	}
}
