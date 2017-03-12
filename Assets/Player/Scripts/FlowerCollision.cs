using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCollision : MonoBehaviour
{
    public Rigidbody myRidgidbody;

    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<FixedJoint>().connectedBody = myRidgidbody;
    }
}
