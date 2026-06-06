using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Collections;

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
                //LeftDoor.transform.localPosition = new Vector3(LeftDoor.transform.localPosition.x, 20, LeftDoor.transform.localPosition.z);
                StartCoroutine(move(LeftDoor, new Vector3(LeftDoor.transform.localPosition.x, 20, LeftDoor.transform.localPosition.z)));
                SoundManager.Instance.PlaySFX(SoundManager.Instance.door);
                leftDoorClosed = true;
                Debug.Log("Mimic Closepot");
            }
            else
            {
                //move door up
                //LeftDoor.transform.localPosition = new Vector3(LeftDoor.transform.localPosition.x, 220, LeftDoor.transform.localPosition.z);
                StartCoroutine(move(LeftDoor, new Vector3(LeftDoor.transform.localPosition.x, 120.7f, LeftDoor.transform.localPosition.z)));
                SoundManager.Instance.PlaySFX(SoundManager.Instance.door);
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
                //RightDoor.transform.localPosition = new Vector3(RightDoor.transform.localPosition.x, 20, RightDoor.transform.localPosition.z);\
                StartCoroutine(move(RightDoor, new Vector3(RightDoor.transform.localPosition.x, 20, RightDoor.transform.localPosition.z)));
                SoundManager.Instance.PlaySFX(SoundManager.Instance.door);
                rightDoorClosed = true;
            }
            else
            {
                //RightDoor.transform.localPosition = new Vector3(RightDoor.transform.localPosition.x, 220, RightDoor.transform.localPosition.z);
                StartCoroutine(move(RightDoor, new Vector3(RightDoor.transform.localPosition.x, 120.7f, RightDoor.transform.localPosition.z)));
                SoundManager.Instance.PlaySFX(SoundManager.Instance.door);
                rightDoorClosed = false;
            }

            buttonID = 0;
        }

        if (buttonID == 3)
        {
            if (leftVentClosed == false)
            {
                //LeftVent.transform.localPosition = new Vector3(LeftVent.transform.localPosition.x, 20, LeftVent.transform.localPosition.z);
                StartCoroutine(move(LeftVent, new Vector3(LeftVent.transform.localPosition.x, 20f, LeftVent.transform.localPosition.z)));
                SoundManager.Instance.PlaySFX(SoundManager.Instance.door);
                leftVentClosed = true;
            }
            else
            {
                //LeftVent.transform.localPosition = new Vector3(LeftVent.transform.localPosition.x, 220 , LeftVent.transform.localPosition.z);
                StartCoroutine(move(LeftVent, new Vector3(LeftVent.transform.localPosition.x, 78.3f, LeftVent.transform.localPosition.z)));
                SoundManager.Instance.PlaySFX(SoundManager.Instance.door);
                leftVentClosed = false;
            }

            buttonID = 0;
        }

        if (buttonID == 4)
        {
            if (rightVentClosed == false)
            {
                //RightVent.transform.localPosition = new Vector3(RightVent.transform.localPosition.x, 20, RightVent.transform.localPosition.z);
                StartCoroutine(move(RightVent, new Vector3(RightVent.transform.localPosition.x, 20f, RightVent.transform.localPosition.z)));
                SoundManager.Instance.PlaySFX(SoundManager.Instance.door);
                rightVentClosed = true;
            }
            else
            {
                //RightVent.transform.localPosition = new Vector3(RightVent.transform.localPosition.x, 220, RightVent.transform.localPosition.z);
                StartCoroutine(move(RightVent, new Vector3(RightVent.transform.localPosition.x, 78.3f, RightVent.transform.localPosition.z)));
                SoundManager.Instance.PlaySFX(SoundManager.Instance.door);
                rightVentClosed = false;
            }

            buttonID = 0;
        }

        if (buttonID == 5)
        {
            if (cubeClosed == false)
            {
                ArnavCubthur.transform.localPosition = new Vector3(ArnavCubthur.transform.localPosition.x, 20, ArnavCubthur.transform.localPosition.z);
                SoundManager.Instance.PlaySFX(SoundManager.Instance.door);
                cubeClosed = true;
            }
            else
            {
                ArnavCubthur.transform.localPosition = new Vector3(ArnavCubthur.transform.localPosition.x, 220, ArnavCubthur.transform.localPosition.z);
                SoundManager.Instance.PlaySFX(SoundManager.Instance.door);
                cubeClosed = false;
            }

            buttonID = 0;
        }

        
    IEnumerator move(GameObject thing, UnityEngine.Vector3 target)
    {
        UnityEngine.Vector3 startPosition = thing.transform.localPosition;
        float elapsedTime = 0;
        float duration = 0.2f;

        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            thing.transform.localPosition = UnityEngine.Vector3.Lerp(startPosition, target, t);
            yield return null;
        }

        thing.transform.localPosition = target; 
    }



    }

}