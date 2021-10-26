using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    
    public ShipControl shipControl;
    public DestroyOnEndGame destroyOnEndGame;
    public Text scoreText;
    public Text gameOverText;
    public Text heartsText;
    public Text MenuText;
    public Text respawnText;
    public Button respawnButton;
    public Button MenuButton;
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
        
        shipControl.transform.position = new Vector3(0f,-5f,0f);
        shipControl.countHearts = 2;
        respawnText.enabled = false;
        respawnButton.enabled = false;
        gameOverText.enabled = false;
        respawnButton.image.enabled = false;
        MenuText.enabled = false;
        MenuButton.enabled = false;
        MenuButton.image.enabled = false;
        playerScore = 0;
        Time.timeScale = 1;
        Invoke("IsFlag", 0.1f);
        Hearts(2);
        AddScore();
    }
    public void PlayerDied()
    {
        destroyOnEndGame.isFlag = true;
        respawnButton.image.enabled = true;
        respawnText.enabled = true;
        respawnButton.enabled = true;
        gameOverText.enabled = true;
        MenuText.enabled = true;
        MenuButton.enabled = true;
        MenuButton.image.enabled = true;
        Time.timeScale = 0;
    }

    public void IsFlag()
    {
        destroyOnEndGame.isFlag = false;
    }
}
