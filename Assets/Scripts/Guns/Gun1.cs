using UnityEngine;

public class Gun1 : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject effect1;
    // public ParticleSystem muzzleFlash;
    public float damage = 50f;
    public float range = 120f; 
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
        int mask = ~LayerMask.GetMask("Player");

        if (Physics.Raycast(ourCam.transform.position, ourCam.transform.forward, out hit, range, mask))
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
        
        // GameObject tracer = 
        // Instantiate(tracerPrefab, 
        // gun1.position + gun1.forward * 0.2f + gun1.up * 0.1f, 
        // Quaternion.identity);
        // tracer.GetComponent<BulletTracer>().target = shootPoint;
        // SoundManager.Instance.PlaySFX(SoundManager.Instance.Shoot);

        GameObject gun1Impact = Instantiate(effect1, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(gun1Impact, 2f);
        
    }
}
