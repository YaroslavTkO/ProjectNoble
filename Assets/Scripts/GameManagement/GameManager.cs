using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score;
    public int Score {  get { return score; } set { score = value; UiManager.Instance.UpdateScore(value); } }

    private bool isGameActive = true;
    public bool IsGameActive { get { return isGameActive; } } 

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
    public void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        UiManager.Instance.UpdateHighScore(highScore);
    }

    public void SaveRecord()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
            UiManager.Instance.UpdateHighScore(highScore);
            Debug.Log(PlayerPrefs.GetInt("HighScore"));
        }

    }

    public void GameOver()
    {
        if (isGameActive)
        {
            SaveRecord();
            Debug.Log("Game over. Score: " + (int)Score);
            isGameActive = false;
            Time.timeScale = 0;
            

        }

    }
}
