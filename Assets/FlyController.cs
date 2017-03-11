using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlyController : MonoBehaviour
{

    public float FlySpeed;
    public float RotationSpeed;
    public BoxCollider FlyVolume;

    public SphereCollider Target;

    private Rigidbody _body;

	// Use this for initialization
	void Start ()
	{
	    // Set initial position within the volume.
	    transform.position = RandomPosition();
        RandomizeTarget();

	    _body = GetComponent<Rigidbody>();
	}

    private Vector3 RandomPosition()
    {
        return FlyVolume.transform.position + Hadamard(Random.insideUnitSphere, FlyVolume.bounds.extents);
    }

    private void RandomizeTarget()
    {
        // TODO: random time intervals for target selection... given constant speed select angle, then
        // distance and clamp distance into the volume?
        // TODO: any good way to ensure it has a reasonable distance to go? See comment above instead for placement.
        Target.transform.position = RandomPosition();
    }

    // Hadamard product; element-wise multiplcation.
    private static Vector3 Hadamard(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }

    // Update is called once per frame
    void Update () {
		// TODO: banking; maybe targets always on outside edge of volume.
        var targetVelocity = Target.transform.position - transform.position;
        Debug.Log(targetVelocity);

        //_body.velocity = Vector3.Lerp(_body.velocity, targetVelocity * FlySpeed, RotationSpeed);
        _body.velocity = targetVelocity;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other != Target)
        {
            return;
        }

        RandomizeTarget();
    }
}
