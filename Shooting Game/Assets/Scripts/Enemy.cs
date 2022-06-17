using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{

    public int   currentHp;
    public int   maxHp;
    public int   baseDamage;
    public int   currentDamage;
    public float baseSpeed;
    public float currentSpeed;
    public int   score; // 적을 처치했을 때 주는 점수
    public int   exp;
    public int dropChance; // 아이템 드랍률
    public int[] table = {20, 0, 0, 0};

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

    private void Start()
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
        score         = 100;
        exp           = 2;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet") || col.CompareTag("Player"))
        {
            currentHp -= player.currentDamage;
            if (isDead())
            {
                Destroy(gameObject);
                Debug.Log($"{this.name} died."); // 지우기
                GameManager.gameManager.uiManager.GetScore(score);
                Debug.Log($"{score}점을 얻었습니다."); // 지우기
                GameManager.gameManager.AddExp(exp);
                Debug.Log($"{exp}exp를 얻었습니다."); // 지우기
                GameManager.gameManager.itemManager.ItemLoot(this);
            }
            Debug.Log($"Remain hp: {currentHp}"); // 지우기
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
