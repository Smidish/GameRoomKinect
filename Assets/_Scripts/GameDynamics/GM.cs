//Script basierend auf Jenny Rinks Wolfgame
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public bool trollBuild;

    public static float vertVel = 0;
    public static int coinTotal = 0;
    public static float timeTotal = 0;
    public float waittoload = 0;

    public float zScenePos = 30;


   // public Transform bbNoPit;

    public Transform coinObj;
    public Transform enemyObj;
    public Transform boniObj;

    public AudioClip sound;
    public AudioSource asource;

    private int randNum;
    private int randNumX;
    private int randNumY;
    private float x;
    private float y;

    // Update is called once per frame
    void Update()
    {
        if (zScenePos > 3) //Random Objekte (obst/coins/Capsules) erschaffen
        {
            randNumX = Random.Range(-15, 15);
            x = randNumX * 0.2f;
            randNumY = Random.Range(0, 2);
            y = randNumY;

            randNum = Random.Range(0,9);
            if (randNum <= 6) //70% Wahrscheinlichkeit
            {
                Instantiate(coinObj, new Vector3(x, y, zScenePos), coinObj.rotation);
            }
            else if(randNum>6 && randNum<=8) //20% Wahrscheinlichkeit
            {
                Instantiate(enemyObj, new Vector3(x, y, zScenePos), enemyObj.rotation);
            }
            else if (randNum == 9) //10% Wahrscheinlichkeit
            {
                Instantiate(boniObj, new Vector3(x, y, zScenePos), boniObj.rotation);
            }


            // Instantiate(bbNoPit, new Vector3(0, 1.07f, zScenePos), bbNoPit.rotation);
            zScenePos -= 2;
        }

        timeTotal += Time.deltaTime;

        //Game finished
        if (waittoload > 2 || timeTotal > 100)
        {
            asource.clip = sound;
            asource.Play();
            wait(4.0f);
            SceneManager.LoadScene("end");
        }
    }

    IEnumerator wait(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
