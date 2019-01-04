using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRFocusMarkerBase : MonoBehaviour {

    [SerializeField] private VRFocusRayCaster vrRayCaster;
    private bool isFocused = false;
    private float processingTime = 10;
    private float focusTime = 0;

	// Use this for initialization
	void Start () {
		
        if (this.vrRayCaster == null)
        {
            throw new System.Exception("ray caster is null");
        }

	}
	
	// Update is called once per frame
	void Update () {
		
        if (this.isFocused)
        {
            this.focusTime = this.focusTime + Time.deltaTime;

            if (this.focusTime >= this.processingTime)
            {
                this.OnFocusMarkerExecute();
                this.OnFocusMarkerStop();
            }

        }


    }

    //click
    public virtual void OnFocusMarkerStart()
    {
        this.isFocused = true;

    }


    public virtual void OnFocusMarkerStop()
    {
        this.isFocused = false;
        this.focusTime = 0;
    }

    public virtual void OnFocusMarkerExecute()
    {
        if (this.vrRayCaster.CurrentInteractable != null)
        {
            this.vrRayCaster.CurrentInteractable.OnInteractableDown(false);
        }
    }

}
