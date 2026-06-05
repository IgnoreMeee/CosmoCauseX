using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera ourCam;
    public GameObject DoorButtonLeft;
    public GameObject DoorButtonRight;
    public GameObject VentButtonLeft;
    public GameObject VentButtonRight;

    Ray ray;
    RaycastHit hit;
    public Collider colliderToHit;
    public doorcontroller Doorcontroller; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        //range of button hit
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
        Touch();
    
    }

    //checks if the ray is otouching a gameobejct

    public void Touch()
    {
        if (Input.GetMouseButtonDown(0))
        {
        
            if (Physics.Raycast(ray, out hit, 30f))
            {
                
                if (hit.collider.gameObject.CompareTag("ButtonLeft"))
                {
                    GameObject DoorController = GameObject.Find("DoorController");
                    doorcontroller Doorcontroller = DoorController.GetComponent<doorcontroller>();
                    Doorcontroller.buttonID = 1;
                    Debug.Log("Sliming out arnav");
                }
                
                if (hit.collider.gameObject.CompareTag("ButtonRight"))
                {
                    GameObject DoorController = GameObject.Find("DoorController");
                    doorcontroller Doorcontroller = DoorController.GetComponent<doorcontroller>();
                    Doorcontroller.buttonID = 2;
                }

                if (hit.collider.gameObject.CompareTag("VentLeft"))
                {
                    GameObject DoorController = GameObject.Find("DoorController");
                    doorcontroller Doorcontroller = DoorController.GetComponent<doorcontroller>();
                    Doorcontroller.buttonID = 3;
                }

                if (hit.collider.gameObject.CompareTag("VentRight"))
                {
                    GameObject DoorController = GameObject.Find("DoorController");
                    doorcontroller Doorcontroller = DoorController.GetComponent<doorcontroller>();
                    Doorcontroller.buttonID = 4;
                }
               
            }
        }
    }
}
