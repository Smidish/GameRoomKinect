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
    public Transform obstObj;
    public Transform capsuleObj;

    public int randNum;


    // Use this for initialization
    void Start()
    {

       /* for (int i = 0; i < 7; i++)
        {
            //Instantiate(bbNoPit, new Vector3(0, 0, i*4), bbNoPit.rotation); // baut Blocklandschaft ..macht mit der Schleife irgendwie nicht was es soll, daher einzeln
        }*/


      //  Instantiate(bbNoPit, new Vector3(0, 0, 0), bbNoPit.rotation); // baut Blocklandschaft 
      //  Instantiate(bbNoPit, new Vector3(0, 0, 4), bbNoPit.rotation);
      //  Instantiate(bbNoPit, new Vector3(0, 0, 8), bbNoPit.rotation);
      //  Instantiate(bbNoPit, new Vector3(0, 0, 12), bbNoPit.rotation);
      //  Instantiate(bbNoPit, new Vector3(0, 0, 16), bbNoPit.rotation);
      //  Instantiate(bbNoPit, new Vector3(0, 0, 20), bbNoPit.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (zScenePos > 3) //Random Objekte (obst/coins/Capsules) erschaffen
        {
            randNum = Random.Range(0, 15);


            //(x, y, z)
            if (randNum < 3)
            {
                Instantiate(coinObj, new Vector3(-1, 1.07f, zScenePos), coinObj.rotation);
            }

            if (randNum > 7 && randNum < 10)
            {
                Instantiate(coinObj, new Vector3(1, 1.07f, zScenePos), coinObj.rotation);
            }

            if (randNum > 10)
            {
                Instantiate(coinObj, new Vector3(0, 1.07f, zScenePos), coinObj.rotation);
            }


            if (randNum == 5)
            {
                Instantiate(obstObj, new Vector3(0, 1.07f, zScenePos), obstObj.rotation);
            }

            if (randNum == 4)
            {
                Instantiate(obstObj, new Vector3(1, 1.07f, zScenePos), obstObj.rotation);
            }

            if (randNum == 6)
            {
                Instantiate(obstObj, new Vector3(-1, 1.07f, zScenePos), obstObj.rotation);
            }


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
