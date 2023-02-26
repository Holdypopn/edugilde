using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class scoreScript : MonoBehaviour
{
    public int MenuScene;
    public static int scoreValue = 0;
    public TextMeshProUGUI scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score " + scoreValue;  
    }

    void OnDisable()
    {
        if(scoreValue > PlayerPrefs.GetInt("score"))
            PlayerPrefs.SetInt("score", scoreValue);
    }

}
