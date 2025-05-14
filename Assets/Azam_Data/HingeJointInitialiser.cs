using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeJointInitialiser : MonoBehaviour
{
    public float targetAngle = 45f; // Desired angle in degrees

    void Start()
    {
        HingeJoint hinge = GetComponent<HingeJoint>();

        JointSpring spring = hinge.spring;
        spring.targetPosition = targetAngle;
        hinge.spring = spring;
        hinge.useSpring = true;
    }
}

    
