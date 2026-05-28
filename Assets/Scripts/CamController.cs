using UnityEngine;

public class CamController : MonoBehaviour
{
    Camera currentCam;
    Camera cam1;
    Camera cam2;
    Camera[] camList = new Camera[2];
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam1 = GameObject.Find("Cam1").GetComponent<Camera>();
        cam2 = GameObject.Find("Cam2").GetComponent<Camera>();
        
        currentCam = cam1;

        camList[0] = cam1;
        camList[1] = cam2;
    }

    // Update is called once per frame
    void Update()
    {
        SwapCams();
    }

    void SwapCams()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentCam == cam1)
            {
                currentCam = cam2;
            } else
            {
                currentCam = cam1;
            }
            SwitchTexture();
        }
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
