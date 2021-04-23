using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; // references the character controller

    public float speed = 12f; // how fast the player moves
    public float gravity = -9.81f; // acceleration due to gravity 

    public Transform groundCheck; // references the new empty gameObject titled "GroundCheck"
    public float groundDistance = 0.4f; // size of the sphere created for checking ground collsion
    public LayerMask groundMask; // allows us to control what objects the sphere will check for (if we didn't, it would think we're always touching the ground
                                 // because it's colliding with the player gameObject

    public float jumpHeight = 3f; // float for how high we want to jump

    Vector3 velocity; // Vector3 to hold velocity for gravity pulling the player down
    bool isGrounded; // bool to determine if the player is grounded or not

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // CheckSphere creates an invisible sphere
                                                                                            // first parameter is the position of where the groundcheck object is
                                                                                            // second parameter is the radius of the sphere created
                                                                                            // third is the mask which allows us to specify what objects will be considered ground
        
        if (isGrounded && velocity.y < 0) // 
        {
            velocity.y = -2f; // ground check will occur just before the player hits the ground so setting it to a small value prevents the player from floating
        }// if

        float x = Input.GetAxis("Horizontal"); // floats to hold positions in the xz-plane
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime); // uses the character controller to move independent of fps (due to Time.deltaTime)

        // allows jumping if the player is grounded and presses the jump key (by default is space bar)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // based on physics equation v = sqrt(h*-2*g)
        }

        velocity.y += gravity * Time.deltaTime; // adjust the velocity in the y direction of the Vector3 velocity 

        controller.Move(velocity * Time.deltaTime); // using the character controller and .move(), we are moving the player's body based on the velocity
                                                    // using Time.deltaTime twice due to physics equation for vertical displacement of an object in freefall:
                                                    // (delta)y = 0.5gt^2
    }// Update function
}
