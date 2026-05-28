using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



public class ShopMenu : MonoBehaviour
{

    public PlayerMovement x;
    public PointSystem points;
    public Button Gun1;
    public Button Gun2;
    [SerializeField] TMP_Text pointText;

    void Update()
    {
        pointText.text = points.point.ToString();
    }
    

    public void Confirm()
    {
        x.CloseShop();
    }


    public void GunOne()
    {
        if (points.point >= 100)
        {
            Debug.Log("equiped");
            points.point -=100;
            Gun1.interactable = false;
        } else {
        Debug.Log("I can't get this im broke");
        }
    }

    public void GunTwo()
    {
        if (points.point >= 150)
        {
            Debug.Log("equiped");
            points.point -=150;
            Gun2.interactable = false;

        } else {
        Debug.Log("I can't get this im broke");
        }
    }

    
}
