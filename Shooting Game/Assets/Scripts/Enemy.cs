using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{

    public int   hp;
    public int   maxHp;
    public int   baseDamage;
    public int   currentDamage;
    public float baseSpeed;
    public float currentSpeed;
    
    private Rigidbody2D rigid;
    private BoxCollider2D collider;

    private Player player;

    private void Awake() // EnemySetting
    {
        maxHp         = 30;
        hp            = maxHp;
        baseDamage    = 10;
        currentDamage = baseDamage;
        baseSpeed     = 3.0f;
        currentSpeed  = baseDamage;
        
        player   = GetComponent<Player>();
        rigid    = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        
    }

    public void Move()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (gameObject.CompareTag("Bullet"))
        {
            hp -= currentDamage;
            Debug.Log($"Remain hp: {hp}");
        }
    }
}
