using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ProgressBarInteractable : VRInteractableBase
{
    //public TextMeshProUGUI title;
    //public Text title;
    public Image ButtonImage;
    public Text text;
    public float GazeTriggerTime = 2f;
    private bool isLoading = false;
    private float counter;
    public GameObject sphere;
    public GameObject vrCamera;

    void Awake()
    {
        //title = gameObject.AddComponent<TextMeshProUGUI>();
    }

	
	// Update is called once per frame
	void Update () {

        if (isLoading)
        {

            counter += Time.deltaTime;

            ButtonImage.fillAmount = counter / GazeTriggerTime;

            if (counter > GazeTriggerTime)
            {
                isLoading = false;

                StartCoroutine(LoadScene());
            }

        }

    }

    public override void OnInteractableDown(bool isClicked)
    {
        base.OnInteractableDown(isClicked);

        StartCoroutine(LoadScene());
    }

    public override void OnInteractableRayIn()
    {
        base.OnInteractableRayIn();

        sphere.SetActive(false);

        isLoading = true;

        text.text = "LOADING";
    }

    public override void OnInteractableRayOut()
    {
        base.OnInteractableRayOut();

        sphere.SetActive(true);

        isLoading = false;

        ButtonImage.fillAmount = 0;

        counter = 0;

        text.text = "START";
    }

    private IEnumerator LoadScene()
    {

        sphere.SetActive(false);

        text.gameObject.SetActive(false);

        float movingTime = 7.0f;

        Vector3 cameraOriginalPosition = vrCamera.gameObject.transform.position;

        Vector3 buttonOriginalPosition = ButtonImage.gameObject.transform.position;
        
        Vector3 buttonDestinationPosition = new Vector3(ButtonImage.gameObject.transform.position.x, ButtonImage.gameObject.transform.position.y + 80.0f, ButtonImage.gameObject.transform.position.z + 100.0f);

        Vector3 cameraDestinationPosition = new Vector3(0.0f, 1.0f, -100.0f);

        Quaternion cameraDestinationRotation = new Quaternion(0.0f, 180.0f, 0.0f, 0);

        // Execute this loop once per frame until the timer exceeds the duration.
        float passedTime = 0.0f;
        while (passedTime <= movingTime)
        {
            // Set the colour based on the normalised time.
            vrCamera.gameObject.transform.position = Vector3.Lerp(cameraOriginalPosition, cameraDestinationPosition, passedTime / movingTime);

            ButtonImage.gameObject.transform.position = Vector3.Lerp(buttonOriginalPosition, buttonDestinationPosition, passedTime / movingTime);

            // Increment the timer by the time between frames and return next frame.
            passedTime += Time.deltaTime;
            yield return null;
        }
        vrCamera.gameObject.transform.rotation = cameraDestinationRotation;
        SceneManager.LoadScene("Scene2");
    }
    
}
