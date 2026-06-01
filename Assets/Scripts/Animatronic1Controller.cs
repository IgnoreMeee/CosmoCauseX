using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Numerics;
using JetBrains.Annotations;
using UnityEngine.Rendering;
using System.Collections;

public class FreddyController : MonoBehaviour
{

    public Clock clock;
    //public CameraControl cameraControl;
    public doorcontroller doorControl;
    public GameObject animatronic;
    //public jumpscareController jumpscareControl;

    difficultycontroller a1;
    public event Action freddyJumpscare;
    UnityEngine.Vector3 currentPos;
    UnityEngine.Vector3 currentCoord;
    UnityEngine.Vector3 targetPos;
    UnityEngine.Vector3 targetPos2;

    public int previousIndex;
    public int locationIndex = 0;
    
    public int location = 6;
    int prevTime = 0;
    int timePerChance;

    int timeSinceJumpscare = 100000;
    float duration = 2.9f;


    int jumpscareFailTime = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clock = clock.GetComponent<Clock>();
        currentPos = transform.position;
        transform.position = new UnityEngine.Vector3(17.57f, currentPos.y, 71.26f); 
        a1 = GameObject.Find("DifficultyController").GetComponent<difficultycontroller>(); 
        timePerChance = 21 - a1.animatronic1difficulty;

