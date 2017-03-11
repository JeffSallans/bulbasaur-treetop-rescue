using UnityEngine;
using System.Collections;

/// <summary>
/// The movement for the monkey
/// </summary>
[RequireComponent(typeof(Monkey))]
public class MonkeyMovement : MonoBehaviour {

    private Monkey monkey;

    /// <summary>
    /// The z height of the floor
    /// </summary>
    public float minY = 0;

    /// <summary>
    /// The z height of the ceiling
    /// </summary>
    public float maxY = 10;

    // Use this for initialization
    void Start () {
        monkey = gameObject.GetComponent<Monkey>();
	}
	
	// Update is called once per frame
	void Update () {

        var input = InputManager.getCurrentInputManager()
            .playerControls[monkey.playerNumber];
        
        var pos = transform.position;

        pos.x += monkey.walkSpeed * input.getHorizontalAxis();
        pos.z += monkey.walkSpeed * input.getVerticalAxis();

        //Floor restriction
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
	}
}
