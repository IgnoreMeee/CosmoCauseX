using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SettingUI : MonoBehaviour
{
    
    public Slider UISlider, SFXSlider;
    SceneTracker scene;
    public Canvas TheGameCanvas, SettingCanvas;
    public GameObject Crosshair;
    public PlayerMovement player;
    
    void Start()
    {
        UISlider.value = SoundManager.Instance.uiSource.volume;
        SFXSlider.value = SoundManager.Instance.sfxSource.volume;

        SoundManager.Instance.uiSource.volume = SaveData.Instance.info.UIVolume;
        SoundManager.Instance.sfxSource.volume = SaveData.Instance.info.SFXVolume;

        UISlider.value = SoundManager.Instance.uiSource.volume;
        SFXSlider.value = SoundManager.Instance.sfxSource.volume;
        
        UISlider.onValueChanged.AddListener(SetUIVolume);
        SFXSlider.onValueChanged.AddListener(SetSFXVolume);
        

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
