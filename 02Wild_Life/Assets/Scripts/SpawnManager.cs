using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    private int animalIndex;

    private float spawnRangeX = 14f;

    private float spawnPosZ;
    
    [SerializeField, Range(2,5)]
    private float startDelay = 2f;
    [SerializeField, Range(0, 3)]
    private float spawnInterval = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPosZ = this.transform.position.z;
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }
    
    private void SpawnRandomAnimal()
    {
        float xRand = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(xRand, 0, spawnPosZ);
        animalIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[animalIndex], 
            spawnPos, 
            enemies[animalIndex].transform.rotation);
    }
}
