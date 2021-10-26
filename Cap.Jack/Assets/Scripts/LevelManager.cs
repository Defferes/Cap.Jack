using System.Collections;
using System.Collections.Generic;
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
}
