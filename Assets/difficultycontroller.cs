using UnityEngine;
using UnityEngine.Analytics;
using TMPro;
using UnityEngine.UI;

public class difficultycontroller : MonoBehaviour
{
    public static difficultycontroller instance;
    NightCode nightCode; 

    public TextMeshProUGUI BeginText;
    public int animatronic1difficulty = 0;
    public int animatronic2difficulty = 0;
    public int animatronic3difficulty = 0;
    // public int animatronic4difficulty = 0;

    public GameObject a1I, a1D, a2I, a2D, a3I, a3D;

    void Awake() {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    void Start()
    {
        nightCode = GameObject.Find("Night").GetComponent<NightCode>();
    }

    

    // Update is called once per frame
    void Update()
    {
        
        setValues();

        if (nightCode.Night <= 5) {
            HideButtons();
            Debug.Log(nightCode.Night);
        } 
        UpdateButton();
    }

    public void increaseA1()
    {
        if (nightCode.Night > 5) {
        if(animatronic1difficulty < 20)
            animatronic1difficulty++;
        }
    }

    public void decreaseA1()
    {
        if (nightCode.Night > 5) {
        if(animatronic1difficulty > 0)
        animatronic1difficulty--;
        }
    }

    public void increaseA2()
    {
        if (nightCode.Night > 5) {
        if(animatronic2difficulty < 20)
            animatronic2difficulty++;
        }
    }

    public void decreaseA2()
    {
        if (nightCode.Night > 5) {
        if(animatronic2difficulty > 0)
        animatronic2difficulty--;
        }
    }

    public void increaseA3()
    {
        if (nightCode.Night > 5) {
        if(animatronic3difficulty < 20)
            animatronic3difficulty++;
        }
    }

    public void decreaseA3()
    {
        if (nightCode.Night > 5) {
        if(animatronic3difficulty > 0)
        animatronic3difficulty--;
        }
    }

    // public void increaseA4()
    // {
    //     if (nightCode.Night > 5) {
    //     if(animatronic4difficulty < 20)
    //         animatronic4difficulty++;
    //     }
    // }

    // public void decreaseA4()
    // {
    //     if (nightCode.Night > 5) {
    //     if(animatronic4difficulty > 0)
    //     animatronic4difficulty--;
    //     }
    // }

    public void setValues()
    {
        if (nightCode.Night == 6) return;

        animatronic1difficulty = nightCode.Night * 4;
        animatronic2difficulty = nightCode.Night * 4;
        animatronic3difficulty = nightCode.Night * 4;
        // animatronic4difficulty = nightCode.Night * 4;
    }

    public void HideButtons()
    {
        a1I.SetActive(false);
        a1D.SetActive(false);
        a2I.SetActive(false);
        a2D.SetActive(false);
        a3I.SetActive(false);
        a3D.SetActive(false);
        // a4I.SetActive(false);
        // a4D.SetActive(false);
        
    }

    public void UpdateButton()
    {
        BeginText.text = "Play Night " + nightCode.Night;
        Debug.Log("Night " + nightCode.Night);
    }
}
