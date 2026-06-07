using UnityEngine;
public class Target : MonoBehaviour
{
    float health = 30f;
    Astroid manager;
    void Start()
    {
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
        }
    }
}
