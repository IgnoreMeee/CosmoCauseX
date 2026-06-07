using UnityEngine;
public class Target : MonoBehaviour
{
    InventoryScript inventory;
    float health = 30f;
    Astroid manager;
    void Start()
    {
        inventory = FindFirstObjectByType<InventoryScript>();
        manager = FindFirstObjectByType<Astroid>();
    }
    public void TakeDamage(float amt)
    {
        health -= amt;
        if (health <= 0f)
        {
            if (manager != null)
            {
                manager.OnAsteroidDestroyed(gameObject);
            }   
            SoundManager.Instance.PlaySFX(SoundManager.Instance.astroidExplode);
            Destroy(gameObject);
            Debug.Log("i died");
            if (inventory.meteorFragments < 9) StartCoroutine(inventory.AddMeteorFrag(2f));
        }
    }
}
