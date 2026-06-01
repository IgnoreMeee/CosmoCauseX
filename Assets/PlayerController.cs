using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera ourCam;
    public GameObject DoorButtonLeft;
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

    public void Touch()
    {
        //checks if touching a gameobejct

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 3f))
            {
                if (hit.collider.gameObject == DoorButtonLeft)
                {
                    Debug.Log("I JUST HIT THE JACKPOT!!!");

                    GameObject DoorController = GameObject.Find("DoorController");
                    doorcontroller Doorcontroller = DoorController.GetComponent<doorcontroller>();
                    Doorcontroller.buttonID = 1;
                }
                
                if (hit.collider.gameObject == DoorButtonLeft)
                {
                    
                }

                if (hit.collider.gameObject == DoorButtonLeft)
                {
                    
                }

                if (hit.collider.gameObject == DoorButtonLeft)
                {
                    
                }
               
            }
        }
    }
}
