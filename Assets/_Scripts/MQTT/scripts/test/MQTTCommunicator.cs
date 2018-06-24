using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine.UI;
using System.Threading;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;

using System;

/*BASED ON: https://github.com/vovacooper/Unity3d_MQTT
 * 
 * The reworked the MQTT Design a bit. 
 * We have 3 Components (MQTTCommunicator, MQTTReciever and MQTT Publisher)
 * 
 * The MQTTCommunicator just subscribes to every Topic (which makes it easy for our UseCase)
 * The Reciever saves the last Messages of the Topic in his interests
 * GamePlay Elements now talk to the MQTTReciever and get a the last Message of some Topic
 */


public class MQTTCommunicator : MonoBehaviour {

	//This is the broker
	private MqttClient client;

	//Connection Details
	public string ipAdress = "0.0.0.0";
	public int Port = 8080;
	public bool Localhost = false; 

	private string clientId;

	//Cache/Buffer for Messages that come in:
	//The Messages come in async so this collects everything that comes in between the Updates
	//And everything collected in the meantime gets sent
	private Dictionary<MQTTReciever, string[]> RecieverTopicCollection;
	private List<MqttMsgPublishEventArgs> packageBuffer;

	// Called before start
	void Awake () {
		if(Localhost) //Automatically sets the IP-Adress (good for debugging)
			ipAdress = "127.0.0.1";
	}

	void Start(){
		
		//Create Client instance
		client = new MqttClient(IPAddress.Parse(ipAdress),Port , false , null ); 
		//register to message received (Callback)
		client.MqttMsgPublishReceived += client_MqttMsgPublishReceived; 
		clientId = Guid.NewGuid().ToString(); 

		//Connect to Broker
		Debug.Log("Connecting ..");
		client.Connect (clientId);

		/* Maybe used in the future :D
		Thread thread = new Thread(connect);
		thread.Start();*/

		//Intialize Buffer
		RecieverTopicCollection = new Dictionary<MQTTReciever, string[]> ();
		packageBuffer = new List<MqttMsgPublishEventArgs> ();

		//Just subscribe to everything
		client.Subscribe (new string[]{"#"}, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE }); 
	}

	//When a new Message arrives
	void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
	{ 	
		//Add Message to packageBuffer
		packageBuffer.Add (e);

	} 

	public bool subscribe(string[] Topics, MQTTReciever reciever){
		//This associates a Reciever with some Topics
		try {
				RecieverTopicCollection.Add (reciever, Topics);
				return true;
		}catch(Exception err) {
		return false;
	}
	}


	public void Update(){
		
		try{
			if(client.IsConnected)
			{
				//Cant use original packageBuffer because it could be changed while the function is running
				List<MqttMsgPublishEventArgs> updatePackageBuffer = new List<MqttMsgPublishEventArgs> (packageBuffer);
				//Check each Package
				foreach (MqttMsgPublishEventArgs package in updatePackageBuffer) {
					//Check each Recipient
					foreach (MQTTReciever reciever in RecieverTopicCollection.Keys) {
						//Check each Topic
						//All Messages get bundeld
						List<MQTTMessage> messagesForReciever = new List<MQTTMessage> ();
						foreach (string topic in RecieverTopicCollection[reciever]) {
							//If Topic matches with message --> send
							if (topic == package.Topic) {
								string Message = System.Text.Encoding.UTF8.GetString (package.Message);
								messagesForReciever.Add(new MQTTMessage(Message, package.Topic));
							}
						}
						if(messagesForReciever.Count>0)
							reciever.sendMessages (messagesForReciever);
					}
				}
				//Everything that got sent, gets deleted
				foreach (MqttMsgPublishEventArgs package in updatePackageBuffer)
					packageBuffer.Remove (package);
			}}catch(Exception e){
			Debug.Log ("Error in MQTTCommunicator Update:" + e);
		}

	}

	public void publishAMessage(MQTTMessage msg){
		client.Publish(msg.Topic, System.Text.Encoding.ASCII.GetBytes(msg.Message));
		
	}

	public bool isConnected(){
		try{
		return client.IsConnected;
		} catch(Exception e){
			return false;
		}
	}
}

public class MQTTMessage{
	public string Message;
	public string Topic;

	public MQTTMessage(string Message, string Topic){
		this.Message = Message;
		this.Topic = Topic;
	}
}
