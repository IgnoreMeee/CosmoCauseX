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
    

    public void Confirm()
    {
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

        } else {
        Debug.Log("I can't get this im broke");
        }
    }

    
}
