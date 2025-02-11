using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class RubyController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public int maxHealth = 5;
    public int health {get { return currentHealth;}}
    int currentHealth;
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;
    private Rigidbody2D rb2D;
    private Vector2 position;
    private Animator animator;
    private Vector2 lookDirection = new Vector2(1,0);


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        position= rb2D.position;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");
       Vector2 move = new Vector2(horizontal, vertical);
       if(!Mathf.Approximately(move.x,0.0f)||
       !Mathf.Approximately(move.y, 0.0f))
       {
        lookDirection.Set(move.x,move.y);
        lookDirection.Normalize();
       }
       animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

       //position.x = position.x + moveSpeed * horizontal * Time.deltaTime;
       //position.y = position.y + moveSpeed * vertical * Time.deltaTime;
       position += move*moveSpeed*Time.deltaTime;
       rb2D.MovePosition(position);
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }
   public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        animator.SetTrigger("Hit");
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        //Debug.Log(currentHealth + "/" + maxHealth);
        Debug.Log($"{currentHealth}/{maxHealth}");
    }
}
