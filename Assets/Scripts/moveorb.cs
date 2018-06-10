using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class moveorb : MonoBehaviour {
    public KeyCode moveL; 
    public KeyCode moveR;
    public KeyCode jump;

    public float horizVel = 0;  // Horizontal linie für rechts und links bewegen
    public int laneNum = 2;     //Raumeinschränkung, damit Spieler nicht über den Rand läuft
    public string controllLocked = "n";

    public Transform boomObj;

    public GameObject mPlayer;
    private float xPlayer;
	
	// Update is called once per frame
	void Update () { 
        xPlayer = BodySourceView.PlayerMovement.x;
        Vector3 temp = new Vector3(xPlayer*2, 0, 0);//Werte von 3 bis -6
        mPlayer.transform.position = temp;
        Debug.Log(mPlayer.transform.position);
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, 0, 0); // Spieler steht und ist nach rechts/links beweglich wenn Variable horizVel verändert wird

        if ((Input.GetKeyDown (moveL)) && (laneNum > 1) && (controllLocked == "n")) // nach links
        {
            horizVel = -2;
            StartCoroutine (stopSlide());
            laneNum -= 1;       //damit der Spieler nicht zu weit nach draußen geht
            controllLocked = "y";
        }

        if ((Input.GetKeyDown(moveR)) && (laneNum <3) && (controllLocked == "n"))   //nach rechts
        {
            horizVel = 2;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controllLocked = "y";
        }
    }



    void OnTriggerEnter(Collider other)
    {
   
        if (other.gameObject.name == "Coin(Clone)")

        {
            Debug.Log("coin collision");
            Destroy(other.gameObject);
            GM.coinTotal += 1;
        }
        else if(other.gameObject.name == "Enemy(Clone)") 
        {
            Debug.Log("enemy collision");
            Destroy(other.gameObject);
            GM.zVelAdj = 0;
            GM.coinTotal -= 2;
            //Instantiate(boomObj, transform.position, boomObj.rotation); // aktivieren, wenn brutale Version^^

        }
        else if(other.gameObject.name == "Boni(Clone)")
        {
            Debug.Log("boni collision");
            Destroy(other.gameObject);

        }
    }


    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(.5f);
        horizVel = 0;
        controllLocked = "n";

    }
}
