using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class LevelManager : MonoBehaviour
{
    public string sceneToLoad = "Main";


    public void LoadGame()
    {
        SceneManager.LoadScene(sceneToLoad);
        Time.timeScale = 1;
    }
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("Interface");
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
