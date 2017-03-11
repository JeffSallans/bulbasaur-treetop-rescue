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
    /// <summary>
    /// Target to hook to
    /// </summary>
    public Rigidbody hookTarget;

    private PlayerData player;
    private Rigidbody myRidgidbody;

    public Rigidbody vineRigidbody;

    // Use this for initialization
    void Start()
    {
        myRidgidbody = gameObject.GetComponent<Rigidbody>();
        player = gameObject.GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var input = InputManager.getCurrentInputManager()
            .playerControls[player.playerNumber];

        var currentHindgeJoint = gameObject.GetComponent<HingeJoint>();

        // Instantiated Vine
        Rigidbody vine = null;

        // Set the hook on press and hold
        if (!currentHindgeJoint && input.getSecondaryActionHold())
        {
            
            //gameObject.AddComponent<HingeJoint>();

            //var addedHindgeJoin = gameObject.GetComponent<HingeJoint>();

            //var offset = hookTarget.gameObject.transform.position - gameObject.transform.position;
            //addedHindgeJoin.anchor = offset;
            //addedHindgeJoin.axis = new Vector3(1, 1, 1);

           //vine = Instantiate(vineRigidbody, player.transform);
            //myRidgidbody.GetComponent<FixedJoint>().connectedBody = vine;
            //var vineFixedJoint = vine.GetComponent<FixedJoint>();
            //vineFixedJoint.connectedBody = myRidgidbody;
        }
        // Remove the hook on keyup
        else if (currentHindgeJoint && !input.getSecondaryActionHold())
        {
            Destroy(currentHindgeJoint);
            Destroy(vine);
        }
    }
}
