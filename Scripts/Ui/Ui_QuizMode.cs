using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ui_QuizMode : MonoBehaviour
{
    bool isSettingPopup;

    AudioSource backgroundMusic;

    public GameObject background;

    public TextMeshProUGUI stageText;
    public TextMeshProUGUI lifeCountText;
    
    void Start()
    {   
        Managers.Game.Init();

        isSettingPopup = false;

        GameObject prefab = Resources.Load<GameObject>("Prefabs/Characters/Character" + (int)(Managers.JsonData.gameData.equipCharacter + 1));
        Instantiate(prefab);

        if (Managers.Game.gameMode == Define.GameMode.BasicMode)
            background.GetComponent<SpriteRenderer>().color = new Color(0.7686f, 0.8196f, 0.8196f);

        backgroundMusic = GetComponent<AudioSource>();
    }

    void Update()
    {
        lifeCountText.text = "x " + Managers.Game.lifeCount.ToString();
        stageText.text = "Score " + Managers.Game.quizScore.ToString();

        if (Managers.JsonData.gameData.backgroundMusicVolume)
        {
            backgroundMusic.volume = 1.0f;
        }
        else
        {
            backgroundMusic.volume = 0f;
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameObject.Find("Ui_SettingPopup(Clone)") == null)
                {
                    isSettingPopup = false;
                }   
                
                if (isSettingPopup)
                {
                    GameObject go = GameObject.Find("Ui_SettingPopup(Clone)");
                    go.GetComponent<Ui_SettingPopup>().ResumeBtn();
                    isSettingPopup = false;
                }
                else
                {
                    SettingBtn();
                    isSettingPopup = true;
                }
            }
        }
    }

    public void SettingBtn()
    {
        PlayerPrefs.SetInt("PlayerState", 0);
        Managers.Ui.ShowPopup("Ui_SettingPopup");
    }
}
