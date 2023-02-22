using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public int gameStartScene;
    public TextMeshProUGUI numberText;
    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        SetNumberText(slider.value);
    }
    public void SetNumberText(float value) 
    {
        numberText.text = value.ToString();
    }


    public void QuitGame() 
    {
        Application.Quit();
    }


    public void StartGame() 
    {
        SceneManager.LoadScene(gameStartScene);
    }

}
