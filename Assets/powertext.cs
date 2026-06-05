using TMPro;
using UnityEngine;

public class powertext : MonoBehaviour
{
    public TextMeshProUGUI PowerText;
    public power Power;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Power = Power.GetComponent<power>();
        PowerText = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PowerText.text = Power.powerPercent.ToString() + "%";
        
    }
}
