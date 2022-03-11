using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController controller;

    public float speed;
    public float gravity = -9.82f;

    public Transform groundCheck;
    public float groundMesafe = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;

    Vector3 velocity;
    bool isGrounded;
    float yerelHiz;
    Vector3 move;

	void Update () {
        if((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Input.GetAxis("Vertical") > 0)
        {
            yerelHiz = 12f;
        }
        else
        {
            yerelHiz = 0f;
        }
        move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

        isGrounded = Physics.CheckSphere(groundCheck.position, groundMesafe, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        controller.Move(move * (speed + yerelHiz) * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
	}
}
