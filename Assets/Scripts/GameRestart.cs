using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRestart : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    private int highscore = 0;

    void Start() {
        int highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Score: " + GameManager.instance.GetScore() + "\nBest: " + highscore;
    }

    public void RestartGame() {
        GameManager.instance.Restart();
    }

    public void ResetHighScore() {
        PlayerPrefs.SetInt("highscore", 0);
        scoreText.text = "Score: " + GameManager.instance.GetScore() + "\nBest: " + highscore;
    }
}
