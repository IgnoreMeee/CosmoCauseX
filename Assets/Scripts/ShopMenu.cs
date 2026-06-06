using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



public class ShopMenu : MonoBehaviour
{

    public PlayerMovement x;
    public GunSwitching gun;
    public power p;
    public Button Gun1;
    public Button Gun2;
    public Button Bat1;
    public Button Bat2;
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

        if (gun.equiped == 200)
        {
            Gun1.interactable = false;
            Gun2.interactable = false;
        }
        
         if (p.Power == 1)
        {
            Bat1.interactable = false;
        }

        if (p.Power == 400)
        {
            Bat1.interactable = false;
            Bat2.interactable = false;
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
            SoundManager.Instance.PlayUI(SoundManager.Instance.SpendMoney);
            PointSystem.Instance.point -=100;
            SaveData.Instance.info.point = PointSystem.Instance.point;
            
            Gun1.interactable = false;
            gun.OwnGun1 = true;
            SaveData.Instance.info.Have1 = gun.OwnGun1;

        } else {
            SoundManager.Instance.PlayUI(SoundManager.Instance.NoSpendMoney);
            Debug.Log("I can't get this im broke");
        }
    }

    public void GunTwo()
    {
        
        if (PointSystem.Instance.point >= 150)
        {
            Debug.Log("equiped");
            SoundManager.Instance.PlayUI(SoundManager.Instance.SpendMoney);
            PointSystem.Instance.point -=150;
            SaveData.Instance.info.point = PointSystem.Instance.point;

            Gun2.interactable = false;
            gun.OwnGun2 = true;
            SaveData.Instance.info.Have2 = gun.OwnGun2;

        } else {
            SoundManager.Instance.PlayUI(SoundManager.Instance.NoSpendMoney);
            Debug.Log("I can't get this im broke");
        }
    }
    public void BatteryOne()
    {
        
        if (PointSystem.Instance.point >= 150)
        {
            Debug.Log("i upgrade my battery");
            SoundManager.Instance.PlayUI(SoundManager.Instance.SpendMoney);
            PointSystem.Instance.point -=150;
            SaveData.Instance.info.point = PointSystem.Instance.point;

            p.maxPower = 200;
            p.Power = 200;
            Bat1.interactable = false;
            SaveData.Instance.info.max = p.maxPower;

        } else {
            SoundManager.Instance.PlayUI(SoundManager.Instance.NoSpendMoney);
            Debug.Log("I can't get this im broke");
        }
    }
    public void BatteryTwo()
    {
        
        if (PointSystem.Instance.point >= 200)
        {
            Debug.Log("i have the best battery now");
            SoundManager.Instance.PlayUI(SoundManager.Instance.SpendMoney);
            PointSystem.Instance.point -=200;
            SaveData.Instance.info.point = PointSystem.Instance.point;

            p.maxPower = 400;
            p.Power = 400;
            Bat2.interactable = false;
            SaveData.Instance.info.max = p.maxPower;

        } else {
            SoundManager.Instance.PlayUI(SoundManager.Instance.NoSpendMoney);
            Debug.Log("I can't get this im broke");
        }
    }

    
}
