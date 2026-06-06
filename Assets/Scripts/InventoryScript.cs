using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public Canvas InventoryCanvas;
    public TextMeshProUGUI FragText;
    public TextMeshProUGUI OtherText;

    bool invOpen = false;
    public int meteorFragments = 0;
    public int otherRandomThing = 0;
    int[] amounts = new int[2];
    int[] sorted = new int[2];
    TextMeshProUGUI[] texts = new TextMeshProUGUI[2];
    Vector3 pos1 = new Vector3(-376, 262, 0);
    Vector3 pos2 = new Vector3(-360, 180, 0);
    Vector3[] positions = new Vector3[2];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        texts[0] = FragText;
        texts[1] = OtherText;

        positions[0] = pos1;
        positions[1] = pos2;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmounts();
        OpenInventory();

        texts[0].text = "Meteor Fragments x" + meteorFragments;
        texts[1].text = "Other Random Thing x" + otherRandomThing;
    }

    void UpdateAmounts()
    {
        amounts[0] = meteorFragments;
        amounts[1] = otherRandomThing;
    }

    int GetAmount(string text)
    {
        if (int.TryParse(text, out int num)) return num;
        return GetAmount(text.Substring(1));
    }

    void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
    
            if (!invOpen) {
                InventoryCanvas.gameObject.SetActive(true);
                invOpen = true;
            }
            else {
                InventoryCanvas.gameObject.SetActive(false);
                invOpen = false;
            }

            
        }

        if(Input.GetKeyDown(KeyCode.G)) SortByAmount();
        if(Input.GetKeyDown(KeyCode.Q)) meteorFragments++;
        if(Input.GetKeyDown(KeyCode.E)) otherRandomThing++;
    }

    void SortByAmount()
    {
        sorted = BubbleSort(amounts);
        for (int i = 0; i < texts.Length; i++)
        {
            for (int j = 0; j < sorted.Length; j++)
            {
                if (GetAmount(texts[i].text) == sorted[j])
                {
                    texts[i].rectTransform.anchoredPosition = positions[j];
                    continue;
                }
            }
        }


        Debug.Log(sorted[0] + " " + sorted[1]);
    }

    public static int[] BubbleSort(int[] arr)
  {
    for (int i = 0; i <= arr.Length; i++)
    {
      for (int j = 0; j < arr.Length - 1; j++)
      {
        int temp = arr[j];
        if (arr[j] > arr[j + 1])
        {
          arr[j] = arr[j + 1];
          arr[j + 1] = temp;
        }
      }
    }
    return arr;
  }
}
