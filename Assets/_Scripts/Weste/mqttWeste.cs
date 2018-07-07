using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using System;

//zuständig für Kommunikation zwischen Weste und Game
public class mqttWeste : MonoBehaviour
{
    public static mqttWeste sharedMQTT = null;

    public mqttWeste()
    {
        mqttWeste.sharedMQTT = this;
    }

    private MqttClient client;

    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) //ankommende NAchrichten
    {
        Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));
    }

    public void SendHit() //schickt "1", wenn Spieler getroffen wurde
    {
        Debug.Log("sending hit");
        client.Publish("weste", System.Text.Encoding.UTF8.GetBytes("1"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        Debug.Log("sent");
    }

    public void SendLife() //schickt "2", wenn Spieler Leben eingesammelt hat
    {
        Debug.Log("sending life");
        client.Publish("weste", System.Text.Encoding.UTF8.GetBytes("2"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        Debug.Log("sent");
    }

    public void restartGame() //sendet "0" zu Beginn des Spiels und baut Connection auf
    {
        client = new MqttClient(IPAddress.Parse("127.0.0.1"), 1883, false, null);
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
        string clientId = Guid.NewGuid().ToString();
        client.Connect(clientId);
        client.Subscribe(new string[] { "#" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        client.Publish("weste", System.Text.Encoding.UTF8.GetBytes("0"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
    }
}
