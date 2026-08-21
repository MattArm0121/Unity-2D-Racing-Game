using UnityEngine;
using System.Collections.Generic;
using System;
using System.Security.Cryptography;

public enum ShaftType
{
    motor, steering
}

[System.Serializable]
public class DriveShaft
{
    public WheelCollider leftWheel, rightWheel;
    public ShaftType shaftType;
}

public class Wheels3DScript : MonoBehaviour
{
    public List<DriveShaft> shafts;


    [SerializeField] float maxMotorTorque, maxSteeringAngle;

    public void ApplyLocalPositionToVisuals (WheelCollider collider)
    {
        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (DriveShaft shaft in shafts)
        {
            if (shaft.shaftType == ShaftType.steering)
            {
                shaft.leftWheel.steerAngle = steering;
                shaft.rightWheel.steerAngle = steering;
            }
            else if (shaft.shaftType == ShaftType.motor)
            {
                shaft.leftWheel.motorTorque = motor;
                shaft.rightWheel.motorTorque = motor;
            }

            ApplyLocalPositionToVisuals(shaft.leftWheel);
            ApplyLocalPositionToVisuals(shaft.rightWheel);
        }
    }
}
