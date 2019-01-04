using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ScreenInteractable : VRInteractableBase
{

    public VideoPlayer videoplayer;
	public Material screenMaterial;
    public bool isLoading = false;
    public GameObject console1;

	// Use this for initial
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(isLoading == false)
        {
            videoplayer.Stop();
            screenMaterial.color = Color.black;
            if (console1.transform.localScale.x < 0.7375f)
            {
                console1.transform.localScale += new Vector3(0.005f, 0.005f, 0.005f);
            }
        }
        if(videoplayer.isPlaying && console1.transform.localScale.x > 0.0f)
        {
            console1.transform.localScale -= new Vector3(0.005f, 0.005f, 0.005f);
        }
	}

    public override void OnInteractableDown(bool isClicked)
    {
        base.OnInteractableDown(isClicked);
        screenMaterial.color = Color.white;
        videoplayer.Play();
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
