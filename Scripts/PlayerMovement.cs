using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D player;

    float horizontalInput;
    bool facingRight = true;

    private Animator animator;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(horizontalInput * speed, player.velocity.y);

        if (horizontalInput > 0.01f && !facingRight)
        {
            Flip();
        } else if (horizontalInput < -0.01f && facingRight)
        {
            Flip();
        }

        animator.SetBool("walk", horizontalInput != 0);
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    

}
