using UnityEngine;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour
{
    SceneTracker scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scene = GameObject.Find("SceneTracker").GetComponent<SceneTracker>();
        scene.currentScene = SceneManager.GetActiveScene().name;

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
