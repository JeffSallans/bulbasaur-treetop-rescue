using UnityEngine;
using System.Collections;

/// <summary>
/// Adds ability to link monkey to a rigid body
/// 
/// See - https://unity3d.com/learn/tutorials/topics/physics/physics-joints
/// </summary>
[RequireComponent(typeof(PlayerData))]
public class Hook : MonoBehaviour
{
    private PlayerData player;

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
                player.swingPoint.GetComponent<SpringJoint>().connectedBody = null;
                player.gameObject.GetComponent<FollowObject>().enabled = false;
                player.swingPoint = null;
            }
        }
    }
}
