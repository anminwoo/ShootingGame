using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemManager : MonoBehaviour
{
    enum ItemNumber
    {
        healItem    = 0,
        maxHpUpItem = 1,
        shieldItem  = 2,
        speedUpItem = 3
    }
    
    [SerializeField] private Item[] items;
    [Space] 
    [SerializeField] private int itemCount;
    [Header("Item Types")]
    [SerializeField] private Item healItem;
    [SerializeField] private Item maxHpUpItem;
    [SerializeField] private Item shieldItem;
    [SerializeField] private Item speedUpItem;

    public int[] table = { 40, 30, 30 };
    public int total;
    public int randomNum;

    private void Awake()
    {
        itemCount = 4;
        healItem    = Resources.Load<Item>("Prefabs/Heal Item");
        maxHpUpItem = Resources.Load<Item>("Prefabs/MaxHpUp Item");
        shieldItem  = Resources.Load<Item>("Prefabs/Shield Item");
        speedUpItem = Resources.Load<Item>("Prefabs/SpeedUp Item");
        items = new Item[itemCount];
        items[(int)ItemNumber.healItem]    = healItem;
        items[(int)ItemNumber.maxHpUpItem] = maxHpUpItem;
        items[(int)ItemNumber.shieldItem]  = shieldItem;
        items[(int)ItemNumber.speedUpItem] = speedUpItem;

        total = 100;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void DropItem(GameObject gameObject)
    {
        Instantiate(items[(int)ItemNumber.healItem], gameObject.transform.position, gameObject.transform.rotation);
    }

    public void ItemLoot(Enemy enemy)
    {
        randomNum = Random.Range(0, total + 1);

        for (int i = 0; i < enemy.table.Length; i++)
        {
            if (randomNum <= enemy.table[i])
            {
                Debug.Log("RandomNumber: " + randomNum + "\t" + enemy.table[i]);
                Instantiate(items[i], enemy.transform.position, enemy.transform.rotation);
                return;
            }
            else
            {
                Debug.Log($"RandomNumber - enemy.table[i] = {randomNum}");
                randomNum -= enemy.table[i];
            }
        }
    }
}
