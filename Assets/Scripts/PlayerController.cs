using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Latina
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Vector2 LastDirection;
        [SerializeField] Vector2 CurrentDirection;
        [SerializeField] float speed;
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] float fireForce;
        private Animator animator;
        Rigidbody2D rb;
        Vector2 mousePosition;
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
        float aimAngle;
        private void Update()
        {
            AnimationChange();
            if(Input.GetMouseButtonDown(0)){
                Shoot();
            }
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        private void FixedUpdate()
        {
            rb.velocity = CurrentDirection * speed;
            CurrentDirection.Normalize();
            Vector2 aimDir = mousePosition - rb.position;
            aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg - 90f;
        }
        void Shoot(){
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, aimAngle));
            Vector2 shootDirection = mousePosition - rb.position;
            shootDirection.Normalize();
            bullet.GetComponent<Rigidbody2D>().AddForce(shootDirection * fireForce, ForceMode2D.Impulse);
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

