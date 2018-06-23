using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public static SoundController shared = null;

    public  AudioSource asource;
    public  AudioClip trollSound;
    public  AudioClip badHit;
    public  AudioClip goodHit;
    public  AudioClip boniHit;

    public SoundController()
    {
        SoundController.shared = this;
    }

    public void playSound(SoundType id)
    {
        //enum
        switch (id)
        {
            case SoundType.goodHit:
                Debug.Log(goodHit);
                asource.clip = goodHit;
                break;
            case SoundType.badHit:
                asource.clip = badHit;
                break;
            case SoundType.boniHit:
                asource.clip = boniHit;
                break;
            case SoundType.trollSound:
                asource.clip = trollSound;
                break;
            default:
                Debug.Log("Sound Error");
                break;
        }
        asource.Play();
    }

    //public static void playSound(int id)
    //{
    //    SoundController sc = new SoundController();
    //    sc._playSound(id);
    //}
}

public enum SoundType
{
    goodHit,
    badHit,
    boniHit,
    trollSound
}
