using UnityEngine;

public class livescontroller : MonoBehaviour
{
    public int lives;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(lives == 3)
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
        }else if(lives == 2)
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(false);
        }
        else
        {
            life1.SetActive(true);
            life2.SetActive(false);
            life3.SetActive(false);
        }
    }
}
