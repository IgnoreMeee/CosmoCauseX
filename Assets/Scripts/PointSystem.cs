using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public int point;
    public static PointSystem Instance;

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

    void Start()
    {
        point = SaveData.Instance.info.point;
    }

    
}
