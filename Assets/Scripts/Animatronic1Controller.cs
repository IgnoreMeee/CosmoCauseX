using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class FreddyController : MonoBehaviour
{

    public Clock clock;
    //public CameraControl cameraControl;
    public doorcontroller doorControl;
    //public jumpscareController jumpscareControl;

    public event Action freddyJumpscare;

    public int locationIndex = 0;
    
    public int location = 6;
    int prevTime = 0;
    int timePerChance = 7;

    int timeSinceJumpscare = 100000;

    int jumpscareFailTime = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clock = clock.GetComponent<Clock>();
        //cameraControl = cameraControl.GetComponent<CameraControl>();
        //doorControl = doorControl.GetComponent<DoorControl>();
        //jumpscareControl = jumpscareControl.GetComponent<jumpscareController>();
    }
    // Update is called once per frame
    void Update()
    {
        moveTime();
        // if (clock.seconds == 5)
        // {
        //     jumpscare();
        // }
        
    }

    void moveTime()
    {
        if (clock.seconds == prevTime + timePerChance)
        {
            prevTime = clock.seconds;
            
            if (UnityEngine.Random.Range(1, 2) == 1)
            {
                Move();
                Debug.Log("Freddy: " + locationIndex);
            }
           
            
        }

        if (clock.seconds == timeSinceJumpscare + 3)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void Move()
    {
        switch (locationIndex)
        {
            case 4:
                locationIndex = 6;
                break;
            case 5:
                locationIndex = 7;
                break;
            case 6:
                if (doorControl.leftDoorClosed == false)
                {
                    jumpscare();
                    locationIndex = 0;
                } else
                {
                    locationIndex = 0;
                }
                break;

            case 7:
                if (doorControl.rightDoorClosed == false)
                {
                    jumpscare();
                    locationIndex = 0;
                } else
                {
                    locationIndex = 0;
                }
                break;

            default:
                locationIndex += UnityEngine.Random.Range(1, 3);
                break;
        
        }
    }

    void jumpscare()
    {
        Debug.Log("Jumpscare!");
        //jumpscareControl.killerAnimtronic = "Freddy";
        //freddyJumpscare.Invoke();
        timeSinceJumpscare = clock.seconds;
       
    }
}

