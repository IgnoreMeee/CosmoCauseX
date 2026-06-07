using UnityEngine;
using TMPro;

public class PointsDisplay : MonoBehaviour
{
    TextMeshProUGUI pointsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointsText = GameObject.Find("PointsText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "Points: " + SaveData.Instance.info.point.ToString();
    }
}
