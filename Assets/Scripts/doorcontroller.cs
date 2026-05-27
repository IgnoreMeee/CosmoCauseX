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
    
    public bool leftDoorClosed = false;
    public bool rightDoorClosed = false;
    public bool leftVentClosed = false;
    public bool rightVentClosed = false;

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
                LeftDoor.transform.position = new Vector3(LeftDoor.transform.position.x, LeftDoor.transform.position.y - 4, LeftDoor.transform.position.z);
                leftDoorClosed = true;
            }
            else
            {
                //move door up
                LeftDoor.transform.position = new Vector3(LeftDoor.transform.position.x, LeftDoor.transform.position.y + 4, LeftDoor.transform.position.z);
                leftDoorClosed = false;

            }

            buttonID = 0;
        }

        if (buttonID == 2)
        {
            if (rightDoorClosed == false)
            {
                RightDoor.transform.position = new Vector3(RightDoor.transform.position.x, RightDoor.transform.position.y - 4, RightDoor.transform.position.z);
                rightDoorClosed = true;
            }
            else
            {
                RightDoor.transform.position = new Vector3(RightDoor.transform.position.x, RightDoor.transform.position.y + 4, RightDoor.transform.position.z);
                rightDoorClosed = false;
            }

            buttonID = 0;
        }

        if (buttonID == 3)
        {
            if (leftVentClosed == false)
            {
                LeftVent.transform.position = new Vector3(LeftVent.transform.position.x, LeftVent.transform.position.y - 2, LeftVent.transform.position.z);
                leftVentClosed = true;
            }
            else
            {
                LeftVent.transform.position = new Vector3(LeftVent.transform.position.x, LeftVent.transform.position.y + 2, LeftVent.transform.position.z);
                leftVentClosed = false;
            }

            buttonID = 0;
        }

        if (buttonID == 4)
        {
            if (rightVentClosed == false)
            {
                RightVent.transform.position = new Vector3(RightVent.transform.position.x, RightVent.transform.position.y - 2, RightVent.transform.position.z);
                rightVentClosed = true;
            }
            else
            {
                RightVent.transform.position = new Vector3(RightVent.transform.position.x, RightVent.transform.position.y + 2, RightVent.transform.position.z);
                rightVentClosed = false;
            }

            buttonID = 0;
        }




    }
}
