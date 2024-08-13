using Latina;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float hp;
    [SerializeField] Transform player;

    [Header("Collision check")]
    [SerializeField] float radius;
    [SerializeField] LayerMask WhatIsLayerMask;


    private Animator animator;
    private SpriteRenderer sr;
    Rigidbody2D rb;
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(FlashBlink());
            takeDame(1);
        }
    }

    private void FixedUpdate()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, WhatIsLayerMask);
        if (hit != null)
        {
            if (Vector2.Distance(transform.position, player.position) < 0.3f)
            {
                StartCoroutine(Attack());
            }
            else
            {
                //Di chyển khi phát hiện
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
                animator.SetTrigger("Run");
                Vector2 dir = (player.position - transform.position).normalized;
                if(dir.x > 0)
                {
                    sr.flipX = false;
                }
                else if(dir.x < 0)
                {
                    sr.flipX = true;
                }
            }
        }
        else
        {
            animator.SetTrigger("Idle");
        }


    }


    public void takeDame(float dame)
    {
        hp -= dame;
        if(hp <= 0)
        {
            animator.SetTrigger("Die");
            GetComponent<Collider2D>().enabled = false;
            speed = 0;
            Destroy(gameObject,.4f);
        }
    }


    IEnumerator FlashBlink()
    {
        sr.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.05f);
        sr.color = new Color(1, 1, 1, 1);
    }

    IEnumerator Attack() {
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.5f);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
