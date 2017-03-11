using UnityEngine;
using System.Collections;

/// <summary>
/// Adds ability to link monkey to a rigid body
/// 
/// See - https://unity3d.com/learn/tutorials/topics/physics/physics-joints
/// </summary>
[RequireComponent(typeof(Monkey))]
[RequireComponent(typeof(Rigidbody))]
public class Hook : MonoBehaviour
{
    /// <summary>
    /// Target to hook to
    /// </summary>
    public Rigidbody hookTarget;

    private Monkey monkey;
    private Rigidbody myRidgidbody;

    // Use this for initialization
    void Start()
    {
        myRidgidbody = gameObject.GetComponent<Rigidbody>();
        monkey = gameObject.GetComponent<Monkey>();
    }

    // Update is called once per frame
    void Update()
    {
        var input = InputManager.getCurrentInputManager()
            .playerControls[monkey.playerNumber];

        var currentHindgeJoint = gameObject.GetComponent<HingeJoint>();

        // Set the hook on press and hold
        if (!currentHindgeJoint && input.getSecondaryActionHold())
        {
            gameObject.AddComponent<HingeJoint>();

            var addedHindgeJoin = gameObject.GetComponent<HingeJoint>();

            var offset = hookTarget.gameObject.transform.position - gameObject.transform.position;
            addedHindgeJoin.anchor = offset;
            addedHindgeJoin.axis = new Vector3(1, 1, 1);
        }
        // Remove the hook on keyup
        else if (currentHindgeJoint && !input.getSecondaryActionHold())
        {
            Destroy(currentHindgeJoint);
        }
    }
}
