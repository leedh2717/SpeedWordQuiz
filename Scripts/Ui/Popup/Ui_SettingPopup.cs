using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_SettingPopup : MonoBehaviour
{
    public Sprite[] musicOnOff;

    public Button backgroundMusicBtn;
    public Button effectMusicVolumeBtn;

    void Start()
    {
        Time.timeScale = 0;

        if (Managers.JsonData.gameData.backgroundMusicVolume)
            backgroundMusicBtn.GetComponent<Image>().sprite = musicOnOff[1];
        else
            backgroundMusicBtn.GetComponent<Image>().sprite = musicOnOff[0];

        if (Managers.JsonData.gameData.effectMusicVolume)
            effectMusicVolumeBtn.GetComponent<Image>().sprite = musicOnOff[1];
        else
            effectMusicVolumeBtn.GetComponent<Image>().sprite = musicOnOff[0];
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ResumeBtn();
            }
        }
    }

    public void MusicOnOff(int music)
    {
        if (music == 0)
        {
            if (Managers.JsonData.gameData.backgroundMusicVolume)
            {
                backgroundMusicBtn.GetComponent<Image>().sprite = musicOnOff[0];
                Managers.JsonData.gameData.backgroundMusicVolume = false;
                Managers.JsonData.SaveData();
            }
            else
            {
                backgroundMusicBtn.GetComponent<Image>().sprite = musicOnOff[1];
                Managers.JsonData.gameData.backgroundMusicVolume = true;
                Managers.JsonData.SaveData();
            }                
        }
        else
        {
            if (Managers.JsonData.gameData.effectMusicVolume)
            {
                effectMusicVolumeBtn.GetComponent<Image>().sprite = musicOnOff[0];
                Managers.JsonData.gameData.effectMusicVolume = false;
                Managers.JsonData.SaveData();
            }
            else
            {
                effectMusicVolumeBtn.GetComponent<Image>().sprite = musicOnOff[1];
                Managers.JsonData.gameData.effectMusicVolume = true;
                Managers.JsonData.SaveData();
            }
        }
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

    public void ResumeBtn()
    {
        Time.timeScale = 1;        
        Managers.Ui.ClosePopup(gameObject);
        PlayerPrefs.SetInt("PlayerState", 1);
    }
}
