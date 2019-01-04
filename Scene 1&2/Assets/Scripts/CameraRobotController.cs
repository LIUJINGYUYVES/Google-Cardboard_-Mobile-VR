using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRobotController : MonoBehaviour
{

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public Transform robotKyle;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        #if UNITY_EDITOR
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        robotKyle.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        #endif

        //Color col = GetComponent<Camera>().backgroundColor;
        //col.b = Random.Range(10f, 60f);
        //col.r = Random.Range(10f, 70f);
        //col.g = Random.Range(10f, 90f);
        //col.b = col.b + 0.01f;
        //GetComponent<Camera>().backgroundColor = col;


    }
}
