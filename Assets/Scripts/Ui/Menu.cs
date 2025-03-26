using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        highScoreText.text = "High score: " + PlayerPrefs.GetInt("HighScore", 0);
    }



    public void LoadScene(int id)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(id);
    }
}
