using UnityEngine;

public class buttonController : MonoBehaviour
{
    public GameObject DoorButtonLeft;

    Ray ray;
    RaycastHit hit;
    int hi = 33;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        ChecKForColliders();
;    }

    void ChecKForColliders()
    {
        Ray ray = new Ray(transform.position,transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log(hit.collider.DoorButtonLeft);
            Debug.Log("Gimmick");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hi == 33)  
        {

        }
    }
}
