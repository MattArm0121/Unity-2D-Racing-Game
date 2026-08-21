using UnityEngine;

public class Wheel2DScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] WheelJoint2D frontWheel, rearWheel;

    float motorSpeed;

    void Update()
    {
        motorSpeed = Input.GetAxis("Horizontal") * speed * -1;
    }

    void FixedUpdate()
    {
        JointMotor2D backMotor = new JointMotor2D
        {
            motorSpeed = motorSpeed,
            maxMotorTorque = rearWheel.motor.maxMotorTorque
        };

        rearWheel.motor = backMotor;
        frontWheel.motor = backMotor;
    }
}
