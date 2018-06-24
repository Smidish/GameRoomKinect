using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectsScript : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("DESTORY");
        Destroy(col.gameObject);
    }
}
