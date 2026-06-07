using UnityEngine;

public class countMimic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int countAbc(string str) 
        {
            if (str.Length < 3) 
            {
                return 0;
            }

            if (str.Substring(0, 3).Equals("abc")) 
            {
                return 1 + countAbc(str.Substring(1));
            }

            return countAbc(str.Substring(1));
        }
    }
}
