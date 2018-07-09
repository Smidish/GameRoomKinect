using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script für Hände, erkennt, wenn Objekt eingesammelt wurde
public class collisionRecognizer : MonoBehaviour {

    public ParticleSystem psh;
    public Color red;
    public Color green;
    public Color blue;
    private void Start()
    {
        GetComponent<ParticleSystem>().Stop();
    }
    void OnTriggerEnter(Collider other)
    {
        var main = psh.main;
        if (other.gameObject.name == "Coin_new(Clone)")
        {
            main.startColor = blue;
        }
        else if (other.gameObject.name == "Structure_subdiv2(Clone)")
        {
            main.startColor = red;
        }
        else if (other.gameObject.name == "Boni(Clone)")
        {
            main.startColor = green;
        }

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
