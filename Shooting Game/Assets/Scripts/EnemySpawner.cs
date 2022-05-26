using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    void Start()
    {
        StartCoroutine(EnemySpawnCoroutine());
    }

    void Update()
    {
        
    }
    
    IEnumerator EnemySpawnCoroutine()
    {
        while (true)
        {
            Instantiate(enemies[0], transform.position, transform.rotation);
            yield return new WaitForSeconds(2f);
        }
    }
}
