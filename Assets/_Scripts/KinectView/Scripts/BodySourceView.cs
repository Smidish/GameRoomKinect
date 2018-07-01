﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kinect = Windows.Kinect;

using Joint = Windows.Kinect.Joint;
using Windows.Kinect;

public class BodySourceView : MonoBehaviour 
{

    public static Vector3 PlayerMovement;
    public static Vector3 PlayerMovementHR;
    public static Vector3 PlayerMovementHL;
    public BodySourceManager mBodySourceManager;
    public GameObject mJointObject;                 //Material for Tracking Points
    
    private Dictionary<ulong, GameObject> _Bodies = new Dictionary<ulong, GameObject>();
   
    private List<JointType> _joints = new List<JointType>
    {
        JointType.SpineBase,
        JointType.HandLeft,
        JointType.HandRight
    };
    
    void Update () 
    {
       // #region Get Kinect data
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
                
                RefreshBodyObject(body, _Bodies[body.TrackingId]);
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
        //HERE Position der Joints abgreifen
        //needs to be testet with kinect
        foreach(JointType _joint in _joints)
        {
            Joint sourceJoint = body.Joints[_joint];
            Vector3 targetPosition = GetVector3FromJoint(sourceJoint);
            targetPosition.z = 0;
            if (_joint == JointType.SpineBase)
            {
                PlayerMovement = targetPosition;
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
        }
    }
    
    
    private static Vector3 GetVector3FromJoint(Kinect.Joint joint)
    {
        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);
    }
}