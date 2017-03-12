using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrappleMovement : MonoBehaviour {

    public PlayerData playerData;

    public float swingingPower = 20;

    private bool isActive = false;

    private Rigidbody myRidgidbody;
    private PlayerInput playerInput;

    // Use this for initialization
    void Start () {
        myRidgidbody = gameObject.GetComponent<Rigidbody>();
        playerInput = InputManager.getCurrentInputManager()
            .playerControls[playerData.playerNumber];
    }
	
	// Update is called once per frame
	void Update () {

		if (playerData.isSwinging && !isActive)
        {
            isActive = true;

            gameObject.transform.position = playerData.gameObject.transform.position;
        }
        else if (playerData.isSwinging)
        {
            var inputVector = new Vector3(-playerInput.getVerticalAxis(), 0, playerInput.getHorizontalAxis());
            myRidgidbody.AddRelativeForce(inputVector * swingingPower);
        }
        else
        {
            isActive = false;
        }
	}
}

