using UnityEngine;
using System.Collections;

/// <summary>
/// Adds ability to the monkey to jump
/// 
/// See - http://answers.unity3d.com/questions/642441/help-with-simple-jump-script.html
/// </summary>
[RequireComponent(typeof(Monkey))]
[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    /// <summary>
    /// True if the monkey is on the ground
    /// </summary>
    public bool grounded = true;

    /// <summary>
    /// The force of the jump
    /// </summary>
    public float jumpPower = 1;

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

        if (!grounded && myRidgidbody.velocity.y == 0)
        {
            grounded = true;
        }
        if (input.getActionPressDown() && grounded == true)
        {
            myRidgidbody.AddRelativeForce(transform.up * jumpPower);
            grounded = false;
        }
    }
}
