using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class CamController : MonoBehaviour
{
    Camera currentCam;

    public Camera StageCam;
    public Camera DiningCam;
    public Camera LeftHallCam;
    public Camera LeftCornerCam;
    public Camera JustinCam;
    public Camera LeftVentCam;
    public Camera RightHallCam;
    public Camera RightRandomRoomCam;
    public Camera RightVentCam;
    int camCursor = 0;
    Camera[] camList = new Camera[9];
    float[] camRot = new float[9];
    float[] camLeftRot = new float[9];
    float[] camRightRot = new float[9];
    bool camIsTurningLeft = true;
    bool camIsTurningRight = false;
    bool canFlip = true;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        currentCam = StageCam;

        camList[0] = StageCam;
        camList[1] = DiningCam;
        camList[2] = LeftHallCam;
        camList[3] = LeftCornerCam;
        camList[4] = JustinCam;
        camList[5] = LeftVentCam;
        camList[6] = RightHallCam;
        camList[7] = RightRandomRoomCam;
        camList[8] = RightVentCam;

        
    for (int i = 0; i < camList.Length; i++) camRot[i] = camList[i].transform.eulerAngles.y;
    for (int i = 0; i < camList.Length; i++) camLeftRot[i] = camList[i].transform.eulerAngles.y - 20f;
    for (int i = 0; i < camList.Length; i++) camRightRot[i] = camList[i].transform.eulerAngles.y + 20f;

    }

    // Update is called once per frame
    void Update()
    {
        SwapCams();
        MoveCameras();

        for (int i = 0; i < camList.Length; i++)
        {
            if (camList[i].depth == 0)
            {
                camList[i].gameObject.SetActive(false);
            } else
            {
                camList[i].gameObject.SetActive(true);
            }
        }
    }

    void SwapCams()
    {
            if (Input.anyKeyDown && !string.IsNullOrEmpty(Input.inputString))
        {
            if (int.TryParse(Input.inputString, out int index))
            {
                currentCam = camList[index];
            }
        }

        // if (Input.GetKeyDown(KeyCode.F)) {

        //     if (camCursor == 9) camCursor = -1;
        //     camCursor++;

        //     currentCam = camList[camCursor];
            SwitchTexture();
        // } 
        
            
        
    }

    void SwitchTexture()
    {
        currentCam.depth = 2;
        for (int i = 0; i < camList.Length; i++)
        {
            if (camList[i] != currentCam)
            {
                camList[i].depth = 0;
            }
        }
    }

    void MoveCameras()
    {
        if (camIsTurningLeft) {
        for (int i = 0; i < camList.Length; i++)
        {
            Transform camTransform = camList[i].transform;
            float currentY = camTransform.eulerAngles.y;
            float nextY = Mathf.MoveTowardsAngle(currentY, camLeftRot[i], 2f * Time.deltaTime);
            camTransform.rotation = Quaternion.Euler(camTransform.eulerAngles.x, nextY, camTransform.eulerAngles.z);
        }

        }

        if (camIsTurningRight) {
            
        for (int i = 0; i < camList.Length; i++)
        {
            Transform camTransform = camList[i].transform;
            float currentY = camTransform.eulerAngles.y;
            float nextY = Mathf.MoveTowardsAngle(currentY, camRightRot[i], 2f * Time.deltaTime);
            camTransform.rotation = Quaternion.Euler(camTransform.eulerAngles.x, nextY, camTransform.eulerAngles.z);
        }

        }

        if ((Mathf.Abs(Mathf.DeltaAngle(camList[0].transform.eulerAngles.y, camLeftRot[0])) <= 0.5f ||
           Mathf.Abs(Mathf.DeltaAngle(camList[0].transform.eulerAngles.y, camRightRot[0])) <= 0.5f)
           && canFlip) {

            StartCoroutine(SwapCamDir(3f));
            canFlip = false;
        }

        if (camList[0].transform.eulerAngles.y >= camRot[0] - 2f && camList[0].transform.eulerAngles.y <= camRot[0] + 2f) 
        {canFlip = true;}
        
        }
    
    
    

    IEnumerator SwapCamDir(float delay) {
        yield return new WaitForSeconds(delay);
        if (camIsTurningLeft) {
            camIsTurningLeft = false;
            camIsTurningRight = true;
        } else {
            camIsTurningLeft = true;
            camIsTurningRight = false;
        }
        
    }
}
    
