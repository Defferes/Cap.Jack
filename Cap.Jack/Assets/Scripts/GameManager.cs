using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverText;
    public Text heartsText;
    private int playerScore = 0;
    public void AddScore()
    {
        playerScore++;
        scoreText.text = "Score: " + playerScore.ToString();
    }
    
    public void Hearts(int hearts)
    {
        heartsText.text = "Hearts: " + hearts;
    }
    public void RespawnClick()
    {
        gameOverText.enabled = false;
        playerScore = 0;
    }
    public void PlayerDied()
    {
        gameOverText.enabled = true;
        Time.timeScale = 0;
    }
}
