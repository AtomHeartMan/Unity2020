using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    [SerializeField]
    private float spawnRange = 9;

    public int enemyCount;
    public int enemyWave = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(enemyWave);
    }

    private void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            enemyWave++;
            SpawnEnemyWave(enemyWave);

            int numberOfPowerUps = Random.Range(0, 3);
            for (int i = 0; i < numberOfPowerUps; i++)
            {
                Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation); 
            }
        }
    }

    /// <summary>
    /// Método que genera una posición aleatoria dentro de la zona de juego
    /// </summary>
    /// <returns> Devuelve posición aleatoria dentro de la zona de juego </returns>
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPositionX = Random.Range(spawnRange, -spawnRange);
        float spawnPositionZ = Random.Range(spawnRange, -spawnRange);
        Vector3 randomPos = new Vector3(spawnPositionX, 0, spawnPositionZ);
        return randomPos;
    }

    /// <summary>
    /// Método que genera un número determinado de enemigos en pantalla
    /// <param name="numberOfEnemies"> Cantidad de enemigos a generar</param>
    /// </summary>
    void SpawnEnemyWave(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
