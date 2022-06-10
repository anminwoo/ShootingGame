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
    [SerializeField] private Text currentExpText;
    [SerializeField] private Text requireExpText;
    [SerializeField] private Text playerLevelText;

    [SerializeField] private Slider hpSlider;
    [SerializeField] private Slider expSlider;

    [SerializeField] private Player player;

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject abilityPanel;

    private bool isMenuPanelOpen; // 메뉴가 열려있는지
    private bool isAbilityPanelOpen; // 능력선택창이 열려있는지
    private bool isPause; // 일시정지 상태인지

    private void Awake()
    {
        
    }

    void Start()
    {
        currentHpText.text  = player.currentHp.ToString(); // 플레이어 현재 체력 텍스트
        maxHpText.text      = player.maxHp.ToString(); // 플레이어 최대 체력 텍스트
        scoreText.text      = "Score: " + 0.ToString(); // 점수 초기화
        currentExpText.text = player.currentExp.ToString(); // 플레이어 현재 경험치 텍스트
        requireExpText.text = player.requireExp.ToString(); // 다음 레벨에 필요한 경험치 요구량
        
        hpSlider.maxValue  = player.maxHp; // 플레이어 최대 체력 게이지
        hpSlider.value     = player.currentHp; // 플레이어 현재 체력 게이지
        // Debug.Log($"player hp: {player.hp}, player maxHp {player.maxHp}");
        playerLevelText.text = "Level: " + player.playerLevel.ToString();
        expSlider.value    = player.currentExp; // 플레이어 현재 경험치 게이지
        expSlider.maxValue = player.requireExp; // 플레이어 요구 경험치 게이지

        menuPanel = GameObject.Find("Canvas").transform.Find("Menu Panel").gameObject;
        abilityPanel = GameObject.Find("Canvas").transform.Find("Ability Select Panel").gameObject;
        isMenuPanelOpen = false; // 메뉴 판넬이 끄기
        isAbilityPanelOpen = false; // 능력선택창 끄기
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
    
    public void ControlAbilityPanel()
    {
        isAbilityPanelOpen = !isAbilityPanelOpen;
        Pause();
        abilityPanel.SetActive(isAbilityPanelOpen);
        /*isAbilityPanelOpen = true;
        Pause();
        abilityPanel.SetActive(isAbilityPanelOpen);
        // 능력을 선택한다면 했다면
        isAbilityPanelOpen = false;
        abilityPanel.SetActive(isAbilityPanelOpen);
        Pause();*/
    }

    public void Pause()
    {
        if (isMenuPanelOpen || isAbilityPanelOpen) // 메뉴나 능력선택창이 켜져있을 경우
        {
            isPause = true;
        }
        else
        {
            isPause = false;
        }
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

    public void SetLevelText(int level)
    {
        playerLevelText.text = "Level: " + player.playerLevel.ToString();
    }

    public void SetExpText(int currentValue)
    {
        currentExpText.text = currentValue.ToString();
    }

    public void SetRequireExpText(int requireValue)
    {
        requireExpText.text = requireValue.ToString();
    }

    public void SetExpSlider(int currentValue)
    {
        expSlider.value = currentValue;
    }

    public void SetExpSlider(int currentValue, int requireValue)
    {
        expSlider.value    = currentValue;
        expSlider.maxValue = requireValue;
    }
}
