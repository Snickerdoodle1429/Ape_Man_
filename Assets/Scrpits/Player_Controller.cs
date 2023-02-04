using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    //[SerializeField] private int speed = 5;

    public float moveSpeed = 1f;
    
    //private Vector2 movement;
    private Vector2 moveInput;

    private Rigidbody2D rb;
    private Animator animator;

    //public CharacterController2D controller;

    //public float runSpeed = 40f;

    //float horizontalMove = 0f;
    

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        if (moveInput.x != 0 || moveInput.y != 0)
        {
        animator.SetFloat("X", moveInput.x);
        animator.SetFloat("Y", moveInput.y);

        animator.SetBool("IsWalking", true);
        } else {
       animator.SetBool("IsWalking", false);
        }
    }

    //private void OnMovement(InputValue value) { 
    //movement = value.Get<Vector2>();

    //if (movement.x != 0 || movement.y != 0)
    //{
    //animator.SetFloat("X", movement.x);
    //animator.SetFloat("Y", movement.y);

    //animator.SetBool("IsWalking", true);
    //} else {
    //animator.SetBool("IsWalking", false);
    //}
    //}

    //private void Update()
    //{
    //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

    //horizontal = Input.GetAxis("Horizontal");
    //vertical = Input.GetAxis("Vertical");

    //Vector2 move = new Vector2(horizontal, vertical);
    //}

    //private void FixedUpdate() {

    //controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);

    //rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);

    // Varient 1
    //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

    // Varient 2
    // if(movement.x != 0  || movment.y !=0){
    // rb.velocity = movement * speed;
    // }

    //Varient 3
    //rb.addForce(movement * speed)
    //}
}