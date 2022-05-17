using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject commonEnemy;
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
            Instantiate(commonEnemy, transform.position, transform.rotation);
            yield return new WaitForSeconds(3f);
        }
    }
}
