using UnityEngine;
using System.Collections;

/// <summary>
/// Adds ability to link monkey to a rigid body
/// 
/// See - https://unity3d.com/learn/tutorials/topics/physics/physics-joints
/// </summary>
[RequireComponent(typeof(PlayerData))]
[RequireComponent(typeof(Rigidbody))]
public class Hook : MonoBehaviour
{
    private PlayerData player;
    private Rigidbody myRidgidbody;

    public GameObject crossHairs;
    public GameObject camera;

    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int hookMask;
    int RayLength = 50;
    //public Rigidbody vineRigidbody;


    // Use this for initialization
    void Start()
    {
        myRidgidbody = gameObject.GetComponent<Rigidbody>();
        player = gameObject.GetComponent<PlayerData>();
        hookMask = LayerMask.GetMask("Hook");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var input = InputManager.getCurrentInputManager()
            .playerControls[player.playerNumber];

        if (input.getSecondaryActionPressDown())
        {
            camera.GetComponentInChildren<CapsuleCollider>().enabled = true;
        }
        
        // Remove the hook on keyup
        if (!input.getSecondaryActionHold())
        {
            camera.GetComponentInChildren<CapsuleCollider>().enabled = false;
            if (player.isSwinging) {
                player.swingPoint = null;
            }
        }
    }
}
