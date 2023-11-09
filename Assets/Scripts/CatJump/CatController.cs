using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class CatController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public Canvas uiCanvas;
    CatUIController uIController;

    bool blueFlag = false;
    bool onGround = true;
    float jumpForce = 350f;
    float walkForce = 30f;
    float maxWalkSpeed = 2f;
    float threshold = 0.2f;
    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        uIController = uiCanvas.GetComponent<CatUIController>();
    }
    private void Update()
    {
        Walk();
        Jump();
        ResetPos();
    }

    private void Walk()
    {
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow) || Input.acceleration.x > threshold) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.acceleration.x < -threshold) key = -1;
        float speedx = Mathf.Abs(rigid2D.velocity.x);
        if (speedx < maxWalkSpeed)
        {
            rigid2D.AddForce(transform.right * key * walkForce);
            if (key == -1)
            {
                spriteRenderer.flipX = true;
            }
            else if (key == 1)
            {
                spriteRenderer.flipX = false;
            }
        }
        if (key != 0) animator.SetTrigger("Walk");
        else animator.SetTrigger("Idle");
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            onGround = false;
            animator.SetTrigger("Jump");
            rigid2D.AddForce(transform.up * jumpForce);
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (onGround)
        {
            onGround = false;
            animator.SetTrigger("Jump");
            rigid2D.AddForce(transform.up * jumpForce);
        }
    }
    private void ResetPos()
    {
        if (transform.position.y < -3.5)
        {
            transform.position = new Vector3(0, -3);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "MiddleFlag")
        {
            blueFlag = true;
        }
        if (collision.gameObject.CompareTag("Flag") && blueFlag)
        {
            Time.timeScale = 0;
            uIController.GameOver();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cloud"))
            onGround = true;
    }
}
