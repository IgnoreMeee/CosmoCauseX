using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SettingUI : MonoBehaviour
{
    public Slider masterVolume;
    public Slider UIVolume;
    public Slider SFXVolume;

    void Start()
    {
        masterVolume.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }

    void ValueChangeCheck()
    {
        Debug.Log (masterVolume.value);
    }
     public void Back()
    {
        SoundManager.Instance.PlayUI(SoundManager.Instance.ButtonClick);
        SceneManager.LoadScene("TitleScreen");
    }
}
