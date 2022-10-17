using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Define;

public class Ui_CountDown : MonoBehaviour
{
    public TextMeshProUGUI countText;

    int countNum = 3;

    void Update()
    {
        if (Managers.Game.GetQuizQuestion() == Define.QuizQuestion.NotSet && Managers.Game.GetQuizAnswer() == Define.QuizAnswer.NotSet)
            StartCoroutine(Count());        
    }

    IEnumerator Count()
    {
        Managers.Game.SetQuizQuestion(Define.QuizQuestion.Ready);

        countText.gameObject.SetActive(true);

        countText.text = countNum.ToString();
        yield return new WaitForSeconds(1f);
        countText.text = (--countNum).ToString();
        yield return new WaitForSeconds(1f);
        countText.text = (--countNum).ToString();
        yield return new WaitForSeconds(1f);

        countText.gameObject.SetActive(false);

        Managers.Game.SetQuizQuestion(Define.QuizQuestion.QuestionStart);
    }
}
