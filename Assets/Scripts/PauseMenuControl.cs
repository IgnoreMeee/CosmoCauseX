using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuControl : MonoBehaviour
{
    SceneTracker scene;
    public PlayerMovement player;
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

    public void ResumeButton()
    {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;

            player.Resume.gameObject.SetActive(false);
            player.Settings.gameObject.SetActive(false);
            player.Exit.gameObject.SetActive(false);

            player.paused = false;
            Time.timeScale = 1f;
    }

    public void SettingsButton()
    {
        player.paused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("SettingScreen");
    }

    public void ExitButton()
    {
        player.paused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title Screen");
    }
}
