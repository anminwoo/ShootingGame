using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIManager : MonoBehaviour
{
    [SerializeField] private int  score;
    [SerializeField] private Text currentHpText;
    [SerializeField] private Text maxHpText;
    [SerializeField] private Text scoreText;

    [SerializeField] private Slider hpSlider;

    [SerializeField] private Player player;

    [SerializeField] private GameObject menuPanel;

    private bool isMenuPanelOpen;
    private bool isPause;

    private void Awake()
    {
        
    }

    void Start()
    {
        currentHpText.text = player.currentHp.ToString(); // 플레이어 현재 체력 텍스트
        maxHpText.text     = player.maxHp.ToString(); // 플레이어 최대 체력 텍스트
        scoreText.text     = "Score: " + 0.ToString(); // 점수 초기화
        
        hpSlider.maxValue  = player.maxHp; // 플레이어 최대 체력 게이지
        hpSlider.value     = player.currentHp; // 플레이어 현재 체력 게이지
        // Debug.Log($"player hp: {player.hp}, player maxHp {player.maxHp}");

        menuPanel = GameObject.Find("Canvas").transform.Find("Menu Panel").gameObject;
        isMenuPanelOpen = false; // 메뉴 판넬이 끄기
        isPause = false; // 게임 멈춤 끄기
    }

    void Update()
    {
        
    }

    public void ControlMenuPanel()
    {
        isMenuPanelOpen = !isMenuPanelOpen;
        Pause();
        menuPanel.SetActive(isMenuPanelOpen);
    }

    public void Pause()
    {
        isPause = !isPause;
        if (isPause)
        {
            Time.timeScale = 0;
            Debug.Log("게임이 멈췄습니다.");
        }
        else
        {
            Time.timeScale = 1;
            Debug.Log("게임이 진행됩니다.");
        }

        // Time.timeScale = isPause == true ? 1 : 0;
    }

    public void GetScore(int getScore) // 플레이어 점수 획득
    {
        score += getScore;
        scoreText.text = "Score: " + score.ToString();
    }
    
    public void SetHpSlider(int currentValue) // currentHp만 바꾸는 함수
    {
        hpSlider.value = currentValue;
    }

    public void SetHpSlider(int maxValue, int currentValue) // maxHp, currentHp만 바꾸는 함수
    {
        hpSlider.maxValue = maxValue; // 최대 hp
        hpSlider.value    = currentValue; // 현재 hp
        // SetHpSlider(currentValue);
    }

    public void SetHpSlider(int minValue, int maxValue, int currentValue) // minHp, maxHp, currentHp를 바꾸는 함수
    {
        hpSlider.minValue = minValue;     // 최소 hp
        hpSlider.maxValue = maxValue;     // 최대 hp
        hpSlider.value    = currentValue; // 현재 hp
        // SetHpSlider(maxValue, currentValue);
    }

    public void SetHpText(int currentValue)
    {
        currentHpText.text = player.currentHp.ToString();
    }

    public void SetHpText(int maxValue, int currentValue)
    {
        maxHpText.text     = player.maxHp.ToString();
        currentHpText.text = player.currentHp.ToString();
        // SetHpText(currentValue);
    }
    // public void SetSlider(Slider slider, int minValue, int maxValue, int currentValue) {}
}
