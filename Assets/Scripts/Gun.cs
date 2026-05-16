using UnityEngine;

public class Gun : MonoBehaviour
{
    float damage = 10f;
    float range = 100f; 
    Vector3 shootPoint;

    public Camera ourCam;
    public GameObject tracerPrefab;

    void Update()
    {
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
        
        GameObject tracer = Instantiate(tracerPrefab, transform.position, Quaternion.identity);
        tracer.GetComponent<BulletTracer>().target = shootPoint;
        SoundManager.Instance.PlaySFX(SoundManager.Instance.Shoot);

        
    }
}
