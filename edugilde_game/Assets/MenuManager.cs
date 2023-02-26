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
    
    public void QuitGame() 
    {
        Application.Quit();
    }
    public void StartGame() 
    {
        SceneManager.LoadScene(gameStartScene);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(MenuScene);
    }
}
