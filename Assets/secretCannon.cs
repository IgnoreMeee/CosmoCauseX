using System.Collections;
using UnityEngine;

public class secretCannon : MonoBehaviour
{
    public int secretValue;
    public string[] secretArray = new string[5];





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Declaring the secret number
        secretValue = Random.Range(0, 27);

        secretArray[0] = "Q";
        secretArray[1] = "E";
        secretArray[2] = "R";
        secretArray[3] = "T";
        secretArray[4] = "Y";
        secretArray[5] = "U";
        secretArray[6] = "I";
        secretArray[7] = "O";
        secretArray[8] = "P";
        secretArray[9] = "G";
        secretArray[10] = "H";
        secretArray[11] = "J";
        secretArray[12] = "K";
        secretArray[13] = "L";
        secretArray[14] = "Z";
        secretArray[15] = "X";
        secretArray[16] = "C";
        secretArray[17] = "V";
        secretArray[18] = "B";
        secretArray[19] = "N";
        secretArray[20] = "M";
        secretArray[21] = "4";
        secretArray[22] = "5";
        secretArray[23] = "6";
        secretArray[24] = "7";
        secretArray[25] = "8";
        secretArray[26] = "9";
        secretArray[27] = "0";


        Debug.Log(secretArray[secretValue]);









    }

    // Update is called once per frame
    void Update()
    {
        CauseNon();
    }

    void CauseNon()
    {
        if (secretValue == 1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                //replaceMeLater
                secretValue = 0;
            }

        }
    }
}
