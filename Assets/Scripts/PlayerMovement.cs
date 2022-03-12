using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Character Variables
    [SerializeField] private CharacterController characterController;
    private Vector3 velocity;
    private float speed = 10f;
    private float gravity = -20f;
    private float jumpHeight = 2f;
    #endregion Character Variables

    #region Ground Checker Variables 
    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask groundMask;
    private float groundCheckRadius = 0.4f;
    private bool isGrounded;
    #endregion Ground Checker Variables
   

    // Update is called once per frame
    void Update()
    {
        // Return true if grounded
        // Return false if not grounded
        isGrounded = Physics.CheckSphere(groundChecker.position, groundCheckRadius, groundMask);

        // Resetting the velocity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // This will lead to move the player on the world coordinates
        // We need to move the character on the local coordinates
        // Vector3 move = new Vector3(x, 0f, z);

        // Instead we use the following
        Vector3 move = transform.right * z + transform.forward * x;

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Math Formulas
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        characterController.Move(velocity * Time.deltaTime);
    }
}
