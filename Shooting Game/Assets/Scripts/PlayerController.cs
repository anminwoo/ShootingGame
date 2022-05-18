using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    public PlayerBullet playerBullet;

    void Awake()
    {
        PlayerSetting();
    }

    private void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void PlayerSetting()
    {
        hp = 100;
        maxHp = 100;
        baseDamage = 10;
        currentDamage = 10;
        baseSpeed = 10f;
        currentSpeed = 10f;   
    }
    
    public void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        h = h * baseSpeed * Time.deltaTime;
        v = v * baseSpeed * Time.deltaTime;
        
        transform.Translate(Vector3.right * h);
        transform.Translate(Vector3.up * v);
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(playerBullet, transform.position, playerBullet.transform.rotation);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            
        }
    }
}
