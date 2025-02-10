using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public int maxHealth = 5;
    public int health {get { return currentHealth;}}
    int currentHealth;
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;
    Rigidbody2D rb2D;
  
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");
       Vector2 position = rb2D.position;
       position.x = position.x + moveSpeed * horizontal * Time.deltaTime;
       position.y = position.y + moveSpeed * vertical * Time.deltaTime;
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
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        //Debug.Log(currentHealth + "/" + maxHealth);
        Debug.Log($"{currentHealth}/{maxHealth}");
    }
}
