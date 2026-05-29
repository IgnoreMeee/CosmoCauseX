using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float interactRange = 5f;
    public Camera ourCam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Touch();
        }
    }

    public void Touch()
    {
        //whatever the hell joyce did
        if (Physics.Raycast)
    }
}