        if(a1.animatronic1difficulty > 18)
        {
            duration = 20.9f - a1.animatronic1difficulty;
        }
        
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
                previousIndex = 1;
                locationIndex = getRandom(new int[] {10, 13});
                break;
            case 2:
                previousIndex = 2;
                locationIndex = getRandom(new int[] {3, 8});
                break;
            case 3:
                previousIndex = 3;
                locationIndex = getRandom(new int[] {4, 5});
                break;
            case 4:
                previousIndex = 4;
                locationIndex = 6;
                break;
            case 5:
                previousIndex = 5;
                locationIndex = getRandom(new int[] {6, 9});
                break;
            case 6:
                previousIndex = 6;
                locationIndex = 7;
                break;
            case 7: //jumpscare case
                previousIndex = 7;    
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
                previousIndex = 8;    
                locationIndex = 9;
                break;
            case 9:
                previousIndex = 9;
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
                        Debug.Log("Animatronic Continuing Pursuit");
                    }
                    else //retreat
                    {
                        locationIndex = 0;
                        Debug.Log("Animatronic Retreating!");
                    }
                    
                }
                break;
            case 10:
                previousIndex = 10;
                locationIndex = getRandom(new int[] {11, 12});
                break;
            case 11:
                previousIndex = 11;
                locationIndex = 10;
                break;
            case 12:
                previousIndex = 12;
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
                previousIndex = 13;
                locationIndex = 14;
                break;
            case 14:
                previousIndex = 14;
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
                previousIndex = 0;    
                locationIndex += UnityEngine.Random.Range(1, 3);
                break;        
        }

        switch (locationIndex)
        {
            case 0:
                Debug.Log("original position");
                transform.position = new UnityEngine.Vector3(17.57f, currentPos.y, 71.26f); 
                break;
            case 1:
                targetPos = new UnityEngine.Vector3(-15.63f, currentPos.y, 64.25f);
                StartCoroutine(MoveRoutineLinear(targetPos, duration));
                //transform.position = new UnityEngine.Vector3(-15.63f, currentPos.y, 64.25f);
                break;
            case 2:
                targetPos = new UnityEngine.Vector3(-21.06f, currentPos.y, 101.83f); 
                StartCoroutine(MoveRoutineLinear(targetPos, duration));
                break;
            case 3:
                targetPos = new UnityEngine.Vector3(-21.07f, currentPos.y, 128.4f); 
                targetPos2 = new UnityEngine.Vector3(-41.36f, currentPos.y, 128.4f);
                StartCoroutine(MoveRoutineCurve(targetPos, targetPos2, duration));
                break;
            case 4:
                targetPos = new UnityEngine.Vector3(-41.36f, currentPos.y, 146.92f); 
                targetPos2 = new UnityEngine.Vector3(-61.22f, currentPos.y, 146.92f);
                StartCoroutine(MoveRoutineCurve(targetPos, targetPos2, duration));
                break;
            case 5:
                targetPos = new UnityEngine.Vector3(-66.82f, currentPos.y, 128.4f); //works for both previous indexes (3 and 9)
                StartCoroutine(MoveRoutineLinear(targetPos, duration));
                break;
            case 6:
                if(previousIndex == 5)
                {
                    targetPos = new UnityEngine.Vector3(-81.19f, currentPos.y, 128.4f);
                    StartCoroutine(MoveRoutineLinear(targetPos, duration));
                }
                else
                {
                    targetPos = new UnityEngine.Vector3(-81.19f, currentPos.y, 146.92f);
                    targetPos2 = new UnityEngine.Vector3(-81.19f, currentPos.y, 128.4f);
                    StartCoroutine(MoveRoutineCurve(targetPos, targetPos2, duration));
                }
                
                break;
            case 7:
                targetPos = new UnityEngine.Vector3(-91.87f, currentPos.y, 128.4f); 
                targetPos2 = new UnityEngine.Vector3(-91.87f, currentPos.y, 115.62f);
                StartCoroutine(MoveRoutineCurve(targetPos, targetPos2, duration));
                break;
            case 8:
                targetPos = new UnityEngine.Vector3(-45.61f, currentPos.y, 101.66f); 
                StartCoroutine(MoveRoutineLinear(targetPos, duration));
                break;
            case 9:
                if(previousIndex == 8)
                {
                    targetPos = new UnityEngine.Vector3(-45.61f, currentPos.y, 117.44f);
                    targetPos2 = new UnityEngine.Vector3(-66.76f, currentPos.y, 117.44f); 
                    StartCoroutine(MoveRoutineCurve(targetPos, targetPos2, duration));
                }
                else
                {
                    targetPos = new UnityEngine.Vector3(-66.76f, currentPos.y, 117.44f);
                    StartCoroutine(MoveRoutineLinear(targetPos, duration));
                }
                break;
            case 10:
                if(previousIndex == 1)
                {
                    targetPos = new UnityEngine.Vector3(-66.82f, currentPos.y, 64.27f);
                    StartCoroutine(MoveRoutineLinear(targetPos, duration));
                }
                else
                {
                    targetPos = new UnityEngine.Vector3(-66.82f, currentPos.y, 19.33f);
                    targetPos2 = new UnityEngine.Vector3(-66.82f, currentPos.y, 64.27f);
                    StartCoroutine(MoveRoutineCurve(targetPos, targetPos2, duration));  
                }
                
                break;
            case 11:
                targetPos = new UnityEngine.Vector3(-66.82f, currentPos.y, 19.33f);
                targetPos2 = new UnityEngine.Vector3(-56.77f, currentPos.y, 19.33f);
                StartCoroutine(MoveRoutineCurve(targetPos, targetPos2, duration));  
                break;
            case 12:
                targetPos = new UnityEngine.Vector3(-91.87f, currentPos.y, 64.27f);
                targetPos2 = new UnityEngine.Vector3(-91.87f, currentPos.y, 71.64f);
                StartCoroutine(MoveRoutineCurve(targetPos, targetPos2, duration)); 
                break;
            case 13:
                targetPos = new UnityEngine.Vector3(-23.92f, currentPos.y, 75.63f);
                targetPos2 = new UnityEngine.Vector3(-57.24f, currentPos.y, 75.63f);
                StartCoroutine(MoveRoutineCurve(targetPos, targetPos2, duration)); 
                break;
            case 14:
                targetPos = new UnityEngine.Vector3(-66.83f, currentPos.y, 75.63f);
                targetPos2 = new UnityEngine.Vector3(-66.83f, currentPos.y, 79.56f);
                StartCoroutine(MoveRoutineCurve(targetPos, targetPos2, duration));  
                break;
            default:
                break;
        }
    }

    private IEnumerator MoveRoutineLinear(UnityEngine.Vector3 target, float duration)
    {
        UnityEngine.Vector3 startPosition = transform.position;
        float elapsedTime = 0;

        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            transform.position = UnityEngine.Vector3.Lerp(startPosition, target, t);
            yield return null;
        }

        transform.position = target; 
    }

    private IEnumerator MoveRoutineCurve(UnityEngine.Vector3 target, UnityEngine.Vector3 target2, float duration)
    {
        UnityEngine.Vector3 startPosition = transform.position;
        float elapsedTime = 0;
        duration = duration / 2;

        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            transform.position = UnityEngine.Vector3.Lerp(startPosition, target, t);
            yield return null;
        }

        transform.position = target; 

        startPosition = transform.position;
        elapsedTime = 0;
        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            transform.position = UnityEngine.Vector3.Lerp(startPosition, target2, t);
            yield return null;
        }
        transform.position = target2; 

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

