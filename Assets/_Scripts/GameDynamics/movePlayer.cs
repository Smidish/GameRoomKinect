//Script ursprünglich basierend auf Jennifer Rinks Wolfgame
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//kümmert sich um die Bewegungen des Spielers und weiter Game Dynamics
public class movePlayer : MonoBehaviour {

    public bool KeyboardInput;
    public bool KinectBehindPlayer;
    public float xWertApassen;
    public float yWertApassen;
    public float yWertHoch;
    public GameObject mPlayer; //Spieler in Game
    public GameObject HL; //left Hand
    public GameObject HR; //right Hand
    public Text scoretext;
    public Text lifetext;
    public GameObject tunnel;
    public KeyCode moveL; 
    public KeyCode moveR;
    public ParticleSystem ps;
    public Color red;
    public Color green;
    public Color blue;


    private float horizVel = 0; 
    private int laneNum = 2;     //nur bei Tastatur relevant: Raumeinschränkung, damit Spieler nicht über den Rand läuft (nur bei Tastatur Input)
    private string controllLocked = "n";
    private float xPlayer;
    private float yPlayer;

    public static Vector3 playerMovementCamera;

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
            if (KinectBehindPlayer)
            {
                xPlayer = BodySourceView.PlayerMovement.x * -1; //Werte spiegeln, wenn Kinect hinter dem Spieler aufgebaut ist
            }
            else {
                xPlayer = BodySourceView.PlayerMovement.x;
            }
            yPlayer = BodySourceView.PlayerMovement.y+4;
            Vector3 temp = new Vector3(xPlayer, yPlayer, BodySourceView.PlayerMovement.z); //Vector aus der Kinect
            Vector3 tempHR = new Vector3(BodySourceView.PlayerMovementHR.x, BodySourceView.PlayerMovementHR.y, BodySourceView.PlayerMovementHR.z);
            Vector3 tempHL = new Vector3(BodySourceView.PlayerMovementHL.x, BodySourceView.PlayerMovementHL.y, BodySourceView.PlayerMovementHL.z);
            mPlayer.transform.position = new Vector3(xPlayer, yPlayer, BodySourceView.PlayerMovement.z);
            HR.transform.position = tempHR;
            HL.transform.position = tempHL;
            playerMovementCamera = temp;
        }
        scoretext.text = "Score: " + GM.coinTotal;
        lifetext.text = "Lifes: " + GM.hitcount;
    }

    void OnTriggerEnter(Collider other)
    {
        //leuchtenden Ring durch Tunnel schicken
        TriggerEnter.OnTriggerEnter(other);
        var main = ps.main;
        if (other.gameObject.name == "Coin_new(Clone)")
        {
            main.startColor = blue;
        }
        else if (other.gameObject.name == "Structure_subdiv2(Clone)")
        {
            main.startColor = red;
        }
        else if (other.gameObject.name == "Boni(Clone)")
        {
            main.startColor = green;
        }
        ps.Play();
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(.5f);
        horizVel = 0;
        controllLocked = "n";
    }
}
