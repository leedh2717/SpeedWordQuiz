using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ui_QuizQuestion : MonoBehaviour
{
    public Image question;
    public TextMeshProUGUI questionText;

    void Update()
    {
        if (Managers.Game.GetQuizQuestion() == Define.QuizQuestion.QuestionStart)
            StartCoroutine(QuizStart());
    }

    IEnumerator QuizStart()
    {
        Managers.Game.SetQuizQuestion(Define.QuizQuestion.Ready);

        questionText.gameObject.SetActive(true);

        Managers.Game.RandomNum();
        questionText.text = Managers.Game.quizProblem.question[Managers.Game.randomQNum];

        yield return new WaitForSeconds(1f);
        Managers.Game.SetQuizAnswer(Define.QuizAnswer.Ready);
    }
}
