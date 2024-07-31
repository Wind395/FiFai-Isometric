using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;
    Vector2 moveInput;
    Vector2 lastMoveInput;
    public Vector2 forceToApply;
    public float forceDamping;
    Boolean isRunning;
    [SerializeField] private float moveSpeed = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        SetAnimation();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private void OnMove(InputValue value)
    {
        float moveH = value.Get<Vector2>().x;
        float moveV = value.Get<Vector2>().y;
        if ((moveH == 0 && moveV == 0) && moveInput.x != 0 || moveInput.y != 0)
        {
            lastMoveInput = moveInput;
        }
        moveInput = new Vector2(moveH, moveV).normalized;
    }
    private void Movement()
    {
        Vector2 moveForce = moveInput * moveSpeed;
        moveForce += forceToApply;
        forceToApply /= forceDamping;
        if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
        {
            forceToApply = Vector2.zero;
        }
        rb.velocity = moveInput * moveSpeed;
    }
    void SetAnimation()
    {
        animator.SetFloat("MoveX", moveInput.x);
        animator.SetFloat("MoveY", moveInput.y);
        animator.SetFloat("MoveMagnitude", moveInput.magnitude);
        animator.SetFloat("LastMoveX", lastMoveInput.x);
        animator.SetFloat("LastMoveY", lastMoveInput.y);
    }
}
