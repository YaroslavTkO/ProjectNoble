using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject gameOverScreen;


    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextGameOverScreen;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI highScoreTextGameOverScreen;

    public GameObject[] controlsButtons;


    public static UiManager Instance;

    public void UpdateScore(int newScore)
    {
        scoreText.text = "Score: " + newScore.ToString();
        scoreTextGameOverScreen.text = "Score: " + newScore.ToString();
    }
    public void UpdateHighScore(int newHighScore)
    {
        highScoreText.text = "High score: " + newHighScore.ToString();
        highScoreTextGameOverScreen.text = "High score: " + newHighScore.ToString();
    }
    public void TogglePauseMenuState(bool state)
    {
        pauseMenu.SetActive(state);
        Time.timeScale = (!state && GameManager.Instance.IsGameActive) ? 1 : 0;
         
    }

    public void ToggleControlsButtons()
    {
        bool state = PlayerPrefs.GetInt("buttons", 1) == 1;
        foreach (var button in controlsButtons)
        {
            button.SetActive(state);

        }
    }

    public void LoadScene(int id)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(id);
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

    private void Start()
    {
        gameOverScreen.GetComponent<Tips>().SetTip();
        gameOverScreen.SetActive(false);
        pauseMenu.SetActive(false);
        ToggleControlsButtons();
    }

}
