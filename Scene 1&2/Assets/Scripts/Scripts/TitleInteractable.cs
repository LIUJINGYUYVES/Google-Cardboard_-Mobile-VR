using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleInteractable : VRInteractableBase
{
    public GameObject sphere;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnInteractableRayIn()
    {
        base.OnInteractableRayIn();
        sphere.SetActive(false);
    }

    public override void OnInteractableRayOut()
    {
        base.OnInteractableRayOut();
        sphere.SetActive(true);
    }
}
