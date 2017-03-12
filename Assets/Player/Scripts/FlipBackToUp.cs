using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// When not swinging, the player will move the model back to upright
/// </summary>
[RequireComponent(typeof(PlayerData))]
public class FlipBackToUp : MonoBehaviour {

    /// <summary>
    /// Speed of orientation
    /// </summary>
    public float smoothing = 100;

    private PlayerData playerData;

    // Use this for initialization
    void Start()
    {
        playerData = gameObject.GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void FixedUpdate () {
		
        if (!playerData.isSwinging )
        {
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0), smoothing * Time.deltaTime);
        }
	}
}
