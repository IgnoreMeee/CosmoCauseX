using System.Collections;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    public GameObject Ass;
    public Rigidbody AssRb;
    GameObject[] asteroids = new GameObject[5];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (asteroids[0] == null && asteroids[1] == null && asteroids[2] == null && asteroids[3] == null && asteroids[4] == null)
        {
            SummonAsteroids();
        }

        MoveAsteroids();
    }

    public void SummonAsteroids()
    {
        for (int i = 0; i < asteroids.Length; i++)
        {
            GameObject asteroid = Instantiate(Ass, new Vector3(Ass.transform.position.x, Ass.transform.position.y, Ass.transform.position.z - (i * 3)), Quaternion.identity);
            asteroids[i] = asteroid;
            asteroids[i].SetActive(true);
        }
        
    }

    public void MoveAsteroids()
    {
        for (int i = 0; i < asteroids.Length; i++)
        {
            if (asteroids[i] == null) continue;
            
            if (asteroids[i].transform.position.x <= -22)
            {
                Destroy(asteroids[i]);
            } else
            {
                asteroids[i].GetComponent<Rigidbody>().linearVelocity = new Vector3(-10f, 0, 0);
            }
        }


    }
}
