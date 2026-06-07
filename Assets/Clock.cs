using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clock : MonoBehaviour
{
    public event Action UpdateTime;
    NightCode nightCode;
    public PointSystem point;
    public PlayerMovement player;
    public int seconds = 0;
    int prevTime = 0;
    string[] hours = {"12 AM", "1 AM", "2 AM", "3 AM", "4 AM", "5 AM", "6 AM"};
    public string hour;
    int lastPointSecond = -1;
    difficultycontroller a;    

    void Start()
    {
        player.OpenShop();
        player.paused = true;
        a = GameObject.Find("DifficultyController").GetComponent<difficultycontroller>();
        nightCode = GameObject.Find("Night").GetComponent<NightCode>();
        point = PointSystem.Instance;   
    }

    void Update()
    {
        Timer();

        AddPoints();

        UpdateTimeGUI();

        if(Input.GetKeyDown(KeyCode.Q))
            seconds = 359;
    }

    void Timer()
    {
        if (Math.Floor(Time.time) > prevTime)
        {
            prevTime = (int)Math.Floor(Time.time);
            seconds++;
            //Debug.Log(seconds);
        }
    }

    void UpdateTimeGUI()
    {
        switch (seconds)
        {
            case >= 0 and < 60:
                hour = hours[0];
                break;
            case >= 60 and < 120:
                hour = hours[1];
                break;
            case >= 120 and < 180:
                hour = hours[2];
                break;
            case >= 180 and < 240:
                hour = hours[3];
                break;
            case >= 240 and < 300:
                hour = hours[4];
                break;
            case >= 300 and < 360:
                hour = hours[5];
                break;
            case >= 360 and < 420:
                hour = hours[6];
                if (nightCode.Night <= 5)
                {
                    nightCode.Night++;
                    SaveData.Instance.info.night = nightCode.Night;
                    
                    
                    SaveData.Instance.SavetoJson();
                    Debug.Log("save");
                }
                SceneManager.LoadScene("6AM");
                break;
        }
    }

    void AddPoints()
    {
        if (seconds % 60 == 0 && seconds != 0 && seconds != lastPointSecond)
        {
            lastPointSecond = seconds;
            // point.point += 10;
            PointSystem.Instance.point += a.animatronic1difficulty + a.animatronic2difficulty + a.animatronic3difficulty;
            SaveData.Instance.info.point = PointSystem.Instance.point;
            SaveData.Instance.SavetoJson();
            Debug.Log("saved");
            
        }
    }
    void IncreaseTime()
    {
        if (Time.time > prevTime)
        {
            //Debug.Log("Time " + Time.time);
        }
    }
}