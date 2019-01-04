using System.Collections;
using UnityEngine;

public class FloorInteractable : VRInteractableBase
{

    public Transform mainCamera;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnInteractableDown(bool isClicked)
    {
        base.OnInteractableDown(isClicked);
        StartCoroutine(MoveUp());


    }

    private IEnumerator MoveUp()
    {

        Vector3 destinationPosition = new Vector3(-5.37f, 4.92f, 2.65f);

        // Fading is now happening.  This ensures it won't be interupted by non-coroutine calls.
        float movingTime = 3f;
        Vector3 originalPosition = mainCamera.transform.position;

        // Execute this loop once per frame until the timer exceeds the duration.
        float passedTime = 0f;
        while (passedTime <= movingTime)
        {
            // Set the colour based on the normalised time.
            mainCamera.transform.position = Vector3.Lerp(originalPosition, destinationPosition, passedTime / movingTime);

            // Increment the timer by the time between frames and return next frame.
            passedTime += Time.deltaTime;
            yield return null;
        }

    }
}
