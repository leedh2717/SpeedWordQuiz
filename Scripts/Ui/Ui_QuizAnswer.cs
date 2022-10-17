using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Define;

public class Ui_QuizAnswer : MonoBehaviour
{
    public Image[] answer;
    public TextMeshProUGUI[] answerText;

    int score;
    float speed = 3;

    void Update()
    {
        score = Managers.Game.quizScore;

        if (score == 5)
            speed = 3.5f;
        else if (score == 10)
            speed = 4;
        else if (score == 15)
            speed = 4.5f;
        else if (score == 20)
            speed = 5f;
        else if (score == 25)
            speed = 5.5f;
        else if (score >= 30)
            speed = 6;

        if (Managers.Game.GetQuizAnswer() == Define.QuizAnswer.AnswerStart)
        {
            QuizStart();
        }
        else if (Managers.Game.GetQuizAnswer() == Define.QuizAnswer.AnswerEnd)
        {
            Init();
            Managers.Game.SetQuizAnswer(Define.QuizAnswer.Ready);
        }
        else if (Managers.Game.GetQuizAnswer() == Define.QuizAnswer.Ready)
        {
            StartCoroutine(QuizReady());
        }
    }

    void Init()
    {
        for (int i = 0; i < answer.Length; i++)
        {
            answer[i].gameObject.SetActive(true);

            RectTransform tr = answer[i].rectTransform;

            answer[i].rectTransform.anchoredPosition = new Vector3(tr.anchoredPosition.x, 1250f, 0);
        }
    }    

    IEnumerator QuizReady()
    {
        Init();

        int successAnswer = Managers.Game.randomQNum;
        int[] failAnswer = new int[2];

        int endNum = Managers.Game.quizProblem.question.Count;

        // 랜덤 문제 셋팅
        if (successAnswer == 0)
        {
            failAnswer[0] = Random.Range(1, successAnswer/2);
            failAnswer[1] = Random.Range(successAnswer/2, endNum-1);
        }
        else if(successAnswer == endNum-1)
        {
            failAnswer[0] = Random.Range(0, successAnswer/2);
            failAnswer[1] = Random.Range(successAnswer/2, endNum-2);
        }
        else
        {
            failAnswer[0] = Random.Range(0, successAnswer);
            failAnswer[1] = Random.Range(successAnswer+1, endNum-1);
        }

        // 랜덤 문제 위치 설정
        int successAnswerTr = Managers.Game.randomTrNum;
        if (successAnswerTr == 0)
        {
            answerText[0].text = Managers.Game.quizProblem.answer[successAnswer];
            answerText[1].text = Managers.Game.quizProblem.answer[failAnswer[0]];
            answerText[2].text = Managers.Game.quizProblem.answer[failAnswer[1]];
        }
        else if (successAnswerTr == 1)
        {
            answerText[0].text = Managers.Game.quizProblem.answer[failAnswer[0]];
            answerText[1].text = Managers.Game.quizProblem.answer[successAnswer];
            answerText[2].text = Managers.Game.quizProblem.answer[failAnswer[1]];
        }
        else if (successAnswerTr == 2)
        {
            answerText[0].text = Managers.Game.quizProblem.answer[failAnswer[0]];
            answerText[1].text = Managers.Game.quizProblem.answer[failAnswer[1]];
            answerText[2].text = Managers.Game.quizProblem.answer[successAnswer];
        }

        yield return new WaitForSeconds(1f);

        Managers.Game.SetQuizAnswer(Define.QuizAnswer.AnswerStart);
    }

    void QuizStart()
    {       
        for (int i = 0; i < answer.Length; i++)
        {
            answer[i].transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            
            if (answer[i].rectTransform.anchoredPosition.y <= -765f)
            {
                Managers.Game.SetQuizAnswer(Define.QuizAnswer.AnswerEnd);
            }
        }                  
    }
}
