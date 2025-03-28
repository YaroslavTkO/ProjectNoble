using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public DifficultyDatabase database;

    private int score;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            UiManager.Instance.UpdateScore(value);
            if (nextMilestone < database.scoresMilestones.Count &&
                score >= database.scoresMilestones[nextMilestone])
            {
                nextMilestone++;
                mineGenerator.UpdateGenerationRate(database.difficulties[nextMilestone].mineGenerationRate);
                platformGenerator.UpdateGenerationRate(database.difficulties[nextMilestone].platformGenerationRates);

            }


        }
    }
    private int nextMilestone = 0;

    private bool isGameActive = true;
    public bool IsGameActive { get { return isGameActive; } }

    private MineGeneration mineGenerator;
    private PlatformGeneration platformGenerator;

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
        mineGenerator = GetComponent<MineGeneration>();
        platformGenerator = GetComponent<PlatformGeneration>();
        mineGenerator.UpdateGenerationRate(database.difficulties[nextMilestone].mineGenerationRate);
        platformGenerator.UpdateGenerationRate(database.difficulties[nextMilestone].platformGenerationRates);
    }

    public void SaveRecord()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
            UiManager.Instance.UpdateHighScore(score);
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
            UiManager.Instance.gameOverScreen.SetActive(true);


        }

    }
}
