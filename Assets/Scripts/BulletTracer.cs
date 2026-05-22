using UnityEngine;

public class BulletTracer : MonoBehaviour
{
    public Vector3 target;
    public float speed = 100f;

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    
}
