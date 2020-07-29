using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayTimeDuration = 1f;
    private bool isPlayerAtExit;
    private bool isPlayerCaught;
    private bool hasAudioPlayed;

    public GameObject player;

    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio, exitAudio;
    
    private float timer;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }   
    }

    private void Update()
    {
        if (isPlayerAtExit)
        {
           EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio); 
        }
        else if (isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    /// <summary>
    /// Lanza la imagen de fin de la partida
    /// </summary>
    /// <param name="imageCanvasGroup"> Imagen de fin de partida correspondiente</param>
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        timer += Time.deltaTime;
        imageCanvasGroup.alpha = Mathf.Clamp(timer / fadeDuration, 0, 1);

        if (!hasAudioPlayed)
        {
            audioSource.Play();
            hasAudioPlayed = true;
        }
        if (timer > fadeDuration + displayTimeDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Debug.Log("Yes.");
                Application.Quit();
            }
        }
    }
    public void CatchPlayer()
    {
        isPlayerCaught = true;
    }
}
