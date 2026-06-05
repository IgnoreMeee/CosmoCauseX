using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class doorcontroller : MonoBehaviour
{
    //GameObjects
    public GameObject LeftDoor;
    public GameObject RightDoor;
    public GameObject LeftVent;
    public GameObject RightVent;

    public GameObject ArnavCubthur;
    
    public bool leftDoorClosed = false;
    public bool rightDoorClosed = false;
    public bool leftVentClosed = false;
    public bool rightVentClosed = false;

    public bool cubeClosed = false;

    public int buttonID = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (buttonID == 1)
        {
            if (leftDoorClosed == false)
            {
                //move door down 
                LeftDoor.transform.localPosition = new Vector3(LeftDoor.transform.localPosition.x, 20, LeftDoor.transform.localPosition.z);
                leftDoorClosed = true;
                Debug.Log("Mimic Closepot");
            }
            else
            {
                //move door up
                LeftDoor.transform.localPosition = new Vector3(LeftDoor.transform.localPosition.x, 220, LeftDoor.transform.localPosition.z);
                leftDoorClosed = false;
                Debug.Log("Mimic Openpot");

            }
            
            Debug.Log("Mimic Jackpot");
            buttonID = 0;
        }

        if (buttonID == 2)
        {
            if (rightDoorClosed == false)
            {
                RightDoor.transform.localPosition = new Vector3(RightDoor.transform.localPosition.x, 20, RightDoor.transform.localPosition.z);
                rightDoorClosed = true;
            }
            else
            {
                RightDoor.transform.localPosition = new Vector3(RightDoor.transform.localPosition.x, 220, RightDoor.transform.localPosition.z);
                rightDoorClosed = false;
            }

            buttonID = 0;
        }

        if (buttonID == 3)
        {
            if (leftVentClosed == false)
            {
                LeftVent.transform.localPosition = new Vector3(LeftVent.transform.localPosition.x, 20, LeftVent.transform.localPosition.z);
                leftVentClosed = true;
            }
            else
            {
                LeftVent.transform.localPosition = new Vector3(LeftVent.transform.localPosition.x, 220 , LeftVent.transform.localPosition.z);
                leftVentClosed = false;
            }

            buttonID = 0;
        }

        if (buttonID == 4)
        {
            if (rightVentClosed == false)
            {
                RightVent.transform.localPosition = new Vector3(RightVent.transform.localPosition.x, 20, RightVent.transform.localPosition.z);
                rightVentClosed = true;
            }
            else
            {
                RightVent.transform.localPosition = new Vector3(RightVent.transform.localPosition.x, 220, RightVent.transform.localPosition.z);
                rightVentClosed = false;
            }

            buttonID = 0;
        }

        if (buttonID == 5)
        {
            if (cubeClosed == false)
            {
                ArnavCubthur.transform.localPosition = new Vector3(ArnavCubthur.transform.localPosition.x, 20, ArnavCubthur.transform.localPosition.z);
                cubeClosed = true;
            }
            else
            {
                ArnavCubthur.transform.localPosition = new Vector3(ArnavCubthur.transform.localPosition.x, 220, ArnavCubthur.transform.localPosition.z);
                cubeClosed = false;
            }

            buttonID = 0;
        }

        




    }
}