using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText; // Viittaus Game Over TextMeshPro -objektisi inspectorissa
    private PlayerController playerControllerScript; // Viittaus PlayerController scriptiin

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameOverText.SetActive(false); // Varmista, ett‰ Game Over -teksti on piilotettu kun peli alkaa.
        playerControllerScript.gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
   
        if (playerControllerScript.gameOver)
        {
            ShowGameOverText();
        }

        // T‰m‰ funktio mahdollistaa pelin aloittamista uudelleen painamalla Enter-n‰pp‰int‰.
        if (playerControllerScript.gameOver && Input.GetKeyDown(KeyCode.Return))
        {
            RestartGame();
        }
    }

    // T‰m‰ menetelm‰ n‰ytt‰‰ Game Over tekstin, kun peli p‰‰ttyy
    void ShowGameOverText()
    {
        gameOverText.SetActive(true);
    }

    // T‰m‰ menetelm‰ k‰ynnist‰‰ pelin uudelleen pelattavaksi
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // K‰ynnist‰‰ uudelleen scenen alusta

        
        playerControllerScript.ResetPlayerState();
    }
}