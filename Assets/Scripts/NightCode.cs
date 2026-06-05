using UnityEngine;

public class NightCode : MonoBehaviour
{
    public static NightCode Instance;
    public int Night = 1;
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
        Night = SaveData.Instance.info.night;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
