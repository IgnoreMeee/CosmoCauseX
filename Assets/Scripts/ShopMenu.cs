using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



public class ShopMenu : MonoBehaviour
{

    public PlayerMovement x;
    public GunSwitching gun;
    public Button Gun1;
    public Button Gun2;
    [SerializeField] TMP_Text pointText;

    void Update()
    {
        pointText.text = PointSystem.Instance.point.ToString();

    }

    void Start()
    {
         if (gun.equiped == 1)
        {
            Gun1.interactable = false;
        }

        if (gun.equiped == 2)
        {
            Gun2.interactable = false;
            Gun1.interactable = false;
        }
    }
    

    public void Confirm()
    {
        x.paused = false;
        x.CloseShop();
        PointSystem.Instance.point = SaveData.Instance.info.point;
    }


    public void GunOne()
    {
        
        if (PointSystem.Instance.point >= 100)
        {
            Debug.Log("equiped");
            PointSystem.Instance.point -=100;
            SaveData.Instance.info.point = PointSystem.Instance.point;
            
            Gun1.interactable = false;
            gun.OwnGun1 = true;
            SaveData.Instance.info.Have1 = gun.OwnGun1;

        } else {
        Debug.Log("I can't get this im broke");
        }
    }

    public void GunTwo()
    {
        
        if (PointSystem.Instance.point >= 150)
        {
            Debug.Log("equiped");
            PointSystem.Instance.point -=150;
            SaveData.Instance.info.point = PointSystem.Instance.point;

            Gun2.interactable = false;
            gun.OwnGun2 = true;
            SaveData.Instance.info.Have2 = gun.OwnGun2;

        } else {
        Debug.Log("I can't get this im broke");
        }
    }

    
}
