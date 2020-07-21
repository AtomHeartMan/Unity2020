using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject [] obstaclePreFabs;

    private Vector3 spawnPos;

    private float startDelay = 2;

    private float repeatDelay = 2;
    
    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnPos = this.transform.position;
       InvokeRepeating("SpawnObstacle", startDelay, repeatDelay );
    }

    void SpawnObstacle()
    {
        if (!_playerController.gameOver)
        {
            GameObject obstaclePreFab = obstaclePreFabs[Random.Range(0, obstaclePreFabs.Length)];
            Instantiate(obstaclePreFab, spawnPos, obstaclePreFab.transform.rotation);
        }
    }
}
