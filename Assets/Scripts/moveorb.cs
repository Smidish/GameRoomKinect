//Script basierend auf Jenny Rinks Wolfgame
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class moveorb : MonoBehaviour {

    public bool KeyboardInput;

    public float xWertApassen;
    public float yWertApassen;
    public float yWertHoch;

    public KeyCode moveL; 
    public KeyCode moveR;

    public float horizVel = 0;  // Horizontal linie für rechts und links bewegen
    public int laneNum = 2;     //Raumeinschränkung, damit Spieler nicht über den Rand läuft
    public string controllLocked = "n";

    public Transform boomObj;

    public static Vector3 playerMovement;

    public GameObject mPlayer;
    private float xPlayer;
    private float yPlayer;

    // Update is called once per frame
    void Update () { 
        

        if (KeyboardInput) //Keyboard Input
        {
            GetComponent<Rigidbody>().velocity = new Vector3(horizVel, 0, 0);
            if ((Input.GetKeyDown(moveL)) && (laneNum > 1) && (controllLocked == "n")) // nach links
            {
                horizVel = -2;
                StartCoroutine(stopSlide());
                laneNum -= 1;    
                controllLocked = "y";
            }
            if ((Input.GetKeyDown(moveR)) && (laneNum < 3) && (controllLocked == "n"))   //nach rechts
            {
                horizVel = 2;
                StartCoroutine(stopSlide());
                laneNum += 1;
                controllLocked = "y";
            }
        }
        else //Kinect Input
        {
            xPlayer = BodySourceView.PlayerMovement.x;
            yPlayer = BodySourceView.PlayerMovement.y;
            Vector3 temp = new Vector3(xPlayer * xWertApassen, yPlayer * yWertApassen + yWertHoch, 0);//Werte von 3 bis -6
            mPlayer.transform.position = temp;
            Debug.Log(mPlayer.transform.position);
            playerMovement = temp;
        }
      

        
    }

    void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.name == "Coin(Clone)")
        if (other.gameObject.name == "Coin_new(Clone)")
        {
            Debug.Log("coin collision");
            Destroy(other.gameObject);
            GM.coinTotal += 1;
        }
        //else if(other.gameObject.name == "Enemy(Clone)") 
        else if (other.gameObject.name == "Structure_subdiv2(Clone)")            
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
