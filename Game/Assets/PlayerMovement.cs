using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerMovement : MonoBehaviour
{
   
    //Variables
    Vector3 moveDir = Vector3.zero;

    float speed = 7.0F;
    float rotateSpeed = 200f;
    float rot = 0f;
    float gravity = 8;

    public Animator animator;
    public CharacterController controller;

    private void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (controller.isGrounded) {
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isRunning", true);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                moveDir = new Vector3(0, 0, 0);
                animator.SetBool("isRunning", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                
                moveDir = new Vector3(0, 0, -1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
               
                moveDir = new Vector3(0, 0, 0);
          
            }
            rot += Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, rot, 0);
        }
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
        
    }
}
