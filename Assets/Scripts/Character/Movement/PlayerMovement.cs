using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController characterController;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float gravity = -9.81f;

    bool isGrounded;


    float characterSpeed = 10.0f;
    float jumpSpeed = 2.0f;



    Vector3 velocity;


    void Update()
    {
        CharacterMovement();
    }

    void CharacterMovement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xMovement + transform.forward * zMovement;
   
        bool isSprinting = (Mathf.Abs(xMovement) > 0 || Mathf.Abs(zMovement) > 0) && Input.GetKey(KeyCode.LeftShift) && isGrounded;
        float currentSpeed = isSprinting ? characterSpeed * 1.5f : characterSpeed;

        characterController.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpSpeed * -2.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
