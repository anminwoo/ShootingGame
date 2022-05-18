using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    
    public PlayerController player;
    
    public UIManager uiManager;
    public ButtonManager buttonManager;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    void Damaged(int damage)
    {
        player.hp -= damage;
        uiManager.hpSlider.value = player.hp;
    }

    void Heal(int heal)
    {
        player.hp = player.hp + heal > player.maxHp ? player.maxHp : player.hp + heal;
        uiManager.hpSlider.value = player.hp;
    }

    void IncreaseDamage(int damage)
    {
        player.currentDamage += damage;
    }

    int Add(int a, int b)
    {
        return a + b;
    }

    int Sub(int a, int b)
    {
        return a > b ? a - b : 0;
    }
    
}
