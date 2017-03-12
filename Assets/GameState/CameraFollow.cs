using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform thePlayer;
    public Transform target;            
    public Transform cameraTarget;
    public float smoothing = 5f;        // The speed with which the camera will be following.
    public float camSmoothing = 5f;


    Vector3 offset;                     // The initial offset from the target.

    private PlayerInput playerInput;

    void Start()
    {
        // Calculate the initial offset.
        //offset = transform.position - target.position;

        playerInput = InputManager.getCurrentInputManager()
            .playerControls[thePlayer.GetComponent<PlayerData>().playerNumber];
    }

    void FixedUpdate()
    {
        // Create a postion the camera is aiming for based on the offset from the target.
        //Vector3 targetCamPos = target.position + offset;


        // Smoothly interpolate between the camera's current position and it's target position.
        transform.position = Vector3.Lerp(transform.position, cameraTarget.position, smoothing * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, cameraTarget.position.y, transform.position.z);

        transform.LookAt(target.transform);

        var hitBottomClamp = cameraTarget.transform.position.y < -2 && playerInput.getSecondaryVerticalAxis() < 0;
        var hitTopClamp = cameraTarget.transform.position.y > 5 && playerInput.getSecondaryVerticalAxis() > 0;

        if (!hitBottomClamp && !hitTopClamp) {
            cameraTarget.transform.RotateAround(thePlayer.transform.position, Vector2.left, -playerInput.getSecondaryVerticalAxis() * Time.deltaTime * camSmoothing);
        }



        // y-axis roatation to change negative is left and positive is right. Horizontal Axis
        // x - axis rotation is up and down. Vertical Axis

        //transform.rotation = Quaternion.AngleAxis(playerInput.getSecondaryHorizontalAxis() * 90, Vector3.Up);


    }
}
