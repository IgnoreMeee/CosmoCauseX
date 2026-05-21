using UnityEngine;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SaveData.Instance.LoadJson();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressStart()
    {
        SoundManager.Instance.PlayUI(SoundManager.Instance.ButtonClick);
        SceneManager.LoadScene("TheGame");
    }
    public void Setting()
    {
        SoundManager.Instance.PlayUI(SoundManager.Instance.ButtonClick);
        SceneManager.LoadScene("SettingScreen");
    }
}
