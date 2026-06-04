using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveButtonStuff : MonoBehaviour
{
    public Button SaveButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SaveButton.onClick.AddListener(SaveData.Instance.SavetoJson);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
