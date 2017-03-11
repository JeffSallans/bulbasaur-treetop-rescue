using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAt : MonoBehaviour
{

    public GameObject Target;
    public float MaxRotationSpeed;

    // Whether the object has snapped to point at the initial target position.
    private Boolean _initialSnap;

	// Use this for initialization
	void Start ()
	{
	    _initialSnap = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (!_initialSnap)
	    {
            transform.rotation = ToTarget();
	        _initialSnap = true;
            return;
	    }

	    var rotationSpeed = MaxRotationSpeed * Time.deltaTime;

	    var targetRotation = ToTarget();
	    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
	}

    private Quaternion ToTarget()
    {
        return Quaternion.LookRotation(Target.transform.position - transform.position);
    }
}
