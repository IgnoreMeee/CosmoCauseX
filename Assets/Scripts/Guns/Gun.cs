using UnityEngine;

public class Gun : MonoBehaviour
{
    public PlayerMovement player;
    public ParticleSystem muzzleFlash;
    public GameObject effect;
    public float damage = 10f;
    public float range = 100f; 
    Vector3 shootPoint;


    public Camera ourCam;
    // public GameObject tracerPrefab;

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
        muzzleFlash.Play();
        RaycastHit hit;
        //generate a new tracer
        int mask = ~LayerMask.GetMask("Player");

        if (Physics.Raycast(ourCam.transform.position, ourCam.transform.forward, out hit, range, mask))
        {
            if (hit.transform == player) return;
            //damage target
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            shootPoint = hit.point;
            Debug.Log("HIT: " + hit.transform.name);

        } else  {
            shootPoint = ourCam.transform.position
                    + ourCam.transform.forward * range;
        }
        
        GameObject gunImpact = Instantiate(effect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(gunImpact, 2f);
        // GameObject tracer = Instantiate(tracerPrefab, transform.position, Quaternion.identity);
        // tracer.GetComponent<BulletTracer>().target = shootPoint;
        SoundManager.Instance.PlaySFX(SoundManager.Instance.Shoot);
        Debug.Log("sound");

        
    }
}
