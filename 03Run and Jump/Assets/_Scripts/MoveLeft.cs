using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerController.gameOver)
        {
            transform.Translate((Vector3.left * speed * Time.deltaTime), Space.World);
        }
    }
}
