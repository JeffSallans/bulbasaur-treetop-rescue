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
            playerData.swingPoint = other.gameObject;
        }
    }
}
