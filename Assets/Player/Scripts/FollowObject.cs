using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use this to have a position lock on an object with a certain offset
/// </summary>
public class FollowObject : MonoBehaviour {

    /// <summary>
    /// Game object to follow
    /// </summary>
    public GameObject targetToFollow;

    /// <summary>
    /// Offset from the target (relative) to keep this game object
    /// </summary>
    public Vector3 offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate() {

        var localOffsetToGlobal = targetToFollow.transform.TransformDirection(offset);

        var pos = targetToFollow.transform.position + localOffsetToGlobal;
        pos.y = targetToFollow.transform.position.y + offset.y;

        transform.position = pos;
	}
}
