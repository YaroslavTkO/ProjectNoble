using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{

    public GameObject pauseMenu;


    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;


    public static UiManager Instance;

    public void UpdateScore(int newScore)
    {
        scoreText.text = "Score: " + newScore.ToString();
    }
    public void UpdateHighScore(int newHighScore)
    {
        highScoreText.text = "High score: " + newHighScore.ToString();
    }
    public void TogglePauseMenuState(bool state)
    {
        pauseMenu.SetActive(state);
        Time.timeScale = (!state && GameManager.Instance.IsGameActive) ? 1 : 0;
         
    }

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
