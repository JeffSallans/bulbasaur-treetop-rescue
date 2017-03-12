using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savior_upward : MonoBehaviour
{

    public Collider savior_volume;
    public float upward_velocity;

    private Rigidbody playerRigidbody;

	// Use this for initialization
	void Start ()
	{
	    playerRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other == savior_volume)
        {
            Vector3 velocity = playerRigidbody.velocity;
            playerRigidbody.velocity = new Vector3(velocity.x, upward_velocity, velocity.z);
        }
    }
}
