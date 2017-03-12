using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOnNextHook : MonoBehaviour {

    public PlayerData playerData;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
        if (playerData.isSwinging)
        {
            gameObject.SetActive(false);
        }
	}
}
