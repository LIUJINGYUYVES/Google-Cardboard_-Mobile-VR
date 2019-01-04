using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VRInput : MonoBehaviour {

    public event Action OnDown;                                 // Called when Fire1 is pressed.
    public event Action OnUp;  

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        CheckInput();

	}

    private void CheckInput()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            // If anything has subscribed to OnDown call it.
            if (OnDown != null)
                OnDown();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            // If anything has subscribed to OnDown call it.
            if (OnUp != null)
                OnUp();
        }


    }

    private void OnDestroy()
    {
        // Ensure that all events are unsubscribed when this is destroyed.
        OnDown = null;
        OnUp = null;
    }

}
