using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;

using System;

public class mqttWeste : MonoBehaviour
{

    public static mqttWeste sharedMQTT = null;

    public mqttWeste()
    {
        mqttWeste.sharedMQTT = this;
    }

    private MqttClient client;
    // Use this for initialization
    //void Start()
    //{
    //    // create client instance 
    //    client = new MqttClient(IPAddress.Parse("127.0.0.1"), 1883, false, null);

    //    // register to message received 
    //    client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

    //    string clientId = Guid.NewGuid().ToString();
    //    client.Connect(clientId);

    //    // subscribe to the topic "/home/temperature" with QoS 2 
    //    client.Subscribe(new string[] { "#" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

    //}
    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));
    }


    public void SendHit()
    {
        Debug.Log("sending hit");
        client.Publish("weste", System.Text.Encoding.UTF8.GetBytes("1"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        Debug.Log("sent");
    }

    public void restartGame()
    {
        // create client instance 
        client = new MqttClient(IPAddress.Parse("127.0.0.1"), 1883, false, null);

        // register to message received 
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

        string clientId = Guid.NewGuid().ToString();
        client.Connect(clientId);

        // subscribe to the topic "/home/temperature" with QoS 2 
        client.Subscribe(new string[] { "#" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });


        Debug.Log("sending restart");
        client.Publish("weste", System.Text.Encoding.UTF8.GetBytes("0"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        Debug.Log("sent");
    }
}
