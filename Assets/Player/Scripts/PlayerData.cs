using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{ 
    /// <summary>
    /// The ID associated with the player
    /// </summary>
    public int playerNumber;

    /// <summary>
    /// How fast the player should walk
    /// </summary>
    public float walkSpeed;

    /// <summary>
    /// How fast the player should swing
    /// </summary>
    public float swingSpeed;

    /// <summary>
    /// How fast the player should swing
    /// </summary>
    public float attachForceMag;

    /// <summary>
    /// How fast the player should fall
    /// </summary>
    public float fallSpeed;

    /// <summary>
    /// True when the user is swinging
    /// </summary>
    public bool isSwinging
    {
        get
        {
            return (swingPoint != null);
        }
    }

    /// <summary>
    /// The target game object to swing around
    /// </summary>
    public GameObject swingPoint;

    /// <summary>
    /// Weight of the player
    /// </summary>
    public float mass = 10;

    /// <summary>
    /// Gravity constant of the game
    /// </summary>
    public float gravity = 9.8f;

    /// <summary>
    /// Reference of grapple movement hack
    /// </summary>
    public GameObject grappleObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
