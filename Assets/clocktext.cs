using TMPro;
using UnityEngine;

public class ClockText : MonoBehaviour
{
    private TextMeshProUGUI clockText;

    public Clock clock;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clock = clock.GetComponent<Clock>();
        clockText = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        clockText.text = clock.hour;
        
    }
}