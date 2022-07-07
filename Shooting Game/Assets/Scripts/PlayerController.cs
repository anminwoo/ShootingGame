using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (Input.GetKeyDown(KeyCode.O))
        {
            float growSize = 1.25f;
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * growSize, gameObject.transform.localScale.y * growSize);
            Debug.Log($"Player가 커졌습니다.");
        }
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        h = h * player.currentSpeed * Time.deltaTime;
        v = v * player.currentSpeed * Time.deltaTime;
        
        transform.Translate(Vector3.right * h);
        transform.Translate(Vector3.up * v);

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void Shoot()
    {
        if (Time.timeScale == 0) // 일시정지 상태일 때 멈춤
        {
            return;
        }
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
            if (player.currentHp <= 0) // 죽음
            {
                player.gameObject.SetActive(false);
                GameManager.gameManager.buttonManager.ChangeScene("GameOverScene");
            }
            Debug.Log($"받은 데미지 {enemyInstance} 남은 체력: {player.currentHp} 남은 적 체력{enemyInstance.currentHp}"); // 지우기
        }
    }
}
