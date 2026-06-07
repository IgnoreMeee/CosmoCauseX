using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using System.Collections;


public class InventoryScript : MonoBehaviour
{
    public Canvas InventoryCanvas;

    public TextMeshProUGUI FragText;
    public TextMeshProUGUI EBC;
    public TextMeshProUGUI EBU;
    public TextMeshProUGUI EBR;
    public TextMeshProUGUI EBL;
    public TextMeshProUGUI RyansBS;

    bool invOpen = false;

    public int meteorFragments = 0;
    public int ExoticButters = 0;
    public int ExoticButtersC = 0;
    public int ExoticButtersU = 0;
    public int ExoticButtersR = 0;
    public int ExoticButtersL = 0;
    
    int[] amounts = new int[2];
    int[] sorted = new int[2];
    TextMeshProUGUI[] texts = new TextMeshProUGUI[5];
    TextMeshProUGUI[] textsRarity = new TextMeshProUGUI[5];


    Vector3 pos1 = new Vector3(-376, 262, 0);
    Vector3 pos2 = new Vector3(-360, 180, 0);
    Vector3 pos3 = new Vector3(-360, 100, 0);
    Vector3 pos4 = new Vector3(-360, 20, 0);
    Vector3 pos5 = new Vector3(-360, -60, 0);

    Vector3[] positions = new Vector3[5];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        texts[0] = FragText;
        texts[1] = EBC;
        texts[2] = EBU;
        texts[3] = EBR;
        texts[4] = EBL;

        textsRarity = texts;

        positions[0] = pos1;
        positions[1] = pos2;
        positions[2] = pos3;
        positions[3] = pos4;
        positions[4] = pos5;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmounts();
        OpenInventory();
        

        texts[0].text = "Meteor Fragments (Common) x" + meteorFragments;
        texts[1].text = "Exotic Butters (Common) x" + ExoticButtersC;
        texts[2].text = "Exotic Butters (Uncommon) x" + ExoticButtersU;
        texts[3].text = "Exotic Butters (Rare) x" + ExoticButtersR;
        texts[4].text = "Exotic Butters (EXOTIC) x" + ExoticButtersL;
        

        Show();

        if (RyansBS.gameObject.activeSelf) {
            StartCoroutine(KillRyan(2f));
        }
        
    }

    IEnumerator KillRyan(float delay) {
        
        yield return new WaitForSecondsRealtime(delay);
        RyansBS.gameObject.SetActive(false);
    }

    public IEnumerator AddMeteorFrag(float delay)
    {
        meteorFragments++;
        RyansBS.gameObject.SetActive(true);
        RyansBS.text = "Meteor Fragment (Common) x1";
        yield return new WaitForSecondsRealtime(delay);
        RyansBS.gameObject.SetActive(false);
    }

    public IEnumerator AddExoticButter(float delay) {
        int yo = GetEB();
        RyansBS.gameObject.SetActive(true);
        if (yo < 25) {
            RyansBS.text = "Exotic Butter (Common) x1";
        } else if (yo < 40) {
            RyansBS.text = "Exotic Butter (Uncommon) x1";
        } else if (yo < 50) {
            RyansBS.text = "Exotic Butter (Rare) x1";
        } else {
            RyansBS.text = "Exotic Butter (EXOTIC) x1";
        }
        yield return new WaitForSecondsRealtime(delay);
        RyansBS.gameObject.SetActive(false);
    }

    void Show() {

        for (int i = 0; i < texts.Length; i++)
        {
            if (GetAmount(texts[i].text) > 0) texts[i].gameObject.SetActive(true);
            else texts[i].gameObject.SetActive(false);
        }
    }

    public int GetEB() {
        int chance = Random.Range(0, 55);
        if (chance < 25) {
            ExoticButtersC++;
        } else if (chance < 40) {
            ExoticButtersU++;
        } else if (chance < 50) {
            ExoticButtersR++;
        } else {
            ExoticButtersL++;
        }
        return chance;
    }

    void UpdateAmounts()
    {
        amounts[0] = meteorFragments;
        amounts[1] = ExoticButters;
    }

    int GetAmount(string text)
    {
        if (int.TryParse(text, out int num)) return num;
        return GetAmount(text.Substring(1));

        // if (int.TryParse(text.Substring(text.Length - 1), out int num)) {
        //     return GetAmount(text.Substring(text.Length - 1) + text.Substring(0, text.Length - 2));
        // }
        
        // return int.Parse(new string(text.Reverse().ToArray()));

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
        if(Input.GetKeyDown(KeyCode.H)) SortByAlphabet();
        if(Input.GetKeyDown(KeyCode.J)) SortByRarity();
        if(Input.GetKeyDown(KeyCode.K)) SortByAlphabetBackwards();

        if (meteorFragments < 9) if(Input.GetKeyDown(KeyCode.R)) meteorFragments++;
        if (ExoticButtersC < 9) if(Input.GetKeyDown(KeyCode.E)) ExoticButtersC++;
        if (ExoticButtersU < 9) if(Input.GetKeyDown(KeyCode.T)) ExoticButtersU++;
        if (ExoticButtersR < 9) if(Input.GetKeyDown(KeyCode.Y)) ExoticButtersR++;
        if (ExoticButtersL < 9) if(Input.GetKeyDown(KeyCode.U)) ExoticButtersL++;
        
    }

    void SortByAmount()
    {
        int[] amounts = new int[texts.Length];
        for (int i = 0; i < texts.Length; i++)
        {
            amounts[i] = GetAmount(texts[i].text);
        }

        sorted = BubbleSort(amounts);
        bool[] used = new bool[sorted.Length];

        for (int i = 0; i < texts.Length; i++)
        {
            int amount = GetAmount(texts[i].text);
            
            for (int j = 0; j < sorted.Length; j++)
            {
                if (!used[j] && amount == sorted[j])
                {
                    texts[i].rectTransform.anchoredPosition = positions[j];
                    used[j] = true; 
                    break; 
                }
            }
        }


        Debug.Log(sorted[0] + " " + sorted[1]);
    }

    void SortByAlphabet() {

        List<TextMeshProUGUI> sortedTexts = texts.OrderBy(t => t.text).ToList();
        for (int i = 0; i < texts.Length; i++)
        {
            sortedTexts[i].rectTransform.anchoredPosition = positions[i];
        }
    }

    void SortByAlphabetBackwards() {

        List<TextMeshProUGUI> sortedTexts = texts.OrderByDescending(t => t.text).ToList();
        for (int i = 0; i < texts.Length; i++)
        {
            sortedTexts[i].rectTransform.anchoredPosition = positions[i];
        }
    }

    void SortByRarity() {
        for (int i = 0; i < texts.Length; i++) {
            texts[i].rectTransform.anchoredPosition = positions[i];
        }
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
