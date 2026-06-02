using UnityEngine;

public class Alarm : MonoBehaviour
{
    
    public Light myLight;
    public GameObject lightObject;
    public float interval = 0.2f;
    private float timer;

    void Update()
    {
        Flickering();
    }

    public void Flickering()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            myLight.enabled = !myLight.enabled;
            timer = 0f;
        }
    }


}

