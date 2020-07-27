using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    { 
        loading, inGame, gameOver
    }

    public GameState gameState;
    
    public List<GameObject> targetPrefabs;
    public List<GameObject> lives;

    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;
    public Button restartButton;
    
    private int _score;
    private int Score
    {
        set
        {
            _score = Mathf.Clamp(value, 0, 9999);
        }
        get
        {
            return _score;
        }
    }

    public TextMeshProUGUI gameOverText;

    public GameObject titleScreen;
    private int numberOfLives;

    // Start is called before the first frame update
    public void StartGame(int difficulty)
    {
        gameState = GameState.inGame;
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        numberOfLives = difficulty;

        for (int i = 0; i < numberOfLives; i++)
        {
            lives[i].SetActive(true);
        }
        StartCoroutine(SpawnTarget());
        Score = 0;
        UpdateScore(0);
    }

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        MaxScore();
    }

    IEnumerator SpawnTarget()
    {
        while (gameState == GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }

    /// <summary>
    /// Actualiza la puntuación y la muestra por pantalla
    /// </summary>
    /// <param name="scoreToAdd">Número de puntos a añadir a la puntuación global</param>
    public void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        scoreText.text = "Score: \n" + Score;
    }

    public void MaxScore()
    {
        int maxScore = PlayerPrefs.GetInt("MAX_SCORE", 0);
        scoreText.text = "Max Score: \n" + maxScore;
    }

    private void SetMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt("MAX_SCORE", 0);
        if (Score > maxScore)
        {
            PlayerPrefs.SetInt("MAX_SCORE", Score);
            //TODO: Si hay nueva puntuación másxima, festival de lucecitas.
        }
    }

    public void GameOver()
    {
        numberOfLives--;
        if (numberOfLives >= 0)
        {
            Image heartImage = lives[numberOfLives].GetComponent<Image>();
            var tempColor = heartImage.color;
            tempColor.a = 0.3f;
            heartImage.color = tempColor;  
        }
        
        if (numberOfLives <= 0)
        {
            SetMaxScore();
            MaxScore();
            gameState = GameState.gameOver;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
