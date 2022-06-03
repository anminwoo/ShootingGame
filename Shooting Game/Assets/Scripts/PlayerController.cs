using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private BoxCollider2D collider;
    private Player player;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
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
        Shoot();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        h = h * player.currentSpeed * Time.deltaTime;
        v = v * player.currentSpeed * Time.deltaTime;
        
        transform.Translate(Vector3.right * h);
        transform.Translate(Vector3.up * v);
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(player.bullet, transform.position, player.bullet.transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Debug.Log(col.gameObject.name); // 지우기
        if (col.CompareTag("Enemy"))
        {
            var enemyInstance = col.gameObject.GetComponent<Enemy>();
            Debug.Log($"enemyInstance currentDamage = {enemyInstance.currentDamage}");
            GameManager.gameManager.GetDamage(enemyInstance.currentDamage);
            Debug.Log($"받은 데미지 {enemyInstance} 남은 체력: {player.currentHp}"); // 지우기
        }
    }
}
