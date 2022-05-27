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
