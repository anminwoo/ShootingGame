using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

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
            float randPosY = UnityEngine.Random.Range(-8f, 8.5f);
            Instantiate(enemies[0], new Vector3(transform.position.x, randPosY, transform.position.z), transform.rotation);
            yield return new WaitForSeconds(2f);
        }
    }
}
