using UnityEngine;

public class SoundManager : MonoBehaviour
{
     public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource uiSource;
    public AudioSource sfxSource;

    [Header("UI Sound")]
    public AudioClip ButtonClick;

    [Header("Game Sound")]
    public AudioClip Shoot;
    


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayUI(AudioClip clip)
    {
        uiSource.PlayOneShot(clip);
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
        // SoundManagement.Instance.PlaySFX(SoundManagement.Instance.GalloShoot);
