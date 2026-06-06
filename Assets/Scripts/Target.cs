using UnityEngine;

public class Target : MonoBehaviour
{
    float health = 30f;

    public void TakeDamage(float amt)
    {
        health -= amt;
        if (health <= 0f)
        {
            Destroy(gameObject);
            SoundManager.Instance.PlaySFX(SoundManager.Instance.astroidExplode);
            Debug.Log("i died");
        }
    }
}
