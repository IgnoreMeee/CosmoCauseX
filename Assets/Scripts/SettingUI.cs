using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SettingUI : MonoBehaviour
{
    public Slider UIVolume;
    public Slider SFXVolume;

    public AudioSource uiSource;
    public AudioSource sfxSource;

    void Start()
    {
        uiSource.volume = UIVolume.value;
        sfxSource.volume = SFXVolume.value;
        
        UIVolume.onValueChanged.AddListener(delegate {ValueChange(); });
        SFXVolume.onValueChanged.AddListener(delegate {ValueChange(); });
    }

    void ValueChangeCheck()
    {
        
        
    }

    void ValueChange()
    {
        Debug.Log (UIVolume.value);
        uiSource.volume = UIVolume.value;

        Debug.Log (SFXVolume.value);
        sfxSource.volume = SFXVolume.value;
    }
     public void Back()
    {
        SoundManager.Instance.PlayUI(SoundManager.Instance.ButtonClick);
        SceneManager.LoadScene("Title Screen");
    }
}
