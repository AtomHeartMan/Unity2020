using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float speed = 500;
    private GameObject _focalPoint;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public float powerUpDuration = 5f;

    private float normalStrength = 10; // how hard to hit enemy without powerup
    private float powerupStrength = 25; // how hard to hit enemy with powerup

    private float turboBoost;
    public ParticleSystem turboSmoke;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(_focalPoint.transform.forward * verticalInput * speed * Time.deltaTime); 

        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);

        //Añadimos un impulso extra al pulsar la barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(_focalPoint.transform.forward *turboBoost, ForceMode.Impulse);
            turboSmoke.Play();
        }
    }
    

    // Coroutine to count down powerup duration
    IEnumerator PowerUpCooldown()
    {
        powerupIndicator.SetActive(true);
        yield return new WaitForSeconds(powerUpDuration);
        powerupIndicator.SetActive(false);
        hasPowerup = false;
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - this.transform.position;

            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }
        }else if (other.gameObject.CompareTag("Powerup"))
        { 
            Destroy(other.gameObject);
            hasPowerup = true;
            StartCoroutine(PowerUpCooldown()); 
        }
    }
}

