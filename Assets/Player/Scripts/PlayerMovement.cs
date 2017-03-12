using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private PlayerData player;
    private Rigidbody myRidgidbody;

    /// <summary>
    /// The y height of the floor
    /// </summary>
    public float minY = 0;

    /// <summary>
    /// The y height of the ceiling
    /// </summary>
    public float maxY = 10;

    /// <summary>
    /// False if the player is on the ground
    /// </summary>
    public bool jump = false;
    public bool grounded = false;
    public Transform groundCheck;

    private PlayerInput playerInput;

    public float camSmoothing = 200;

    /// <summary>
    /// The force of the jump
    /// </summary>
    public float jumpPower;

    /// <summary>
    /// The force of the swinging DI
    /// </summary>
    public float swingingPower;

    // Use this for initialization
    void Start()
    {
        player = gameObject.GetComponent<PlayerData>();
        myRidgidbody = gameObject.GetComponent<Rigidbody>();
        playerInput = InputManager.getCurrentInputManager()
            .playerControls[player.playerNumber];
    }

    // Update is called once per frame
    void Update()
    {
        // Jumping
        grounded = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (playerInput.getActionPressDown() && grounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector2.up, playerInput.getSecondaryHorizontalAxis() * Time.deltaTime * camSmoothing);

        var inputVector = new Vector3(-playerInput.getVerticalAxis(), 0, playerInput.getHorizontalAxis());

        // Movement
        if (!player.isSwinging)
        {
            var pos = transform.position;
            if (inputVector.magnitude > 0)
            {
                var worldInput = transform.TransformDirection(inputVector);
                pos += player.walkSpeed * worldInput;
            }
            
            transform.position = pos;
        }
        else
        {
            //myRidgidbody.AddRelativeForce(inputVector * swingingPower);
        }

        // Execute the Jump
        if(jump)
        {
            myRidgidbody.AddRelativeForce(transform.up * jumpPower);
            jump = false;
        }
    }
}
