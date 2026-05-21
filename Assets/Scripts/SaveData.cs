using UnityEngine;

public class SaveData : MonoBehaviour
{
    public Information info = new Information();
    public static SaveData Instance;
    // public SettingUI setting;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavetoJson();
        }
        // if (Input.GetKeyDown(KeyCode.L))
        // {
        //     LoadJson();
        // }
    }
    public void SavetoJson()
    {
        string infoData = JsonUtility.ToJson(info);
        string filePath = Application.persistentDataPath + "/InfoData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, infoData);
        Debug.Log("saved");
    }

    public void LoadJson()
    {
        string filePath = Application.persistentDataPath + "/InfoData.json";
        string infoData = System.IO.File.ReadAllText(filePath);

        info = JsonUtility.FromJson<Information>(infoData);
        Debug.Log("Load");
    }
}

[System.Serializable]
public class Information
{
    public int point;
    public float UIVolume;
    public float SFXVolume;
}


