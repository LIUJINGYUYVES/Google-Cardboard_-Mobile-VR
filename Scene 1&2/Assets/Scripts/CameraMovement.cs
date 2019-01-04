using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject mainCamera;

    public Transform vrCamera;

    public float toggleAngle = 30.0f;

    public bool moveForward;

    public Animator animator;

    private CharacterController characterController;

    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update () {

        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
        {
            moveForward = true;
        }
        else
        {
            moveForward = false;
        }
        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            characterController.SimpleMove(forward * vrCamera.eulerAngles.x / 20);
            //animator.Play("WalkRM");
            animator.enabled = true;
            if (Camera.main.fieldOfView >= 60.0f)
            {
                Camera.main.fieldOfView -= Time.deltaTime * 2;
            }

        }
        else
        {
            Camera.main.fieldOfView = 80.0f;
            animator.enabled = false;
        }
    }
}
