using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ShieldItem : Item
{
    void Start()
    {
        speed = 5f;
    }
    
    void Update()
    {
        
    }
    public override void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public override void UseItem()
    {
        Debug.Log($"쉴드 아이템");
        if (GameManager.gameManager.player.maxHp >= 20)
        {
            GameManager.gameManager.player.minHp = 20;
            Debug.Log($"플레이어의 최소 체력을 20으로 설정함");
        }
        else
        {
            GameManager.gameManager.player.minHp = GameManager.gameManager.player.maxHp;
            Debug.Log($"플레이어의 최소 체력을 {GameManager.gameManager.player.maxHp}으로 설정함");
        }
        Debug.Log($"플레이어의 minHp: {GameManager.gameManager.player.minHp}");
    }
}
