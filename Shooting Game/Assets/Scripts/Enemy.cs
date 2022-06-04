using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{

    public int   currentHp;
    public int   maxHp;
    public int   baseDamage;
    public int   currentDamage;
    public float baseSpeed;
    public float currentSpeed;
    
    private Rigidbody2D   rigid;
    private BoxCollider2D collider;

    [SerializeField] private Player player;

    public void Awake()
    {
        EnemySetting(); // 적의 능력치 설정
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        rigid    = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        
    }

    public void FixedUpdate()
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

    public void EnemySetting() // 적 능력치 설정 함수
    {
        maxHp         = 20;
        currentHp     = maxHp;
        baseDamage    = 5;
        currentDamage = baseDamage;
        baseSpeed     = 3.5f;
        currentSpeed  = baseSpeed;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet") || col.CompareTag("Player"))
        {
            currentHp -= player.currentDamage;
            if (isDead())
            {
                Destroy(gameObject);
                Debug.Log($"{this.name} died.");
            }
            Debug.Log($"Remain hp: {currentHp}");
        }
    }

    public bool isDead()
    {
        return currentHp <= 0 ? true : false;
    }

    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
