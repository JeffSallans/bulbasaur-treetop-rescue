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
    private Rigidbody myRigidbody;

	// Use this for initialization
	void Start () {
        playerData = gameObject.GetComponent<PlayerData>();
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        myRigidbody = gameObject.GetComponent<Rigidbody>();

        if (playerData.isSwinging)
        {
            // boost force
            //myRigidbody.AddRelativeForce(playerData.swingSpeed * gameObject.transform.forward);


            // Setting 1 will create the magnitude
            var pendulumStringVector = playerData.swingPoint.gameObject.transform.position - gameObject.transform.position;

            var directionOfPendulumForce = Vector3.Cross(-pendulumStringVector, Vector3.left);

            var angleOfThePendulumRope = Vector3.Angle(Vector3.up, pendulumStringVector.normalized);


            var instantanousVelocity = myRigidbody.velocity.magnitude;

            // Centripital Force
            var centripetalForce = playerData.swingSpeed * (playerData.mass + instantanousVelocity * instantanousVelocity * Mathf.Cos(Mathf.Deg2Rad * angleOfThePendulumRope)) / pendulumStringVector.magnitude;
            calculatedForce = centripetalForce * pendulumStringVector.normalized * Time.deltaTime;


            myRigidbody.AddRelativeForce(centripetalForce * pendulumStringVector.normalized * Time.deltaTime);
            myRigidbody.AddRelativeForce(playerData.mass * playerData.gravity * Vector3.up * Time.deltaTime);

            // Pendulum force
            //var pendulumForce = -playerData.mass * playerData.gravity * Mathf.Cos(Mathf.Deg2Rad * angleOfThePendulumRope);
            //calculatedForce = pendulumForce * -pendulumStringVector.normalized * Time.deltaTime;
            //rigidbody.AddForce(pendulumForce * -pendulumStringVector.normalized);
            //rigidbody.AddForce(playerData.mass * playerData.gravity * Vector3.up);
        }
        else
        {
            myRigidbody.AddForce(playerData.mass * playerData.gravity * Vector3.up * Time.deltaTime);
        }
    }
}
