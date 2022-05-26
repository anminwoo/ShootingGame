using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text currentHpText;
    [SerializeField] private Text maxHpText;

    [SerializeField] private Text scoreText;

    [SerializeField] private Slider hpSlider;

    [SerializeField] private Player player;

    private void Awake()
    {

    }

    void Start()
    {
        currentHpText.text = player.currentHp.ToString(); // 플레이어 현재 체력 텍스트
        maxHpText.text     = player.maxHp.ToString(); // 플레이어 최대 체력 텍스트
        scoreText.text     = 0.ToString(); // 점수 초기화
        
        hpSlider.maxValue  = player.maxHp; // 플레이어 최대 체력 게이지
        hpSlider.value     = player.currentHp; // 플레이어 현재 체력 게이지
        // Debug.Log($"player hp: {player.hp}, player maxHp {player.maxHp}");
    }

    void Update()
    {

    }

    public void HealHp(int heal)
    {
        if (player.currentHp + heal > player.maxHp)
        {
            player.currentHp = player.maxHp;
            SetHpSlider(player.currentHp);
            Debug.Log($"회복량이 플레이어의 최대 체력{player.maxHp}을 넘어 최대체력으로 설정됨.");

        }
        else
        {
            Debug.Log($"회복 전 플레이어의 체력: {player.currentHp}");
            player.currentHp += heal;
            Debug.Log($"회복 후 플레이어의 체력: {player.currentHp}");
            SetHpSlider(player.currentHp);
        }

        hpSlider.value = player.currentHp;
    }

    public void GetDamage(int damage)
    {
        Debug.Log($"공격 받기 전 플레이어의 체력: {player.currentHp}"); // 지우기
        if (player.currentHp - damage <= 0)
        {
            // hp 1로 살아남는 능력이 있다면 여기에 추가
            player.currentHp = 0;
            Debug.Log($"플레이어의 체력이 {player.currentHp}이 되어 사망하였습니다."); // 지우기
            // Dead()
            // 부활 기능도 추가하면 좋을 듯
        }
        else
        {
            player.currentHp -= damage;
            Debug.Log($"공격 받은 후 플레이어의 체력: {player.currentHp}"); // 지우기
        }

        SetHpSlider(player.currentHp);
        hpSlider.value = player.currentHp;
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
        SetHpSlider(0, player.maxHp + extraHp, player.currentHp + extraHp);
        // player.maxHp += extraHp;
        // player.hp    += extraHp;
        // hpSlider.maxValue = player.maxHp;
        // hpSlider.value    = player.hp;
    }

    public void DecreaseMaxHp(int lossHp)
    {
        player.maxHp -= lossHp;
        if (player.currentHp > player.maxHp)
        {
            player.currentHp = player.maxHp;
        }

        SetHpSlider(0, player.maxHp, player.currentHp);
        hpSlider.maxValue = player.maxHp;
        hpSlider.value = player.currentHp;
    }

    public void IncreaseSpeed(float extraSpeed)
    {
        player.currentSpeed += extraSpeed;
    }

    public void DecreaseSpeed(float lossSpeed)
    {
        player.currentSpeed -= lossSpeed;
    }

    public void SetHpSlider(int currentValue) // currentHp만 바꾸는 함수
    {
        hpSlider.value = currentValue;
    }

    public void SetHpSlider(int maxValue, int currentValue) // maxHp, currentHp만 바꾸는 함수
    {
        hpSlider.maxValue = maxValue;     // 최대 hp
        hpSlider.value    = currentValue; // 현재 hp
    }

    public void SetHpSlider(int minValue, int maxValue, int currentValue) // minHp, maxHp, currentHp를 다 바꾸는 함수
    {
        hpSlider.minValue = minValue;     // 최소 hp
        hpSlider.maxValue = maxValue;     // 최대 hp
        hpSlider.value    = currentValue; // 현재 hp
    }
    
    // public void SetSlider(Slider slider, int minValue, int maxValue, int currentValue) {}
}
