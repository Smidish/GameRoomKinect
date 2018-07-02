using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoScript : MonoBehaviour {
    public VideoPlayer VP;
    public Canvas UICanvas;

    public VideoClip video1;
    public VideoClip video2;

    void Start () {
        UICanvas.enabled = false;
        VP.clip = video1;
        VP.Play();
        StartCoroutine(wait(7));
    }

	public void onButtonClick()
    {
        VP.clip = video2;
        VP.Play();
        StartCoroutine(wait(3));
    }

    IEnumerator wait(int s)
    {
        if (s == 3)
        {
            UICanvas.enabled = false;
        }
        yield return new WaitForSeconds(s);
        if (s == 7)
        {    
            UICanvas.enabled = true;
        }
        if(s == 3)
        {
            SceneChange.ChangeScene("main");
        }
    }
}
