using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlyController : MonoBehaviour
{

    public float FlyMaxSpeed;
    public float FlyAcceleration;
    public BoxCollider FlyVolume;

    public Collider Target;

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
        Vector3 random = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        return FlyVolume.transform.position + Hadamard(random, FlyVolume.bounds.extents);
    }

    private void RandomizeTarget()
    {
        // TODO: random time intervals for target selection... given constant speed select angle, then
        // distance and clamp distance into the volume?
        // TODO: any good way to ensure it has a reasonable distance to go? See comment above instead for placement.
        // TODO: maybe targets always on outside edge of volume.
        Target.transform.position = RandomPosition();
        Target.transform.rotation = Quaternion.LookRotation(transform.position - Target.transform.position);

        
    }

    // Hadamard product; element-wise multiplcation.
    private static Vector3 Hadamard(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }

    // Update is called once per frame
    void Update () {
		// TODO: banking
        Vector3 targetVelocity = Vector3.Normalize(Target.transform.position - transform.position) * FlyMaxSpeed;
        _body.velocity = Vector3.Lerp(_body.velocity, targetVelocity, FlyAcceleration);
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
