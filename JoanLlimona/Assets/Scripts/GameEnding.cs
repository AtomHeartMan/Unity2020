using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayTimeDuration = 1f;
    private bool isPlayerAtExit;
    
    public GameObject player;

    public CanvasGroup exitBackgroundImageCanvasGroup;
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
            timer += Time.deltaTime;
            exitBackgroundImageCanvasGroup.alpha = Mathf.Clamp(timer / fadeDuration, 0, 1);
        }

        if (timer > fadeDuration +displayTimeDuration)
        {
            EndLevel();
        }
    }

    /// <summary>
    /// Desvanece el Canvas Group y finaliza el juego
    /// </summary>
    void EndLevel()
    {
        Debug.Log("Yes.");
        Application.Quit();
    }
}
