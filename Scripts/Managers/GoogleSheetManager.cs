using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class GoogleSheetManager : MonoBehaviour
{
    const string URL1 = "https://docs.google.com/spreadsheets/d/1G7VGUXS-HGFpOlL709t9bIwaUYfl3w8sF9K_7VVBjqg/export?format=tsv";
    const string URL2 = "https://docs.google.com/spreadsheets/d/1G7VGUXS-HGFpOlL709t9bIwaUYfl3w8sF9K_7VVBjqg/export?format=tsv&gid=107360871";

    const int BasicQuestionCount = 742;
    const int HardQuestionCount = 505;

    string data;


    void Start()
    {
        bool boolQuizBase = File.Exists(Application.persistentDataPath + "/" + "QuizBasic");
        bool boolQuizHard = File.Exists(Application.persistentDataPath + "/" + "QuizHard");

        if (boolQuizBase && boolQuizHard)
        {
            Managers.QuizData.LoadData("QuizBasic");
            Managers.QuizData.LoadData("QuizHard");
            if (Managers.QuizData.quizBasic.question.Count != BasicQuestionCount && Managers.QuizData.quizHard.question.Count != HardQuestionCount)
            { 
                File.Delete(Application.persistentDataPath + "/" + "QuizBasic");
                File.Delete(Application.persistentDataPath + "/" + "QuizHard");
                StartCoroutine(QuizDataUpdate());
            }
        }
        else
        {
            StartCoroutine(QuizDataUpdate());            
        }        
    }

    IEnumerator QuizDataUpdate()
    {
        Managers.Ui.ShowPopup("Ui_DataLodingPopup");

        UnityWebRequest www = UnityWebRequest.Get(URL1);
        yield return www.SendWebRequest();
        data = www.downloadHandler.text;
        DataSplit(data, Managers.QuizData.quizBasic.question, Managers.QuizData.quizBasic.answer);
        Managers.QuizData.SaveData(Managers.QuizData.quizBasic, "QuizBasic");
        Managers.QuizData.LoadData("QuizBasic");

        www = UnityWebRequest.Get(URL2);
        yield return www.SendWebRequest();
        data = www.downloadHandler.text;
        DataSplit(data, Managers.QuizData.quizHard.question, Managers.QuizData.quizHard.answer);
        Managers.QuizData.SaveData(Managers.QuizData.quizHard, "QuizHard");
        Managers.QuizData.LoadData("QuizHard");

        if (Managers.QuizData.quizBasic.question.Count == BasicQuestionCount && Managers.QuizData.quizHard.question.Count == HardQuestionCount)
        {
            Managers.Ui.ClosePopup(GameObject.Find("Ui_DataLodingPopup(Clone)").gameObject);
            Managers.Ui.ShowPopup("Ui_DataCompletePopup");
        }
        else
        {
            Managers.Ui.ShowPopup("Ui_DataFailPopup");
            System.IO.File.Delete(Application.persistentDataPath + "/" + "QuizBasic");
            System.IO.File.Delete(Application.persistentDataPath + "/" + "QuizHard");
        }
    }

    void DataSplit(string data, List<string> question, List<string> answer)
    {
        string[] row = data.Split('\n');

        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length;

        for (int i = 0; i < rowSize; i++)
        {            
            string[] column = row[i].Split('\t');
            for (int j = 0; j < columnSize; j++)
            {
                if (j == 0)
                    question.Add(column[j]);
                else
                    answer.Add(column[j]);
            }
        }
    }
}
