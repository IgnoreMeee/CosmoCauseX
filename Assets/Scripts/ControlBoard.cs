using UnityEngine;

public class ControlBoard : MonoBehaviour
{
    public Camera ourCam;
    public Transform player;
    public PlayerMovement movement;
    public GameObject gun;
    public GameObject lightObject;

    
    
   
    void Update()
    {
        RaycastHit see;
        bool lookingAtChair = Physics.Raycast(ourCam.transform.position, ourCam.transform.forward, out see, 10f)&& see.transform.name == "Chair";

        if (Input.GetKeyDown(KeyCode.F) && movement.canMove && lookingAtChair)
        {
            player.transform.position = transform.position + new Vector3(0, 0.8f, 0);
            movement.canMove = false;
            gun.SetActive(true);
            lightObject.SetActive(false);
            
        } else if (Input.GetKeyDown(KeyCode.F) && !movement.canMove)
        {
            movement.canMove = true;
            // player.transform.position = transform.position + Vector3.left;
            gun.SetActive(false);
        }

    }

}

    
