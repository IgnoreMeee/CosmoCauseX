using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SettingUI : MonoBehaviour
{
<<<<<<< Updated upstream
    
    public Slider UISlider, SFXSlider;
    
=======
    SceneTracker scene;
    public Slider UIVolume;
    public Slider SFXVolume;


>>>>>>> Stashed changes
    void Start()
    {
        UISlider.value = SoundManager.Instance.uiSource.volume;
        SFXSlider.value = SoundManager.Instance.sfxSource.volume;

        SoundManager.Instance.uiSource.volume = SaveData.Instance.info.UIVolume;
        SoundManager.Instance.sfxSource.volume = SaveData.Instance.info.SFXVolume;

        UISlider.value = SoundManager.Instance.uiSource.volume;
        SFXSlider.value = SoundManager.Instance.sfxSource.volume;
        
<<<<<<< Updated upstream
        UISlider.onValueChanged.AddListener(SetUIVolume);
        SFXSlider.onValueChanged.AddListener(SetSFXVolume);
=======
        UIVolume.onValueChanged.AddListener(SetUIVolume);
        SFXVolume.onValueChanged.AddListener(SetUIVolume);

        scene = GameObject.Find("SceneTracker").GetComponent<SceneTracker>();
>>>>>>> Stashed changes
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
        SoundManager.Instance.PlayUI(SoundManager.Instance.ButtonClick);
        SceneManager.LoadScene(scene.currentScene);
    }
}
