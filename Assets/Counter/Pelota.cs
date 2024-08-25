using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
  public int scoreValue = 1;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("No se encuentra el GameManager en la escena.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager == null)
        {
            Debug.LogError("GameManager no está asignado.");
            return;
        }

        if (other.CompareTag("Canasta"))
        {
            gameManager.AddScore(scoreValue);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Suelo"))
        {
            gameManager.LoseLife();
            Destroy(gameObject);
        }
    }
}
