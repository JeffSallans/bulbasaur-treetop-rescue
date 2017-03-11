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

    public LineRenderer lineRenderer;

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

        //var currentHindgeJoint = gameObject.GetComponent<HingeJoint>();

        // Instantiated Vine
        Rigidbody vine = null;
        Vector3 offset = hookTarget.gameObject.transform.position - gameObject.transform.position;

        var fixedJoint = hookTarget.GetComponent<FixedJoint>();

        if (input.getSecondaryActionPressDown())
        {
            float dist = Vector3.Distance(hookTarget.gameObject.transform.position, gameObject.transform.position);
            Debug.Log(dist);
            Debug.Log(myRidgidbody.velocity.normalized.ToString());
            myRidgidbody.AddForce(myRidgidbody.velocity.normalized * Time.deltaTime * player.attachForceMag);
            //lineRenderer.enabled = true;
            //lineRenderer.SetPosition(0, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z));
            //lineRenderer.SetPosition(1, new Vector3(hookTarget.gameObject.transform.position.x, hookTarget.gameObject.transform.position.y, hookTarget.gameObject.transform.position.z));
            //vine = Instantiate(vineRigidbody, gameObject.transform);
        }

        // Set the hook on press and hold
        if (input.getSecondaryActionHold())
        {
            fixedJoint.connectedBody = myRidgidbody;
            

            //addedHindgeJoin.anchor = offset;
            //addedHindgeJoin.axis = new Vector3(1, 1, 1);

            //myRidgidbody.GetComponent<FixedJoint>().connectedBody = vine;
            //var vineFixedJoint = vine.GetComponent<FixedJoint>();
            //vineFixedJoint.connectedBody = myRidgidbody;
        }
        // Remove the hook on keyup
        else if (!input.getSecondaryActionHold())
        {
            //Destroy(currentHindgeJoint);
            Destroy(vine);
            fixedJoint.connectedBody = null;
        }
    }
}
