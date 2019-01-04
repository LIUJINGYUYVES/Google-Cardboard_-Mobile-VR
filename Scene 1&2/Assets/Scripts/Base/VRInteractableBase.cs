using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class VRInteractableBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //click
    public virtual void OnInteractableDown(bool isClicked)
    {


    }


    public virtual void OnInteractableUp(bool isClicked)
    {


    }

    //ray
    public virtual void OnInteractableRayIn()
    {


    }


    public virtual void OnInteractableRayOut()
    {


    }

}
