using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTTReciever : MonoBehaviour {

	public MQTTCommunicator mqttCommunicator;
	public string[] Topics;
	private bool hasSubscriptions = false;

	private List<MQTTMessage> lastMessagesRecieved;
	//TODO: Create Dicitionary to save the topic and the message
		//private Dictionary<string topic, 


	// Use this for initialization
	void Start () {
	}

	public void addTopic(string addedTopic){
		string[] argumentArrayTopic = { addedTopic };
		mqttCommunicator.subscribe (argumentArrayTopic, this);
	}

	//Called from Communicator
	public void sendMessages(List<MQTTMessage> messages){
		lastMessagesRecieved = messages;
	}

	public List<MQTTMessage> getLastMessagesRecieved(){
		return lastMessagesRecieved;
	}


	public string getLastMessageOfTopic(string topic){
		if (lastMessagesRecieved != null) {
			foreach (MQTTMessage msg in lastMessagesRecieved) {
				if (msg.Topic == topic)
					return msg.Message;
			}
		}

		return null;
	}

	// Update is called once per frame
	void Update () {
		//Try to subscripe 
		if (!hasSubscriptions) {
//			Debug.Log ("Trying to subscribe");
				hasSubscriptions = mqttCommunicator.subscribe (Topics, this);
		}
	}
}
