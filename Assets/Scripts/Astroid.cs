using System.Collections;
using System.Linq;
using NUnit.Framework.Constraints;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    public GameObject Ass;
    public GameObject meteortrail;
    public Rigidbody AssRb;
    public GameObject lightObject;
    float asteroidSpawnDelay = 2f;
    Clock clock;
    string prevHour = "12 AM";
    GameObject[] asteroids = new GameObject[10];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clock = GameObject.Find("Clock").GetComponent<Clock>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clock.hour != prevHour) {
            Debug.Log("FUCKING KILL YOURSELF");
            
            SummonAsteroids();
            // lightObject.SetActive(true);
            StartCoroutine(SpawnAsteroid(asteroidSpawnDelay));
            
            prevHour = clock.hour;
            Debug.Log(clock.hour + " " + prevHour);
        }
        
        MoveAsteroids();
    }

    public void SummonAsteroids()
    {
        for (int i = 0; i < asteroids.Length; i++)
        {
            float randomYShift = Random.Range(-1f, 2f);
            float randomZShift = Random.Range(0f, 10f);

            float AssY = Ass.transform.position.y + randomYShift;
            float AssZ = Ass.transform.position.z + randomZShift;
           
            GameObject asteroid = Instantiate(Ass, new Vector3(Ass.transform.position.x, Ass.transform.position.y + randomYShift, Ass.transform.position.z - randomZShift), Quaternion.identity);
            asteroid.SetActive(false);
            GameObject meteor = Instantiate(meteortrail, new Vector3(Ass.transform.position.x, Ass.transform.position.y + randomYShift, Ass.transform.position.z - randomZShift), Quaternion.identity);
            meteor.transform.eulerAngles = new Vector3(0, -90, 0);

            meteor.transform.SetParent(asteroid.transform);

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
            
            if (asteroids[i].transform.position.x >= -109)
            {
                Destroy(asteroids[i]);
            } else
            {
                asteroids[i].GetComponent<Rigidbody>().linearVelocity = new Vector3(4f, 0, 0);
            }

            }
        }


    }
}
