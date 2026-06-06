using UnityEngine;

public class ControlBoard : MonoBehaviour
{
    public Camera ourCam;
    public Transform player;
    public Transform chair;
    public PlayerMovement movement;
    public GameObject gun;
    public GameObject lightObject;

    
    
   
   void Update()
{
    RaycastHit see;
    int mask = ~LayerMask.GetMask("Player");
    bool lookingAtChair = 
    Physics.Raycast(
        ourCam.transform.position, 
        ourCam.transform.forward, 
        out see, 
        10f,mask)
        && see.transform.name == "Chair";

    if (!Input.GetKeyDown(KeyCode.F))
        return;

    if (movement.canMove && lookingAtChair)
    {
        EnterChair();
    }
    else if (!movement.canMove)
    {
        ExitChair();
    }
}

void EnterChair()
{
    player.position = chair.position + Vector3.up * 0.8f;
    movement.canMove = false;

    gun.SetActive(true);
    lightObject.SetActive(false);
}

void ExitChair()
{
    player.position = chair.position + Vector3.right;
    movement.canMove = true;
    gun.SetActive(false);
}

}

    
