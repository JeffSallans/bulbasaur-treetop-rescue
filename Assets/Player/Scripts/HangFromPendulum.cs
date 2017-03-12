using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The object will be constrained to rotate the target point
/// </summary>
[RequireComponent(typeof(PlayerData))]
[RequireComponent(typeof(Rigidbody))]
public class HangFromPendulum : MonoBehaviour {

    public Vector3 calculatedForce;

    private PlayerData playerData;
    private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        playerData = gameObject.GetComponent<PlayerData>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (playerData.isSwinging)
        {
            // Setting 1 will create the magnitude
            var pendulumStringVector = Vector3.MoveTowards(playerData.swingPoint.gameObject.transform.position, gameObject.transform.position, 1);

            var directionOfPendulumForce = Vector3.Cross(-pendulumStringVector, Vector3.left);

            var angleOfThePendulumRope = Vector3.Angle(Vector3.up, pendulumStringVector);

            var pendulumForce = playerData.mass * playerData.gravity * Mathf.Sin(angleOfThePendulumRope);

            calculatedForce = pendulumForce * pendulumStringVector * Time.deltaTime;
            rigidbody.AddForce(pendulumForce * directionOfPendulumForce.normalized * Time.deltaTime);
        }
        else
        {
            rigidbody.AddForce(playerData.mass * playerData.gravity * Vector3.down * Time.deltaTime);
        }
    }
}
