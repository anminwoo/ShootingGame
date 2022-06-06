using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SpeedDownItem : Item
{
    void Start()
    {
        speed = 10f;
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
        Debug.Log("스피드 다운 아이템"); // 지우기
        GameManager.gameManager.DecreaseSpeed(2f);
    }
}
