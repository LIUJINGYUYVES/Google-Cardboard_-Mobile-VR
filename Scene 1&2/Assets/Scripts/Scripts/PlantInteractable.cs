using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInteractable : VRInteractableBase
{

    public float GazeTriggerTime = 2f;
    private bool isLoading = false;
    private float counter = 0.0f;
    public Transform plant;
    //private CharacterController characterController;

    // Use this for initialization
    void Start () {
        //characterController = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {

        if(isLoading && plant.transform.localScale.x <= 1.8f)
        {
            counter += Time.deltaTime;
            if (counter > GazeTriggerTime)
            {
                plant.transform.localScale += new Vector3(0.005f, 0.005f, 0.005f); 
            }
        }
        else
        {
            if (plant.transform.localScale.x > 1.0f)
            {
                plant.transform.localScale -= new Vector3(0.005f, 0.005f, 0.005f);
            }   
        }
	}

    public override void OnInteractableRayIn()
    {
        base.OnInteractableRayIn();
        isLoading = true;
    }

    public override void OnInteractableRayOut()
    {
        base.OnInteractableRayOut();
        isLoading = false;
    }

}
