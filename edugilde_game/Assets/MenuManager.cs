using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public int gameStartScene;
    public int MenuScene;

    void Start()
    {

    }
    void Update()
    {   
        if(Input.GetKey(KeyCode.Escape))
        SceneManager.LoadScene(MenuScene);    
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
    public void StartGame() 
    {
        SceneManager.LoadScene(gameStartScene);
        scoreScript.scoreValue = 0;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(MenuScene);
    }
}
