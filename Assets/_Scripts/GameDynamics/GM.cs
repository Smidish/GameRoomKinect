//Script basierend auf Jenny Rinks Wolfgame
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public bool trollBuild;

    public int gameDuration;

    public static float vertVel = 0;
    public static int coinTotal = 0;
    public static float timeTotal = 0;
    public static int hitcount = 0;

    public float zScenePos;


   // public Transform bbNoPit;

    public Transform coinObj;
    public Transform enemyObj;
    public Transform boniObj;

    private int randNum;
    private int randNumX;
    private int randNumY;
    private float x;
    private float y;

    private List<Transform> objList;

    void Start()
    {
        coinTotal = 0;
        hitcount = 0;
        timeTotal = 0;
        if(objList != null)
        {
            foreach (Transform tf in objList)
            {
                Destroy(tf.gameObject);
            }
        }
        objList = new List<Transform>();
        mqttWeste.sharedMQTT.restartGame();
    }

    void Update()
    {
        randNumX = Random.Range(-15, 15);
        x = randNumX * 0.2f;
        randNumY = Random.Range(0, 3);
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

        //Game finished
        if (hitcount >= 3 || timeTotal > gameDuration)
        {
            if (trollBuild)
            {
                SoundController.shared.playSound(SoundType.trollSound);
                wait(4.0f);
            }
            SceneManager.LoadScene("end");
        }
    }

    IEnumerator wait(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
