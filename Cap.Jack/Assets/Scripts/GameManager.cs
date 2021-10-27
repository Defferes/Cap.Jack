using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    
    public ShipControl shipControl;
    public DestroyOnEndGame destroyOnEndGame;
    public Text scoreText, gameOverText, heartsText, MenuText, respawnText;
    public Button respawnButton,MenuButton;
    private int playerScore = 0;
    public void AddScore()
    {
        playerScore++;
        scoreText.text = "Score: " + playerScore.ToString();
    }
    
    public void WriteHearts(int hearts)
    {
        heartsText.text = "Hearts: " + hearts;
    }
    public void RespawnClick()
    {
        
        shipControl.transform.position = new Vector3(0f,-5f,0f);
        shipControl.countHearts = 2;
        shipControl.SwapColor();
        TextAndButtonEnabled(false);
        playerScore = 0;
        Time.timeScale = 1;
        Invoke("IsFlag", 0.1f);
        WriteHearts(2);
        AddScore();
        
    }
    public void PlayerDied()
    {
        destroyOnEndGame.isFlag = true;
        TextAndButtonEnabled(true);
        Time.timeScale = 0;
    }

    public void IsFlag()
    {
        destroyOnEndGame.isFlag = false;
    }

    public void TextAndButtonEnabled(bool isFlag)
    {
        respawnButton.image.enabled = isFlag;
        respawnText.enabled = isFlag;
        respawnButton.enabled = isFlag;
        gameOverText.enabled = isFlag;
        MenuText.enabled = isFlag;
        MenuButton.enabled = isFlag;
        MenuButton.image.enabled = isFlag;
    }
}
