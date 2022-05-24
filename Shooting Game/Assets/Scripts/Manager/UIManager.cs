using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text hpText;
    [SerializeField] private Text maxHpText;

    [SerializeField] private Text scoreText;
    
    [SerializeField] private Slider hpSlider;
    
    [SerializeField] private Player player;

    private void Awake()
    {
        
    }

    void Start()
    {
        hpSlider.maxValue = player.maxHp;
        hpSlider.value = player.hp;
    }

    void Update()
    {
        
    }

    public void HealHp(int heal)
    {
        if (player.hp + heal > player.maxHp)
        {
            player.hp = player.maxHp;
        }
        else
        {
            player.hp += heal;
        }
        hpSlider.value = player.hp;
    }

    public void GetDamage(int damage)
    {
        if (player.hp - damage <= 0)
        {
            player.hp = 0;
            // Dead()
            // 부활 기능도 추가하면 좋을 듯
        }
        else
        {
            player.hp -= damage;
        }
        hpSlider.value = player.hp;
    }
}
