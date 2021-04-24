using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f; // float for mouse sensitivity

    public Transform playerBody; // allows us manipulate the physical body of our gameObject

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // locks the cursor to the centre of the screen
    }// start

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime * 20; // floats to hold the mouse x and mouse y coordinate values
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime * 20; // Time.deltaTime makes it so that the speed of our mouse movement is not dependent on our fps

        xRotation -= mouseY; // xRotation value is determined by the mouseY float
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // clamps the rotation to prevent the player from looking behind them by looking very up or very down


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX); // rotates the player's body around the y axis
    }// update
}
