using UnityEngine;

public class mimicEars : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int bunnyEars2(int bunnies) 
        {
            if (bunnies == 0)
            {
                return 0;
            }
            
            if (bunnies == 1)
            {
                return 2;
            }
            
            if (bunnies %2 == 0 )
            {
                return 3 + bunnyEars2(bunnies-1);
            }
            
            return 2 + bunnyEars2(bunnies-1);
        }

    }
}
