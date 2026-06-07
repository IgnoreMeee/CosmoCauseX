using UnityEngine;

public class sumDigits : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int sumDigits(int n) 
        {
        if (n < 10)
        {
            return n;
        }
        
        return (n%10) + sumDigits(n/10);
        }
    }
}
