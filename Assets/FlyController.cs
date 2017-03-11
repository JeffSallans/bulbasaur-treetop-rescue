using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlyController : MonoBehaviour
{

    public float FlySpeed;
    public BoxCollider FlyVolume;

    public Boolean SelectedStartPosition = false;

    private Vector3 _minimumBounds;
    private Vector3 _maxmimumBounds;

    // TODO: random time intervals for target selection... given constant speed select angle, then
    // distance and clamp distance into the volume?

	// Use this for initialization
	void Start ()
	{
        // Distance to volume bounds from center for each side.
	    var edgeFromCenter = FlyVolume.bounds.extents;

        // Set bounds for target selecction.
        _minimumBounds = FlyVolume.transform.position - edgeFromCenter;
	    _maxmimumBounds = FlyVolume.transform.position + edgeFromCenter;

	    // Set initial position within the volume.
	    var positionSource = Random.insideUnitSphere;

        // TODO: less ugly way to do this? component-wise multiplication of edgeFromCenter and positionSource.

	    transform.position = FlyVolume.transform.position + Hadamard(positionSource, edgeFromCenter);
	    SelectedStartPosition = true;
	}

    // Hadamard product; element-wise multiplcation.
    Vector3 Hadamard(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
