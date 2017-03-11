using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlyController : MonoBehaviour
{

    public float FlySpeed;
    public BoxCollider FlyVolume;

    public SphereCollider Target;

	// Use this for initialization
	void Start ()
	{
	    // Set initial position within the volume.
	    transform.position = RandomPosition();
        RandomizeTarget();
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

	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != Target)
        {
            return;
        }

        RandomizeTarget();
    }
}
