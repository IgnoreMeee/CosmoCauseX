using UnityEngine;

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
    Camera[] camList = new Camera[10];
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        currentCam = StageCam;

        camList[0] = currentCam;
        camList[1] = StageCam;
        camList[2] = DiningCam;
        camList[3] = LeftHallCam;
        camList[4] = LeftCornerCam;
        camList[5] = JustinCam;
        camList[6] = LeftVentCam;
        camList[7] = RightHallCam;
        camList[8] = RightRandomRoomCam;
        camList[9] = RightVentCam;

    }

    // Update is called once per frame
    void Update()
    {
        SwapCams();
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
}
