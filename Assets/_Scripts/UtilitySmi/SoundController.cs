using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//kümmert sich um die Soundausgabe
public class SoundController : MonoBehaviour {

    public static SoundController shared = null;

    public  AudioSource asource;
    public  AudioClip trollSound;
    public  AudioClip badHit;
    public  AudioClip goodHit;
    public  AudioClip boniHit;
    public AudioClip ambient;
    public AudioClip startSound;
    public AudioClip endSound;

    public SoundController()
    {
        SoundController.shared = this;
    }

    public void playSound(SoundType id)
    {
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
            case SoundType.ambient:
                asource.clip = ambient;
                break;
            case SoundType.startSound:
                asource.clip = startSound;
                break;
            case SoundType.endSound:
                asource.clip = endSound;
                break;
            default:
                Debug.Log("Sound Error");
                break;
        }
        asource.Play();
    }
}

public enum SoundType
{
    goodHit,
    badHit,
    boniHit,
    trollSound,
    ambient,
    startSound,
    endSound
}
