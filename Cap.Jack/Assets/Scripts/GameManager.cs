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
    public Text respawnText;
    public Button respawnButton;
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
        Destroy(GameObject.Find("Meteor(Clone)"));
        destroyOnEndGame.isFlag = false;
        shipControl.transform.position = new Vector3(0f,-5f,0f);
        shipControl.hearts = 2;
        respawnText.enabled = false;
        respawnButton.enabled = false;
        gameOverText.enabled = false;
        respawnButton.image.enabled = false;
        playerScore = 0;
        Time.timeScale = 1;
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
        Time.timeScale = 0;
    }
}
