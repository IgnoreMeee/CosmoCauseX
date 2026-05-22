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
                Debug.Log("Index: " + locationIndex);
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

            case 1:
                locationIndex = getRandom(new int[] {10, 13});
                break;
            case 2:
                locationIndex = getRandom(new int[] {3, 8});
                break;
            case 3:
                locationIndex = getRandom(new int[] {4, 5});
                break;
            case 4:
                locationIndex = 6;
                break;
            case 5:
                locationIndex = getRandom(new int[] {6, 9});
                break;
            case 6:
                locationIndex = 7;
                break;
            case 7: //jumpscare case
                if (doorControl.leftDoorClosed == false)
                {
                    jumpscare();
                    locationIndex = 0;
                } else
                {
                    locationIndex = 0;
                }
                break;
            case 8:
                locationIndex = 9;
                break;
            case 9:
                if (doorControl.leftDoorClosed == false)
                {
                    jumpscare();
                    locationIndex = 0;
                } else
                {
                    int continueAttack = getRandom(new int[] {1, 2});
                    if (continueAttack == 1) //continue
                    {
                        locationIndex = 5;
                    }
                    else //retreat
                    {
                        locationIndex = 0;
                    }
                    
                }
                break;
            case 10:
                locationIndex = getRandom(new int[] {11, 12});
                break;
            case 11:
                locationIndex = 10;
                break;
            case 12:
                if (doorControl.rightDoorClosed == false)
                {
                    jumpscare();
                    locationIndex = 0;
                } else
                {
                    locationIndex = 0;
                }
            break;
            case 13:
                locationIndex = 14;
                break;
            case 14:
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

    public int getRandom(int[] array)
    {
        int randomIndex = UnityEngine.Random.Range(0, array.Length);
        int result = array[randomIndex];
        return result;
    }

    void jumpscare()
    {
        Debug.Log("Jumpscare!");
        //jumpscareControl.killerAnimtronic = "Freddy";
        //freddyJumpscare.Invoke();
        timeSinceJumpscare = clock.seconds;
       
    }
}

