using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
using System.IO;

public class GameDataManager : MonoBehaviour
{
    Define.QuizQuestion question;
    Define.QuizAnswer answer;
    public Define.GameMode gameMode;

    // 랜덤 퀴즈번호랑 퀴즈위치
    public int randomQNum;
    public int randomTrNum;

    public int lifeCount;
    public int quizScore;

    public QuizProblem quizProblem;

    public void Init()
    {
        question = Define.QuizQuestion.NotSet;
        answer = Define.QuizAnswer.NotSet;
        lifeCount = 2;
        quizScore = 0;

        if (gameMode == Define.GameMode.BasicMode)
        {
            quizProblem = Managers.QuizData.quizBasic;
        }
        else if (gameMode == Define.GameMode.HardMode)
        {
            quizProblem = Managers.QuizData.quizHard;
        }
    }

    public void RandomNum()
    {
        
        randomQNum = Random.Range(0, quizProblem.question.Count);
        randomTrNum = Random.Range(0, 3);
    }

    public void QuizSuccess()
    {
        quizScore += 1;
        SetQuizQuestion(Define.QuizQuestion.QuestionStart);
        SetQuizAnswer(Define.QuizAnswer.Ready);
    }

    public void QuizFail(GameObject player)
    {
        player.GetComponent<PlayerController>().QuizFailEffect();

        if (lifeCount > 0)
        {            
            lifeCount--;
            SetQuizQuestion(Define.QuizQuestion.QuestionStart);
            SetQuizAnswer(Define.QuizAnswer.Ready);
        }
        else
        {
            Time.timeScale = 0;
            player.GetComponent<PlayerController>().PlayerDie();

            // 최고점수보다 스코어가 높으면 갱신
            if (gameMode == Define.GameMode.BasicMode)
            {
                if (quizScore > Managers.JsonData.gameData.basicBestScore)
                {
                    Managers.JsonData.gameData.basicBestScore = quizScore;
                    Managers.JsonData.SaveData();
                }
            }
            else if (gameMode == Define.GameMode.HardMode)
            {
                if (quizScore > Managers.JsonData.gameData.hardBestScore)
                {
                    Managers.JsonData.gameData.hardBestScore = quizScore;
                    Managers.JsonData.SaveData();
                }
            }   
            Managers.JsonData.gameData.money += quizScore;
            Managers.JsonData.SaveData();

            Managers.Ui.ShowPopup("Ui_ScorePopup");
        }        
    }

    #region 퀴즈질문GetSet
    public Define.QuizQuestion GetQuizQuestion()
    {
        return question;
    }
    public void SetQuizQuestion(Define.QuizQuestion mode)
    {
        question = mode;
    }
    #endregion

    #region 퀴즈답변GetSet
    public Define.QuizAnswer GetQuizAnswer()
    {
        return answer;
    }
    public void SetQuizAnswer(Define.QuizAnswer mode)
    {
        answer = mode;
    }
    #endregion
}
