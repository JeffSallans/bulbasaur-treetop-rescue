using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets the swing point if a collision was found
/// </summary>
public class FlowerCollision : MonoBehaviour
{
    public PlayerData playerData;

    // Use this for initialization
    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (!playerData.isSwinging)
        {
            other.GetComponent<SpringJoint>().connectedBody = playerData.grappleObject.GetComponent<Rigidbody>();
            playerData.gameObject.GetComponent<FollowObject>().enabled = true;
            var playerRigidbody = playerData.gameObject.GetComponent<Rigidbody>();
            var grappleRigidbody = other.gameObject.GetComponent<Rigidbody>();

            grappleRigidbody.velocity = playerRigidbody.velocity;
            grappleRigidbody.angularVelocity = playerRigidbody.angularVelocity;

            grappleRigidbody.isKinematic = false;
            playerRigidbody.isKinematic = true;
            playerData.gameObject.GetComponent<Collider>().enabled = false;

            playerData.swingPoint = other.gameObject;
        }
    }
}
