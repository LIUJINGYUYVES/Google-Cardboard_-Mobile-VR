using UnityEngine;

public class RoofInteractable : VRInteractableBase
{

    public Transform floor;

    public Transform mainCamera;

    //private CharacterController characterController;

    public bool isLoading;

    // Use this for initialization
    void Start () {

        //characterController = GetComponent<CharacterController>();

    }
	
	// Update is called once per frame
	void Update () {

        //if (isLoading && floor.transform.localScale.x > 0.2f && floor.transform.position.y > 0)
        //{
        //    floor.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
        //    floor.transform.localScale -= new Vector3(0.005f, 0.005f, 0.005f);
        //}
        //else
        //{
        //    transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        //}
        if(isLoading)
        {
            if (floor.transform.localScale.x > 0.2f)
            {
                floor.transform.localScale -= new Vector3(0.005f, 0.005f, 0.005f);
            }
            if (floor.transform.position.y > 0.2f)
            {
                floor.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
                if(mainCamera.position.y > 0.57f)
                {
                    //mainCamera.position = new Vector3(floor.transform.position.x, floor.transform.position.y + 1.0f, floor.transform.position.z);
                    mainCamera.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
                }
            }
            if(floor.transform.localScale.x <= 0.2f && floor.transform.position.y <= 0.2f)
            {
                isLoading = false;
                mainCamera.position = new Vector3(floor.transform.position.x, floor.transform.position.y + 1.0f, floor.transform.position.z);
            }
        }
        else
        {
            if (floor.transform.localScale.x < 1.0f && floor.transform.localScale.y < 1.0f)
            {
                floor.transform.localScale += new Vector3(0.005f, 0.005f, 0.005f);
            }
            if (floor.transform.position.y <= 4.0f)
            {
                floor.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
                if (mainCamera.transform.position.y <= 6.0f)
                {
                    mainCamera.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
                }
            }
        }

    }

    public override void OnInteractableDown(bool isClicked)
    {
        base.OnInteractableDown(isClicked);
        isLoading = true;
    }

}
