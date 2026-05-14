using UnityEngine;

public class PlayerCamScript : MonoBehaviour
{

    public float sensX;
    public float sensY;

    public Transform orientation;
    public GameObject cameraPos;
    public GameObject player;

    float xRotation;
    float yRotation;
    bool mouseLocked = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (mouseLocked)
            {
                UnlockMouse();
                mouseLocked = false;
            }
             else
             {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                mouseLocked = true;
             }
        }

        transform.position = cameraPos.transform.position;

        player.transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

    }

    void MoveCamera()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX * 35;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY * 35;

        yRotation += mouseX;
        xRotation -= mouseY;
        
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
