using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static Managers s_instance = null;
    public static Managers Instance { get { Init(); return s_instance; } }

    public static UiManager s_uiManager = new UiManager();
    public static GameDataManager s_gameManager = new GameDataManager();
    public static JsonDataManager s_jsonManager = new JsonDataManager();
    public static QuizDataManager s_quizManager = new QuizDataManager();
    
    public static UiManager Ui { get { return s_uiManager; } }
    public static GameDataManager Game { get { return s_gameManager; } }
    public static JsonDataManager JsonData { get { return s_jsonManager; } }
    public static QuizDataManager QuizData { get { return s_quizManager; } }
    
    void Start()
    {
        Init();
    }

    private static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }        
    }
}
