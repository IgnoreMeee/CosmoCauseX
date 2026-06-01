using UnityEngine;

public class Gun1 : MonoBehaviour
{
    public PlayerMovement player;
    public Transform gun1;
    public float damage = 50f;
    public float range = 120f; 
    Vector3 shootPoint;

    public Camera ourCam;
    public GameObject tracerPrefab;

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
        
        GameObject tracer = 
        Instantiate(tracerPrefab, 
        gun1.position + gun1.forward * 0.2f + gun1.up * 0.1f, 
        Quaternion.identity);
        tracer.GetComponent<BulletTracer>().target = shootPoint;
        // SoundManager.Instance.PlaySFX(SoundManager.Instance.Shoot);

        
    }
}
