//Script basierend auf Jenny Rinks Wolfgame
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{

    public static float vertVel = 0;
    public static int coinTotal = 0;
    public static float timeTotal = 0;
    public float waittoload = 0;

    public float zScenePos = 30;

    public static float zVelAdj = 1;

    public static string lvCompStatus = "";

   // public Transform bbNoPit;

    public Transform coinObj;
    public Transform enemyObj;
    public Transform boniObj;

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



            
            
            


            //(x, y, z)
            //if (randNum < 3)
            //{
            //    Instantiate(coinObj, new Vector3(-1, 1.07f, zScenePos), coinObj.rotation);
            //}

            //if (randNum > 7 && randNum < 10)
            //{
            //    Instantiate(coinObj, new Vector3(1, 1.07f, zScenePos), coinObj.rotation);
            //}

            //if (randNum > 10)
            //{
            //    Instantiate(coinObj, new Vector3(0, 1.07f, zScenePos), coinObj.rotation);
            //}


            //if (randNum == 5)
            //{
            //    Instantiate(obstObj, new Vector3(0, 1.07f, zScenePos), obstObj.rotation);
            //}

            //if (randNum == 4)
            //{
            //    Instantiate(obstObj, new Vector3(1, 1.07f, zScenePos), obstObj.rotation);
            //}

            //if (randNum == 6)
            //{
            //    Instantiate(obstObj, new Vector3(-1, 1.07f, zScenePos), obstObj.rotation);
            //}


            // Instantiate(bbNoPit, new Vector3(0, 1.07f, zScenePos), bbNoPit.rotation);
            zScenePos -= 5;
        }



        timeTotal += Time.deltaTime;

        if (lvCompStatus == "Fail")
        {
            waittoload += Time.deltaTime;


        }

        if (waittoload > 2)
        {
            SceneManager.LoadScene("Levelcomp");
        }

        if (timeTotal > 100)
        {
            SceneManager.LoadScene("Levelcomp");
        }
    }
}
