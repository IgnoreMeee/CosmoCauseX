using UnityEngine;

public class SoundManager : MonoBehaviour
{
     public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource uiSource;
    public AudioSource sfxSource;

    [Header("UI Sound")]
    public AudioClip ButtonClick;
    public AudioClip switchCam;
    public AudioClip SpendMoney;
    public AudioClip NoSpendMoney;

    [Header("SFX Sound")]
    public AudioClip Shoot;
    public AudioClip Shoot1;
    public AudioClip Shoot2;
    public AudioClip Walking; //not sure but ye
    public AudioClip astroidExplode;
    public AudioClip alarm;
    public AudioClip jumpScare;
    
    


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
