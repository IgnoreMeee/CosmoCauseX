using UnityEngine;

public class Target : MonoBehaviour
{
    float health = 30f;
    public InventoryScript inventory;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<InventoryScript>();
    }

    public void TakeDamage(float amt)
    {
        health -= amt;
        if (health <= 0f)
        {
            Destroy(gameObject);
            SoundManager.Instance.PlaySFX(SoundManager.Instance.astroidExplode);
            Debug.Log("i died");
            if (inventory.meteorFragments < 9) StartCoroutine(inventory.AddMeteorFrag(2f));
        }
    }
}
