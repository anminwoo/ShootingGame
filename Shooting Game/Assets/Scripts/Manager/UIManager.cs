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
        hpText.text       = player.hp.ToString(); // 플레이어 현재 체력 텍스트
        maxHpText.text    = player.maxHp.ToString(); // 플레이어 최대 체력 텍스트
        hpSlider.maxValue = player.maxHp; // 플레이어 최대 체력 게이지
        hpSlider.value    = player.hp; // 플레이어 현재 체력 게이지
        // Debug.Log($"player hp: {player.hp}, player maxHp {player.maxHp}");
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

    public void IncreaseDamage(int extraDamage)
    {
        player.currentDamage += extraDamage;
    }

    public void DecreaseDamage(int damage)
    {
        player.currentDamage -= damage;
    }

    public void IncreaseMaxHp(int extraHp)
    {
        SetHpSlider(0, player.maxHp + extraHp, player.hp + extraHp);
        // player.maxHp += extraHp;
        // player.hp    += extraHp;
        // hpSlider.maxValue = player.maxHp;
        // hpSlider.value    = player.hp;
    }

    public void DecreaseMaxHp(int lossHp)
    {
        player.maxHp -= lossHp;
        if (player.hp > player.maxHp)
        {
            player.hp = player.maxHp;
        }

        SetHpSlider(0, player.maxHp, player.hp);
        hpSlider.maxValue = player.maxHp;
        hpSlider.value = player.hp;
    }

    public void IncreaseSpeed(float extraSpeed)
    {
        player.currentSpeed += extraSpeed;
    }

    public void DecreaseSpeed(float lossSpeed)
    {
        player.currentSpeed -= lossSpeed;
    }

    public void SetHpSlider(int minValue, int maxValue, int currentValue)
    {
        hpSlider.minValue = minValue;     // 최소 hp
        hpSlider.maxValue = maxValue;     // 최대 hp
        hpSlider.value    = currentValue; // 현재 hp
    }
    
    // public void SetSlider(Slider slider, int minValue, int maxValue, int currentValue) {}
}
