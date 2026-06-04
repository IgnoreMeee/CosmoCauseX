using System.Collections;
using System.Linq;
using NUnit.Framework.Constraints;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    public GameObject Ass;
    public GameObject meteortrail;
    public GameObject meteorexplosion;
    public Rigidbody AssRb;
    public GameObject lightObject;
    public livescontroller lives;
    float asteroidSpawnDelay = 2f;
    Clock clock;
    int prevTime;
    string prevHour = "12 AM";
    GameObject[] asteroids = new GameObject[10];
    GameObject[] booms = new GameObject[10]; //10 BIG BOOMS
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
            StartCoroutine(SpawnAsteroid(asteroidSpawnDelay));
            lightObject.SetActive(true);
            
            prevHour = clock.hour;
            Debug.Log(clock.hour + " " + prevHour);
        }
        
        MoveAsteroids();
    }

    public void SummonAsteroids()
    {
        for (int i = 0; i < asteroids.Length; i++)
        {
            float randomYShift = Random.Range(-1f, 1f);
            float randomZShift = Random.Range(-9f, 9f);

            float AssY = Ass.transform.position.y + randomYShift;
            float AssZ = Ass.transform.position.z + randomZShift;
           
            GameObject asteroid = Instantiate(Ass, new Vector3(Ass.transform.position.x, Ass.transform.position.y + randomYShift, Ass.transform.position.z + randomZShift), Quaternion.identity);
            asteroid.SetActive(false);
            GameObject meteor = Instantiate(meteortrail, new Vector3(Ass.transform.position.x, Ass.transform.position.y + randomYShift, Ass.transform.position.z + randomZShift), Quaternion.identity);
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
            
            if (asteroids[i].transform.position.x >= -108)
            {
                GameObject boom = Instantiate(meteorexplosion, new Vector3(asteroids[i].transform.position.x, asteroids[i].transform.position.y, asteroids[i].transform.position.z), Quaternion.identity);
                booms[i] = boom;
                lives.lives -= 1;
                Destroy(asteroids[i]);
                StartCoroutine(deleteExplosion(booms[i]));
            } else
            {
                asteroids[i].GetComponent<Rigidbody>().linearVelocity = new Vector3(4f, 0, 0);
            }

            }
        }


    }

    IEnumerator deleteExplosion(GameObject prefab)
    {
        float elapsedTime = 0;
        while(elapsedTime < 1)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(prefab);
    }
}
