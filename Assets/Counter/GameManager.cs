using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
 public static GameManager Instance { get; private set; }
    public int score = 0;
    public int lives = 3;
    public Text scoreText;
    public Text livesText;
    public Text highScoreText;
    public Text playerNameText;
    public GameObject gameOverPanel;

    private string playerName;
    private int highScore;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

     

        ResetGameState(); 

        playerName = PlayerPrefs.GetString("PlayerName", "Player");
        playerNameText.text = "Player: " + playerName;

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;

        UpdateUI();
        gameOverPanel.SetActive(false);
    }

    public void ResetGameState()
    {
        // Reiniciar las variables del juego
        score = 0;
        lives = 3;

        UpdateUI();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateUI();
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.SetString("HighScoreName", playerName);
            PlayerPrefs.Save();
            highScoreText.text = "High Score: " + highScore + " by " + playerName;
        }
    }

    public void LoseLife()
    {
        lives--;
        UpdateUI();
        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
        if (livesText != null) livesText.text = "Lives: " + lives;
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuInicial"); // Carga la escena del menú de inicio
        Destroy(gameObject); 

    }
}
