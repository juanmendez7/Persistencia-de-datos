using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour
{
     public TMP_InputField playerNameInputField; 
    public TextMeshProUGUI lastScoreText;       
    void Start()
    {
        // Cargar el nombre del jugador y mostrarlo en el Input Field
        string lastPlayerName = PlayerPrefs.GetString("PlayerName", "");
        playerNameInputField.text = lastPlayerName;

        // Cargar y mostrar el puntaje más alto
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        string highScoreName = PlayerPrefs.GetString("HighScoreName", "N/A");
        lastScoreText.text = "High Score: " + highScore + " by " + highScoreName;
    }

    public void OnStartButtonClicked()
    {
        string playerName = playerNameInputField.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Scene"); 
    }
}
