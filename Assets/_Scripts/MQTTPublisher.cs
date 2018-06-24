using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTTPublisher : MonoBehaviour {

	public MQTTCommunicator mqttCommunicator;

	public void publish(MQTTMessage msg){
		mqttCommunicator.publishAMessage (msg);
	}
}
