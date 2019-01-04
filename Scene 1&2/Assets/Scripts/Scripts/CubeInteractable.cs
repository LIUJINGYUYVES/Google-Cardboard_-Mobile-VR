using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeInteractable : VRInteractableBase {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnInteractableDown(bool isClicked)
    {
        base.OnInteractableDown(isClicked);

        //var rigidBody = this.gameObject.GetComponent<Rigidbody>();
        //rigidBody.useGravity = true;
        SceneManager.LoadScene("PwCFuture");
    }


}
