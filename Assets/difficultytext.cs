using TMPro;
using UnityEngine;

public class difficultytext : MonoBehaviour
{
    public TextMeshProUGUI a1text;
    public TextMeshProUGUI a2text;
    public TextMeshProUGUI a3text;
    public TextMeshProUGUI a4text;
    public difficultycontroller DifficultyController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        a1text.text = DifficultyController.animatronic1difficulty.ToString();
        a2text.text = DifficultyController.animatronic2difficulty.ToString();
        a3text.text = DifficultyController.animatronic3difficulty.ToString();
        a4text.text = DifficultyController.animatronic4difficulty.ToString();
    }
}
