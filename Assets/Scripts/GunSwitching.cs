using UnityEngine;

public class GunSwitching : MonoBehaviour
{
    public int equiped = 0;
    public bool OwnGun1 = false;
    public bool OwnGun2 = false;
    


    void Start()
    {
        equiped = SaveData.Instance.info.equiped;
        OwnGun1 = SaveData.Instance.info.Have1;
        OwnGun2 = SaveData.Instance.info.Have2;
        SelectWeapon(equiped);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            equiped = 0;
            SaveData.Instance.info.equiped = equiped;
            SelectWeapon(0);
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && OwnGun1)
        {
            equiped = 1;
            SaveData.Instance.info.equiped = equiped;
            SelectWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && OwnGun2)
        {
            equiped = 2;
            SaveData.Instance.info.equiped = equiped;
            SelectWeapon(2);
        }
    }
    void SelectWeapon(int index)
    {
        
       int i = 0;

        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(i == index);
            i++;
        }
    }
}
