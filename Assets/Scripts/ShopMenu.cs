using UnityEngine;
using UnityEngine.SceneManagement;


public class ShopMenu : MonoBehaviour
{

    public PlayerMovement x;

    public void Confirm()
    {
        x.CloseShop();
    }
}
