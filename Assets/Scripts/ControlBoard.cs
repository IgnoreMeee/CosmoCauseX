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
    if (!Input.GetKeyDown(KeyCode.F))
        return;

    if (movement.canMove && LookingAtChair())
    {
        EnterControlBoard();
    }
    else if (!movement.canMove)
    {
        ExitControlBoard();
    }
}

bool LookingAtChair()
{
    int mask = ~LayerMask.GetMask("Player");

    return Physics.Raycast(
        ourCam.transform.position,
        ourCam.transform.forward,
        out RaycastHit hit,
        10f, mask)
        && hit.transform.CompareTag("Chair");
}

void EnterControlBoard()
{
    player.position = chair.position + Vector3.up * 0.8f;
    movement.canMove = false;

    gun.SetActive(true);
    lightObject.SetActive(false);
}

void ExitControlBoard()
{
    movement.canMove = true;
    gun.SetActive(false);
}

}

    
