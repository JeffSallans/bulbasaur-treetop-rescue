using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupDefaultXboxInput : MonoBehaviour {

	// Use this for initialization
	void Awake() {
        var inputManager = InputManager.getCurrentInputManager();

        inputManager.assignPlayerInput(new ControllerPlayerInput(1));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
