using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class ClickerScriptThing : MonoBehaviour
{

    public GameObject Button1

    public void InstantiateCube ()
    {
        Instantiate(Button1, transform.position, Quanternin.identity)
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()  
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Button1 == getClickedObject(put RaycastHit hit))
            {
                Console.WriteLine("Mimic!");
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Console.WriteLine("micix");
        }
    }



}

 
    
