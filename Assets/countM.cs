using UnityEngine;

public class countM : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int countX(string str) 
        {
            if (str.Length == 0) 
            {
                return 0;
            }

            if (str[0] == 'm') 
            {
                return 1 + countX(str.Substring(1));
            }

            return countX(str.Substring(1));
        }

    }
}
