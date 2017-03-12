using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets the swing point if a collision was found
/// </summary>
[RequireComponent(typeof(PlayerData))]
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
            playerData.swingPoint = other.gameObject;
        }
    }
}
