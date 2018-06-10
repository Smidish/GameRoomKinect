using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kinect = Windows.Kinect;

using Joint = Windows.Kinect.Joint;
using Windows.Kinect;

public class BodySourceView : MonoBehaviour 
{
    //public Material BoneMaterial;
    // public GameObject BodySourceManager;
    public BodySourceManager mBodySourceManager;
    public GameObject mJointObject; //Material for Tracking Points
    
    private Dictionary<ulong, GameObject> _Bodies = new Dictionary<ulong, GameObject>();
   

    private List<JointType> _joints = new List<JointType>
    {
        JointType.SpineBase,
    };

    
    //private Dictionary<Kinect.JointType, Kinect.JointType> _BoneMap = new Dictionary<Kinect.JointType, Kinect.JointType>()
    //{       
    //    { Kinect.JointType.HandTipLeft, Kinect.JointType.HandLeft },
    //    { Kinect.JointType.HandTipRight, Kinect.JointType.HandRight },
    //    { Kinect.JointType.SpineBase, Kinect.JointType.SpineMid },
    //    { Kinect.JointType.SpineMid, Kinect.JointType.SpineShoulder },
    //    { Kinect.JointType.SpineShoulder, Kinect.JointType.Neck },
    //    { Kinect.JointType.Neck, Kinect.JointType.Head },
    //};
    
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
            GameObject newJoint = Instantiate(mJointObject);
            newJoint.name = joint.ToString();
            Debug.Log(newJoint.name);
            newJoint.transform.parent = body.transform;
        }
        return body;

        // for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
        // {
        //     GameObject jointObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //     
        //     LineRenderer lr = jointObj.AddComponent<LineRenderer>();
        //     lr.SetVertexCount(2);
        //     lr.material = BoneMaterial;
        //     lr.SetWidth(0.05f, 0.05f);
        //     
        //     jointObj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        //     jointObj.name = jt.ToString();
        //     jointObj.transform.parent = body.transform;
        // }


    }
    
    private void RefreshBodyObject(Kinect.Body body, GameObject bodyObject)
    {
        //HERE Position der Joints abgreifen
        foreach(JointType _joint in _joints)
        {
            Joint sourceJoint = body.Joints[_joint];
            Vector3 targetPosition = GetVector3FromJoint(sourceJoint);
            targetPosition.z = 0;

            Transform jointObject = bodyObject.transform.Find("SpineBase");
            Debug.Log(jointObject);
            jointObject.position = targetPosition;
        }

      //  for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
      //  {
      //      Kinect.Joint sourceJoint = body.Joints[jt];
      //      Kinect.Joint? targetJoint = null;
      //      
      //      if(_BoneMap.ContainsKey(jt))
      //      {
      //          targetJoint = body.Joints[_BoneMap[jt]];
      //      }
      //      
      //      Transform jointObj = bodyObject.transform.Find(jt.ToString());
      //      jointObj.localPosition = GetVector3FromJoint(sourceJoint);
      //      
      //      LineRenderer lr = jointObj.GetComponent<LineRenderer>();
      //      if(targetJoint.HasValue)
      //      {
      //          lr.SetPosition(0, jointObj.localPosition);
      //          lr.SetPosition(1, GetVector3FromJoint(targetJoint.Value));
      //          lr.SetColors(GetColorForState (sourceJoint.TrackingState), GetColorForState(targetJoint.Value.TrackingState));
      //      }
      //      else
      //      {
      //          lr.enabled = false;
      //      }
      //  }
    }
    
    
    private static Vector3 GetVector3FromJoint(Kinect.Joint joint)
    {
        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);
    }
}
