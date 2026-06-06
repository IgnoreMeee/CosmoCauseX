using UnityEngine;
using TMPro;

public class SearchBar : MonoBehaviour
{
    public TMP_InputField searchBar;
    public SearchableItems [] items;

    public void Search()
    {
        
    }
}

public class SearchableItems
{
    public string gun1 = "A Better Gun";
    public GameObject Gun1;
    public string gun2 = "A Even Better Gun";
    public GameObject Gun2;
    public string bat1 = "Battery Upgrades";
    public GameObject Bat1;
    public string bat2 = "Battery Ultimate Upgrades";
    public GameObject Bat2;
}

