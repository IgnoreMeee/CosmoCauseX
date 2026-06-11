using UnityEngine;

public class NightCode : MonoBehaviour
{
    public static NightCode Instance;
    [HideInInspector]
    public int Night;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // RefreshFromSave();
        
        
        
    }

    // public void RefreshFromSave()
    // {
    //     if (SaveData.Instance == null)
    //         return;

    //     
    // }

    // Update is called once per frame
    void Update()
    {
        Night = SaveData.Instance.info.night;
        //Debug.Log("Night from title screen " + Night);
    }
}
