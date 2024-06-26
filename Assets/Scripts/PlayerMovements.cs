using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveH * moveSpeed, moveV * moveSpeed);

        Vector2 direction = new Vector2(moveH, moveV);

        animator.SetTrigger(AnimationEffects());
    }

    string AnimationEffects()
    {
        if (moveH > 0)
        {
            return "E";
        }
        if (moveH < 0)
        {
            return "W";
        }
        if (moveV > 0)
        {
            return "N";
        }
        if (moveV < 0)
        {
            return "S";
        }
        return null;
    }

    public void Move(InputAction.CallbackContext callbackContext)
    {
        moveH = callbackContext.ReadValue<Vector2>().x;
        moveV = callbackContext.ReadValue<Vector2>().y;
    }
}
