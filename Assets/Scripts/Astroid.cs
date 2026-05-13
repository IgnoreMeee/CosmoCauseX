using System.Collections;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    public GameObject Ass;
    public Rigidbody AssRb;
    float asteroidSpawnDelay = 2f;
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
            StartCoroutine(SpawnAsteroid(asteroidSpawnDelay));

        }
        
        MoveAsteroids();
    }

    public void SummonAsteroids()
    {
        for (int i = 0; i < asteroids.Length; i++)
        {
            float randomYShift = Random.Range(-1f, 2f);
            float randomZShift = Random.Range(0f, 10f);
           
            GameObject asteroid = Instantiate(Ass, new Vector3(Ass.transform.position.x, Ass.transform.position.y + randomYShift, Ass.transform.position.z - randomZShift), Quaternion.identity);
            asteroids[i] = asteroid;
        }
        
    }

    public IEnumerator SpawnAsteroid(float delay)
    {
        for (int i = 0; i < asteroids.Length; i++)
        {
            if (asteroids[i] == null) continue;
            if (asteroids[i].activeSelf) continue;
            yield return new WaitForSeconds(delay);
            asteroids[i].SetActive(true);
            
        }
    }

    public void MoveAsteroids()
    {
        for (int i = 0; i < asteroids.Length; i++)
        {
            if (asteroids[i] == null) continue;

            if (asteroids[i].activeSelf) {
            
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
}
