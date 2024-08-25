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
    public GameObject gameOverPanel; // Panel que contiene el botón de reinicio

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
        UpdateUI();
        gameOverPanel.SetActive(false); // Asegúrate de que el panel esté oculto al inicio
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateUI();
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
        Time.timeScale = 0; // Pausar el juego
        gameOverPanel.SetActive(true); // Mostrar el panel de fin del juego
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Reanudar el juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reiniciar la escena actual
    }
}
