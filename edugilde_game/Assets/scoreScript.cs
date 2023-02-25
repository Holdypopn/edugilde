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

        // Brings player to Menu while ingame    
        if(Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene(MenuScene);    
    }

    void OnDisable()
    {
        Debug.Log("ONDISABLE");
        PlayerPrefs.SetInt("score", scoreValue);
    }

}
