//Script ursprünglich basierend auf Jennifer Rinks Wolfgame
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//Hauptscript, managed den Spielablauf 
public class GM : MonoBehaviour
{
    public float maxSpornX;
    public int maxSpornYR;
    public int maxSpornYL;
    public int gameDuration;
    public float zScenePos;
    public Transform coinObj;
    public Transform enemyObj;
    public Transform boniObj;

    public static float vertVel = 0;
    public static int coinTotal = 0;
    public static float timeTotal = 0;
    public static int hitcount = 3;

    private int randNum;
    private int randNumX;
    private int randNumY;
    private float x;
    private float y;

    private List<Transform> objList;

    void Start()
    {
        //Werte zu beginn auf Null zurücksetzen
        coinTotal = 0;
        hitcount = 3;
        timeTotal = 0;
        if(objList != null)
        {
            foreach (Transform tf in objList)
            {
                Destroy(tf.gameObject);
            }
        }
        objList = new List<Transform>();

        //Broker Verbindung starten
        mqttWeste.sharedMQTT.restartGame();
        SoundController.shared.playSound(SoundType.startSound);
    }

    //Hier werden alle Spielobjekte gespornt
    void Update()
    {
        //zufälliges spornen der Objekte
        randNumX = Random.Range(-15, 15);
        x = randNumX * maxSpornX;
        randNumY = Random.Range(maxSpornYL, maxSpornYR);
        y = randNumY;
       
        randNum = Random.Range(0,400);
        if (randNum <= 6) //70% Wahrscheinlichkeit
        {
            objList.Add(Instantiate(coinObj, new Vector3(x, y, zScenePos), coinObj.rotation));
        }
        if(randNum>6 && randNum<=8) //20% Wahrscheinlichkeit
        {
            objList.Add(Instantiate(enemyObj, new Vector3(x, y, zScenePos), enemyObj.rotation));
        }
        if (randNum == 9) //10% Wahrscheinlichkeit
        {
            objList.Add(Instantiate(boniObj, new Vector3(x, y, zScenePos), boniObj.rotation));
        }

        timeTotal += Time.deltaTime;

        //Game finished if player got hit 3 times or time is up
        if (hitcount <= 0 || timeTotal > gameDuration)
        {
            SoundController.shared.playSound(SoundType.endSound);
            wait(4.0f);
            SceneManager.LoadScene("end");
        }
    }

    IEnumerator wait(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
