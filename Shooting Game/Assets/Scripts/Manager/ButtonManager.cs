using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ButtonManager : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void ClickAbilityButton1()
    {
        GameManager.gameManager.IncreaseDamage(Random.Range(2, 8));
        GameManager.gameManager.uiManager.ControlAbilityPanel();
    }
    
    public void ClickAbilityButton2()
    {
        GameManager.gameManager.IncreaseMaxHp(Random.Range(5, 21));
        GameManager.gameManager.uiManager.ControlAbilityPanel();
    }
    
    public void ClickAbilityButton3()
    {
        GameManager.gameManager.IncreaseSpeed(Random.Range(0.2f, 1.0f));
        GameManager.gameManager.uiManager.ControlAbilityPanel();
    }
    
    public void ClickAbilityButton4()
    {
        GameManager.gameManager.IncreaseAttackSpeed(Random.Range(0.025f, 0.1f));
        GameManager.gameManager.uiManager.ControlAbilityPanel();
    }
}
