using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionRecognizer : MonoBehaviour {

    private void Start()
    {
        GetComponent<ParticleSystem>().Stop();
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hand Collision");
        StartCoroutine(PlayAnimation());
        TriggerEnter.OnTriggerEnter(other);
    }
    IEnumerator PlayAnimation()
    {
        GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1.0f);
        GetComponent<ParticleSystem>().Stop();
    }
}
