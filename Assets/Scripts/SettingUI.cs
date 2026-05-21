using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SettingUI : MonoBehaviour
{
    
    public Slider UISlider, SFXSlider;
    
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
        SceneManager.LoadScene("Title Screen");
    }
}
