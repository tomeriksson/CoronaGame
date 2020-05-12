using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerMovement : MonoBehaviour
{

    //Variables
    Vector3 moveDir = Vector3.zero;

    float speed = 7.0F;
    float gravity = 8;

    public Animator animator;
    public CharacterController controller;
    public LayerMask groundMask;

    private void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        MoveCharacter();
        RotateCharacter();
        Shoot();
    }

    private void MoveCharacter()
    {
        controller.Move(moveDir * Time.deltaTime);
        //if (controller.isGrounded)
        {
            moveDir = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);
            animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
            //animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        }
        moveDir.y -= gravity * Time.deltaTime;
    }

    private void RotateCharacter()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, groundMask))
        {
            transform.LookAt(hitInfo.point);
        }
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("isShooting", true);
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
    }


}
