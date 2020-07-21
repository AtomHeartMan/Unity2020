using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 10f;

    [SerializeField] 
    private float translationSpeed = 1f;
    
    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerController.gameOver)
        {
            transform.localPosition += Vector3.left*translationSpeed*Time.deltaTime;
            this.transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
    }
}
