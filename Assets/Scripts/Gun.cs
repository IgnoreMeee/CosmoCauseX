using UnityEngine;

public class Gun : MonoBehaviour
{
    float damage = 10f;
    float range = 100f; 

    public Camera ourCam;

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
        if (Physics.Raycast(ourCam.transform.position,  ourCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
        ;
    }
}
