using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script für Hände, erkennt, wenn Objekt eingesammelt wurde
public class collisionRecognizer : MonoBehaviour {

    public ParticleSystem psh;
    private void Start()
    {
        GetComponent<ParticleSystem>().Stop();
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hand Collision");
        StartCoroutine(PlayAnimation());
        psh.Play();
        TriggerEnter.OnTriggerEnter(other);
    }
    IEnumerator PlayAnimation()
    {
        GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1.0f);
        GetComponent<ParticleSystem>().Stop();
    }
}
