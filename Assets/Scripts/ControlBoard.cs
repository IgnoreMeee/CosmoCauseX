using UnityEngine;

public class ControlBoard : MonoBehaviour
{
    public Camera ourCam;
    public Transform player;
    public PlayerMovement movement;
    public GameObject gun;
    bool sit = false;
    
   
    void Update()
    {
        RaycastHit see;
        bool lookingAtChair = Physics.Raycast(ourCam.transform.position, ourCam.transform.forward, out see, 10f)&& see.transform.name == "Chair";

        if (Input.GetKeyDown(KeyCode.F) && movement.canMove && lookingAtChair)
        {
            movement.canMove = false;
            player.transform.position = transform.position + new Vector3(0, 0.6f, 0);
            gun.SetActive(true);
            
        } else if (Input.GetKeyDown(KeyCode.F) && !movement.canMove)
        {
            movement.canMove = true;
            player.transform.position = transform.position + Vector3.left;
            gun.SetActive(true);
        }

    }

}

    
