using UnityEngine;
using UnityEngine.SceneManagement;

public class InitCode : MonoBehaviour
{
    SceneTracker scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scene = GameObject.Find("SceneTracker").GetComponent<SceneTracker>();
        scene.currentScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
