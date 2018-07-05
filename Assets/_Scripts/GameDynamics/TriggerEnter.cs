using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : SoundController {

   //Klasse, die alle Zusammenstße des Players mit GameObjekten ausführt
    public static void OnTriggerEnter(Collider other)
    {
        //Punkte/Coin Objekt, Spieler erhält einen Punkt
        if (other.gameObject.name == "Coin_new(Clone)")
        {      
            GM.coinTotal += 1;
            moveObjects.plusminusspeed -= 0.1f;
            SoundController.shared.playSound(SoundType.goodHit); 
        } 
        //bad Object, Spieler verliert 2 Punkte und 1 Leben
        else if (other.gameObject.name == "Structure_subdiv2(Clone)")
        {
            GM.coinTotal -= 2;
            GM.hitcount -= 1;
            moveObjects.plusminusspeed += 0.1f;
            mqttWeste.sharedMQTT.SendHit();
            SoundController.shared.playSound(SoundType.badHit);
        }
        //Life Object, Spieler erhält 2 Punkt eund ein Leben
        else if (other.gameObject.name == "Boni(Clone)")
        {
            GM.coinTotal += 2;
            GM.hitcount += 1;
            mqttWeste.sharedMQTT.SendLife();
            SoundController.shared.playSound(SoundType.trollSound);
        }
        Destroy(other.gameObject);
    }
}
