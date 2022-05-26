using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private int score;
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

    public void HealHp(int heal) // 플레이어가 회복을 받음
    {
        if (player.currentHp + heal > player.maxHp) // 회복량 + 현재 체력이 최대 체력 보다 클 때
        {
            player.currentHp = player.maxHp;
            Debug.Log($"회복량이 플레이어의 최대 체력{player.maxHp}을 넘어 최대체력으로 설정됨.");

        }
        else // 회복량 + 현재 체력이 최대 체력 보다 작을 때
        {
            Debug.Log($"회복 전 플레이어의 체력: {player.currentHp}");
            player.currentHp += heal;
            Debug.Log($"회복 후 플레이어의 체력: {player.currentHp}");
        }
        SetHpSlider(player.currentHp);
    }

    public void GetDamage(int damage) // 플레이어가 데미지를 입음
    {
        Debug.Log($"공격 받기 전 플레이어의 체력: {player.currentHp}"); // 지우기
        if (player.currentHp - damage <= player.minHp) // 플레이어 현재 체력 - 데미지가 최소 체력 보다 작을 때
        {
            // 능력이라던지 특정 아이템 켜기
            player.currentHp = player.minHp;
            if (player.currentHp == 0)
            {
                // Dead()
                Debug.Log($"플레이어의 체력이 {player.currentHp}이 되어 사망하였습니다."); // 지우기
            }
            // 부활 기능도 추가하면 좋을 듯
        }
        else
        {
            player.currentHp -= damage;
            Debug.Log($"공격 받은 후 플레이어의 체력: {player.currentHp}"); // 지우기
        }

        SetHpSlider(player.currentHp);
    }

    public void IncreaseDamage(int extraDamage) // 플레이어의 현재 공격력을 올린다.
    {
        player.currentDamage += extraDamage;
    }

    public void DecreaseDamage(int damage) // 플레이어의 현재 공격력을 줄인다.
    {
        // 공격력이 음수가 되지 않도록 처리 필요함
        player.currentDamage -= damage;
    }

    public void IncreaseMaxHp(int extraHp) // 플레이어의 최대 체력을 늘린다.
    {
        SetHpSlider(0, player.maxHp + extraHp, player.currentHp + extraHp);
    }

    public void DecreaseMaxHp(int lossHp) // 플레이어의 최대체력을 줄인다
    {
        player.maxHp -= lossHp;
        if (player.maxHp <= 0) // 플레이어의 최대 체력 <= 0 이된다면
        {
            player.maxHp = 1; // 최대 체력을 1로 함
        }
        if (player.currentHp > player.maxHp)
        {
            player.currentHp = player.maxHp;
        }
        SetHpSlider(player.maxHp, player.currentHp);
    }

    public void IncreaseSpeed(float extraSpeed) // 플레이어의 현재 이동속도를 올린다.
    {
        player.currentSpeed += extraSpeed;
    }

    public void DecreaseSpeed(float lossSpeed) // 플레이어의 현재 이동속도를 줄인다.
    {
        // 플레이어 이속이 음수가 되지 않도록 방지 해줘야 할 수도 있다
        player.currentSpeed -= lossSpeed;
    }

    public void GetScore(int getScore) // 플레이어 점수 획득
    {
        score += getScore;
        scoreText.text = score.ToString();
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
