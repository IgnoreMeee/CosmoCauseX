using UnityEngine;
using System.Collections.Generic;

public class buttonController : MonoBehaviour
{
    public GameObject MimicEarsButton;
    public GameObject CountMButton;
    public GameObject FibbonacciButton;
    public GameObject SumDigitsButton;
    public GameObject CountMimicButton;
    public GameObject BackButton;


    public GameObject MimicEarsText;
    public GameObject MimicEarsText2;
    public GameObject MimicEarsConfirmButton;

    public GameObject CountMText;
    public GameObject CountMText2;
    public GameObject CountMConfirmButton;

    public GameObject SumDigitsText;
    public GameObject SumDigitsText2;
    public GameObject SumDigitsConfirmButton;

    public GameObject CountMimicText;
    public GameObject CountMimicText2;
    public GameObject CountMimicConfirmButton;


    public GameObject FibbonacciText;
    public GameObject FibbonacciText2;
    public GameObject FibbonacciConfirmButton;

    public bool inputOn = false;
    public List<int> inputNumbers = new List<int>();
    public List<int> inputString = new List<int>();
    public string numbers;


    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MimicEarsText.SetActive(false);
        MimicEarsText2.SetActive(false);
        MimicEarsConfirmButton.SetActive(false);

        CountMText.SetActive(false);
        CountMText2.SetActive(false);
        CountMConfirmButton.SetActive(false);

        SumDigitsText.SetActive(false);
        SumDigitsText2.SetActive(false);
        SumDigitsConfirmButton.SetActive(false);

        CountMimicText.SetActive(false);
        CountMimicText2.SetActive(false);
        CountMimicConfirmButton.SetActive(false);

        FibbonacciText.SetActive(false);
        FibbonacciText2.SetActive(false);
        FibbonacciConfirmButton.SetActive(false);

        BackButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MimicEarsButtonClick()
    {
        MimicEarsButton.SetActive(false);
        CountMButton.SetActive(false);
        FibbonacciButton.SetActive(false);
        SumDigitsButton.SetActive(false);
        CountMimicButton.SetActive(false);
        BackButton.SetActive(true);

        MimicEarsText.SetActive(true);
        MimicEarsText2.SetActive(true);
        MimicEarsConfirmButton.SetActive(true);

        


    }
    
    public void CountMButtonClick()
    {
        MimicEarsButton.SetActive(false);
        CountMButton.SetActive(false);
        FibbonacciButton.SetActive(false);
        SumDigitsButton.SetActive(false);
        CountMimicButton.SetActive(false);
        BackButton.SetActive(true);

        CountMText.SetActive(true);
        CountMText2.SetActive(true);
        CountMConfirmButton.SetActive(true);

    }
    
    
    public void SumDigitsButtonClick()
    {
        MimicEarsButton.SetActive(false);
        CountMButton.SetActive(false);
        FibbonacciButton.SetActive(false);
        SumDigitsButton.SetActive(false);
        CountMimicButton.SetActive(false);
        BackButton.SetActive(true);

        SumDigitsText.SetActive(true);
        SumDigitsText2.SetActive(true);
        SumDigitsConfirmButton.SetActive(true);

    }
    
    public void CountMimicButtonClick()
    {
        MimicEarsButton.SetActive(false);
        CountMButton.SetActive(false);
        FibbonacciButton.SetActive(false);
        SumDigitsButton.SetActive(false);
        CountMimicButton.SetActive(false);
        BackButton.SetActive(true);

        CountMimicText.SetActive(true);
        CountMimicText2.SetActive(true);
        CountMimicConfirmButton.SetActive(true);

    
    }

    public void FibbonacciButtonClick()
    {
        MimicEarsButton.SetActive(false);
        CountMButton.SetActive(false);
        FibbonacciButton.SetActive(false);
        SumDigitsButton.SetActive(false);
        CountMimicButton.SetActive(false);
        BackButton.SetActive(true);

        FibbonacciText.SetActive(true);
        FibbonacciText2.SetActive(true);
        FibbonacciConfirmButton.SetActive(true);

    }

     public void BackButtonClick()
    {
        MimicEarsButton.SetActive(true);
        CountMButton.SetActive(true);
        FibbonacciButton.SetActive(true);
        SumDigitsButton.SetActive(true);
        CountMimicButton.SetActive(true);
        BackButton.SetActive(false);

        MimicEarsText.SetActive(false);
        MimicEarsText2.SetActive(false);
        MimicEarsConfirmButton.SetActive(false);

        CountMText.SetActive(false);
        CountMText2.SetActive(false);
        CountMConfirmButton.SetActive(false);

        SumDigitsText.SetActive(false);
        SumDigitsText2.SetActive(false);
        SumDigitsConfirmButton.SetActive(false);

        CountMimicText.SetActive(false);
        CountMimicText2.SetActive(false);
        CountMimicConfirmButton.SetActive(false);

        FibbonacciText.SetActive(false);
        FibbonacciText2.SetActive(false);
        FibbonacciConfirmButton.SetActive(false);




    }


    public void MimicEarsConfirmButtonClick()
    {
        GetInputNumber();

    }

    public void CountMonfirmButtonClick()
    {

    }

    public void SumDigitsConfirmButtonClick()
    {
        
        
             if (inputOn = true)
            {
            for (int i = 0; i < inputNumbers.Count; i++)
                {
                    numbers += inputNumbers[i].ToString();
                }

                int total = int.Parse(numbers);

                Debug.Log(total);

                inputOn = false;
            }
        
           
        GetInputNumber();
        

    }

    public void CountMimicConfirmButtonClick()
    {

    }

    public void FibbonacciConfirmButtonClick()
    {
        Debug.Log("I eat pizza, i Drink soda"); 


    }

    public void GetInputNumber()
    {
        inputOn = true;
        if (inputOn = true)
        {
            Debug.Log("hi");

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                inputNumbers.Add(1);
            }   
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                inputNumbers.Add(2);
            }   

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                inputNumbers.Add(3);
            }   

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                inputNumbers.Add(4);
            }   

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                inputNumbers.Add(5);
            }   

            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                inputNumbers.Add(6);
            }   

            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                inputNumbers.Add(7);
            }   

            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                inputNumbers.Add(8);
            }   

            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                inputNumbers.Add(9);
            }   

            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                inputNumbers.Add(0);
            }   
        }
        
    }

     public void GetInputString()
    {
        inputOn = true;
        if (inputOn = true)
        {  
            if (Input.GetKeyDown(KeyCode.Q))
            {
                inputString.Add(1);
            }
        }
       

    }

    public void EndInputButtonClick()
    {
        inputOn = false;



    }

}


