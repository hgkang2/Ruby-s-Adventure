using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 4.0f;
    public bool vertical;
    public float changeTime = 3.0f;
    private Rigidbody2D rb2D;
    private float timer;
    private int direction = 1;
    private Vector2 position;
    private Animator animator;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        position = rb2D.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
        if(vertical)
        {
            animator.SetFloat("MoveX",0);
            animator.SetFloat("MoveY", direction);
            position.y += moveSpeed * direction * Time.deltaTime;
        }
        else
        {
            animator.SetFloat("MoveX",direction);
            animator.SetFloat("MoveY",0);
        position.x += moveSpeed * direction *Time.deltaTime;
        }   
        rb2D.MovePosition(position);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player =
        other.gameObject.GetComponent<RubyController>();
        if (player != null)
        //if(other.TryGetComponent<RubyController>(out var player))
        {
            player.ChangeHealth(-1);
        }
    }
}
