using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ui_ScorePopup : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI scoreText;
    public Button retryBtn;
    public Button homeBtn;

    void Start()
    {
        if (Managers.Game.gameMode == Define.GameMode.BasicMode)
        {
            bestScoreText.text = Managers.JsonData.gameData.basicBestScore.ToString();
        }
        else if (Managers.Game.gameMode == Define.GameMode.HardMode)
        {
            bestScoreText.text = Managers.JsonData.gameData.hardBestScore.ToString();
        }        
        scoreText.text = Managers.Game.quizScore.ToString();        
    }

    public void RetryBtn()
    {
        Time.timeScale = 1;
        Managers.Ui.MoveScene("Game");
    }

    public void HomeBtn()
    {
        Time.timeScale = 1;
        Managers.Ui.MoveScene("Main");
    }
}
