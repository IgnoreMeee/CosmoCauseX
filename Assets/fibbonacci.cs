using UnityEngine;

public class fibbonacci : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int fibonacci(int n) 
        {
            if (n < 2)
            {
                return n;
            }
            
            if (n == 2)
            {
                return 1;
            }
            
            return fibonacci(n-1) + fibonacci(n-2);
        }
    }
}
