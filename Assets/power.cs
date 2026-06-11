using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class power : MonoBehaviour
{
    public Clock clock;
    public doorcontroller doorControl;
    public AudioSource audioSource;
    public MimicController mimicController;


    float prevSecond = 0;
    float powerLossOverTime = 1.5f;
    float counterBeforePowerLoss = 0;
    float powerLossRate = 20;

    float powerLossLeftDoor = 0;
    float powerLossRightDoor = 0;
    float totalpowerLoss = 0;
    float powerLossCounterIncreaseTotal = 0;

    public float Power;
    public float maxPower = 100;
    public float powerPercent = 100;

    bool outageSoundPlayed = false;
    bool jumpscared = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        Debug.Log($"START: maxPower={maxPower}, Power={Power}");
        maxPower = SaveData.Instance.info.max;
        Power = SaveData.Instance.info.max;

        clock = clock.GetComponent<Clock>();
        doorControl = doorControl.GetComponent<doorcontroller>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Power <= 0)
        {
            Power = 0;

            /* if(outageSoundPlayed == false)
            {
                audioSource.Play();
                outageSoundPlayed = true;
            } */

            if(jumpscared == false)
            {
                mimicController.jumpscare();
                jumpscared = true;
            }
            



        } else
        {
            losePower();
        }

        doorPowerLoss();
        powerPercent = Mathf.FloorToInt((Power / maxPower) * 100);

    }

    void losePower()
    {
        powerLossCounterIncreaseTotal = powerLossOverTime + totalpowerLoss;

        if (clock.seconds != prevSecond)
        {
            prevSecond = clock.seconds;
            counterBeforePowerLoss  += powerLossCounterIncreaseTotal;

            if (counterBeforePowerLoss >= powerLossRate)
            {
                Power--;
                counterBeforePowerLoss = 0;
            }
        }
    }

    void doorPowerLoss()
    {
        if (doorControl.leftDoorClosed)
        {
            powerLossLeftDoor = 7f;
        } else
        {
            powerLossLeftDoor = 0;
        }
        if (doorControl.rightDoorClosed)
        {
            powerLossRightDoor = 7f;
        } else
        {
            powerLossRightDoor = 0;
        }
        if (doorControl.leftVentClosed)
        {
            powerLossLeftDoor = 7f;
        } else
        {
            powerLossLeftDoor = 0;
        }
        if (doorControl.rightVentClosed)
        {
            powerLossRightDoor = 7f;
        } else
        {
            powerLossRightDoor = 0;
        }

        totalpowerLoss = powerLossLeftDoor + powerLossRightDoor;
    }

}
