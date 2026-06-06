using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SettingUI : MonoBehaviour
{
    
    public Slider UISlider, SFXSlider, BackgroundSlider;
    SceneTracker scene;
    public Canvas TheGameCanvas, SettingCanvas;
    public GameObject Crosshair;
    public PlayerMovement player;
    
    void Start()
    {
        UISlider.value = SoundManager.Instance.uiSource.volume;
        SFXSlider.value = SoundManager.Instance.sfxSource.volume;
        BackgroundSlider.value = SoundManager.Instance.background.volume;

        SoundManager.Instance.uiSource.volume = SaveData.Instance.info.UIVolume;
        SoundManager.Instance.sfxSource.volume = SaveData.Instance.info.SFXVolume;
        SoundManager.Instance.background.volume = SaveData.Instance.info.BackgroundVolume;

        UISlider.value = SoundManager.Instance.uiSource.volume;
        SFXSlider.value = SoundManager.Instance.sfxSource.volume;
        BackgroundSlider.value = SoundManager.Instance.background.volume;
        
        UISlider.onValueChanged.AddListener(SetUIVolume);
        SFXSlider.onValueChanged.AddListener(SetSFXVolume);
        BackgroundSlider.onValueChanged.AddListener(SetBackgroundVolume);
    

        scene = GameObject.Find("SceneTracker").GetComponent<SceneTracker>();
    }

    void ValueChangeCheck()
    {
        
        
    }

    public void SetUIVolume(float volume)
    {
        SoundManager.Instance.uiSource.volume = volume;
        SaveData.Instance.info.UIVolume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        SoundManager.Instance.sfxSource.volume = volume;
        SaveData.Instance.info.SFXVolume = volume;
    }

    public void SetBackgroundVolume(float volume)
    {
        SoundManager.Instance.background.volume = volume;
        SaveData.Instance.info.BackgroundVolume = volume;
    }

   
     public void Back()
    {
        SaveData.Instance.SavetoJson();
        SoundManager.Instance.PlayUI(SoundManager.Instance.ButtonClick);
        SceneManager.LoadScene(scene.currentScene);
    }

    public void BackCause() {
        SoundManager.Instance.PlayUI(SoundManager.Instance.ButtonClick);
        TheGameCanvas.gameObject.SetActive(true);
        SettingCanvas.gameObject.SetActive(false);

        player.Resume.gameObject.SetActive(true);
        player.Settings.gameObject.SetActive(true);
        player.Exit.gameObject.SetActive(true);
        Crosshair.SetActive(true);
    }
}
