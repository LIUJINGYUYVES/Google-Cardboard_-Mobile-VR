using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRFocusRayCaster : MonoBehaviour {

    [SerializeField] private VRInput vrInput;
    [SerializeField] private VRFocusMarkerBase vrFocusMarker;
    private GameObject focusCamera;
    private VRInteractableBase currentInteractable;

    public VRInteractableBase CurrentInteractable { get { return currentInteractable; } }

	private void OnDestroy()
	{
        vrInput.OnUp -= HandleUp;
        vrInput.OnDown -= HandleDown;
	}

	// Use this for initialization
	void Start () {

        if (this.vrInput == null)
        {
            throw new System.Exception("vrinput is null");
        }

        if (this.vrFocusMarker == null)
        {
            throw new System.Exception("focus marker is null");
        }

        this.focusCamera = Camera.main.gameObject;

        vrInput.OnUp += HandleUp;
        vrInput.OnDown += HandleDown;

	}
	
	// Update is called once per frame
	void Update () {

        this.FocusRaycast();

	}

    private void FocusRaycast(){

        // Create a ray that points forwards from the camera.
        Ray ray = new Ray(this.focusCamera.transform.position, this.focusCamera.transform.forward);
        RaycastHit hit;

        // Do the raycast forweards to see if we hit an interactive item
        if (Physics.Raycast(ray, out hit, 1000))
        {
            VRInteractableBase interactible = hit.collider.gameObject.GetComponent<VRInteractableBase>();

            if ((interactible == null && this.currentInteractable != null)
               || (interactible != null && interactible != this.currentInteractable && this.currentInteractable != null))
            {
                this.currentInteractable.OnInteractableRayOut();
                this.vrFocusMarker.OnFocusMarkerStop();
            }

            if (interactible != null && interactible != this.currentInteractable)
            {
                interactible.OnInteractableRayIn();
                this.vrFocusMarker.OnFocusMarkerStart();
            }

            this.currentInteractable = interactible;

        }
        else
        {
            if (this.currentInteractable != null)
            {
                this.currentInteractable.OnInteractableRayOut();
                this.vrFocusMarker.OnFocusMarkerStop();
            }

            this.currentInteractable = null;
        }

    }

    private void HandleUp()
    {
        if (this.currentInteractable!= null)
            this.currentInteractable.OnInteractableUp(true);
    }


    private void HandleDown()
    {
        if (this.currentInteractable != null)
        {
            this.currentInteractable.OnInteractableDown(true);
            this.vrFocusMarker.OnFocusMarkerStop();
        }
            
    }



}
