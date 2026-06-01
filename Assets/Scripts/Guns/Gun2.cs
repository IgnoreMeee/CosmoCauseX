using UnityEngine;

public class Gun2 : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject effect2;
    ParticleSystem muzzleFlash;
    public float damage = 100f;
    public float range = 175f; 
    Vector3 shootPoint;

    public Camera ourCam;

    void Update()
    {
        if (player.paused) return;
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        // muzzleFlash.Play();
        RaycastHit hit;
        //generate a new tracer
        
        if (Physics.Raycast(ourCam.transform.position, ourCam.transform.forward, out hit, range))
        {
            //damage target
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            shootPoint = hit.point;

        } else  {
            shootPoint = ourCam.transform.position
                    + ourCam.transform.forward * range;
        }
        
        // SoundManager.Instance.PlaySFX(SoundManager.Instance.Shoot);

        GameObject gun2Impact = Instantiate(effect2, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(gun2Impact, 2f);
        
    }
}
