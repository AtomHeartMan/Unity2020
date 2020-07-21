using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public float moveForce, powerUpForce, powerUpTime;
    private GameObject origin;
    private bool hasPowerUp;

    public GameObject[] powerUpIndicators;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        origin = GameObject.Find("Origin");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(origin.transform.forward * (moveForce * forwardInput), ForceMode.Force);
        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.transform.position = this.transform.position + 0.5f * Vector3.down;
        }

        if (this.transform.position.y < -10)
        {
            SceneManager.LoadScene("Prototype 4");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 rejectFromPlayer = collision.gameObject.transform.position - this.transform.position;
            enemyRigidbody.AddForce(rejectFromPlayer*powerUpForce, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountdown()
    {
        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.SetActive(true);
            yield return new WaitForSeconds(powerUpTime/powerUpIndicators.Length);
            indicator.SetActive(false);
        }
        hasPowerUp = false; 
        
    }
}
