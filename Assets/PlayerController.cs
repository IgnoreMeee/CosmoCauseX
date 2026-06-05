using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera ourCam;

    //declaring buttons
    public GameObject DoorButtonLeft;
    public GameObject DoorButtonRight;
    public GameObject VentButtonLeft;
    public GameObject VentButtonRight;
    public doorcontroller doorController;

    //declaring cameras
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;
    public GameObject Camera4;
    public GameObject Camera5;
    public GameObject Camera6;
    public GameObject Camera7;
    public GameObject CameraA;
    public GameObject CameraB;
    public CamController camcontroller;



    Ray ray;
    RaycastHit hit;
    public Collider colliderToHit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //range of button hit
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
        Touch();

    }

    //checks if the ray is otouching a gameobejct

    public void Touch()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(ray, out hit, 30f))
            {
                //Door Opening / Closing
                if (hit.collider.gameObject.CompareTag("ButtonLeft"))
                {
                    GameObject DoorController = GameObject.Find("DoorController");
                    doorcontroller doorController = DoorController.GetComponent<doorcontroller>();
                    doorController.buttonID = 1;
                }

                if (hit.collider.gameObject.CompareTag("ButtonRight"))
                {
                    GameObject DoorController = GameObject.Find("DoorController");
                    doorcontroller doorController = DoorController.GetComponent<doorcontroller>();
                    doorController.buttonID = 2;
                }

                if (hit.collider.gameObject.CompareTag("VentLeft"))
                {
                    GameObject DoorController = GameObject.Find("DoorController");
                    doorcontroller doorController = DoorController.GetComponent<doorcontroller>();
                    doorController.buttonID = 3;
                }

                if (hit.collider.gameObject.CompareTag("VentRight"))
                {
                    GameObject DoorController = GameObject.Find("DoorController");
                    doorcontroller doorController = DoorController.GetComponent<doorcontroller>();
                    doorController.buttonID = 4;
                }

                // Camera Switching
                if (hit.collider.gameObject.CompareTag("Camera1"))
                {
                    GameObject CamController = GameObject.Find("CamController");
                    CamController camcontroller = CamController.GetComponent<CamController>();
                    camcontroller.currentCam = camcontroller.camList[2];
                }

                if (hit.collider.gameObject.CompareTag("Camera2"))
                {
                    GameObject CamController = GameObject.Find("CamController");
                    CamController camcontroller = CamController.GetComponent<CamController>();
                    camcontroller.currentCam = camcontroller.camList[4];
                }

                if (hit.collider.gameObject.CompareTag("Camera3"))
                {
                    GameObject CamController = GameObject.Find("CamController");
                    CamController camcontroller = CamController.GetComponent<CamController>();
                    camcontroller.currentCam = camcontroller.camList[3];
                }

                if (hit.collider.gameObject.CompareTag("Camera4"))
                {
                    GameObject CamController = GameObject.Find("CamController");
                    CamController camcontroller = CamController.GetComponent<CamController>();
                    camcontroller.currentCam = camcontroller.camList[5];
                }

                if (hit.collider.gameObject.CompareTag("Camera5"))
                {
                    GameObject CamController = GameObject.Find("CamController");
                    CamController camcontroller = CamController.GetComponent<CamController>();
                    camcontroller.currentCam = camcontroller.camList[8];
                }

                if (hit.collider.gameObject.CompareTag("Camera6"))
                {
                    GameObject CamController = GameObject.Find("CamController");
                    CamController camcontroller = CamController.GetComponent<CamController>();
                    camcontroller.currentCam = camcontroller.camList[6];
                }

                if (hit.collider.gameObject.CompareTag("Camera7"))
                {
                    GameObject CamController = GameObject.Find("CamController");
                    CamController camcontroller = CamController.GetComponent<CamController>();
                    camcontroller.currentCam = camcontroller.camList[7];
                }

                if (hit.collider.gameObject.CompareTag("CameraA"))
                {
                    GameObject CamController = GameObject.Find("CamController");
                    CamController camcontroller = CamController.GetComponent<CamController>();
                    camcontroller.currentCam = camcontroller.camList[1];
                }

                if (hit.collider.gameObject.CompareTag("CameraB"))
                {
                    GameObject CamController = GameObject.Find("CamController");
                    CamController camcontroller = CamController.GetComponent<CamController>();
                    camcontroller.currentCam = camcontroller.camList[0];
                }
                
            }
        }
    }
}

