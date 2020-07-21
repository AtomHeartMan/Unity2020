using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float gravityMultiplier;
    public bool isOnGround;
    private bool _gameOver;

    public bool gameOver {get => _gameOver;}

    private Animator _animator;
    private float speedMultiplier = 1f;
    private const string SPEED_MULTIPLIER = "Speed multiplier";
    private const string JUMP_TRIG = "Jump_trig";
    private const string DEATHB = "Death_b";
    private const string DEATH_TYPE_INT = "DeathType_int";


    public ParticleSystem explosion, dirt;

    public AudioClip jumpSound, crashSound;

    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Speed_f", 1);
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity = gravityMultiplier * new Vector3(0,-9.81f, 0);
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        speedMultiplier += Time.deltaTime / 10;
        _animator.SetFloat(SPEED_MULTIPLIER, 1 + speedMultiplier);
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !_gameOver)
        {
            playerRb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse); //F = m*a
            isOnGround = false;

            _animator.SetTrigger(JUMP_TRIG);
            dirt.Stop();
            _audioSource.PlayOneShot(jumpSound, 1);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (!gameOver)
            {
                isOnGround = true;
                dirt.Play();
            }
        } else if (other.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            Debug.Log("GAME OVER");
            explosion.Play();
            _audioSource.PlayOneShot(crashSound, 1);
            _animator.SetInteger(DEATH_TYPE_INT, Random.Range(1,3));
            _animator.SetBool(DEATHB, true);
            dirt.Stop();
            Invoke("RestartGame", 2.0f);
        }
    }

    void RestartGame()
    {
        speedMultiplier = 1;
        SceneManager.LoadScene("Prototype 3", LoadSceneMode.Single);
    }
}
