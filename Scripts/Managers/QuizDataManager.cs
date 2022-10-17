using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class QuizProblem
{
    public List<string> question = new List<string>();
    public List<string> answer = new List<string>();
}

public class QuizDataManager : MonoBehaviour
{
    public QuizProblem quizBasic = new QuizProblem();
    public QuizProblem quizHard = new QuizProblem();   

    public void SaveData(QuizProblem quiz, string fileName)
    {
        string data = JsonUtility.ToJson(quiz);
        File.WriteAllText(Application.persistentDataPath + "/" + fileName, data);
    }

    public void LoadData(string fileName)
    {
        string data = File.ReadAllText(Application.persistentDataPath + "/" + fileName);

        if (fileName.Equals("QuizBasic"))
            quizBasic = JsonUtility.FromJson<QuizProblem>(data);
        else if (fileName.Equals("QuizHard"))
            quizHard = JsonUtility.FromJson<QuizProblem>(data);
    }
}
