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

    /// <summary>
    /// The force of the jump
    /// </summary>
    public float jumpPower;

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

        // Movement
        var pos = transform.position;

        pos.x += player.walkSpeed * playerInput.getHorizontalAxis();
        pos.z += player.walkSpeed * playerInput.getVerticalAxis();

        //Floor restriction
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

        // Execute the Jump
        if(jump)
        {
            myRidgidbody.AddRelativeForce(transform.up * jumpPower);
            jump = false;
        }
    }
}
