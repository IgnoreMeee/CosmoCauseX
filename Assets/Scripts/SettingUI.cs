using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SettingUI : MonoBehaviour
{
    public Slider UIVolume;
    public Slider SFXVolume;


    void Start()
    {
        SoundManager.Instance.uiSource.volume = UIVolume.value;
        SoundManager.Instance.sfxSource.volume = SFXVolume.value;
        
        UIVolume.onValueChanged.AddListener(SetUIVolume);
        SFXVolume.onValueChanged.AddListener(SetUIVolume);
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
