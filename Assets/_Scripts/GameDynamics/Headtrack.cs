using UnityEngine;
using System.Collections;
using System.IO;

public class Headtrack : MonoBehaviour
{
   // public KinectInterop.JointType joint = KinectInterop.JointType.Head;
    public float OffsetX;
    public float OffsetY;
    public float OffsetZ;
    public float MultiplyX = 1f;
    public float MultiplyY = 1f;
    public float MultiplyZ = 1f;
    void Update()
    {

        //KinectManager manager = KinectManager.Instance;

        //if (manager && manager.IsInitialized())
        //{
        //    if (manager.IsUserDetected())
        //    {
        //        long userId = manager.GetPrimaryUserID();

        //        if (manager.IsJointTracked(userId, (int)joint))
        //        {

                    Vector3 jointPos = BodySourceView.PlayerMovementHead;
                    float NewOffsetX = jointPos.x * MultiplyX + OffsetX;
                    float NewOffsetY = jointPos.y * MultiplyY + OffsetY;
                    float NewOffsetZ = jointPos.z * MultiplyZ + OffsetZ;
                    //float NewOffsetZ = OffsetZ;  // no tracking for Z
                    //Debug.Log(jointPos);
                    //transform.position = new Vector3(NewOffsetX, NewOffsetY, NewOffsetZ);
                    transform.position = new Vector3(NewOffsetX, NewOffsetY, transform.position.z);
                    
        //        }
        //    }
        //}
    }
}