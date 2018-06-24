using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEnter : SoundController {

    //public UnityEvent handsCollision;
    public static void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.name == "Coin(Clone)")
        if (other.gameObject.name == "Coin_new(Clone)")
        {      
            GM.coinTotal += 1;
            SoundController.shared.playSound(SoundType.goodHit); 
        }
        //else if(other.gameObject.name == "Enemy(Clone)") 
        else if (other.gameObject.name == "Structure_subdiv2(Clone)")
        {
            GM.coinTotal -= 2;
            SoundController.shared.playSound(SoundType.badHit);
        }
        else if (other.gameObject.name == "Boni(Clone)")
        {
            //Boni action? Schattenmonster Sounds?
            SoundController.shared.playSound(SoundType.trollSound);
        }
        Destroy(other.gameObject);
    }
}
