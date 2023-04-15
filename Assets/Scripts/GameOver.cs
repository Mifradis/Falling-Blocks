using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public TextMeshProUGUI surviveSecondsUI;
    bool gameOver;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    public void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        surviveSecondsUI.text =((int)Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
}
