using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Players")]
    public Player player1;
    public Player player2;
    [SerializeField] private int player1Lives;
    [SerializeField] private int player2Lives;

    [Header("UI")]
    public GameObject loseMenu;
    public TextMeshProUGUI loseMenuText; 
    public TextMeshProUGUI player1LivesText; 
    public TextMeshProUGUI player2LivesText;

    void Update()
    {
        player1LivesText.text = player1Lives.ToString();
        player2LivesText.text = player2Lives.ToString();
    }

    public void PlayerLoseLife(int player, int livesLost)
    {
        if (player == 1)
        {
            player1Lives = Math.Clamp(player1Lives - livesLost, 0, 100);
        }
        else 
        {
            player2Lives = Math.Clamp(player2Lives - livesLost, 0, 100);
        }

        if (player1Lives == 0)
        {
            Time.timeScale = 0;
            loseMenuText.text = "Player 1 Has Lost!";
            loseMenu.gameObject.SetActive(true);
            return;
        }
        else if (player2Lives == 0)
        {
            Time.timeScale = 0;
            loseMenuText.text = "Player 2 Has Lost!";
            loseMenu.gameObject.SetActive(true);
            return;
        }

        if (player == 1)
        {
            player2.GiveBall();
        }
        else 
        {
            player1.GiveBall();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
