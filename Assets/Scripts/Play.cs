using UnityEngine;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour
{
    SceneTracker scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SaveData.Instance.LoadJson();
        scene = GameObject.Find("SceneTracker").GetComponent<SceneTracker>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToMenu()
    {
        SoundManager.Instance.PlayUI(SoundManager.Instance.ButtonClick);
        SceneManager.LoadScene("Title Screen");
    }
    
    public void PressStart()
    {
        SoundManager.Instance.PlayUI(SoundManager.Instance.ButtonClick);
        SceneManager.LoadScene("Difficulty");
    }
    public void Setting()
    {
        SoundManager.Instance.PlayUI(SoundManager.Instance.ButtonClick);
        SceneManager.LoadScene("SettingScreen");
    }

    public void Begin()
    {
        SoundManager.Instance.PlayUI(SoundManager.Instance.ButtonClick);
        SceneManager.LoadScene("TheGame");
    }
}
