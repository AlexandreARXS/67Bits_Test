using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint; 

    private GameObject currentEnemy; 
    void Start()
    {
        currentEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}