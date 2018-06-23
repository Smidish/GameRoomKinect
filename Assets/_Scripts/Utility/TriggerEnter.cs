using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hands collider");
        //if (other.gameObject.name == "Coin(Clone)")
        if (other.gameObject.name == "Coin_new(Clone)")
        {      
            Destroy(other.gameObject);
            GM.coinTotal += 1;
        }
        //else if(other.gameObject.name == "Enemy(Clone)") 
        else if (other.gameObject.name == "Structure_subdiv2(Clone)")
        {
            Destroy(other.gameObject);
            GM.coinTotal -= 2;
        }
        else if (other.gameObject.name == "Boni(Clone)")
        {
            Destroy(other.gameObject);
        }
    }
}
