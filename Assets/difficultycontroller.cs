using UnityEngine;

public class difficultycontroller : MonoBehaviour
{
    public static difficultycontroller instance;
    public int animatronic1difficulty = 0;
    public int animatronic2difficulty = 0;
    public int animatronic3difficulty = 0;
    public int animatronic4difficulty = 0;

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
    
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseA1()
    {
        if(animatronic1difficulty < 20)
            animatronic1difficulty++;
    }

    public void decreaseA1()
    {
        if(animatronic1difficulty > 0)
        animatronic1difficulty--;
    }

    public void increaseA2()
    {
        if(animatronic2difficulty < 20)
            animatronic2difficulty++;
    }

    public void decreaseA2()
    {
        if(animatronic2difficulty > 0)
        animatronic2difficulty--;
    }

    public void increaseA3()
    {
        if(animatronic3difficulty < 20)
            animatronic3difficulty++;
    }

    public void decreaseA3()
    {
        if(animatronic3difficulty > 0)
        animatronic3difficulty--;
    }

    public void increaseA4()
    {
        if(animatronic4difficulty < 20)
            animatronic4difficulty++;
    }

    public void decreaseA4()
    {
        if(animatronic4difficulty > 0)
        animatronic4difficulty--;
    }
}
