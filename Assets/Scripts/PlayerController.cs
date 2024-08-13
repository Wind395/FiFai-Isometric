using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Latina
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Vector2 LastDirection;
        [SerializeField] Vector2 CurrentDirection;
        [SerializeField] float speed;
        private Animator animator;
        Rigidbody2D rb;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void OnMove(InputValue value)
        {
            float moveX = value.Get<Vector2>().x;
            float moveY = value.Get<Vector2>().y;
            if( (moveX == 0 && moveY == 0) && (CurrentDirection.x != 0 || CurrentDirection.y != 0))
            {
                LastDirection = CurrentDirection;
            }
            CurrentDirection = new Vector2(moveX, moveY);
        }
        // Update is called once per frame
        private void FixedUpdate()
        {
            rb.velocity = CurrentDirection * speed;
            CurrentDirection.Normalize();
        }

        private void Update()
        {
            AnimationChange();
        }

        private void AnimationChange()
        {
            animator.SetFloat("MoveMagnitude", rb.velocity.magnitude);
            animator.SetFloat("MoveX", CurrentDirection.x);
            animator.SetFloat("MoveY", CurrentDirection.y);
            animator.SetFloat("LastMoveX", LastDirection.x);
            animator.SetFloat("LastMoveY", LastDirection.y);
        }


    }
}

