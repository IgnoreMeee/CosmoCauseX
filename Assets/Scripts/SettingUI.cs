using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SettingUI : MonoBehaviour
{
    
    public Slider UISlider, SFXSlider;
    
    SceneTracker scene;
    public Slider UIVolume;
    public Slider SFXVolume;


    void Start()
    {
        SoundManager.Instance.uiSource.volume = UIVolume.value;
        SoundManager.Instance.sfxSource.volume = SFXVolume.value;
        
        UIVolume.onValueChanged.AddListener(SetUIVolume);
        SFXVolume.onValueChanged.AddListener(SetUIVolume);
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

    private void SetUIVolume(float volume)
    {
        SoundManager.Instance.uiSource.volume = volume;
    }

    private void SetSFXVolume(float volume)
    {
        SoundManager.Instance.sfxSource.volume = volume;
    }

   
     public void Back()
    {
        SoundManager.Instance.PlayUI(SoundManager.Instance.ButtonClick);
        SceneManager.LoadScene("Title Screen");
    }
}
//a