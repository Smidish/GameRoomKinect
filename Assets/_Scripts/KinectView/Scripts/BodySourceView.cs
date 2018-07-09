﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kinect = Windows.Kinect;

using Joint = Windows.Kinect.Joint;
using Windows.Kinect;

//Kinect Script, aus dem die Werte für das Spieler Tracking kommen
public class BodySourceView : MonoBehaviour 
{

    public static Vector3 PlayerMovement;
    public static Vector3 PlayerMovementHR;
    public static Vector3 PlayerMovementHL;
    public static Vector3 PlayerMovementHead;
    public BodySourceManager mBodySourceManager;
    public GameObject mJointObject;
    
    private Dictionary<ulong, GameObject> _Bodies = new Dictionary<ulong, GameObject>();
   
    //joints, die im Game genutzt werden
    private List<JointType> _joints = new List<JointType>
    {
        JointType.SpineBase,
        JointType.HandLeft,
        JointType.HandRight,
        JointType.Head
    };
    
    void Update () 
    {
        Body[] data = mBodySourceManager.GetData();
        if (data == null)
        {
            return;
        }
        
        List<ulong> trackedIds = new List<ulong>();
        foreach(var body in data)
        {
            if (body == null)
            {
                continue;
            }
                
            if(body.IsTracked)
            {
                trackedIds.Add (body.TrackingId);
            }
        }
        
        List<ulong> knownIds = new List<ulong>(_Bodies.Keys);
        
        // First delete untracked bodies
        foreach(ulong trackingId in knownIds)
        {
            if(!trackedIds.Contains(trackingId))
            {
                Destroy(_Bodies[trackingId]);
                _Bodies.Remove(trackingId);
            }
        }

        foreach(var body in data)
        {
            if (body == null)
            {
                continue;
            }
            
            if(body.IsTracked)
            {
                if(!_Bodies.ContainsKey(body.TrackingId))
                {
                    _Bodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
                }
               // if (body.TrackingId == 0)
                //{
                    RefreshBodyObject(body, _Bodies[body.TrackingId]);
                //}
            }
        }
    }
    
    private GameObject CreateBodyObject(ulong id)
    {
        GameObject body = new GameObject("Body:" + id);

        foreach (JointType joint in _joints)
        {
            body.SetActive(false);
            GameObject newJoint = Instantiate(mJointObject);
            newJoint.name = joint.ToString();
            newJoint.transform.parent = body.transform;
        }
        return body;
    }
    
    private void RefreshBodyObject(Kinect.Body body, GameObject bodyObject)
    {
        //this is where the magic happens aka joint daten aus der Kinect auslesen
        foreach(JointType _joint in _joints)
        {
            Joint sourceJoint = body.Joints[_joint];
            Vector3 targetPosition = GetVector3FromJoint(sourceJoint);

            //hier Wert nur weiter geben, wenn Spieler sich in einem bestimmten Wertebereich befindet (Spielfeld begrenzen)
            if (_joint == JointType.SpineBase)
            {
                if (targetPosition.z > -22 && targetPosition.x > -7 && targetPosition.x < 7)
                {
                    PlayerMovement = targetPosition;
                }
               
                Transform jointObject = bodyObject.transform.Find("SpineBase");
                jointObject.position = targetPosition;
            }
            else if (_joint == JointType.HandLeft)
            {
                PlayerMovementHL = targetPosition;
                Transform jointObjectHL = bodyObject.transform.Find("HandLeft");
                jointObjectHL.position = targetPosition;
            }
            else if (_joint == JointType.HandRight)
            {
                PlayerMovementHR = targetPosition;
                Transform jointObjectHR = bodyObject.transform.Find("HandRight");
                jointObjectHR.position = targetPosition;
            }
            else if (_joint == JointType.Head)
            {
                if (targetPosition.z > -22 && targetPosition.x > -7 && targetPosition.x < 7)
                {
                    PlayerMovementHead = targetPosition;
                }
                Transform jointObjectHead = bodyObject.transform.Find("Head");
                jointObjectHead.position = targetPosition;
            }
        }
    }

    private static Vector3 GetVector3FromJoint(Kinect.Joint joint)
    {
        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * -10);
    }
}
